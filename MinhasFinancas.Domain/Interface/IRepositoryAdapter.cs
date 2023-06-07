using MinhasFinancas.Domain.Entidades;
using System;
using System.Threading.Tasks;

namespace MinhasFinancas.Domain.Interface
{
    public interface IRepositoryAdapter
    {
        Task<UsuarioMF> GetUsuario(string email);
        Task<bool> GetLogin(string email, string passWord);
        Task<UsuarioMF> GetUsuarioById(int usuarioId);
    }
}
