using System;
using System.Collections.ObjectModel;
using XamarinSA.Locator.Models;
using Xamarin.Base;
using Xamarin.Base.ViewModels;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xamarin.Base.Extensions;
using XamarinSA.Locator.Views.Pages;
using XamarinSA.Locator.Data;

namespace XamarinSA.Locator.ViewModels
{
	public class AmbassadorListVM : BaseListViewModel<Ambassador>
	{

		public AmbassadorListVM ()
		{
			//fetch list of ambassadors, then set items.
			AmbassadorService.FetchAmbassadorsAsync ((ambassadors) => Items.Add(ambassadors));

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
	