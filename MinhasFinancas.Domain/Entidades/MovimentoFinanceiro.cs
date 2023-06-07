﻿using MinhasFinancas.Domain.Core.Shared;
using MinhasFinancas.Domain.Enum;
using System;

namespace MinhasFinancas.Domain.Entidades
{
    public class MovimentoFinanceiro : Entidade
    {
        protected MovimentoFinanceiro() { }

        public MovimentoFinanceiro(decimal valor, 
                                   string descricao, 
                                   DateTime data, 
                                   TipoMovimentoEnum tipo)
        {
            Valor = valor;
            Descricao = descricao;
            Data = data.Date;
            Tipo = tipo;
        }

        public decimal Valor { get; }
        public string Descricao { get; }
        public DateTime Data { get; }
        public TipoMovimentoEnum Tipo { get; }
    }
}
