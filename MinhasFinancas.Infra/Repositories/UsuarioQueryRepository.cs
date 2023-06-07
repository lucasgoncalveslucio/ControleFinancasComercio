using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.Infra.Data;
using MinhasFinancas.ViewModel.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Infra.Repositories
{
    public class UsuarioQueryRepository : IUsuarioQueryRepository
    {
        private readonly DataContext _context;

        public UsuarioQueryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UsuarioMF> GetUsuario(string email)
            => await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<UsuarioMF> GetUsuarioById(int usuarioId)
            => await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioId);

        public async Task<bool> GetLogin(string email, string passWord)
            => await _context.Usuarios.AnyAsync(x => x.Email == email);

        
    }
}
