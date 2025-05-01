using API_PDS.Model;
using API_PDS.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace API_PDS.Services
{
    public class PostService
    {
        private readonly CondoSocialContext _context;
        private readonly UtilizadorService _utilizadorService;

        public PostService(CondoSocialContext context)
        {
            _context = context;
        }

        public void NovoPost(PostViewModel pvm)
        {
            Post post = new Post(pvm);
            _context.Add(post);
            _context.SaveChanges();
        }

        public void AddLike(int utilizadorId, int postId)
        {
            Like like = new Like(utilizadorId, postId);

            _context.Like.Add(like);

            Post post = _context.Post.FirstOrDefault(p => p.Id == postId);
            post.NumLikes++;
            _context.SaveChanges();
        }

        public void AddComentario(int utilizadorId, int postId, string c)
        {
            Comentario comentario = new Comentario(utilizadorId, postId, c);

            _context.Comentario.Add(comentario);
            _context.SaveChanges();
        }

        public List<Comentario> BuscaComentarios(int postId)
        {
            return _context.Comentario.Include(u => u.Utilizador).Where(c => c.PostId == postId).ToList();
        }

        public bool TemLike(int utilizadorId, int postId)
        {
            if (_context.Like.Any(l => l.UtilizadorId == utilizadorId && l.PostId == postId))
                return true;
            return false;
        }

        public List<Post> ObtemPosts() {
            return(_context.Post.OrderByDescending(p => p.CreatedOn).ToList());
        }

        public List<Post> ObtemPostsAdmin() {
            return(_context.Post.OrderByDescending(p => p.CreatedOn).Where(p => p.Aceite == false).ToList());
        }

    }
}
