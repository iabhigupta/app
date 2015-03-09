using System;

namespace XamarinSA.Locator.Data.Models
{
	public class Location
	{
		public string Country { get; set; }
		public string City { get; set; }
		public string StateRegion { get; set; }

		private string location;
		public string LocationString {
			get {
				if (String.IsNullOrEmpty (location)) {
					if (!String.IsNullOrEmpty (StateRegion)) {
						location = string.Format ("Location: {0}, {1}, {2}",
							City, StateRegion, Country);
					} else {
						location = string.Format ("Location: {0}, {1}",
							City, Country);
					}
				}
				return location;
			}
			set {
				location = value;
			}
		}

        public GpsCooridinate Cooridinates {get;set;}

		public Location (Ambassador xsa)
		{
            if (xsa != null)
            {
                Cooridinates = GpsCooridinate.Parse(xsa.GpsCoordinates);
                Country = xsa.Country;
                //TODO: fill in rest for city and state/region
            }
		}

	}
}

