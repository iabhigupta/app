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

		public static GpsCooridinate Parse(string p)
        {
            //TODO: determine how this format is being stored in DB.
            //for now, assume pattern: <latitude>;<longitude>
            var split = p.Split(',');
            return new GpsCooridinate()
            {
				Latitude = Double.Parse(split[0]),
                Longitude = Double.Parse(split[1])
            };
        }
    }
}
