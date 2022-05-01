using AssetsApp_AdrianMorales.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssetsApp_AdrianMorales
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
