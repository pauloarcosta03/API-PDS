using API_PDS.Model;
using API_PDS.ViewModel;
using System.Globalization;

namespace API_PDS.Services
{
    public class ReuniaoService
    {
        private readonly CondoSocialContext _context;

        public ReuniaoService(CondoSocialContext context, UtilizadorService utilizadorService)
        {
            _context = context;
        }

        public void NovoPedidoReuniao(PedidoReuniaoViewModel prvm)
        {
            string dataString = prvm.Data + " " + prvm.Hora;
            DateTime dataHora = DateTime.ParseExact(dataString, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            Reuniao reuniao = new Reuniao(dataHora, "NR", prvm.Motivo, prvm.UtilizadorId, null);

            _context.Reunioes.Add(reuniao);
            _context.SaveChanges();
        }

        public void EditaPedidoReuniao(ReuniaoViewModel rvm)
        {
            Reuniao reuniao = _context.Reunioes.FirstOrDefault(reuniao => reuniao.Id == rvm.Id);
            reuniao.Estado = rvm.Estado;
            reuniao.Horario = rvm.Horario;
            reuniao.Ata = rvm.Ata;
            reuniao.GestorCondominioId = rvm.GestorCondominioId;

            _context.SaveChanges();
        }

        public void AprovaPedidoReuniao(int id)
        {
            Reuniao reuniao = _context.Reunioes.FirstOrDefault(reuniao => reuniao.Id == id);
            reuniao.Estado = "Aprovado";

            _context.SaveChanges();
        }

        public void RejeitaPedidoReuniao(int id)
        {
            Reuniao reuniao = _context.Reunioes.FirstOrDefault(reuniao => reuniao.Id == id);
            reuniao.Estado = "Rejeitado";

            _context.SaveChanges();
        }

        public List<Reuniao> ListaReunioesAdmin()
        {
            return _context.Reunioes.Where(r => r.Estado == "NR").ToList();
        }

        public List<Reuniao> ListaReunioesFuturas()
        {
            return _context.Reunioes.Where(r => r.Horario >= DateTime.Now && r.Estado == "Aprovado").ToList();
        }
    }
}
