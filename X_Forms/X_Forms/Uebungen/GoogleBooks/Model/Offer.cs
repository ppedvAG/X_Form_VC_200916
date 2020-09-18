
using Newtonsoft.Json;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GoogleBooks.Model;
//
//    var gBook = GBook.FromJson(jsonString);

namespace X_Forms.Uebungen.GoogleBooks.Model
{
    public partial class Offer
    {
        [JsonProperty("finskyOfferType")]
        public long FinskyOfferType { get; set; }

        [JsonProperty("listPrice")]
        public OfferListPrice ListPrice { get; set; }

        [JsonProperty("retailPrice")]
        public OfferListPrice RetailPrice { get; set; }

        [JsonProperty("giftable")]
        public bool Giftable { get; set; }
    }
}

