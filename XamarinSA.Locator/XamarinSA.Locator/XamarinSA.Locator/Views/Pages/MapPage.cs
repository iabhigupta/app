using System;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using XamarinSA.Locator.Data;
using System.Collections.Generic;
using XamarinSA.Locator.Data.Models;
using XamarinSA.Locator.Interfaces;

namespace XamarinSA.Locator.Views.Pages
{
	//Due to Xaml restrictions with the maps, we must define and use in code...
	public sealed class MapPage : ContentPage
	{
		private async void GenerateMap(ICollection<Ambassador> ambs){
			//get current position data.
			var currentLocation = await DependencyService.Get<ILocationProvider> ().GetCurrentLocation ();

			//create map and set it at the highest zoom possible and center on current location.
            Map worldMap = null;

            if (currentLocation != null)
            {
                worldMap = new Map(
                    MapSpan.FromCenterAndRadius(
                        new Position(currentLocation.Longitude, currentLocation.Latitude),
                        Distance.FromKilometers(double.MaxValue)));
            }
            else
            {
                worldMap = new Map();
            }
            if (ambs != null)
            {
                foreach (var amb in ambs)
                {
                    var location = new Location(amb);

                    worldMap.Pins.Add(new Pin()
                    {
                        Position = new Position(location.Cooridinates.Latitude,
                            location.Cooridinates.Longitude),
                        Type = PinType.Generic,
                        Label = amb.FirstName + " " + amb.LastName,
                        Address = location.LocationString
                    });
                }
            }
			
			worldMap.IsShowingUser = false;
			worldMap.MapType = MapType.Street;
            var layout = ((StackLayout)Content);
            layout.Children.RemoveAt(0);
            layout.Children.Add(worldMap);
		}

		public MapPage ()
		{
			AmbassadorService.FetchAmbassadorsAsync ((ambs) => GenerateMap (ambs));
			Title = "Worldwide";
            Content = new StackLayout()
            {
                Children = {
                    new Label() { Text = "Loading Map..." }
                },
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
		}
	}
}


