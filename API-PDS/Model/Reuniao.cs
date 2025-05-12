using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Reuniao
    {
        public int Id { get; set; }
        public DateTime? Horario { get; set; }
        public string Estado { get; set; }
        public string Motivo { get; set; }
        public string? Ata { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        [ForeignKey("GestorCondominio")]
        public int? GestorCondominioId { get; set; }
        public GestorCondominio? GestorCondominio { get; set; }

        public ICollection<Notificacao>? Notificacoes { get; set; }

        public Reuniao()
        {
            
        }

        public Reuniao(DateTime? Horario, string Estado, string Motivo, int UtilizadorId, int? GestorCondominioId)
        {
            this.Horario = Horario;
            this.Estado = Estado;
            this.Motivo = Motivo;
            this.UtilizadorId = UtilizadorId;
            this.GestorCondominioId = GestorCondominioId;
        }
    }
}
