using System;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using XamarinSA.Locator.Data;
using System.Collections.Generic;
using XamarinSA.Locator.Models;
using XamarinSA.Locator.Interfaces;

namespace XamarinSA.Locator.Views.Pages
{
	//Due to Xaml restrictions with the maps, we must define and use in code...
	public sealed class MapPage : ContentPage
	{
		private async void GenerateMap(IList<Ambassador> ambs){
			//get current position data.
			var currentLocation = await DependencyService.Get<ILocationProvider> ().GetCurrentLocation ();

			//create map and set it at the highest zoom possible and center on current location.

			Map worldMap = new Map (
				MapSpan.FromCenterAndRadius(
					new Position(currentLocation.Longitude, currentLocation.Latitude), 
					Distance.FromKilometers(double.MaxValue)));


			foreach (var amb in ambs) { 
				worldMap.Pins.Add (new Pin () {
					Position = new Position (amb.Location.Latitude,
						amb.Location.Longitude),
					Type = PinType.Generic,
					Label = amb.Name,
					Address = amb.Location.LocationString
				});
			}
			worldMap.IsShowingUser = false;
			worldMap.MapType = MapType.Street;
			((StackLayout)Content).Children.Add (worldMap);
		}

		public MapPage ()
		{
			AmbassadorService.FetchAmbassadorsAsync ((ambs) => GenerateMap (ambs));
			Title = "Global";
			Content = new StackLayout();
		}
	}
}


