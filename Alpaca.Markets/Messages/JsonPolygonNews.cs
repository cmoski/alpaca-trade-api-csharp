using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Alpaca.Markets
{
    [SuppressMessage(
        "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
        Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
    internal sealed class JsonPolygonNews : INewsItem
    {

        [JsonProperty(PropertyName = "symbols", Required = Required.Default)]
        public IEnumerable<string> symbols = new List<String>();

        [JsonProperty(PropertyName = "title", Required = Required.Default)]
        public string? Title { get; set; }


        [JsonProperty(PropertyName = "url", Required = Required.Default)]
        public Uri? Url { get; set; }

        [JsonProperty(PropertyName = "source", Required = Required.Default)]
        public string? Source { get; set; }

        [JsonProperty(PropertyName = "summary", Required = Required.Default)]
        public string? Summary { get; set; }

        [JsonProperty(PropertyName = "image", Required = Required.Default)]
        public Uri? Image { get; set; }

        [JsonProperty(PropertyName = "timestamp", Required = Required.Default)]
        public DateTime? TimeStamp { get; private set; }

        [JsonProperty(PropertyName = "Keywords", Required = Required.Default)]
        public List<string>? Keywords { get; set; } = new List<string>();
    }
}
