using API_PDS.Model;
using API_PDS.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace API_PDS.Services
{
    public class UtilizadorService
    {
        private readonly CondoSocialContext _context;

        public UtilizadorService(CondoSocialContext context)
        {
            _context = context;
        }

        public void AdicionarUtilizador(NovoUtilizadorViewModel uvm)
        {
            //Cria o utilizador
            Utilizador utilizador = new Utilizador(uvm.Nome, uvm.Nif, uvm.NPorta, uvm.CondominioId, uvm.GestorCondominioId, uvm.LoginId);
            _context.Utilizadores.Add(utilizador);
            _context.SaveChanges();

            //adiciona os dados de login
            Login login = new Login(uvm.Password, utilizador.Id);
            _context.Login.Add(login);
            _context.SaveChanges();

            utilizador.LoginId = login.Id;
            _context.SaveChanges();

            Contacto contacto = new Contacto(uvm.contacto, uvm.contactoTag, utilizador.Id);
            _context.Contactos.Add(contacto);
            _context.SaveChanges();
        }

        public int AdicionarUtilizador(NovoCondominioViewModel uvm)
        {
            //Cria o utilizador
            Utilizador utilizador = new Utilizador(uvm.Nome, uvm.Nif, uvm.NPorta, uvm.CondominioId, uvm.GestorCondominioId, uvm.LoginId);
            _context.Utilizadores.Add(utilizador);
            _context.SaveChanges();

            //adiciona os dados de login
            Login login = new Login(uvm.Password, utilizador.Id);
            _context.Login.Add(login);
            _context.SaveChanges();

            utilizador.LoginId = login.Id;
            _context.SaveChanges();

            Contacto contacto = new Contacto(uvm.contacto, uvm.contactoTag, utilizador.Id);
            _context.Contactos.Add(contacto);
            _context.SaveChanges();

            return utilizador.Id;
        }

        public void EditarPerfil(Utilizador utilizador)
        {
            Utilizador utilizadorDb = _context.Utilizadores.FirstOrDefault(u => u.Id == utilizador.Id);
            utilizadorDb.Nome = utilizador.Nome;
            utilizadorDb.Nif = utilizador.Nif;
            utilizadorDb.NPorta = utilizador.NPorta;
            _context.SaveChanges();
        }

        public List<Utilizador> ObterTodos(int id)
        {
            return _context.Utilizadores
                .Where(u=>u.CondominioId == id)
                //.Include(u => u.Condominio)
                //.Include(u => u.GestorCondominio)
                //.Include(u => u.Login)
                .ToList();
        }

        public Utilizador ObterPorId(int id)
        {
            return _context.Utilizadores.FirstOrDefault(u => u.Id == id);
        }
    }
}
