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
        public IActionResult Adicionar(NovoUtilizadorViewModel uvm)
        {
            //Utilizador utilizador = new Utilizador(uvm.Nome, uvm.Nif, uvm.NPorta, uvm.CondominioId, uvm.GestorCondominioId, uvm.LoginId);
            _utilizadorService.AdicionarUtilizador(uvm);

            //Login login = new Login(password, utilizador.Id);

            return Ok();
        }

        [HttpPost("editar")]
        public IActionResult Editar(Utilizador u)
        {
            _utilizadorService.EditarPerfil(u);

            return Ok();
        }

        [HttpGet("todos/{id}")]
        public IActionResult ObterTodos(int id)
        {
            List<Utilizador> utilizadores = _utilizadorService.ObterTodos(id);
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
