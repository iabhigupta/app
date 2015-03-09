using System;
using System.Collections.ObjectModel;
using Xamarin.Base;
using Xamarin.Base.ViewModels;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Collections.Generic;
using XamarinSA.Locator.Data.Extensions;
using XamarinSA.Locator.Views.Pages;
using XamarinSA.Locator.Data;
using XamarinSA.Locator.Data.Models;

namespace XamarinSA.Locator.ViewModels
{
	public class AmbassadorListVM : BaseListViewModel<Ambassador>
	{

		public AmbassadorListVM ()
		{
			//fetch list of ambassadors, then set items.
			AmbassadorService.FetchAmbassadorsAsync ((ambassadors) => {
                if(ambassadors != null)
                    Items.Add(ambassadors);
				MessagingCenter.Send<ICollection<Ambassador>>(ambassadors, "AmbassadorsRecieved");
            });

			SelectionChangedCommand = new Command (async () => {
				if(SelectedItem != null){
					await Navigation.PushAsync(new AmbassadorDetails(){
						BindingContext = new AmbassadorDetailsVM(SelectedItem)
					});
					SelectedItem = null;
				}
			});

		}
	}
}
	