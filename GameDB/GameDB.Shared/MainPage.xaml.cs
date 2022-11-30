using GameDB.Wrapper;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Web;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GameDB
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getProducts();
        }

        public async void getProducts()
        {
            List<Wrapper_MsStore>? msStoreResultList = new List<Wrapper_MsStore>();
            var searchTerm = "Final Fantasy";
            HttpResponseMessage response = await new HttpClient().GetAsync("https://storeedgefd.dsx.mp.microsoft.com/v9.0/pages/searchResults?appVersion=22203.1401.0.0&market=US&locale=en-US&deviceFamily=windows.desktop&query="+ HttpUtility.UrlEncode(searchTerm));
            if (response.IsSuccessStatusCode)
            {
                string text = await response.Content.ReadAsStringAsync();
                if(text != null)
                {
                    JsonNode? jsonResult = JsonNode.Parse(text);
                    msStoreResultList.AddRange(collection: from JsonNode jsonNode in jsonResult!.AsArray()
                                               let msStoreResults = JsonSerializer.Deserialize<Wrapper_MsStore>(jsonNode)
                                               where msStoreResults?.Payload.SearchResults != null
                                               select msStoreResults);
                }
            }

            textBlock.Text = "Encontrados " + msStoreResultList.Select(e => e.Payload.SearchResults.Count).Sum() + $" resultados en la búsqueda de {searchTerm}";
        }
    }
}
