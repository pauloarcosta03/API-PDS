using API_PDS.Model;
using API_PDS.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace API_PDS.Services
{
    public class LoginService
    {
        private readonly CondoSocialContext _context;
        private readonly UtilizadorService _utilizadorService;

        public LoginService(CondoSocialContext context)
        {
            _context = context;
        }

        public int Login(LoginViewModel lvm)
        {
            Contacto c = _context.Contactos.Include(u => u.Utilizador).ThenInclude(u=>u.Login).FirstOrDefault(c => c.Descricao == lvm.email);

            if (c == null) return -1;

            if (c.Utilizador.Login.Password == lvm.Password)
                return c.Utilizador.Id;
            else 
                return -1;
        }

    }
}
