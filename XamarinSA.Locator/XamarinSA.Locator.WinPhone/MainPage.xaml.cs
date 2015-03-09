using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace XamarinSA.Locator.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;
            //TODO: See http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/maps/
            //For deployment requirements to Windows Store.
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new XamarinSA.Locator.App());
        }
    }
}
