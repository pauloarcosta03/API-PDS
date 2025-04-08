using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Notificacao
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public bool Vista { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }

        [ForeignKey("Reuniao")]
        public int ReuniaoId { get; set; }
        public Reuniao Reuniao { get; set; }

        [ForeignKey("Incidencia")]
        public int IncidenciaId { get; set; }
        public Incidencia Incidencia { get; set; }
    }
}
