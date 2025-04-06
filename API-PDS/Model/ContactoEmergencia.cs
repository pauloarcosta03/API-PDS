using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class ContactoEmergencia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Telemovel { get; set; }

        [ForeignKey("Condominio")]
        public int CondominioId { get; set; }
        public Condominio Condominio { get; set; }
    }
}
