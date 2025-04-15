using API_PDS.Model;
using API_PDS.Services;
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
        public IActionResult Add(string Nome, int Nif, int NPorta, int CondominioId, int GestorCondominioId, int LoginId)
        {
            Utilizador utilizador = new Utilizador(/*Id, Nome, Nif, NPorta, CondominioId, GestorCondominioId, LoginId*/);
            //utilizador.Id = Id;
            utilizador.Nome = Nome;
            utilizador.Nif = Nif;
            utilizador.NPorta = NPorta;
            utilizador.CondominioId = CondominioId;
            utilizador.GestorCondominioId = null;
            if (GestorCondominioId != -1)
            {
                utilizador.GestorCondominioId = GestorCondominioId;
            }
            utilizador.LoginId = null;
            if (LoginId != -1)
            {
                utilizador.LoginId = LoginId;
            }
            _utilizadorService.AdicionarUtilizador(utilizador);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Utilizador> utilizadores = _utilizadorService.ObterTodos();
            return Ok(utilizadores);
        }
    }
}
