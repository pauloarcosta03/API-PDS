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
            Incidencia incidencia = new Incidencia(ivm.Mensagem, ivm.UtilizadorId, ivm.CondominioId);
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

        public List<Incidencia> ListaIncidencias() {
            return _context.Incidencias.ToList();
        }

        public List<Incidencia> ListaIncidenciasSemResposta() {
            return _context.Incidencias.Where(i => i.Resposta == null).ToList();
        }

        public Incidencia IncidenciaId(int id) {
            return _context.Incidencias.FirstOrDefault(i => i.Id == id);
        }
    }
}
