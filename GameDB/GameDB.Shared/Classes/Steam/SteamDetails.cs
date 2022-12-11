using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameDB.Classes.Steam;

public class SteamDetails
{
    [JsonPropertyName("success")]
    public bool IsSucceded { get; set; }
    [JsonPropertyName("data")]
    public Data ContentData { get; set; }

    public class Achievements
    {
        [JsonPropertyName("total")]
        public int TotalNumber { get; set; }
        [JsonPropertyName("highlighted")]
        public List<Highlighted> HighlightedAchievements { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class ContentDescriptors
    {
        [JsonPropertyName("ids")]
        public List<object> Ids { get; set; }
        [JsonPropertyName("notes")]
        public object Notes { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("type")]
        public string ContentType { get; set; }
        [JsonPropertyName("name")]
        public string ContentName { get; set; }
        [JsonPropertyName("steam_appid")]
        public int AppId { get; set; }
        [JsonPropertyName("required_age")]
        public int MinimunAge { get; set; }
        [JsonPropertyName("is_freee")]
        public bool IsFree { get; set; }
        [JsonPropertyName("controller_support")]
        public string SupportController { get; set; }
        [JsonPropertyName("dlc")]
        public List<int> DlcList { get; set; }
        [JsonPropertyName("detailed_description")]
        public string LongDescription { get; set; }
        [JsonPropertyName("about_the_game")]
        public string ContentAbout { get; set; }
        [JsonPropertyName("short_description")]
        public string ShortDescription { get; set; }
        [JsonPropertyName("supported_languages")]
        public string Languages { get; set; }
        [JsonPropertyName("reviews")]
        public string Reviews { get; set; }
        [JsonPropertyName("header_image")]
        public string HeaderImageUrl { get; set; }
        [JsonPropertyName("website")]
        public string ContentWebsite { get; set; }
        [JsonPropertyName("pc_requirements")]
        public Requirements PcRequirements { get; set; }
        [JsonPropertyName("mac_requirements")]
        public Requirements MacRequirements { get; set; }
        [JsonPropertyName("linux_requirements")]
        public Requirements LinuxRequirements { get; set; }
        [JsonPropertyName("developers")]
        public List<string> ContentDevelopers { get; set; }
        [JsonPropertyName("publishers")]
        public List<string> ContentPublishers { get; set; }
        [JsonPropertyName("price_ovewview")]
        public PriceOverview PriceOverview { get; set; }
        [JsonPropertyName("packages")]
        public List<int> Packages { get; set; }
        [JsonPropertyName("package_groups")]
        public List<PackageGroup> PackageGroups { get; set; }
        [JsonPropertyName("platforms")]
        public Platforms PlatformsAvailability { get; set; }
        [JsonPropertyName("metacritic")]
        public Metacritic MetacriticValue { get; set; }
        [JsonPropertyName("categories")]
        public List<Category> CategoriesList { get; set; }
        [JsonPropertyName("genres")]
        public List<Genre> ContentGenres { get; set; }
        [JsonPropertyName("screenshots")]
        public List<Screenshot> ScreenshotList { get; set; }
        [JsonPropertyName("movies")]
        public List<Movie> MovieList { get; set; }
        [JsonPropertyName("recommendations")]
        public Recommendations Recommentations { get; set; }
        [JsonPropertyName("achievements")]
        public Achievements Achievements { get; set; }
        [JsonPropertyName("release_date")]
        public ReleaseDate ReleaseDate { get; set; }
        [JsonPropertyName("support_info")]
        public SupportInfo SupportInfo { get; set; }
        [JsonPropertyName("background")]
        public string BackgroundUrl { get; set; }
        [JsonPropertyName("background_raw")]
        public string BackgroundRawUrl { get; set; }
        [JsonPropertyName("content_descriptors")]
        public ContentDescriptors ContentDescriptors { get; set; }
    }

    public class Genre
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class Highlighted
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("path")]
        public string Url { get; set; }
    }

    public class Metacritic
    {
        [JsonPropertyName("score")]
        public int Score { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Movie
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("thumbnail")]
        public string ThumbnailUrl { get; set; }
        [JsonPropertyName("webm")]
        public Webm WebMediaFormat { get; set; }
        [JsonPropertyName("mp4")]
        public Mp4 Mp4Format { get; set; }
        [JsonPropertyName("highlight")]
        public bool IsHighlighted { get; set; }
    }

    public class Mp4
    {
        [JsonPropertyName("480")]
        public string Url480 { get; set; }
        [JsonPropertyName("max")]
        public string UrlMax { get; set; }
    }

    public class PackageGroup
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("selection_text")]
        public string SelectionText { get; set; }
        [JsonPropertyName("save_text")]
        public string SaveText { get; set; }
        [JsonPropertyName("display_type")]
        public int DisplayType { get; set; }
        [JsonPropertyName("is_recurring_subscription")]
        public string IsRecurringSubscription { get; set; }
        [JsonPropertyName("subs")]
        public List<Sub> Subs { get; set; }
    }

    public class Requirements
    {
        [JsonPropertyName("minimum")]
        public string MinRequirements { get; set; }
    }

    public class Platforms
    {
        [JsonPropertyName("windows")]
        public bool IsOnWindows { get; set; }
        [JsonPropertyName("mac")]
        public bool IsOnMac { get; set; }
        [JsonPropertyName("linux")]
        public bool IsOnLinux { get; set; }
    }

    public class PriceOverview
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("initial")]
        public int InitialPrice { get; set; }
        [JsonPropertyName("final")]
        public int FinalPrice { get; set; }
        [JsonPropertyName("discount_percent")]
        public int DiscountPercentage { get; set; }
        [JsonPropertyName("initial_formatted")]
        public string InitialPriceFormattedString { get; set; }
        [JsonPropertyName("final_formatted")]
        public string FinalPriceFormattedString { get; set; }
    }

    public class Recommendations
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    public class ReleaseDate
    {
        [JsonPropertyName("coming_soon")]
        public bool IsComingSoon { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; }
    }

    public class Screenshot
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("path_thumbnail")]
        public string ThumbnailUrl { get; set; }
        [JsonPropertyName("path_full")]
        public string FullUrl { get; set; }
    }

    public class Sub
    {
        [JsonPropertyName("packageid")]
        public int Id { get; set; }
        [JsonPropertyName("percent_savings_text")]
        public string SavingPercentageString { get; set; }
        [JsonPropertyName("percent_savings")]
        public int SavingPercentage { get; set; }
        [JsonPropertyName("option_text")]
        public string OptionText { get; set; }
        [JsonPropertyName("option_description")]
        public string OptionDescription { get; set; }
        [JsonPropertyName("can_get_free_license")]
        public string CanGetFreeLicence { get; set; }
        [JsonPropertyName("is_free_License")]
        public bool IsFreeLicense { get; set; }
        [JsonPropertyName("price_in_cents_with_discount")]
        public int PriceWithDiscounts { get; set; }
    }

    public class SupportInfo
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public class Webm
    {
        [JsonPropertyName("480")]
        public string Url480 { get; set; }
        [JsonPropertyName("max")]
        public string UrlMax { get; set; }
    }


}
