using System;
using System.Threading.Tasks;
using XamarinSA.Locator.Models;
using XamarinSA.Locator.Interfaces;
using Geolocator.Plugin;
using XamarinSA.Locator.iOS.Interop;

[assembly: Xamarin.Forms.Dependency(typeof(LocationService))]

namespace XamarinSA.Locator.iOS.Interop
{
	public class LocationService : ILocationProvider
	{
		public async Task<Location> GetCurrentLocation()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;
			var pin = await locator.GetPositionAsync (timeout: 10000);
			return new Location(){
				Longitude = pin.Longitude,
				Latitude = pin.Latitude
			};
		}

		public LocationService ()
		{
		}
	}
}

