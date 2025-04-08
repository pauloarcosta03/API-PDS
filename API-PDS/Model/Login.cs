using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Login
    {
        public int Id { get; set; }
        public string Password { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

    }
}
