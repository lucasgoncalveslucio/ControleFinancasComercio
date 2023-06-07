﻿using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interface;
using MinhasFinancas.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhasFinancas.Api.Controllers.Financas
{
    [Controller]
    [Route("api/financas")]
    [Produces("application/json")]
    //[Authorize]
    public class MovimentoFinanceiroController : ControllerBase
    {
        private readonly IFinancasAppService _appServiceHandler;

        public MovimentoFinanceiroController(IFinancasAppService appServiceHandler)
        {
            _appServiceHandler = appServiceHandler;
        }

        [HttpGet("receitas")]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 200)]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 404)]
        public async Task<IActionResult> GetReceitasByData(  [FromQuery] DateTime data)
        {
            var result = await _appServiceHandler.GetReceitasByData(  data.Date);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("despesas")]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 200)]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 404)]
        public async Task<IActionResult> GetDespesasByData(  [FromQuery] DateTime data)
        {
            var result = await _appServiceHandler.GetDespesasByData( data.Date);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("consolidado")]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 200)]
        [ProducesResponseType(typeof(IEnumerable<MovimentoFinanceiroViewModel>), 404)]
        public async Task<IActionResult> GetConsolidadoByData([FromQuery] DateTime data)
        {
            var result = await _appServiceHandler.GetConsolidadoByData(data.Date);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(NewMovimentoFinanceiroViewModel), 201)]
        [ProducesResponseType(typeof(Result<IReason>), 400)]
        public async Task<IActionResult> Adicionar([FromBody] NewMovimentoFinanceiroViewModel request)
        {
            var result = await _appServiceHandler.Adicionar(request);

            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Created("", result.Value);
        }

        [HttpPut("{idMovimentoFinanceiro}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(Result<IReason>), 400)]
        public async Task<IActionResult> Atualizar(int idMovimentoFinanceiro, [FromBody] UpdateMovimentoFinanceiroViewModel dados)
        {
            var result = await _appServiceHandler.Atualizar(idMovimentoFinanceiro, dados);

            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok(result.Value);
        }
    }
}
