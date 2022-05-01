using AssetsApp_AdrianMorales.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AssetsApp_AdrianMorales.ViewModels
{
    public class AssetViewModel : BaseViewModel
    {
        Asset MyAsset { get; set; }

        public AssetViewModel()
        {
            MyAsset = new Asset();
        }

        public async Task<bool> AddNewAsset(string pName, string pArea, decimal pCost)
        {
            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MyAsset.Name = pName;
                MyAsset.Area = pArea;   
                MyAsset.Cost = pCost;

                bool R = await MyAsset.AddNewAsset();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }

        // Return the Assets list
        public async Task<ObservableCollection<Asset>> GetAssets()
        {
            if (IsBusy)
                return null;
            else
            {
                IsBusy = true;
                try
                {
                    ObservableCollection<Asset> list = new ObservableCollection<Asset>();

                    list = await MyAsset.GetAssets();

                    if (list != null)
                    {
                        return list;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
    }
}
