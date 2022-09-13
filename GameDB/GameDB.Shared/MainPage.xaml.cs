using GameDB.Wrapper;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using System.Text.Json.Nodes;
using Windows.Foundation;
using Windows.Foundation.Collections;

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
            HttpResponseMessage response = await new HttpClient().GetAsync("https://storeedgefd.dsx.mp.microsoft.com/v9.0/pages/searchResults?appVersion=22203.1401.0.0&market=US&locale=en-US&deviceFamily=windows.desktop&query=Final%20Fantasy");
            if (response.IsSuccessStatusCode)
            {
                String text = await response.Content.ReadAsStringAsync();
                if(text != null)
                {
                    JsonNode jsonResult = JsonArray.Parse(text);
                    msStoreResultList.AddRange(collection: from JsonNode jsonNode in jsonResult.AsArray()
                                               let weatherForecast = JsonSerializer.Deserialize<Wrapper_MsStore>(jsonNode)
                                               where weatherForecast?.Payload.SearchResults != null
                                               select weatherForecast);
                }
            }

            textBlock.Text = "Encontrados " + msStoreResultList.Select(e => e.Payload.SearchResults.Count).Sum() + " resultados en la búsqueda de Final Fantasy";
        }
    }
}
