using GameDB.Classes.GOG;
using GameDB.Interfaces;
using GameDB.Query.GOG;
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
        private GOGQuery QueryGog { get; set; }
        private readonly IImageLoader imageLoader;

        public MainPage()
        {
            this.InitializeComponent();
            QueryGog = new();
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

            GOGListing gogResults = await QueryGog.SearchAsync(searchTerm);

            textBlock.Text = $"Encontrados {gogResults.TotalGamesFound} resultados en la búsqueda de {searchTerm}";
            if (gogResults.ProductList.Count > 1 && gogResults.ProductList[0].ImageUrl is not null)
            {
                mainWindow.Height = ActualHeight;
                var b = await imageLoader.ImageLoader(gogResults.ProductList[0].ImageUrl);
                backgroundImage.ImageSource = b;
            }
        }
    }
}
