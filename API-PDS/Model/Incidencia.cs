using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Incidencia
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public string Resposta { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        [ForeignKey("GestorCondominio")]
        public int GestorCondominioId { get; set; }
        public GestorCondominio GestorCondominio { get; set; }

        [ForeignKey("Condominio")]
        public int CondominioId { get; set; }
        public Condominio Condominio { get; set; }

        public ICollection<Notificacao> Notificacoes { get; set; }
    }
}
