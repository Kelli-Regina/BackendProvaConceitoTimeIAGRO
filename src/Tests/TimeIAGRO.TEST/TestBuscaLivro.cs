using TimeIAGRO.API.Dtos;
using TimeIAGRO.API.Models;
using TimeIAGRO.API.Repositories;

namespace TimeIAGRO.TEST
{
    [TestClass]
    public class TestBuscaLivro
    {
        private ILivroRepository? _livroRepository;
        private List<Livro> _livros = new List<Livro>
            {
                new Livro
                {
                   Id = 1,
                   Nome = "Nome 1",
                   Preco = 10,
                   Especificacao = new Especificacao
                   {
                       PublicacaoOriginal = "Agosto, 2020",
                        Autor = "Autor 1",
                        QuantidadePagina = 5,
                        Ilustrador = new List<string>{"Jose", "Eduardo" },
                        Generos = new List<string>{"Acao", "Ficcao" }
                   }
                },
                new Livro
                {   
                   Id = 2,
                   Nome = "Nome 1",
                   Preco = 20,
                   Especificacao = new Especificacao
                   {
                       PublicacaoOriginal = "Setembro, 2021",
                        Autor = "Autor 2",
                        QuantidadePagina = 6,
                        Ilustrador = new List<string>{"Maria" },
                        Generos = new List<string>{"Acao", "Comedia" }
                   }                  
                },
        };

        public TestBuscaLivro()
        {
            _livroRepository = new LivroRepository(_livros);
        }

        [TestMethod]
        public async Task BuscarLivroPorId()
        {
            var parametro = new ConsultaLivroDto
            {
                Id = 1
            };

            var result = await _livroRepository.BuscarLivroPor(parametro);
            Assert.AreEqual(1, result.ElementAt(0).Id, "Busca de livro com erro");
        }

        [TestMethod]
        public async Task BuscarLivroPorNome()
        {
            var parametro = new ConsultaLivroDto
            {
                Nome = "Nome 1"
            };

            var result = await _livroRepository.BuscarLivroPor(parametro);
            Assert.AreEqual("Nome 1", result.ElementAt(0).Nome, "Busca de livro com erro");
        }

        [TestMethod]
        public async Task BuscarLivroPorPreco()
        {
            var parametro = new ConsultaLivroDto
            {
                Preco = 10
            };

            var result = await _livroRepository.BuscarLivroPor(parametro);
            Assert.AreEqual(10, result.ElementAt(0).Preco, "Busca de livro com erro");
        }

        [TestMethod]
        public async Task BuscarLivroPorPublicacaoOriginal()
        {
            var parametro = new ConsultaLivroDto
            {
                PublicacaoOriginal = "Setembro, 2021"
            };

            var result = await _livroRepository.BuscarLivroPor(parametro);
            Assert.AreEqual("Setembro, 2021", result.ElementAt(0).Especificacao.PublicacaoOriginal, "Busca de livro com erro");
        }

        [TestMethod]
        public async Task BuscarLivroPorAutor()
        {
            var parametro = new ConsultaLivroDto
            {
                Autor = "Autor 2"
            };

            var result = await _livroRepository.BuscarLivroPor(parametro);
            Assert.AreEqual("Autor 2", result.ElementAt(0).Especificacao.Autor, "Busca de livro com erro");
        }

        [TestMethod]
        public async Task BuscarLivroPorQuantidadePagina()
        {
            var parametro = new ConsultaLivroDto
            {
                QuantidadePagina = 5
            };

            var result = await _livroRepository.BuscarLivroPor(parametro);
            Assert.AreEqual(5, result.ElementAt(0).Especificacao.QuantidadePagina, "Busca de livro com erro");
        }

        [TestMethod]
        public async Task BuscarLivroPorIlustrador()
        {
            var parametro = new ConsultaLivroDto
            {
                Ilustrador = "Eduardo"
            };

            var result = await _livroRepository.BuscarLivroPor(parametro);
            Assert.IsTrue(result.ElementAt(0).Especificacao.Ilustrador.Contains("Eduardo"), "Busca de livro com erro");
        }

        [TestMethod]
        public async Task BuscarLivroPorGenero()
        {
            var parametro = new ConsultaLivroDto
            {
                Generos = "Acao"
            };

            var result = await _livroRepository.BuscarLivroPor(parametro); 
            Assert.IsTrue(result.ElementAt(0).Especificacao.Generos.Contains("Acao"), "Busca de livro com erro"); 
        }       
    }
}
