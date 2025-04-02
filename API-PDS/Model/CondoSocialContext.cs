using Microsoft.EntityFrameworkCore;

namespace API_PDS.Model
{
    public class CondoSocialContext : DbContext
    {
        public DbSet<Utilizador> Utilizadores { get; set; }

        public CondoSocialContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
