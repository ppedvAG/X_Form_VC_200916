using System;
using System.Collections.Generic;

using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GoogleBooks.Model;
//
//    var gBook = GBook.FromJson(jsonString);

namespace X_Forms.Uebungen.GoogleBooks.Model
{

    public partial class GBook
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("totalItems")]
        public long TotalItems { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public enum AccessViewStatus { None, Sample, FULL_PUBLIC_DOMAIN };

    public enum Country { De };

    public enum TextToSpeechPermission { Allowed, ALLOWED_FOR_ACCESSIBILITY };

    public enum Viewability { No_Pages, Partial, ALL_PAGES };

    public enum Kind { BooksVolume };

    public enum CurrencyCode { Eur };

    public enum Saleability { ForSale, NotForSale };

    public enum Language { De, En, Fr };

    public enum MaturityRating { NotMature };

    public enum PrintType { Book };

    public partial struct PublishedDate
    {
        public DateTimeOffset? DateTime;
        public long? Integer;

        public bool IsNull => DateTime == null && Integer == null;
    }  
}

