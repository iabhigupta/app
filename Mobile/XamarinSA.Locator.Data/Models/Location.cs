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

		private static Location xamarinHQ;
		public static Location XamarinHQ {
			get {
				if (xamarinHQ == null) {
					//XamarinHQ location: 37.797793, -122.401789
					const double latitude = 37.797793;
					const double longitude = -122.401789;
					const string city = "San Diago";
					const string country = "USA";
					const string state = "California";

					xamarinHQ = new Location () {
						City = city,
						StateRegion = state,
						Country = country,
						Cooridinates = new GpsCooridinate(){
							Longitude = longitude,
							Latitude = latitude
						}
					};
				}
				return xamarinHQ;
			}
		}

		public Location() { }
		public Location (Ambassador xsa)
		{
			Cooridinates = GpsCooridinate.Parse(xsa.GpsCoordinates);
			Country = xsa.Country;
			//TODO: fill in rest for city and state/region
		}

	}
}

