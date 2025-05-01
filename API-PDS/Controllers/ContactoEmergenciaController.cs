using API_PDS.Model;
using API_PDS.Services;
using API_PDS.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API_PDS.Controllers
{
    [ApiController]
    [Route("contacto/emergencia")]
    public class ContactoEmergenciaController : Controller
    {
        private readonly ContactoEmergenciaService _contactoEmergenciaService;
        public ContactoEmergenciaController(ContactoEmergenciaService contactoEmergenciaService)
        {
            _contactoEmergenciaService = contactoEmergenciaService;
        }

        [HttpPost("Add")]
        public IActionResult AddContacto(ContactoEmergenciaViewModel cevm)
        {
            _contactoEmergenciaService.AddContactoEmergencia(cevm);
            return Ok();
        }

        [HttpPost("Editar/{id}")]
        public IActionResult EditaContacto(ContactoEmergenciaViewModel ce, int id)
        {
            _contactoEmergenciaService.EditaContactoEmergencia(ce, id);
            return Ok();
        }

        [HttpGet("{contactoId}")]
        public IActionResult BuscaContacto(int contactoId)
        {
            return Ok(_contactoEmergenciaService.BuscaContacto(contactoId));
        }

        [HttpGet("Lista/{condoId}")]
        public IActionResult ListaContactos(int condoId)
        {
            return Ok(_contactoEmergenciaService.ListaContactos(condoId));
        }
    }
}
