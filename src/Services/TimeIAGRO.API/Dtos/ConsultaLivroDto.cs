using Newtonsoft.Json;
using TimeIAGRO.API.Converters;

namespace TimeIAGRO.API.Dtos
{
    public class ConsultaLivroDto
    {       
        public int? Id { get; set; }        
        public string? Nome { get; set; }        
        public double? Preco { get; set; }
        public string? PublicacaoOriginal { get; set; }       
        public string? Autor { get; set; }       
        public int? QuantidadePagina { get; set; }        
        public string? Ilustrador { get; set; }       
        public string? Generos { get; set; }
        public bool ehOrdenacaoDescendente { get; set; }
        public bool ehConsultaParcial { get; set; }
    }
}
