using System;

namespace US_Geography_
{
    class Program
    {
        class City 
        {
            public String name { get; set; }
            public String state { get; set; }
            public String latitude { get; set; }
            public String longitude { get; set; }
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

            public City(string _name, string _state, string _lat, string _lon, int _pop, int _oldPop, double _growth, double _area, Metro _metro)
            {
                name = _name;
                state = _state;
                latitude = _lat;
                longitude = _lon;
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
                Console.WriteLine("Latitude: {0}, Longitude: {1}", latitude, longitude);
                Console.WriteLine("2019 Population: {0}", population);
                Console.WriteLine("Area: {0} sq. mi.", area);
                Console.WriteLine("Population Density: {0} per sq. mi.", density);
                Console.WriteLine("Metro Area: {0}, Metro population (2019): {1}", metro.metroname, metro.mpop_new);
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
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
        }
    }
}
