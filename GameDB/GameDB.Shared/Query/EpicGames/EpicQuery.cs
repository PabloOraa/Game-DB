using GameDB.Classes.EpicGames;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace GameDB.Query.EpicGames;

public class EpicQuery
{ 
    public async Task<EpicListing> SearchAsync(string query)
    {
        var encoded = HttpUtility.UrlEncode(query).Replace(":", "%3A");
        var request = new EpicRequest(encoded);
        var payload = JsonSerializer.Serialize(request);
        var url = "https://graphql.epicgames.com/graphql";

        var method = new HttpMethod("POST");
        HttpContent body = new StringContent(payload);
        body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var resp = await new HttpClient().PostAsync(url, body);
        var respString = await resp.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<EpicListing>(respString);
    }
}
