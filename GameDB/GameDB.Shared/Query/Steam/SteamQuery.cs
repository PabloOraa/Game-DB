using GameDB.Classes.Steam;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.Json;

namespace GameDB.Query.Steam;

class SteamQuery
{
    public async Task<List<SteamListing>> Search(string gameName, CultureInfo region)
    {
        List<SteamListing> results = new();
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        var stringUrl = $"https://store.steampowered.com/search/suggest?term={gameName}&f=games&cc={region.TwoLetterISOLanguageName}&lang={region.EnglishName}&v=2286217";
        HttpResponseMessage response = await new HttpClient().GetAsync(stringUrl);

        if(response.IsSuccessStatusCode)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            if (responseString.Contains("match ds_collapse_flag "))
            {
                foreach (string s in responseString.Split(new string[] { "match ds_collapse_flag " }, StringSplitOptions.None))
                {
                    if (s.Contains("match_name") && s.Contains("match_price"))
                    {
                        results.Add(new SteamListing(s, region));
                    }
                }
            }
        }

        return results;
    }

    public async Task<SteamDetails> GetDetails(string appId)
    {
        SteamDetails result = new();
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        var stringUrl = $"https://store.steampowered.com/api/appdetails?appids={appId}";
        HttpResponseMessage response = await new HttpClient().GetAsync(stringUrl);

        if (response.IsSuccessStatusCode)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            responseString = responseString[responseString.IndexOf('{', 1)..];
            responseString = responseString[..(responseString.Length - 1)];
            if (responseString is not null)
            {
                result = JsonSerializer.Deserialize<SteamDetails>(responseString);
            }
        }

        return result;
    }
}
