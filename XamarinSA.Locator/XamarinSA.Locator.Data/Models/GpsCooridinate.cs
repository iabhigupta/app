using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinSA.Locator.Data.Models
{
    public class GpsCooridinate
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        internal static GpsCooridinate Parse(string p)
        {
            //TODO: determine how this format is being stored in DB.
            //for now, assume pattern: <longitude>;<Latitude>
            var split = p.Split(',');
            return new GpsCooridinate()
            {
                Longitude = Double.Parse(split[0]),
                Latitude = Double.Parse(split[1])
            };
        }
    }
}
