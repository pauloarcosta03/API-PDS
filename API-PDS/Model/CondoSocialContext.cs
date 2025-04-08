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
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Reuniao> Reunioes { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Notificacao> Notificacao { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Participante> Participante { get; set; }

        public CondoSocialContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
