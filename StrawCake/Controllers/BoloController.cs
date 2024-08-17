using Microsoft.AspNetCore.Mvc;
using StrawCake.Dominio;
using StrawCake.Dominio.Servicos;

namespace StrawBerry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoloController : ControllerBase
    {
        private readonly ServicoBolo _servicoBolo;
        public BoloController(ServicoBolo servicoBolo)
        {
            _servicoBolo = servicoBolo;
        }

        [HttpPost]
        public CreatedResult Adicionar(Bolo bolo)
        {
            var boloCriado = _servicoBolo.Adicionar(bolo);
            return Created(boloCriado.Id, boloCriado);
        }

        [HttpGet]
        public OkObjectResult ObterTodos()
        {
            var bolos = _servicoBolo.ObterTodos();
            return Ok(bolos);
        }

        [HttpGet("{id}")]
        public OkObjectResult ObterPorId(string id)
        {
            var bolo = _servicoBolo.ObterPorId(id);
            return Ok(bolo);
        }

        [HttpPut("{id}")]
        public NoContentResult Atualizar(string id, [FromBody] Bolo bolo) 
        {
            _servicoBolo.Atualizar(id, bolo);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public NoContentResult Remover(string id) 
        {
            _servicoBolo.Remover(id);
            return NoContent();
        }
    }
}
