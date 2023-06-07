using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasFinancas.Infra.Data.Configurations
{
    public class MovimentoFinanceiroConfiguration : IEntityTypeConfiguration<MovimentoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<MovimentoFinanceiro> builder)
        {
            builder.ToTable("MovimentoFinanceiro");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(m => m.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(m => m.Data)
                .HasColumnName("Data")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(m => m.Tipo)
                .HasColumnName("Tipo")
                .HasColumnType("int")
                .IsRequired();

        }
    }
}
