using Microsoft.EntityFrameworkCore;

namespace API_PDS.Model
{
    public class CondoSocialContext : DbContext
    {
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<CodigoPostal> CodigoPostal { get; set; }
        public DbSet<ContactoEmergencia> ContactosEmergencia { get; set; }
        public DbSet<GestorCondominio> GestoresCondominio { get; set; }

        public CondoSocialContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
