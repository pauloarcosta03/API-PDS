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

        [HttpGet("lista/admin")]
        public IActionResult ListaIncidenciasSemResposta()
        {

            return Ok(_incidenciaService.ListaIncidenciasSemResposta());
        }

        [HttpGet("lista")]
        public IActionResult ListaIncidencias()
        {

            return Ok(_incidenciaService.ListaIncidencias());
        }

    }
}
