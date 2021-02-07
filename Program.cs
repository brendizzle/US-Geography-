using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace US_Geography_
{
    class Program
    {
        class City 
        {
            public String name { get; set; }
            public String state { get; set; }
            public Coordinates coord { get; set; }
            public int population;
            public int Population 
            { 
                get {return population; }
                set
                {
                    population = value;
                    density = dens(area, population);
                } 
            }
            public int oldpopulation { get; set; }
            public double growth { get; set; }
            public double area { get; set; }
            public double density { get; set; }

            public Metro metro { get; set; }

            public City(string _name, string _state, Coordinates _coord, int _pop, int _oldPop, double _growth, double _area, Metro _metro)
            {
                name = _name;
                state = _state;
                coord = _coord;
                population = _pop;
                oldpopulation = _oldPop;
                growth = _growth;
                area = _area;
                density = dens(area, population);
                metro = _metro;
            }

            public double dens(double area, int population)
            {
                return Math.Round((population / area), 2);
            }

            public void Info()
            {
                Console.WriteLine("City: {0}, State: {1}", name, state);
                Console.WriteLine("Latitude: {0}, Longitude: {1}", coord.latitude, coord.longitude);
                Console.WriteLine("2019 Population: {0}", population);
                Console.WriteLine("Area: {0} sq. mi.", area);
                Console.WriteLine("Population Density: {0} per sq. mi.", density);
                Console.WriteLine("Metro Area: {0}, Metro population (2019): {1}", metro.metroname, metro.mpop_new);
            }
        }

        public static List<State> csv_reader(string path)
        {
            int count;
            List<State> states = new List<State>();
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach(string line in lines.Skip(8))
            {
                count = 0;
                string[] columns = line.Split(',');
                int num_decades = 11;
                State state = new State(num_decades);
                state.name = columns[0];
                foreach (string column in columns) {
                    if (count > 0 & count < num_decades+1) {
                        Int32.TryParse(column, out int tmp);
                        state.population[count-1] = tmp;
                    }

                    if (count > num_decades) {
                        double.TryParse(column, out double tmp2);
                        state.growth[count-1-num_decades] = tmp2;
                    }

                    count += 1;
                }
                states.Add(state);
            }  

            return states;
        }

        static void Main(string[] args)
        {
            string fp = Directory.GetCurrentDirectory() + "/us_msa.csv";
            string[] rows = System.IO.File.ReadAllLines(fp);
            List<Metro> metrolist = new List<Metro>();

            foreach (string row in rows.Skip(1))
            {
                string[] cols = row.Split(',');
                Int32.TryParse(cols[3], out int column3);
                Int32.TryParse(cols[4], out int column4);
                string[] g = cols[5].Split('%');
                double.TryParse(g[0], out double column5);
                var temp = new Metro(cols[1], column3, column4, column5);
                metrolist.Add(temp);
            }

            for (int i = 0; i < 35; i++)
            {
                double projected = Metro.future_pop(metrolist[i].mgrowth, metrolist[i].mpop_new, 6);
                Console.WriteLine("{0}: {1}\n 2019 Population: {2}, 2025 Population: {3}", i, metrolist[i].metroname, metrolist[i].mpop_new, projected);
            }
            
            string filepath = Directory.GetCurrentDirectory() + "/pop_change.csv";
            var tmp = csv_reader(filepath);
            for (int j = 0; j < 51; j++)
            {
                //Console.WriteLine(tmp[j].name);
            }

            var neg = tmp.FindAll(e => Array.Exists(e.growth, element => element < 0)).ToList();
            int count = 1;
            foreach (State s in neg) {
                Console.WriteLine("{0}: {1}", count, s.name);
                count += 1;
            }

            
        }
    }
}
