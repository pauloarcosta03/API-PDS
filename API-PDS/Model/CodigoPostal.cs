using System.ComponentModel.DataAnnotations;

namespace API_PDS.Model
{
    public class CodigoPostal
    {
        [Key]
        public string CP { get; set; }

        public string Localidade { get; set; }
        public ICollection<Condominio> Condominios { get; set; }

        public CodigoPostal(){}

        public CodigoPostal(string CP, string Localidade)
        {
            this.CP = CP;
            this.Localidade = Localidade;
        }
    }
}
