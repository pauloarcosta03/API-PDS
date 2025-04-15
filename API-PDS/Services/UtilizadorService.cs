using API_PDS.Model;

namespace API_PDS.Services
{
    public class UtilizadorService
    {
        private readonly CondoSocialContext _context;

        public UtilizadorService(CondoSocialContext context)
        {
            _context = context;
        }

        public void AdicionarUtilizador(Utilizador utilizador)
        {

            _context.Utilizadores.Add(utilizador);
            _context.SaveChanges();
        }

        public List<Utilizador> ObterTodos()
        {
            return _context.Utilizadores.ToList();
        }

        public Utilizador ObterPorId(int id)
        {
            return _context.Utilizadores.FirstOrDefault(u => u.Id == id);
        }
    }
}
