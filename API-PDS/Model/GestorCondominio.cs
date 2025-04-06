using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class GestorCondominio
    {
        public int Id { get; set; }
        [ForeignKey("Condominio")]
        public int CondominioId { get; set; }
        public Condominio Condominio { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }
    }
}
