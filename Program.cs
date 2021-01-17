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
                //Console.WriteLine("Latitude: {0}, Longitude: {1}", latitude, longitude);
                Console.WriteLine("2019 Population: {0}", population);
                Console.WriteLine("Area: {0} sq. mi.", area);
                Console.WriteLine("Population Density: {0} per sq. mi.", density);
                Console.WriteLine("Metro Area: {0}, Metro population (2019): {1}", metro.metroname, metro.mpop_new);
            }
        }

        public class Coordinates
        {
            public String latitude { get; set; }
            public String longitude { get; set; }

            public Coordinates(string _latitude, string _longitude)
            {
                latitude = _latitude;
                longitude = _longitude;
            }

            static double convert_coords(string str) 
            {
                string[] coord = str.Split('°');
                double.TryParse(coord[0], out double val);
                return val;
            }
        }

        public class Metro 
        {
            public string metroname { get; set; }
            public int mpop_new { get; set; }
            public int mpop_old { get; set; }
            public double mgrowth { get; set; }

            public Metro(string _metroname, int _mpop_new, int _mpop_old, double _mgrowth)
            {
                metroname = _metroname;
                mpop_new = _mpop_new;
                mpop_old = _mpop_old;
                mgrowth = _mgrowth;
            }

            public Metro()
            {
                metroname = "";
                mpop_new = 0;
                mpop_old = 0;
                mgrowth = 0;
            }

            public static double future_pop(double growth, double initpop, int num_years)
            {
                double growthrate = 1 + growth/100;
                double factor = num_years / 9.0;
                return Math.Round(initpop * Math.Pow(growthrate, factor), 0);
            }
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
            
        }
    }
}
