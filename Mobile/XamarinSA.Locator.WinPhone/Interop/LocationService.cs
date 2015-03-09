using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinSA.Locator.Data.Models;
using XamarinSA.Locator.Interfaces;
using Geolocator.Plugin;
using XamarinSA.Locator.WinPhone.Interop;

[assembly: Xamarin.Forms.Dependency(typeof(LocationService))]
namespace XamarinSA.Locator.WinPhone.Interop
{
    public class LocationService : ILocationProvider
    {
        public async Task<GpsCooridinate> GetCurrentLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var pin = await locator.GetPositionAsync(timeout: 10000);
            return new GpsCooridinate()
            {
                Longitude = pin.Longitude,
                Latitude = pin.Latitude
            };
        }
    }
}
