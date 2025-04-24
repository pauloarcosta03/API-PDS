using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Contacto
    {
        [Key]
        public string Descricao { get; set; }
        public string Tag { get; set; }
        
        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        public Contacto() {}

        public Contacto(string Descricao, string Tag, int UtilizadorId)
        {
            this.Descricao = Descricao;
            this.Tag = Tag;
            this.UtilizadorId = UtilizadorId;
        }
    }
}
