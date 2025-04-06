using System.ComponentModel.DataAnnotations;

namespace API_PDS.Model
{
    public class CodigoPostal
    {
        [Key]
        public string CP { get; set; }

        public string Localidade { get; set; }
        public ICollection<Condominio> Condominios { get; set; }
    }
}
