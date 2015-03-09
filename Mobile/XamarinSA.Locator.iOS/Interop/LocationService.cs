using System;
using System.Threading.Tasks;
using Geolocator.Plugin;
using XamarinSA.Locator.iOS.Interop;
using XamarinSA.Locator.Interfaces;
using XamarinSA.Locator.Data.Models;

[assembly: Xamarin.Forms.Dependency(typeof(LocationService))]

namespace XamarinSA.Locator.iOS.Interop
{
	public class LocationService : ILocationProvider
	{
        public async Task<GpsCooridinate> GetCurrentLocation()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;
			var pin = await locator.GetPositionAsync (timeout: 100000);
			//45.648364, -122.563776
            return new GpsCooridinate()
            {
				Longitude = pin.Longitude,
				Latitude = pin.Latitude
			};
		}

		public LocationService ()
		{
		}
	}
}

