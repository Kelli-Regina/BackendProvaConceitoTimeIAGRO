using Newtonsoft.Json;
using TimeIAGRO.API.Converters;

namespace TimeIAGRO.API.Models
{
    public class Especificacao
    {
        [JsonProperty("Originally published")]
        public string PublicacaoOriginal { get; set; }
        [JsonProperty("Author")]
        public string Autor { get; set; }
        [JsonProperty("Page count")]
        public int QuantidadePagina { get; set; }
        [JsonProperty("Illustrator")]
        [JsonConverter(typeof(SingleOrListConverter<string>))]
        public List<string> Ilustrador { get; set; }
        [JsonProperty("Genres")]
        [JsonConverter(typeof(SingleOrListConverter<string>))]
        public List<string> Generos { get; set; }
    }
}
