using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class ContactoEmergencia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Foto { get; set; }
        public int Telemovel { get; set; }

        [ForeignKey("Condominio")]
        public int CondominioId { get; set; }
        public Condominio Condominio { get; set; }

        public ContactoEmergencia()
        {
            
        }

        public ContactoEmergencia(string Nome, int Telemovel, int CondominioId)
        {
            this.Nome = Nome;
            this.Telemovel = Telemovel;
            this.CondominioId = CondominioId;
        }
    }
}
