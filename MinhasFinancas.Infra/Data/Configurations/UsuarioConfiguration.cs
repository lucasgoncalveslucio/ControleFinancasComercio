using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhasFinancas.Domain.Entidades;

namespace MinhasFinancas.Infra.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioMF>
    {
        public void Configure(EntityTypeBuilder<UsuarioMF> builder)
        {
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Nome)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Email)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.ToTable("movfin_usuario");
        }
    }
}
