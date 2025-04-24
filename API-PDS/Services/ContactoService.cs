using API_PDS.Model;
using API_PDS.ViewModel;

namespace API_PDS.Services
{
    public class ContactoService
    {
        private readonly CondoSocialContext _context;

        public ContactoService(CondoSocialContext context)
        {
            _context = context;
        }

        public void AdicionaContacto(ContactoViewModel cvm)
        {
            Contacto contacto = new Contacto(cvm.Descricao, cvm.Tag, cvm.UtilizadorId);

            _context.Contactos.Add(contacto);
            _context.SaveChanges();
        }

        public Contacto ObtemContacto(string descricao)
        {
            return _context.Contactos.FirstOrDefault(c=>c.Descricao==descricao);
        }

    }
}
