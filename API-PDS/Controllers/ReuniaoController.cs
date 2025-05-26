using API_PDS.Services;
using API_PDS.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API_PDS.Controllers
{
    [ApiController]
    [Route("reuniao")]
    public class ReuniaoController : Controller
    {
        private readonly ReuniaoService _reuniaoService;
        public ReuniaoController(ReuniaoService reuniaoService)
        {
            _reuniaoService = reuniaoService;
        }

        [HttpPost("novo/pedido")]
        public IActionResult AdicionarPedido(PedidoReuniaoViewModel prvm)
        {
            _reuniaoService.NovoPedidoReuniao(prvm);

            return Ok();
        }

        [HttpPost("editar/pedido")]
        public IActionResult EditarPedido(ReuniaoViewModel rvm)
        {
            _reuniaoService.EditaPedidoReuniao(rvm);

            return Ok();
        }

        [HttpPost("aprovar/pedido/{id}")]
        public IActionResult AprovarPedido(int id)
        {
            _reuniaoService.AprovaPedidoReuniao(id);

            return Ok();
        }

        [HttpPost("rejeita/pedido/{id}")]
        public IActionResult RejeitaPedido(int id)
        {
            _reuniaoService.RejeitaPedidoReuniao(id);

            return Ok();
        }

        [HttpPost("add/ata/{id}")]
        public IActionResult AddAta(int id, AddAtaViewModel ata)
        {
            _reuniaoService.AddAta(id, ata.ata);

            return Ok();
        }

        [HttpGet("lista/admin")]
        public IActionResult ListaReunioesAdmin()
        {

            return Ok(_reuniaoService.ListaReunioesAdmin());
        }

        [HttpGet("lista/prox")]
        public IActionResult ListaReunioesFuturas()
        {

            return Ok(_reuniaoService.ListaReunioesFuturas());
        }
    }
}
