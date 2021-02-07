using System;

namespace US_Geography_
{   
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
}