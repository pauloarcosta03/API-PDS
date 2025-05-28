using API_PDS.Model;
using API_PDS.ViewModel;

namespace API_PDS.Services
{
    public class IncidenciaService
    {
        private readonly CondoSocialContext _context;

        public IncidenciaService(CondoSocialContext context, UtilizadorService utilizadorService)
        {
            _context = context;
        }

        public void AddIncidencia(IncidenciaViewModel ivm)
        {
            Utilizador utilizador = _context.Utilizadores.FirstOrDefault(u => u.Id == ivm.UtilizadorId);
            Incidencia incidencia = new Incidencia(ivm.Mensagem, ivm.UtilizadorId, utilizador.CondominioId, ivm.Foto, ivm.Tag);
            _context.Incidencias.Add(incidencia);
            _context.SaveChanges();
        }

        public void ResponderIncidencia(int id, int gestorId, string resposta)
        {
            Incidencia incidencia = _context.Incidencias.FirstOrDefault(i => i.Id == id);

            incidencia.GestorCondominioId = gestorId;
            incidencia.Resposta = resposta;
            _context.SaveChanges();
        }

        public List<Incidencia> ListaIncidencias(int condominioId) {
            return _context.Incidencias.Where(i => i.CondominioId == condominioId).ToList();
        }

        public List<Incidencia> ListaIncidenciasSemResposta(int condominioId) {
            return _context.Incidencias.Where(i => i.Resposta == null && i.CondominioId == condominioId).ToList();
        }

        public List<Incidencia> ListaIncidenciasUtilizador(int utilizadorId) {
            return _context.Incidencias.Where(i => i.UtilizadorId == utilizadorId).ToList();
        }

        public Incidencia IncidenciaId(int id) {
            return _context.Incidencias.FirstOrDefault(i => i.Id == id);
        }
    }
}
