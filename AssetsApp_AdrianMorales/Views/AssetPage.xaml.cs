using AssetsApp_AdrianMorales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssetsApp_AdrianMorales.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssetPage : ContentPage
    {
        private readonly AssetViewModel assetViewPage;
        public AssetPage()
        {
            InitializeComponent();

            BindingContext = assetViewPage = new AssetViewModel();
            LoadAssets();
        }


        private async void LoadAssets()
        {
            var assetList = await assetViewPage.GetAssets();
            LstAssets.ItemsSource = assetList;
        }
    }
}