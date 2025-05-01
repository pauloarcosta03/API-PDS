using API_PDS.Model;
using API_PDS.ViewModel;

namespace API_PDS.Services
{
    public class ContactoEmergenciaService
    {
        private readonly CondoSocialContext _context;

        public ContactoEmergenciaService(CondoSocialContext context)
        {
            _context = context;
        }

        public void AddContactoEmergencia(ContactoEmergenciaViewModel cevm)
        {
            ContactoEmergencia contactoEmergencia = new ContactoEmergencia(cevm.Nome, cevm.Telemovel, cevm.CondominioId);

            _context.ContactosEmergencia.Add(contactoEmergencia);
            _context.SaveChanges();
        }

        public void EditaContactoEmergencia(ContactoEmergenciaViewModel ce, int id)
        {
            ContactoEmergencia contactoEmergencia = _context.ContactosEmergencia.FirstOrDefault(c => c.Id == id);

            contactoEmergencia.Nome = ce.Nome;
            contactoEmergencia.Telemovel = ce.Telemovel;
            _context.SaveChanges();
        }

        public ContactoEmergencia BuscaContacto(int contactoId)
        {
            return _context.ContactosEmergencia.FirstOrDefault(ce => ce.Id == contactoId);
        }

        public List<ContactoEmergencia> ListaContactos(int condoId)
        {
            return _context.ContactosEmergencia.Where(ce => ce.CondominioId == condoId).ToList();
        }
    }
}
