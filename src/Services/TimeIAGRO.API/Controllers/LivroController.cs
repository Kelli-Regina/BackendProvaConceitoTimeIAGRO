using Microsoft.AspNetCore.Mvc;
using TimeIAGRO.API.Dtos;
using TimeIAGRO.API.Repositories;

namespace TimeIAGRO.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {  
        private readonly ILogger<LivroController> _logger;
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILogger<LivroController> logger, ILivroRepository livroRepository)
        {
            _logger = logger;
            _livroRepository = livroRepository;
        }

        [HttpGet("BuscarLivros")]
        public async Task<ActionResult> BuscarLivros([FromQuery] ConsultaLivroDto parametrosLivro)
        {
            var result = await _livroRepository.BuscarLivroPor(parametrosLivro);
            return Ok(result);
        }

        [HttpGet("CalcularFrete/{idLivro}")]
        public async Task<ActionResult> CalcularFrete(int idLivro)
        {
            var result = await _livroRepository.BuscarLivroPorId(idLivro);
            return Ok(result?.CalcularFrete());
        }
    }
}