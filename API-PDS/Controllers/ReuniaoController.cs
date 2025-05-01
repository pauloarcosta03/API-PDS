using API_PDS.Services;
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


    }
}
