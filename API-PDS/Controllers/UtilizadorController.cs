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

        [HttpPost]
        public IActionResult Add(UtilizadorViewModel uvm, string password)
        {
            Utilizador utilizador = new Utilizador(uvm.Nome, uvm.Nif, uvm.NPorta, uvm.CondominioId, uvm.GestorCondominioId, uvm.LoginId);
            _utilizadorService.AdicionarUtilizador(utilizador, password);

            //Login login = new Login(password, utilizador.Id);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Utilizador> utilizadores = _utilizadorService.ObterTodos();
            return Ok(utilizadores);
        }
    }
}
