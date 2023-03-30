using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Linq;
using TimeIAGRO.API.Dtos;
using TimeIAGRO.API.Models;

namespace TimeIAGRO.API.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private IWebHostEnvironment _environment;
        private List<Livro> _livros;

        public LivroRepository(IWebHostEnvironment environment)
        {
            _environment = environment;
            CarregarLivros();
        }

        public LivroRepository(List<Livro> dadosEntrada)
        {
            _livros = dadosEntrada;
        }

        public async Task<Livro> BuscarLivroPorId(int idLivro) => 
            _livros.FirstOrDefault(l => l.Id == idLivro);        

        public async Task<IEnumerable<Livro>> BuscarLivroPor(ConsultaLivroDto parametrosLivro)
        {
            var consulta = _livros.AsQueryable();

            if (parametrosLivro.Id != null)
                consulta = consulta.Where(l => l.Id == parametrosLivro.Id);

            if (parametrosLivro.Nome != null)
                consulta = parametrosLivro.ehConsultaParcial ? consulta.Where(l => l.Nome.ToLower().Contains(parametrosLivro.Nome.ToLower()))
                    : consulta.Where(l => l.Nome.ToLower() == parametrosLivro.Nome.ToLower());

            if (parametrosLivro.Preco != null)
                consulta = consulta.Where(l => l.Preco == parametrosLivro.Preco);

            if (parametrosLivro.PublicacaoOriginal != null)
                consulta = parametrosLivro.ehConsultaParcial ? consulta.Where(l => l.Especificacao.PublicacaoOriginal.ToLower().Contains(parametrosLivro.PublicacaoOriginal.ToLower()))
                    : consulta.Where(l => l.Especificacao.PublicacaoOriginal.ToLower() == parametrosLivro.PublicacaoOriginal.ToLower());

            if (parametrosLivro.Autor != null)
                consulta = parametrosLivro.ehConsultaParcial ? consulta.Where(l => l.Especificacao.Autor.ToLower().Contains(parametrosLivro.Autor.ToLower()))
                    : consulta.Where(l => l.Especificacao.Autor.ToLower() == parametrosLivro.Autor.ToLower());

            if (parametrosLivro.QuantidadePagina != null)
                consulta = consulta.Where(l => l.Especificacao.QuantidadePagina == parametrosLivro.QuantidadePagina);

            if (parametrosLivro.Ilustrador != null)
                consulta = parametrosLivro.ehConsultaParcial ? consulta.Where(l => l.Especificacao.Ilustrador.Any(x => x.ToLower().Contains(parametrosLivro.Ilustrador.ToLower())))
                    : consulta.Where(l => l.Especificacao.Ilustrador.Any(x => x.ToLower() == parametrosLivro.Ilustrador.ToLower()));

            if (parametrosLivro.Generos != null) {
                consulta = parametrosLivro.ehConsultaParcial ? consulta.Where(l => l.Especificacao.Generos.Any(x => x.ToLower().Contains(parametrosLivro.Generos.ToLower())))
                    : consulta.Where(l => l.Especificacao.Generos.Any(x => x.ToLower() == parametrosLivro.Generos.ToLower()));
            }

            if (parametrosLivro.ehOrdenacaoDescendente)
                consulta = consulta.OrderByDescending(l => l.Preco);

            if (!parametrosLivro.ehOrdenacaoDescendente)
                consulta = consulta.OrderBy(l => l.Preco);

            return consulta.ToList();
        }

        private void CarregarLivros()
        {
            var caminhoArquivo = Path.Combine(_environment.ContentRootPath, "DataArchives", "books.json");
            var dadosCarregados = File.ReadAllText(caminhoArquivo);
            _livros = JsonConvert.DeserializeObject<List<Livro>>(dadosCarregados);
        }
    }
}
