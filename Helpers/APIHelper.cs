using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace luceed.Helpers
{
    public class APIHelper
    {
        public static async Task<JsonElement> getResponseArray(HttpResponseMessage response)
        {
            try
            {
                var jsonDocument = JsonDocument.Parse(await response.Content.ReadAsStringAsync());

                if (jsonDocument.RootElement.TryGetProperty("error", out JsonElement errorProperty))
                {
                    string errorMessage = errorProperty.GetString();

                    MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    return JsonDocument.Parse("{}").RootElement;
                }

                return jsonDocument.RootElement.GetProperty("result")[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        public static string setAPI()=>
            Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ConfigurationManager.AppSettings["Username"]}:{ConfigurationManager.AppSettings["Password"]}"));
    }
}
