using GameDB.Enums;
using GameDB.Interfaces;
using GameDB.Services;
using GameDB.Wrapper;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace GameDB
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string Family { get; set; }
        private readonly IImageLoader imageLoader;

        public MainPage()
        {
            this.InitializeComponent();
            foreach(var platform in Enum.GetValues(typeof(DeviceFamily)))
            {
                platforms.Items.Add(platform);
            }
            Family = "";
            platforms.SelectedIndex = 0;
            imageLoader = new ImageLoaderService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getProducts();
        }

        public async void getProducts()
        {
            List<Wrapper_MsStore>? msStoreResultList = new ();
            var searchTerm = nameSearch.Text;
            var region = System.Threading.Thread.CurrentThread.CurrentUICulture;
            var url = $"https://storeedgefd.dsx.mp.microsoft.com/v9.0/pages/searchResults?appVersion=22203.1401.0.0&market={region.TwoLetterISOLanguageName.ToUpper()}&locale={region.IetfLanguageTag}&deviceFamily={Family}&query={HttpUtility.UrlEncode(searchTerm)}";
            HttpResponseMessage response = await new HttpClient().GetAsync(url);
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

            List<SearchResults> msStoreResultsFiltered = new();
            foreach(var result in msStoreResultList)
            {
                foreach(var msStoreResult in result.Payload.SearchResults) 
                {
                    if(msStoreResult.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || msStoreResult.LongDescription.Contains(searchTerm,StringComparison.OrdinalIgnoreCase))
                    {
                        msStoreResultsFiltered.Add(msStoreResult);
                    }
                }
            }

            textBlock.Text = $"Encontrados {msStoreResultsFiltered.Count} resultados en la búsqueda de {searchTerm}";
            if(msStoreResultsFiltered.Count == 1)
            {
                mainWindow.Height = ActualHeight;
                var b = await imageLoader.ImageLoader(msStoreResultsFiltered[0].Previews[0].Url);
                backgroundImage.ImageSource = b;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = (ComboBox)sender; 

            Family = combo.SelectedItem switch
            {
                DeviceFamily.Desktop => "windows.desktop",
                DeviceFamily.Mobile => "windows.mobile",
                DeviceFamily.Hololens => "windows.holographic",
                DeviceFamily.Hub => "windows.team",
                DeviceFamily.Xbox => "windows.xbox",
                DeviceFamily.IoT => "windows.iot",
                _ => "windows.desktop",
            };
        }
    }
}
