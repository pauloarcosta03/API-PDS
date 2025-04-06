using System.ComponentModel.DataAnnotations.Schema;

namespace API_PDS.Model
{
    public class Condominio
    {
        public int Id { get; set; }

        public string Morada { get; set; }

        [ForeignKey("CodigoPostal")]
        public string CP { get; set; }
        public CodigoPostal CodigoPostal { get; set; }

        public ICollection<Utilizador> Utilizadores { get; set; }
        public ICollection<ContactoEmergencia> ContactosEmergencia { get; set; }
        public ICollection<GestorCondominio> GestoresCondominio { get; set; }
    }
}
