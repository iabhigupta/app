using System;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using XamarinSA.Locator.Data;
using System.Collections.Generic;
using XamarinSA.Locator.Data.Models;
using XamarinSA.Locator.Interfaces;
using System.Threading.Tasks;

namespace XamarinSA.Locator.Views.Pages
{
	//Due to Xaml restrictions with the maps, we must define and use in code...
	public sealed class MapPage : ContentPage, ISubscriber
	{
		private static Position ToPosition(Location location){
			return new Position (location.Cooridinates.Latitude, location.Cooridinates.Longitude);
		}

		private void GenerateMap(ICollection<Ambassador> ambs){
			//create map and set it at the highest zoom possible and center on current location.

			Map worldMap = new Map (MapSpan.FromCenterAndRadius (
				ToPosition (Location.XamarinHQ), Distance.FromKilometers (double.MaxValue)));

            if (ambs != null)
            {
                foreach (var amb in ambs)
                {
                    var location = new Location(amb);

                    worldMap.Pins.Add(new Pin()
                    {
						Position = ToPosition(location),
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

		#region ISubscriber Implementation

		public void Subscribe(){
			MessagingCenter.Subscribe<ICollection<Ambassador>> (this,
				"AmbassadorsRecieved", ambs => {
					//got ambassadors, so load up the map view
					GenerateMap(ambs);
			});
		}

		public void Unsubscribe(){
			MessagingCenter.Unsubscribe<ICollection<Ambassador>> (this, "AmbasssadorsRecieved");
		}

		#endregion


		public MapPage ()
		{
			Title = "Worldwide";

            Content = new StackLayout()
            {
                Children = {
                    new Label() { 
						Text = "Loading Map...",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
                },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
		}
	}
}


