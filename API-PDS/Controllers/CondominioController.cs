using API_PDS.Model;
using API_PDS.Services;
using API_PDS.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API_PDS.Controllers
{
    [ApiController]
    [Route("condo")]
    public class CondominioController : ControllerBase
    {
        private readonly CondominioService _condominioService;
        public CondominioController(CondominioService condominioService)
        {
            _condominioService = condominioService;
        }

        [HttpPost("novo")]
        public IActionResult Adicionar(NovoCondominioViewModel cvm)
        {
            //Verifica se já existe Codigo Postal
            bool existeCP = _condominioService.existeCP(cvm.CP);

            if (!existeCP) {
                //Criar CP
                _condominioService.AdicionarCP(cvm.CP, cvm.Localidade);
            }

            Condominio condominio = new Condominio(cvm.Morada, cvm.CP);
            _condominioService.AdicionarCondominio(condominio, cvm);

            return Ok();
        }

        [HttpGet("{Id}")]
        public IActionResult ObterCondominioId(int Id)
        {
            return Ok(_condominioService.ObtemCondominioId(Id));
        }

        [HttpGet("Todos")]
        public IActionResult ObterCondominios()
        {
            return Ok(_condominioService.ObtemTodosCondominios());
        }
    }
}
