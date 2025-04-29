using API_PDS.Model;
using API_PDS.ViewModel;

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

        public List<Post> ObtemPosts() {
            return(_context.Post.OrderByDescending(p => p.CreatedOn).ToList());
        }

    }
}
