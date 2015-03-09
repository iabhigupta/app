using System;
using Xamarin.Forms;
using XamarinSA.Locator.Misc;

namespace XamarinSA.Locator.Views.Pages
{
	public class StyledNavigationPage : NavigationPage
	{
		public StyledNavigationPage (Page content) : base (content)
		{
			BarTextColor = Color.White;
			BarBackgroundColor = Color.FromHex (ColorStyles.XamarinLightBlue);
			Title = content.Title;
			Icon = content.Icon;

			CheckSubscriber (content, true);

			Popped += (object sender, NavigationEventArgs e) => {
				CheckSubscriber(e.Page, false);
			};
			Pushed += (object sender, NavigationEventArgs e) => {
				CheckSubscriber(e.Page, true);
			};
		}

		private void CheckSubscriber(Page toCheck, bool shouldSubscribe){
			if(toCheck is ISubscriber){
				var sub = toCheck as ISubscriber;

				if (shouldSubscribe)
					sub.Subscribe ();
				else
					sub.Unsubscribe ();
			}
		}
	}
}

