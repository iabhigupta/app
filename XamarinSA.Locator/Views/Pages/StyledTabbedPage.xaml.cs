using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinSA.Locator.Views.Pages
{
	public partial class StyledTabbedPage : TabbedPage
	{
		public StyledTabbedPage ()
		{
			InitializeComponent ();
			Children.Add(new StyledNavigationPage(new AmbassadorList()));
			Children.Add (new StyledNavigationPage(new MapPage ()));
		}
	}
}

