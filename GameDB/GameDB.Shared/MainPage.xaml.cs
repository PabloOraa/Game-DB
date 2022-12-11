using GameDB.Classes.Steam;
using GameDB.Enums;
using GameDB.Interfaces;
using GameDB.Query.MsStore;
using GameDB.Query.Steam;
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
        private MsStoreQuery QueryMS { get; set; }
        private SteamQuery QuerySteam { get; set; }
        private readonly IImageLoader imageLoader;

        public MainPage()
        {
            this.InitializeComponent();
            foreach(var platform in Enum.GetValues(typeof(DeviceFamily)))
            {
                platforms.Items.Add(platform);
            }
            QueryMS = new("");
            QuerySteam = new();
            platforms.SelectedIndex = 0;
            imageLoader = new ImageLoaderService();
        }

        private void ButtonMS_Click(object sender, RoutedEventArgs e)
        {
            getProducts();
        }

        private void ButtonSteam_Click(object sender, RoutedEventArgs e)
        {
            getProductsSteam();
        }

        public async void getProductsSteam()
        {
            
            var searchTerm = nameSearch.Text;
            var region = System.Threading.Thread.CurrentThread.CurrentUICulture;

            List<SteamListing> steamResultListing = await QuerySteam.Search(searchTerm, region);

            textBlock.Text = $"Encontrados {steamResultListing.Count} resultados en la búsqueda de {searchTerm} en Steam";
            if(steamResultListing.Count > 0)
            {
                SteamListing selectedListing = steamResultListing[0];
                SteamDetails details = await QuerySteam.GetDetails(selectedListing.AppId);
                mainWindow.Height = ActualHeight;
                var b = await imageLoader.ImageLoader(details.ContentData.BackgroundUrl);
                backgroundImage.ImageSource = b;
                textBlock.Text = $"Encontrados {steamResultListing.Count} resultados en la búsqueda de {searchTerm} en Steam con Resultado de Metacritic: {details.ContentData.MetacriticValue.Score}";
            }
        }

        public async void getProducts()
        {

            var searchTerm = nameSearch.Text;
            var region = System.Threading.Thread.CurrentThread.CurrentUICulture;

            List<MsStoreListing> msStoreResultList = await QueryMS.Search(searchTerm, region);

            List<SearchResults> msStoreResultsFiltered = await QueryMS.Filter(searchTerm, msStoreResultList);

            textBlock.Text = $"Encontrados {msStoreResultsFiltered.Count} resultados en la búsqueda de {searchTerm}";
            if (msStoreResultsFiltered.Count == 1)
            {
                mainWindow.Height = ActualHeight;
                var b = await imageLoader.ImageLoader(msStoreResultsFiltered[0].Previews[0].Url);
                backgroundImage.ImageSource = b;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            QueryMS.SetNewFamily(combo.SelectedItem);
        }
    }
}
