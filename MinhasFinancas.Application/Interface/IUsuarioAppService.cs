using FluentResults;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interface
{
    public interface IUsuarioAppService
    {
        Task<Result<UsuarioViewModel>> CadastrarUsuario(NewUsuarioViewModel usuario);
         

        Task<Result<bool>> AlterarCadastroUsuario(int id, UpdateUsuarioViewModel dados);
    }
}
