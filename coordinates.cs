using System;

namespace US_Geography_
{    
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
}