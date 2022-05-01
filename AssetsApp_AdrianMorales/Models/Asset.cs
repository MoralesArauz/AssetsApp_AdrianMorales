using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AssetsApp_AdrianMorales.Models
{
    public class Asset
    {

        RestRequest Request { get; set; }
        private const string CONTENT_TYPE = "Content-Type";
        private const string MIME_TYPE = "application/json";

        public Asset()
        {
            Request = new RestRequest();
        }



        public int Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public decimal Cost { get; set; }

        public async Task<bool> AddNewAsset()
        {
            bool success = false;

            try
            {
                // Se adjunta a la url base de la dirección del recurso que queremos consumir
                string routeSufix = "Assets";
                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient cliente = new RestClient(FinalApiRoute);

                Request = new RestRequest(FinalApiRoute, Method.Post);

                Request.AddHeader(CONTENT_TYPE, MIME_TYPE);

                // serializar esta clase para pasarla en el body
                string SerializedClass = JsonConvert.SerializeObject(this);
                Request.AddBody(SerializedClass, MIME_TYPE);
                // Esto envía la consulta al api y recibe una respuesta que debemos leer
                RestResponse response = await cliente.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return success;
        }

        public async Task<ObservableCollection<Asset>> GetAssets()
        {
            try
            {
                // Como esta ruta es un poco más compleja de consumir, ya que lleva una función con nombre y ademas dos
                // parámetros, lo más conveniente es formatearla por aparte y luego adjuntarla a Base URL(CnnToAPI.ProductionRoute)
                // para obtener la ruta completa
             
                string routeSufix = "Assets";
                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);
                Request = new RestRequest(FinalApiRoute, Method.Get);
               
                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                var AssetList = JsonConvert.DeserializeObject<ObservableCollection<Asset>>(response.Content);

                if (statusCode == HttpStatusCode.OK)
                {
                    return AssetList;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
