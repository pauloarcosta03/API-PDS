using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Like
    {
        public int Id { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }

        public Like()
        {
            
        }

        public Like(int utilizadorId, int postId)
        {
            this.UtilizadorId = utilizadorId;
            this.PostId = postId;
        }
    }
}
