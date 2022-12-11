using GameDB.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GameDB.Classes.Steam;
public class SteamListing
{
    public string Name { get; protected set; }
    public string StoreLink { get; protected set; }
    public string ImageLink { get; protected set; }
    public double? Price { get; protected set; }
    public SteamType SaleType { get; protected set; }
    public string AppId { get; protected set; }

    public SteamListing(string listingData, CultureInfo region)
    {
        Name = handleSpecialCharacters(listingData.Split('>')[2].Split('<')[0]);
        StoreLink = handleSpecialCharacters(getStoreLink(listingData));
        AppId = handleSpecialCharacters(getAppId(listingData));
        ImageLink = handleSpecialCharacters(getImageLink(listingData));
        var pricingData = getPricing(listingData, region);
        SaleType = pricingData.Item1;
        Price = pricingData.Item2;
    }

    private static string getName(string input)
    {
        return input.Split(new string[] { "<div class=\"match_name\">" }, StringSplitOptions.None)[1].Split(new string[] { "</div>" }, StringSplitOptions.None)[0];
    }

    private static string getStoreLink(string input)
    {
        var first = input.Split(new string[] { "data-ds-tagids=\"" }, StringSplitOptions.None)[1];
        var second = first.Split(new string[] { "\"><div class=\"match_name\"" }, StringSplitOptions.None)[0];
        var final = second.Split(new string[] { "href=\"" }, StringSplitOptions.None)[1];
        if (final.Contains('?'))
        {
            final = final.Split('?')[0];
        }
        if (final.EndsWith("/"))
        {
            final = final.TrimEnd('/');
        }

        return final;
    }

    private static string getAppId(string input)
    {
        return input.Split('=')[1].Replace("\"", "").Split(' ')[0];
    }

    private static string getImageLink(string input)
    {
        var imageLink = input.Split('>')[4].Replace("\"", "").Split('=')[1];
        if (imageLink.Contains("?"))
            imageLink = imageLink.Split('?')[0];
        return imageLink;
    }

    private static Tuple<SteamType, double?> getPricing(string input, CultureInfo region)
    {
        string priceCandidate = input.Split('>')[7].Split('<')[0];
        double? price = null;
        SteamType saleType = SteamType.NotAvailable;
        if (priceCandidate == null || priceCandidate.Length < 2)
        {
            price = null;
            saleType = SteamType.NotAvailable;
        }
        else if (priceCandidate.ToLower().Contains("free"))
        {
            price = null;
            saleType = SteamType.FreeToPlay;
        }
        else
        {
            price = double.Parse(priceCandidate.Replace(region.NumberFormat.CurrencySymbol, ""), CultureInfo.InvariantCulture);
            saleType = SteamType.CostsMoney;
        }
        return new Tuple<SteamType, double?>(saleType, price);
    }

    private static string handleSpecialCharacters(string input)
    {
        var bytes = Encoding.Default.GetBytes(input);
        return Encoding.UTF8.GetString(bytes);
    }
}
