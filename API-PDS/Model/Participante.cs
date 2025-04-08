using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Participante
    {
        public int Id { get; set; }
        public bool Confirma { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
