using API_PDS.Model;
using API_PDS.Services;
using API_PDS.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API_PDS.Controllers
{

    [ApiController]
    [Route("user")]
    public class UtilizadorController : ControllerBase
    {
        private readonly UtilizadorService _utilizadorService;
        public UtilizadorController(UtilizadorService utilizadorService)
        {
            _utilizadorService = utilizadorService;
        }

        [HttpPost("novo")]
        public IActionResult Adicionar(UtilizadorViewModel uvm, string password)
        {
            Utilizador utilizador = new Utilizador(uvm.Nome, uvm.Nif, uvm.NPorta, uvm.CondominioId, uvm.GestorCondominioId, uvm.LoginId);
            _utilizadorService.AdicionarUtilizador(utilizador, password);

            //Login login = new Login(password, utilizador.Id);

            return Ok();
        }

        [HttpGet("todos")]
        public IActionResult ObterTodos()
        {
            List<Utilizador> utilizadores = _utilizadorService.ObterTodos();
            return Ok(utilizadores);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            Utilizador utilizador = _utilizadorService.ObterPorId(id);
            return Ok(utilizador);
        }
    }
}
