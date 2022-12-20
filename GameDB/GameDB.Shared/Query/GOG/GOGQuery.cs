using GameDB.Classes.GOG;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web;

namespace GameDB.Query.GOG;

class GOGQuery
{
    private readonly string BaseUrl = "http://embed.gog.com";
    public async Task<GOGListing> SearchAsync(string query)
    {
        GOGListing gogListing = new();
        var url = $"{BaseUrl}/games/ajax/filtered?mediaType=game&search={query}";
        HttpResponseMessage response = await new HttpClient().GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            string text = await response.Content.ReadAsStringAsync();
            if (text != null)
            {
                gogListing = JsonSerializer.Deserialize<GOGListing>(text);
                foreach(var gogResult in gogListing.ProductList)
                {
                    gogResult.Url = $"{BaseUrl}{gogResult.Url}";
                    gogResult.ForumUrl = $"{BaseUrl}{gogResult.ForumUrl}";
                    gogResult.SupportUrl = $"{BaseUrl}{gogResult.SupportUrl}";
                    gogResult.ImageUrl = $"https:{gogResult.ImageUrl}.jpg";
                    List<string> finalUrlList = new();
                    foreach(var imageProductResult in gogResult.ImageUrlList)
                    {
                        finalUrlList.Add($"https:{imageProductResult}.jpg");
                    }
                    gogResult.ImageUrlList = finalUrlList;
                }
            }
        }

        return gogListing;
    }
}
