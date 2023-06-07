using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entidades;
using System.Reflection;

namespace MinhasFinancas.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        } 
        public DbSet<UsuarioMF> Usuarios { get; set; }
        public DbSet<MovimentoFinanceiro> MovimentoFinanceiro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
