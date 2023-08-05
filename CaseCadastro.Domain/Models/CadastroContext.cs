using Microsoft.EntityFrameworkCore;

namespace CaseCadastro.Domain.Models
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options) { }

        DbSet<Cadastro> Cadastro {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CaseCadastro");

            modelBuilder.Entity<Cadastro>(entity =>
            {
                entity.ToTable("Cadastro");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityColumn();

                entity.Property(e => e.Nome)
                    .HasColumnName("Nome")
                    .HasMaxLength(255);

                entity.Property(e => e.Sobrenome)
                    .HasColumnName("Sobrenome")
                    .HasMaxLength(255);

                entity.Property(e => e.Idade)
                    .HasColumnName("Idade")
                    .HasMaxLength(5);

                entity.Property(e => e.Pais)
                    .HasColumnName("Pais")
                    .HasMaxLength(100);
            });

        }

    }
}
