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

        /// <summary>
        /// Cria novo post
        /// </summary>
        /// <param name="pvm"></param>
        /// <returns></returns>
        [HttpPost("novo")]
        public IActionResult Adicionar(PostViewModel pvm)
        {
            pvm.CreatedOn = DateTime.Now;
            
            _postService.NovoPost(pvm);

            return Ok();
        }

        [HttpPost("eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            _postService.EliminarPost(id);

            return Ok();
        }

        [HttpPost("like/{utilizadorId}/{postId}")]
        public IActionResult Like(int utilizadorId, int postId)
        {
            if (!_postService.TemLike(utilizadorId, postId)) 
                _postService.AddLike(utilizadorId, postId);
            return Ok();
        }

        [HttpPost("comentar/{utilizadorId}/{postId}")]
        public IActionResult Comentar(int utilizadorId, int postId, string comentario)
        {
            _postService.AddComentario(utilizadorId, postId, comentario);
            return Ok();
        }

        /// <summary>
        /// Busca todos os posts do mais novo para o antigo
        /// </summary>
        /// <returns></returns>
        [HttpGet("feed")]
        public IActionResult ObterPostsFeed()
        {
            return Ok(_postService.ObtemPosts());
        }

        /// <summary>
        /// Busca todos os posts do mais novo para o antigo
        /// </summary>
        /// <returns></returns>
        [HttpGet("lista/admin")]
        public IActionResult ObterPostsNaoAprovados()
        {
            return Ok(_postService.ObtemPostsAdmin());
        }
        
        [HttpGet("comentarios/{id}")]
        public IActionResult ObterComentarios(int id)
        {
            return Ok(_postService.BuscaComentarios(id));
        }
    }
}
