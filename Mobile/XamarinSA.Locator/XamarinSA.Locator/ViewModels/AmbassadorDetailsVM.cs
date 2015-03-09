using System;
using Xamarin.Forms;
using Xamarin.Base.ViewModels;
using System.Windows.Input;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using XamarinSA.Locator.Data.Extensions;
using XamarinSA.Locator.Data.Models;

namespace XamarinSA.Locator.ViewModels
{
	public class AmbassadorDetailsVM : BaseViewModel
	{
		private const string Blog = "blog";
		private const string Twitter = "twitter";

		public Ambassador Xsa { get; private set; }
		public ICommand OpenCommand { get; private set; }

		public AmbassadorDetailsVM (Ambassador ambassador)
		{
			Xsa = ambassador;
			OpenCommand = new Command ((openType) => {
				var openFor = openType.ToString().ToLower();
				if(openFor.CompareTo(Blog) == 0){
					Device.OpenUri(new Uri(string.Format("http://{0}", Xsa.Blog)));
					return;
				}
				if(openFor.CompareTo(Twitter) == 0){
					Device.OpenUri(new Uri(string.Format("twitter://user?screen_name={0}", Xsa.TwitterHandle)));
					return;
				}
			});
		}
	}
}

