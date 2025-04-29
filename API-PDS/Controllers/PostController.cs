using API_PDS.Model;
using API_PDS.Services;
using API_PDS.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API_PDS.Controllers
{
    [ApiController]
    [Route("post")]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;
        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpPost("novo")]
        public IActionResult Adicionar(PostViewModel pvm)
        {
            pvm.CreatedOn = DateTime.Now;
            
            _postService.NovoPost(pvm);

            return Ok();
        }

        [HttpGet("lista")]
        public IActionResult ObterCondominioId()
        {
            return Ok(_postService.ObtemPosts());
        }
    }
}
