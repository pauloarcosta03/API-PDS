using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Contacto
    {
        [Key]
        public int Descricao { get; set; }
        public string Tag { get; set; }
        
        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }
    }
}
