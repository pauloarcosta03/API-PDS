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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Utilizador ↔ GestorCondominio (1:1)
            modelBuilder.Entity<Utilizador>()
                .HasOne(u => u.GestorCondominio)
                .WithOne(g => g.Utilizador)
                .HasForeignKey<Utilizador>(u => u.GestorCondominioId)
                .OnDelete(DeleteBehavior.NoAction);

            // Utilizador ↔ Login (1:1)
            modelBuilder.Entity<Utilizador>()
                .HasOne(u => u.Login)
                .WithOne(l => l.Utilizador)
                .HasForeignKey<Utilizador>(u => u.LoginId)
                .OnDelete(DeleteBehavior.NoAction); // ao apagar login, apaga utilizador ou vice-versa

            modelBuilder.Entity<Incidencia>()
                .HasOne(u => u.GestorCondominio)
                .WithMany(l => l.Incidencias)
                .HasForeignKey(u => u.GestorCondominioId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Incidencia>()
                .HasOne(u => u.Utilizador)
                .WithMany(l => l.Incidencias)
                .HasForeignKey(u => u.UtilizadorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
                .HasOne(u => u.Utilizador)
                .WithMany(l => l.Posts)
                .HasForeignKey(u => u.UtilizadorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reuniao>()
                .HasOne(u => u.Utilizador)
                .WithMany(l => l.Reunioes)
                .HasForeignKey(u => u.UtilizadorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comentario>()
                .HasOne(u => u.Utilizador)
                .WithMany(l => l.Comentarios)
                .HasForeignKey(u => u.UtilizadorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne(u => u.Utilizador)
                .WithMany(l => l.Likes)
                .HasForeignKey(u => u.UtilizadorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Participante>()
                .HasOne(u => u.Utilizador)
                .WithMany(l => l.Participantes)
                .HasForeignKey(u => u.UtilizadorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Notificacao>()
                .HasOne(u => u.Post)
                .WithMany(l => l.Notificacoes)
                .HasForeignKey(u => u.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Notificacao>()
                .HasOne(u => u.Utilizador)
                .WithMany(l => l.Notificacoes)
                .HasForeignKey(u => u.UtilizadorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Notificacao>()
                .HasOne(u => u.Reuniao)
                .WithMany(l => l.Notificacoes)
                .HasForeignKey(u => u.ReuniaoId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
