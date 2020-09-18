using Newtonsoft.Json;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GoogleBooks.Model;
//
//    var gBook = GBook.FromJson(jsonString);

namespace X_Forms.Uebungen.GoogleBooks.Model
{
    public partial class AccessInfo
    {
        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("viewability")]
        public Viewability Viewability { get; set; }

        [JsonProperty("embeddable")]
        public bool Embeddable { get; set; }

        [JsonProperty("publicDomain")]
        public bool PublicDomain { get; set; }

        [JsonProperty("textToSpeechPermission")]
        public TextToSpeechPermission TextToSpeechPermission { get; set; }

        [JsonProperty("epub")]
        public Epub Epub { get; set; }

        [JsonProperty("pdf")]
        public Epub Pdf { get; set; }

        [JsonProperty("webReaderLink")]
        public string WebReaderLink { get; set; }

        [JsonProperty("accessViewStatus")]
        public AccessViewStatus AccessViewStatus { get; set; }

        [JsonProperty("quoteSharingAllowed")]
        public bool QuoteSharingAllowed { get; set; }
    }
}

