using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameDB.Classes.EpicGames;

public class EpicRequest
{
    [JsonPropertyName("query")]
    public string GraphlQuery { get { return "query searchStoreQuery($allowCountries: String, $category: String, $count: Int, $country: String!, $keywords: String, $locale: String, $namespace: String, $itemNs: String, $sortBy: String, $sortDir: String, $start: Int, $tag: String, $releaseDate: String, $withPrice: Boolean = false, $withPromotions: Boolean = false, $priceRange: String, $freeGame: Boolean, $onSale: Boolean, $effectiveDate: String) {\n  Catalog {\n    searchStore(\n      allowCountries: $allowCountries\n      category: $category\n      count: $count\n      country: $country\n      keywords: $keywords\n      locale: $locale\n      namespace: $namespace\n      itemNs: $itemNs\n      sortBy: $sortBy\n      sortDir: $sortDir\n      releaseDate: $releaseDate\n      start: $start\n      tag: $tag\n      priceRange: $priceRange\n      freeGame: $freeGame\n      onSale: $onSale\n      effectiveDate: $effectiveDate\n    ) {\n      elements {\n        title\n        id\n        namespace\n        description\n        effectiveDate\n        keyImages {\n          type\n          url\n        }\n        currentPrice\n        seller {\n          id\n          name\n        }\n        productSlug\n        urlSlug\n        url\n        tags {\n          id\n        }\n        items {\n          id\n          namespace\n        }\n        customAttributes {\n          key\n          value\n        }\n        categories {\n          path\n        }\n        catalogNs {\n          mappings(pageType: \"productHome\") {\n            pageSlug\n            pageType\n          }\n        }\n        offerMappings {\n          pageSlug\n          pageType\n        }\n        price(country: $country) @include(if: $withPrice) {\n          totalPrice {\n            discountPrice\n            originalPrice\n            voucherDiscount\n            discount\n            currencyCode\n            currencyInfo {\n              decimals\n            }\n            fmtPrice(locale: $locale) {\n              originalPrice\n              discountPrice\n              intermediatePrice\n            }\n          }\n          lineOffers {\n            appliedRules {\n              id\n              endDate\n              discountSetting {\n                discountType\n              }\n            }\n          }\n        }\n        promotions(category: $category) @include(if: $withPromotions) {\n          promotionalOffers {\n            promotionalOffers {\n              startDate\n              endDate\n              discountSetting {\n                discountType\n                discountPercentage\n              }\n            }\n          }\n          upcomingPromotionalOffers {\n            promotionalOffers {\n              startDate\n              endDate\n              discountSetting {\n                discountType\n                discountPercentage\n              }\n            }\n          }\n        }\n      }\n      paging {\n        count\n        total\n      }\n    }\n  }\n}\n"; } }
    [JsonPropertyName("variables")]
    public Variables EpicVariables { get; set; }

    public EpicRequest(string query)
    {
        EpicVariables = new Variables(query);
    }

    public class Headers
    {
        [JsonPropertyName("Content-Type")]
        public string ContentType { get { return "application/graphql"; } }
    }

    public class Variables
    {
        [JsonPropertyName("category")]
        public string Category { get { return "games/edition/base|bundles/games|editors|software/edition/base"; } }
        [JsonPropertyName("keywords")]
        public string Keywords { get; set; }
        [JsonPropertyName("country")]
        public string Country { get { return "US"; } }
        [JsonPropertyName("allowCountries")]
        public string AllowCountries { get { return "US"; } }
        [JsonPropertyName("locale")]
        public string Locale { get { return "en-US"; } }
        [JsonPropertyName("sortDir")]
        public string SortDir { get { return "DESC"; } }
        [JsonPropertyName("withPrice")]
        public bool WithPrice { get { return true; } }
        [JsonPropertyName("withMapping")]
        public bool WithMapping { get { return true; } }

        public Variables(string query)
        {
            Keywords = query;
        }
    }
}
