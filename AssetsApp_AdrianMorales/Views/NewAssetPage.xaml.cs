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
    public partial class NewAssetPage : ContentPage
    {
        private readonly AssetViewModel assetViewModel;
        public NewAssetPage()
        {
            InitializeComponent();
            BindingContext = assetViewModel = new AssetViewModel();
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            if (ValidateData())
            {

                decimal cost = Convert.ToDecimal(TxtCost.Text.Trim());
                bool R = await assetViewModel.AddNewAsset(TxtName.Text.Trim(), TxtArea.Text.Trim(), cost);

                if (R)
                {
                    await DisplayAlert("Éxito", "El activo se agregó correctamente", "OK");
                    
                    TxtName.Text = string.Empty;
                    TxtArea.Text = string.Empty;
                    TxtCost.Text = string.Empty;
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo agregar el Activo", "OK");
                }
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssetPage());
        }

        private async void BtnListAssets_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssetPage());
        }

        private bool ValidateData()
        {
            bool R = true;

            if (string.IsNullOrEmpty(TxtName.Text))
            {
                DisplayAlert("Error","Debe digitar el nombre del activo","OK");
                TxtName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(TxtArea.Text))
            {
                DisplayAlert("Error", "Debe digitar el área del activo","Ok");
                TxtArea.Focus();
                return false;
            }else if (string.IsNullOrEmpty(TxtCost.Text))
            {
                DisplayAlert("Error", "Debe digitar el costo del activo", "Ok");
                TxtCost.Focus();
                return false;
            }

            return R;
        }
    }
}