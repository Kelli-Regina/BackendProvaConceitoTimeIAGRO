using Newtonsoft.Json;

namespace TimeIAGRO.API.Models
{
    public class Livro
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Nome { get; set; }
        [JsonProperty("price")]
        public double Preco { get; set; }
        [JsonProperty("specifications")]
        public Especificacao Especificacao { get; set; }

        public double CalcularFrete()
        {
            return Math.Round(this.Preco * 0.2, 2);
        }
    }
}
