using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.Domain.Enum;
using MinhasFinancas.Infra.Data;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MinhasFinancas.Infra.Repositories
{
    public class FinancasQueryRepository : IFinancasQueryRepository
    {
        private readonly DataContext _context;

        public FinancasQueryRepository(DataContext context)
        {
            _context = context;
        }

        public async IAsyncEnumerable<MovimentoFinanceiroViewModel> GetReceitasByData(DateTime data)
        {
            var result = await _context.MovimentoFinanceiro
                        .Where(x => x.Data != null && x.Data.Month == data.Month && x.Tipo == TipoMovimentoEnum.Receita)
                        .ToListAsync();


            foreach (var item in result)
            {
                yield return new MovimentoFinanceiroViewModel
                {
                    Id = item.Id,
                    Valor = item.Valor,
                    Descricao = item.Descricao,
                    Data = item.Data
                };
            }
        }

        public async IAsyncEnumerable<MovimentoFinanceiroViewModel> GetDespesasByData(DateTime data)
        {
            var result = await _context.MovimentoFinanceiro
                                       .Where(x => x.Data.Month == data.Month &&
                                              x.Tipo == TipoMovimentoEnum.Despesa)
                                       .ToListAsync();

            foreach (var item in result)
            {
                yield return new MovimentoFinanceiroViewModel
                {
                    Id = item.Id,
                    Valor = item.Valor,
                    Descricao = item.Descricao,
                    Data = item.Data
                };
            }
        }

        public async IAsyncEnumerable<ConsolidadeViewModel> GetConsolidadoByData(DateTime data)
        {
            decimal Despesa =   _context.MovimentoFinanceiro
                                .Where(p => p.Data == data  && 
                                    p.Tipo == TipoMovimentoEnum.Despesa)
                                .Sum(p => p.Valor);

            decimal Receita =   _context.MovimentoFinanceiro
                                .Where(p => p.Data == data &&
                                    p.Tipo == TipoMovimentoEnum.Receita)
                                .Sum(p => p.Valor);

            yield return new ConsolidadeViewModel
            {
                Saldo = Receita- Despesa,
                Data = data
            };

        }
    }
}
