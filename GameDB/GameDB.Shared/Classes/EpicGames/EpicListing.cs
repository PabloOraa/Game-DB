using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameDB.Classes.EpicGames;

public class EpicListing
{
    [JsonPropertyName("errors")]
    public List<Error> Error { get; set; }
    [JsonPropertyName("data")]
    public Data Data { get; set; }
    [JsonPropertyName("extensions")]
    public object Extensions { get; set; }
}

public class Error
{
    [JsonPropertyName("message")]
    public string Message { get; set; }
    [JsonPropertyName("locations")]
    public List<Location> Locations { get; set; }
    [JsonPropertyName("correlationId")]
    public string CorrelationId { get; set; }
    [JsonPropertyName("serviceResponse")]
    public string ServiceResponse { get; set; }
    [JsonPropertyName("stack")]
    public object Stack { get; set; }
    [JsonPropertyName("path")]
    public List<object> Path { get; set; }
}

public class Location
{
    [JsonPropertyName("line")]
    public int Line { get; set; }
    [JsonPropertyName("column")]
    public int Column { get; set; }
}

public class Data
{
    [JsonPropertyName("Catalog")]
    public Catalog Catalog { get; set; }
}

public class Catalog
{
    [JsonPropertyName("searchStore")]
    public SearchStore SearchStore { get; set; }
}

public class SearchStore
{
    [JsonPropertyName("elements")]
    public List<Element> Elements { get; set; }
    [JsonPropertyName("paging")]
    public Paging Paging { get; set; }
}

public class Paging
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
    [JsonPropertyName("total")]
    public int Total { get; set; }
}

public class Element
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("namespace")]
    public string Namespace { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("effectiveDate")]
    public DateTime EffectiveDate { get; set; }
    [JsonPropertyName("keyImages")]
    public List<KeyImage> KeyImages { get; set; }
    [JsonPropertyName("currentPrice")]
    public int CurrentPrice { get; set; }
    [JsonPropertyName("seller")]
    public Seller Seller { get; set; }
    [JsonPropertyName("productSlug")]
    public string ProductSlug { get; set; }
    [JsonPropertyName("urlSlug")]
    public string UrlSlug { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }
    [JsonPropertyName("tags")]
    public List<Tag> Tags { get; set; }
    [JsonPropertyName("items")]
    public List<Item> Items { get; set; }
    [JsonPropertyName("customAttributes")]
    public List<CustomAttribute> CustomAttributes { get; set; }
    [JsonPropertyName("categories")]
    public List<Category> Categories { get; set; }
    [JsonPropertyName("catalogNs")]
    public CatalogNs CatalogNs { get; set; }
    [JsonPropertyName("price")]
    public Price Price { get; set; }
}

public class KeyImage
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }
}

public class Seller
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class Tag
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
}

public class Item
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("namespace")]
    public string Namespace { get; set; }
}

public class CustomAttribute
{
    [JsonPropertyName("key")]
    public string Key { get; set; }
    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class Category
{
    [JsonPropertyName("path")]
    public string Path { get; set; }
}

public class CatalogNs
{
    [JsonPropertyName("mappings")]
    public List<Mapping> Mappings { get; set; }
}

public class Mapping
{
    [JsonPropertyName("pageSlug")]
    public string PageSlug { get; set; }
    [JsonPropertyName("pageType")]
    public string PageType { get; set; }
}

public class Price
{
    [JsonPropertyName("totalPrice")]
    public TotalPrice TotalPrice { get; set; }
}

public class TotalPrice
{
    [JsonPropertyName("discountPrice")]
    public int DiscountPrice { get; set; }
    [JsonPropertyName("originalPrice")]
    public int OriginalPrice { get; set; }
    [JsonPropertyName("voucherDiscount")]
    public int VoucherDiscount { get; set; }
    [JsonPropertyName("discount")]
    public int Discount { get; set; }
    [JsonPropertyName("currencyCode")]
    public string CurrencyCode { get; set; }
    [JsonPropertyName("currencyInfo")]
    public CurrencyInfo CurrencyInfo { get; set; }
    [JsonPropertyName("fmtPrice")]
    public FmtPrice FmtPrice { get; set; }
}

public class CurrencyInfo
{
    [JsonPropertyName("decimals")]
    public int Decimals { get; set; }
}

public class FmtPrice
{
    [JsonPropertyName("originalPrice")]
    public string OriginalPrice { get; set; }
    [JsonPropertyName("discountPrice")]
    public string DiscountPrice { get; set; }
    [JsonPropertyName("intermediatePrice")]
    public string IntermediatePrice { get; set; }
}