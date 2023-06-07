using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;

namespace MinhasFinancas.Application.Interface
{
    public interface IFinancasQueryRepository
    { 
        IAsyncEnumerable<MovimentoFinanceiroViewModel> GetReceitasByData(  DateTime data);
        IAsyncEnumerable<MovimentoFinanceiroViewModel> GetDespesasByData(  DateTime data);
    }
}
