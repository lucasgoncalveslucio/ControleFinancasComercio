using MinhasFinancas.Domain.Entidades;
using MinhasFinancas.ViewModel.ViewModels;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioQueryRepository
    {
 
        Task<bool> GetLogin(string email, string passWord);
        Task<UsuarioMF> GetUsuario(string email);
        Task<UsuarioMF> GetUsuarioById(int usuarioId); 
    }
}
