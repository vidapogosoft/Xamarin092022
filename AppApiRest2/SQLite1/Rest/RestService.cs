using System;
using System.Collections.Generic;
using System.Text;

using SQLite1.DTO;
using SQLite1.Helper;
using SQLite1.Interface;

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SQLite1.Rest
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public RestService()
        {

            _client = new HttpClient();

        }

        public async Task<int> SaveRegistro (DTORegistrado item, bool isNewItem)
        {
            int grabado = 0;

            var uri = new Uri(string.Format(Constants.ApiUrl, "Registrados", string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;


                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }


                if (response.IsSuccessStatusCode)
                {
                    grabado = 1;
                    Debug.WriteLine(@"TodoItem: Saved correct.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Error {0}", ex.Message);
                return grabado;
            }

            return grabado;
        }

    }
}
