#nullable disable

using System;
using System.Collections.Generic;

namespace GameDB.Wrapper
{
    class Wrapper_MsStore
    {
        public string type { get; set; }
        public string Path { get; set; }
        public DateTime ExpiryUtc { get; set; }
        public Payload Payload { get; set; }

    }

    public class Payload
    {
        public string type { get; set; }
        public IList<SearchResults> SearchResults { get; set; }
        public IList<HighlightedResults> HighlightedResults { get; set; }
        public IList<FilterOptions> FilterOptions { get; set; }
        public DepartmentOptions DepartmentOptions { get; set; }
        public string NextUri { get; set; }
        public int Index { get; set; }
    }

    public class SearchResults
    {
        public string type { get; set; }
        public string ProductId { get; set; }
        public string TileLayout { get; set; }
        public string Title { get; set; }
        public IList<Images> Images { get; set; }
        public IList<Previews> Previews { get; set; }
        public string DisplayPrice { get; set; }
        public double Price { get; set; }
        public double AverageRating { get; set; }
        public string RatingsCount { get; set; }
        public IList<string> PackageFamilyNames { get; set; }
        public IList<string> ContentIds { get; set; }
        public bool GamingOptionsXboxLive { get; set; }
        public string AvailableDevicesDisplayText { get; set; }
        public string AvailableDevicesNarratorText { get; set; }
        public string TypeTag { get; set; }
        public string LongDescription { get; set; }
        public string ProductFamilyName { get; set; }
        public IList<SkusSummary> SkusSummary { get; set; }
        public bool IsGamingAppOnly { get; set; }
        public IList<string> Categories { get; set; }
        public string ReleaseDate { get; set; }
        public string PublisherName { get; set; }
        public Installer Installer { get; set; }
        public double MinimumAge { get; set; }
        public string Schema { get; set; }
    }

    public class Images
    {
        public string type { get; set; }
        public string ImageType { get; set; }
        public string Url { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }
        public string Caption { get; set; }
        public string ImagePositionInfo { get; set; }

}
    public class Previews
    {
        public string type { get; set; }
        public string ImageType { get; set; }
        public string Url { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }
        public string Caption { get; set; }
        public string ImagePositionInfo { get; set; }
    }

    public class SkusSummary
    {
        public string type { get; set; }
        public string SkuId { get; set; }
        public double MSRP { get; set; }
        public string DisplayMSRP { get; set; }
        public IList<SalePrices> SalePrices { get; set; }
    }

    public class SalePrices
    {
        public string type { get; set; }
        public double Price { get; set; }
        public string DisplayPrice { get; set; }
        public string BadgeId { get; set; }
    }

    public class Installer
    {
        public string type { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
    }

    public class HighlightedResults
    {
        public string type { get; set; }
    }

    public class FilterOptions
    {
        public string type { get; set; }
        public IList<Choices> Choices { get; set; }
        public string Id { get; set; }
        public bool AlwaysVisible { get; set; }
        public string Title { get; set; }
        public IList<string> DependentFilters { get; set; }
    }

    public class Choices
    {
        public string type { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
    }

    public class DepartmentOptions
    {
        public string type { get; set; }
        public IList<Choices> Choices { get; set; }
        public string Id { get; set; }
        public bool AlwaysVisible { get; set; }
        public string Title { get; set; }
        public IList<string> DependentFilters { get; set; }
    }
}
