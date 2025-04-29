using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime CreatedOn { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
