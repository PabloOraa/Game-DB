using GameDB.Classes.EpicGames;
using GameDB.Interfaces;
using GameDB.Query.EpicGames;
using GameDB.Services;
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
using System.Runtime.InteropServices.WindowsRuntime;
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
        private EpicQuery QueryEpic { get; set; }
        private readonly IImageLoader imageLoader;

        public MainPage()
        {
            this.InitializeComponent();
            QueryEpic = new();
            imageLoader = new ImageLoaderService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getProducts();
        }

        public async void getProducts()
        {
            var searchTerm = nameSearch.Text;
            //var region = System.Threading.Thread.CurrentThread.CurrentUICulture;

            EpicListing epicResultList = await QueryEpic.SearchAsync(searchTerm);

            textBlock.Text = $"Encontrados {epicResultList.Data.Catalog.SearchStore.Elements.Count} resultados en la búsqueda de {searchTerm}";
            if (epicResultList.Data.Catalog.SearchStore.Elements.Count > 1 && epicResultList.Data.Catalog.SearchStore.Elements[0].KeyImages.Count > 0)
            {
                mainWindow.Height = ActualHeight;
                var b = await imageLoader.ImageLoader(epicResultList.Data.Catalog.SearchStore.Elements[0].KeyImages[0].Url);
                backgroundImage.ImageSource = b;
            }
        }
    }
}
