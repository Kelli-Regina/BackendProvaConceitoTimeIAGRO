using TimeIAGRO.API.Dtos;
using TimeIAGRO.API.Models;

namespace TimeIAGRO.API.Repositories
{
    public interface ILivroRepository
    {
        public Task<IEnumerable<Livro>> BuscarLivroPor(ConsultaLivroDto livro);
        public Task<Livro> BuscarLivroPorId(int idLivro);
    }
}
