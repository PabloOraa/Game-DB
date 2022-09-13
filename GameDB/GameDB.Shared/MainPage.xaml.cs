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
            String jsonResponse = @"{
        ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V1.ResponseItem, Microsoft.Marketplace.Storefront.Contracts"",
        ""Path"": ""/search?appVersion=22203.1401.0.0&market=US&locale=en-US&deviceFamily=windows.desktop&query=%22Final+Fantasy%22&mediaType=games&productFamilies=games"",
        ""ExpiryUtc"": ""2022-09-12T11:00:29.8809599Z"",
        ""Payload"": {
            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchResponse, Microsoft.Marketplace.Storefront.Contracts"",
            ""SearchResults"": [
                {
                    ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V8.One.CardModel, Microsoft.Marketplace.Storefront.Contracts"",
                    ""ProductId"": ""9PN0W216SKZB"",
                    ""TileLayout"": ""Poster"",
                    ""Title"": ""FINAL FANTASY VII WINDOWS EDITION"",
                    ""Images"": [
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V2.ImageItem, Microsoft.Marketplace.Storefront.Contracts"",
                            ""ImageType"": ""Poster"",
                            ""Url"": ""http://store-images.s-microsoft.com/image/apps.60784.14287834214643411.d0fc8bd6-dcae-44dc-b6e2-d5fdafab2f45.80615048-4a58-4378-a5fe-e462ae70759e"",
                            ""Height"": 1080,
                            ""Width"": 720,
                            ""BackgroundColor"": """",
                            ""ForegroundColor"": """",
                            ""Caption"": """",
                            ""ImagePositionInfo"": """"
                        }
                    ],
                    ""Previews"": [
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V2.ImageItem, Microsoft.Marketplace.Storefront.Contracts"",
                            ""ImageType"": ""SuperHeroArt"",
                            ""Url"": ""http://store-images.s-microsoft.com/image/apps.34713.14287834214643411.d0fc8bd6-dcae-44dc-b6e2-d5fdafab2f45.bd36f752-d4e0-4943-a27d-22df8caa9b1b"",
                            ""Height"": 1080,
                            ""Width"": 1920,
                            ""BackgroundColor"": """",
                            ""ForegroundColor"": """",
                            ""Caption"": """",
                            ""ImagePositionInfo"": """"
                        }
                    ],
                    ""DisplayPrice"": ""$15.99"",
                    ""Price"": 15.99,
                    ""AverageRating"": 3.8,
                    ""RatingsCount"": ""50"",
                    ""PackageFamilyNames"": [
                        ""39EA002F.FINALFANTASYVII_n746a19ndrrjg""
                    ],
                    ""ContentIds"": [
                        ""ebaf7e46-6bbc-4114-916f-dd7bb15f5219""
                    ],
                    ""GamingOptionsXboxLive"": false,
                    ""AvailableDevicesDisplayText"": """",
                    ""AvailableDevicesNarratorText"": ""PC"",
                    ""TypeTag"": ""app"",
                    ""LongDescription"": ""The world has fallen under the dominion of the Shinra Electric Power Company, a sinister corporation that has monopolized the planet's very life force as Mako energy.\r\nIn the urban megalopolis of Midgar, an anti-Shinra rebel group calling themselves AVALANCHE have stepped up their campaign of resistance.\r\nCloud Strife, a former member of Shinra's elite SOLDIER unit now turned mercenary, lends his aid to the rebels, unaware that he will be drawn into an epic battle for the fate of the planet, while having to come to terms with his own lost past.\r\n\r\nThis game is a port of the original FINAL FANTASY VII.\r\nThe following extra features are included:\r\n◆ 3x speed mode\r\n◆ Ability to turn battle encounters off\r\n◆ Battle enhancement mode"",
                    ""ProductFamilyName"": ""Games"",
                    ""SkusSummary"": [
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V8.SkuSummary, Microsoft.Marketplace.Storefront.Contracts"",
                            ""SkuId"": ""0010"",
                            ""MSRP"": 15.99,
                            ""DisplayMSRP"": ""$15.99"",
                            ""SalePrices"": [
                                {
                                    ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SalePrice, Microsoft.Marketplace.Storefront.Contracts"",
                                    ""Price"": 15.99,
                                    ""DisplayPrice"": ""$15.99"",
                                    ""BadgeId"": ""default""
                                }
                            ]
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V8.SkuSummary, Microsoft.Marketplace.Storefront.Contracts"",
                            ""SkuId"": ""0011""
                        }
                    ],
                    ""IsGamingAppOnly"": false,
                    ""Categories"": [
                        ""Role playing""
                    ],
                    ""ReleaseDate"": ""2020-08-13T00:00:00Z"",
                    ""PublisherName"": ""SQUARE ENIX"",
                    ""Installer"": {
                        ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.Installer, Microsoft.Marketplace.Storefront.Contracts"",
                        ""Type"": ""WindowsUpdate"",
                        ""Id"": ""9PN0W216SKZB""
                    },
                    ""MinimumAge"": 13.0,
                    ""Schema"": ""Card;1""
                }
],
            ""HighlightedResults"": [],
            ""FilterOptions"": [
                {
                    ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilter, Microsoft.Marketplace.Storefront.Contracts"",
                    ""Choices"": [
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""all"",
                            ""Title"": ""All departments""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""apps"",
                            ""Title"": ""Apps""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""games"",
                            ""Title"": ""Games"",
                            ""State"": ""Selected""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""movies"",
                            ""Title"": ""Movies""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""tv"",
                            ""Title"": ""TV Shows""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""devices"",
                            ""Title"": ""Devices""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""passes"",
                            ""Title"": ""Memberships""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""fonts"",
                            ""Title"": ""Fonts""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""themes"",
                            ""Title"": ""Themes""
                        }
                    ],
                    ""Id"": ""mediaType"",
                    ""AlwaysVisible"": false,
                    ""Title"": ""Department"",
                    ""DependentFilters"": [
                        ""Category"",
                        ""SubCategory""
                    ]
                },
                {
                    ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilter, Microsoft.Marketplace.Storefront.Contracts"",
                    ""Choices"": [
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""all"",
                            ""Title"": ""All categories"",
                            ""State"": ""Selected""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Action & adventure"",
                            ""Title"": ""Action & adventure""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Card & board"",
                            ""Title"": ""Card & board""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Casino"",
                            ""Title"": ""Casino""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Classics"",
                            ""Title"": ""Classics""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Companion"",
                            ""Title"": ""Companion""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Educational"",
                            ""Title"": ""Educational""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Family & kids"",
                            ""Title"": ""Family & kids""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Fighting"",
                            ""Title"": ""Fighting""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Multi-player Online Battle Arena"",
                            ""Title"": ""Multi-Player Online Battle Arena""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Music"",
                            ""Title"": ""Music""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Other"",
                            ""Title"": ""Other""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Platformer"",
                            ""Title"": ""Platformer""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Puzzle & trivia"",
                            ""Title"": ""Puzzle & trivia""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Racing & flying"",
                            ""Title"": ""Racing & flying""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Role playing"",
                            ""Title"": ""Role playing""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Shooter"",
                            ""Title"": ""Shooter""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Simulation"",
                            ""Title"": ""Simulation""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Social"",
                            ""Title"": ""Social""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Sports"",
                            ""Title"": ""Sports""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Strategy"",
                            ""Title"": ""Strategy""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Tools"",
                            ""Title"": ""Tools""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Video"",
                            ""Title"": ""Video""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Word"",
                            ""Title"": ""Word""
                        }
                    ],
                    ""Id"": ""Category"",
                    ""AlwaysVisible"": false,
                    ""Title"": ""Category"",
                    ""DependentFilters"": [
                        ""SubCategory""
                    ]
                },
                {
                    ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilter, Microsoft.Marketplace.Storefront.Contracts"",
                    ""Choices"": [
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""all"",
                            ""Title"": ""All ages"",
                            ""State"": ""Selected""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO3"",
                            ""Title"": ""3 and under""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO4"",
                            ""Title"": ""4""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO5"",
                            ""Title"": ""5""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO6"",
                            ""Title"": ""6""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO7"",
                            ""Title"": ""7""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO8"",
                            ""Title"": ""8""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO9"",
                            ""Title"": ""9""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO10"",
                            ""Title"": ""10""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO11"",
                            ""Title"": ""11""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO12"",
                            ""Title"": ""12""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO13"",
                            ""Title"": ""13""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO14"",
                            ""Title"": ""14""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO15"",
                            ""Title"": ""15""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO16"",
                            ""Title"": ""16""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""TO17"",
                            ""Title"": ""17""
                        }
                    ],
                    ""Id"": ""UserAge"",
                    ""AlwaysVisible"": false,
                    ""Title"": ""Audience age""
                },
                {
                    ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilter, Microsoft.Marketplace.Storefront.Contracts"",
                    ""Choices"": [
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""all"",
                            ""Title"": ""All types"",
                            ""State"": ""Selected""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Free"",
                            ""Title"": ""Free""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Paid"",
                            ""Title"": ""Paid""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""Sale"",
                            ""Title"": ""On Sale""
                        }
                    ],
                    ""Id"": ""PriceType"",
                    ""AlwaysVisible"": false,
                    ""Title"": ""Price Type""
                },
                {
                    ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilter, Microsoft.Marketplace.Storefront.Contracts"",
                    ""Choices"": [
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""all"",
                            ""Title"": ""All subscriptions"",
                            ""State"": ""Selected""
                        },
                        {
                            ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                            ""Id"": ""GamePass"",
                            ""Title"": ""Game Pass""
                        }
                    ],
                    ""Id"": ""SubscriptionType"",
                    ""AlwaysVisible"": false,
                    ""Title"": ""Subscription type""
                }
            ],
            ""DepartmentOptions"": {
                ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilter, Microsoft.Marketplace.Storefront.Contracts"",
                ""Choices"": [
                    {
                        ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                        ""Id"": ""all"",
                        ""Title"": ""All departments""
                    },
                    {
                        ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                        ""Id"": ""apps"",
                        ""Title"": ""Apps""
                    },
                    {
                        ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                        ""Id"": ""games"",
                        ""Title"": ""Games"",
                        ""State"": ""Selected""
                    },
                    {
                        ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                        ""Id"": ""movies"",
                        ""Title"": ""Movies""
                    },
                    {
                        ""$type"": ""Microsoft.Marketplace.Storefront.Contracts.V9.SearchFilterChoice, Microsoft.Marketplace.Storefront.Contracts"",
                        ""Id"": ""tv"",
                        ""Title"": ""TV Shows""
                    }
                ],
                ""Id"": ""mediaType"",
                ""AlwaysVisible"": false,
                ""Title"": ""Department"",
                ""DependentFilters"": [
                    ""Category"",
                    ""SubCategory""
                ]
            },
            ""NextUri"": ""/v9.0/search?appVersion=22203.1401.0.0&market=US&locale=en-US&deviceFamily=windows.desktop&query=%22Final+Fantasy%22&mediaType=games&productFamilies=games&cursor=bz0yMCZiPQ%3d%3d&facets=false"",
            ""Index"": 0
        }
    }";
            //getProducts();
            Wrapper_MsStore? weatherForecast = JsonSerializer.Deserialize<Wrapper_MsStore>(jsonResponse);

            Console.WriteLine(weatherForecast);
        }

        public async void getProducts()
        {
            HttpResponseMessage response = await new HttpClient().GetAsync("https://storeedgefd.dsx.mp.microsoft.com/v9.0/pages/searchResults?appVersion=22203.1401.0.0&market=US&locale=en-US&deviceFamily=windows.desktop&query=Final%20Fantasy");
            if (response.IsSuccessStatusCode)
            {
                String text = await response.Content.ReadAsStringAsync();
                //Wrapper_MsStore? weatherForecast = JsonSerializer.Deserialize<Wrapper_MsStore>(text);
                //Console.WriteLine(weatherForecast);
                //product = await response.Content.ReadAsAsync<Product>();
            }
            //return "";
        }
    }
}
