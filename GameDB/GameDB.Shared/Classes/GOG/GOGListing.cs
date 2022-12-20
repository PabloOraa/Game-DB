using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameDB.Classes.GOG;

class GOGListing
{
    [JsonPropertyName("products")]
    public List<Product> ProductList { get; set; }
    [JsonPropertyName("ts")]
    public object Ts { get; set; }
    [JsonPropertyName("page")]
    public int? PageNumber { get; set; }
    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }
    [JsonPropertyName("totalResults")]
    public string? TotalResults { get; set; }
    [JsonPropertyName("totalGamesFound")]
    public int? TotalGamesFound { get; set; }
    [JsonPropertyName("totalMoviesFound")]
    public int? TotalMoviesFound { get; set; }
}

public class Availability
{
    [JsonPropertyName("isAvailable")]
    public bool IsAvailable { get; set; }
    [JsonPropertyName("isAvailableInAccount")]
    public bool IsAvailableInAccount { get; set; }
}

public class FromObject
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }
    [JsonPropertyName("timezone_type")]
    public int? TimezoneType { get; set; }
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }
}

public class Price
{
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }
    [JsonPropertyName("baseAmount")]
    public string? BaseAmount { get; set; }
    [JsonPropertyName("finalAmount")]
    public string? FinalAmount { get; set; }
    [JsonPropertyName("isDiscounted")]
    public bool IsDiscounted { get; set; }
    [JsonPropertyName("discountPercentage")]
    public int? DiscountPercentage { get; set; }
    [JsonPropertyName("discountDifference")]
    public string? DiscountDifference { get; set; }
    [JsonPropertyName("symbol")]
    public string? CurrencySymbol { get; set; }
    [JsonPropertyName("isFree")]
    public bool IsFree { get; set; }
    [JsonPropertyName("discount")]
    public int? Discount { get; set; }
    [JsonPropertyName("isBonusStoreCreditIncluded")]
    public bool IsBonusStoreCreditIncluded { get; set; }
    [JsonPropertyName("bonusStoreCreditAmount")]
    public string? BonusStoreCreditAmount { get; set; }
    [JsonPropertyName("promoId")]
    public string? PromoId { get; set; }
}

public class Product
{
    [JsonPropertyName("customAttributes")]
    public object CustomAttributes { get; set; }
    [JsonPropertyName("developer")]
    public string? Developer { get; set; }
    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }
    [JsonPropertyName("gallery")]
    public List<string?> ImageUrlList { get; set; }
    [JsonPropertyName("video")]
    public Video Video { get; set; }
    [JsonPropertyName("supportedOperatingSystems")]
    public List<string?> SupportedOperatingSystemList { get; set; }
    [JsonPropertyName("genres")]
    public List<string?> GenreList { get; set; }
    [JsonPropertyName("globalReleaseDate")]
    public int? GlobalReleaseDateInMilliseconds { get; set; }
    [JsonPropertyName("isTBA")]
    public bool IsToBeAnnounced { get; set; }
    [JsonPropertyName("price")]
    public Price PriceInformation { get; set; }
    [JsonPropertyName("isDiscounted")]
    public bool IsDiscounted { get; set; }
    [JsonPropertyName("isInDevelopment")]
    public bool IsInDevelopment { get; set; }
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    [JsonPropertyName("releaseDate")]
    public int? ReleaseDateInMilliseconds { get; set; }
    [JsonPropertyName("availability")]
    public Availability AvailabilityInformation { get; set; }
    [JsonPropertyName("salesVisibility")]
    public SalesVisibility SalesVisibilityInformation { get; set; }
    [JsonPropertyName("buyable")]
    public bool IsBuyable { get; set; }
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("image")]
    public string? ImageUrl { get; set; }
    [JsonPropertyName("url")]
    public string? Url { get; set; }
    [JsonPropertyName("supportUrl")]
    public string? SupportUrl { get; set; }
    [JsonPropertyName("forumUrl")]
    public string? ForumUrl { get; set; }
    [JsonPropertyName("worksOn")]
    public WorksOn WorksOnOperativeSystemInformation { get; set; }
    [JsonPropertyName("category")]
    public string? Category { get; set; }
    [JsonPropertyName("originalCategory")]
    public string? OriginalCategory { get; set; }
    [JsonPropertyName("rating")]
    public int? Rating { get; set; }
    [JsonPropertyName("type")]
    public int? Type { get; set; }
    [JsonPropertyName("isComingSoon")]
    public bool IsComingSoon { get; set; }
    [JsonPropertyName("isPriceVisible")]
    public bool IsPriceVisible { get; set; }
    [JsonPropertyName("isMovie")]
    public bool IsMovie { get; set; }
    [JsonPropertyName("isGame")]
    public bool IsGame { get; set; }
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }
    [JsonPropertyName("isWishlistable")]
    public bool IsWishlistable { get; set; }
    [JsonPropertyName("extraInfo")]
    public List<object> ExtraInfoList { get; set; }
    [JsonPropertyName("ageLimit")]
    public int? AgeLimit { get; set; }
}

public class SalesVisibility
{
    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }
    [JsonPropertyName("fromObject")]
    public FromObject FromObjectInformation { get; set; }
    [JsonPropertyName("from")]
    public int? StartDateInMilliseconds { get; set; }
    [JsonPropertyName("toObject")]
    public ToObject ToObjectInformation { get; set; }
    [JsonPropertyName("to")]
    public int? EndDateInMilliseconds { get; set; }
}

public class ToObject
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }
    [JsonPropertyName("timezone_type")]
    public int? TimezoneType { get; set; }
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }
}

public class Video
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }
}

public class WorksOn
{
    [JsonPropertyName("Windows")]
    public bool IsOnWindows { get; set; }
    [JsonPropertyName("Mac")]
    public bool IsOnMax { get; set; }
    [JsonPropertyName("Linux")]
    public bool IsOnLinux { get; set; }
}


