using System;
using Xamarin.Forms;
using XamarinSA.Locator.Views.Pages;

namespace XamarinSA.Locator
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new StyledTabbedPage ();
		}

		protected override void OnResume ()
		{
			base.OnResume ();
		}

		protected override void OnSleep ()
		{
			base.OnSleep ();
		}

		protected override void OnStart ()
		{
			base.OnStart ();
		}
	}
}

