using GameDB.Wrapper;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web;
using GameDB.Enums;

namespace GameDB.Query.MsStore;

class MsStoreQuery
{
    private string Family { get; set; }

    public MsStoreQuery(string family)
    {
        this.Family = family;
    }

    public async Task<List<MsStoreListing>> Search(string gameName, CultureInfo region)
    {
        List<MsStoreListing>? msStoreResultList = new();
        var url = $"https://storeedgefd.dsx.mp.microsoft.com/v9.0/pages/searchResults?appVersion=22203.1401.0.0&market={region.TwoLetterISOLanguageName.ToUpper()}&locale={region.IetfLanguageTag}&deviceFamily={Family}&query={HttpUtility.UrlEncode(gameName)}";
        HttpResponseMessage response = await new HttpClient().GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            string text = await response.Content.ReadAsStringAsync();
            if (text != null)
            {
                JsonNode? jsonResult = JsonNode.Parse(text);
                msStoreResultList.AddRange(collection: from JsonNode jsonNode in jsonResult!.AsArray()
                                                       let msStoreResults = JsonSerializer.Deserialize<MsStoreListing>(jsonNode)
                                                       where msStoreResults?.Payload.SearchResults != null
                                                       select msStoreResults);
            }
        }

        return msStoreResultList;
    }

    public async Task<List<SearchResults>> Filter(string gameName, List<MsStoreListing> msStoreListings)
    {
        List<SearchResults> msStoreResultsFiltered = new();

        foreach (var result in msStoreListings)
        {
            foreach (var msStoreResult in result.Payload.SearchResults)
            {
                if (msStoreResult.Title.Contains(gameName, StringComparison.OrdinalIgnoreCase) || msStoreResult.LongDescription.Contains(gameName, StringComparison.OrdinalIgnoreCase))
                {
                    msStoreResultsFiltered.Add(msStoreResult);
                }
            }
        }

        return msStoreResultsFiltered;
    }


    public void SetNewFamily(object item)
    {
        Family = item switch
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
