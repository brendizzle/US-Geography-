using System;

namespace US_Geography_
{   
    public class Metro 
    {
        public string name { get; set; }
        public int population { get; set; }
        public int population_old { get; set; }
        public double growth { get; set; }

        public Metro(string _name, int _population, int _population_old, double _growth)
        {
            name = _name;
            population = _population;
            population_old = _population_old;
            growth = _growth;
        }

        public Metro()
        {
            name = "";
            population = 0;
            population_old = 0;
            growth = 0;
        }

        public static double future_pop(double growth, double initpop, int num_years)
        {
            double growthrate = 1 + growth/100;
            double factor = num_years / 9.0;
            return Math.Round(initpop * Math.Pow(growthrate, factor), 0);
        }
    }
}