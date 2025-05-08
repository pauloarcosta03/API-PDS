using API_PDS.Model;
using API_PDS.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace API_PDS.Services
{
    public class LoginService
    {
        private readonly CondoSocialContext _context;

        public LoginService(CondoSocialContext context)
        {
            _context = context;
        }

        public ResLoginViewModel Login(LoginViewModel lvm)
        {
            Contacto c = _context.Contactos.Include(u => u.Utilizador).ThenInclude(u=>u.Login).FirstOrDefault(c => c.Descricao == lvm.email);
            ResLoginViewModel rlvm = new ResLoginViewModel();

            if (c == null) return rlvm;

            if (c.Utilizador.Login.Password == lvm.Password)
            {
                rlvm.IdUser = c.Utilizador.Id;
                rlvm.User = c.Utilizador.Nome;
                rlvm.Admin = _context.GestoresCondominio.Any(g => g.UtilizadorId == rlvm.IdUser);//bool

            }
                
            return rlvm;
        }

    }
}
