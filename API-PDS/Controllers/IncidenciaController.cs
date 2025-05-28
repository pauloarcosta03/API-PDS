using API_PDS.Services;
using API_PDS.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API_PDS.Controllers
{
    [ApiController]
    [Route("incidencias")]
    public class IncidenciaController : Controller
    {
        private readonly IncidenciaService _incidenciaService;
        public IncidenciaController(IncidenciaService incidenciaService)
        {
            _incidenciaService = incidenciaService;
        }

        [HttpPost("nova")]
        public IActionResult Adicionar(IncidenciaViewModel ivm)
        {
            _incidenciaService.AddIncidencia(ivm);

            return Ok();
        }

        [HttpPost("resposta/{id}/{gestorId}")]
        public IActionResult Adicionar(int id, int gestorId, string resposta)
        {
            _incidenciaService.ResponderIncidencia(id, gestorId, resposta);

            return Ok();
        }

        [HttpGet("lista/admin/{condominioId}")]
        public IActionResult ListaIncidenciasSemResposta(int condominioId)
        {

            return Ok(_incidenciaService.ListaIncidenciasSemResposta(condominioId));
        }

        [HttpGet("lista/{condominioId}")]
        public IActionResult ListaIncidencias(int condominioId)
        {

            return Ok(_incidenciaService.ListaIncidencias(condominioId));
        }

        [HttpGet("lista/user/{utilizadorId}")]
        public IActionResult ListaIncidenciasUtilizador(int utilizadorId)
        {

            return Ok(_incidenciaService.ListaIncidenciasUtilizador(utilizadorId));
        }

    }
}
