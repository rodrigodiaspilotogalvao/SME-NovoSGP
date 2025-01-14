﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SGP.Api.Filtros;
using SME.SGP.Aplicacao;
using SME.SGP.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SGP.Api.Controllers
{
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/v1/dashboard/naapa")]
    public class DashboardNaapaController : ControllerBase
    {
        [HttpGet("frequencia/turma/evasao/abaixo50porcento")]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        [ProducesResponseType(typeof(IEnumerable<GraficoFrequenciaTurmaEvasaoDto>), 200)]
        [Permissao(Permissao.DNA_C, Policy = "Bearer")]
        public async Task<IActionResult> ObterFrequenciaTurmaEvasaoAbaixo50Porcento([FromQuery] FiltroGraficoFrequenciaTurmaEvasaoDto filtro,
            [FromServices] IObterDashboardFrequenciaTurmaEvasaoAbaixo50PorcentoUseCase useCase)
        {
            return Ok(await useCase.Executar(filtro));
        }

        [HttpGet("frequencia/turma/evasao/sempresenca")]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        [ProducesResponseType(typeof(IEnumerable<GraficoFrequenciaTurmaEvasaoDto>), 200)]
        [Permissao(Permissao.DNA_C, Policy = "Bearer")]
        public async Task<IActionResult> ObterFrequenciaTurmaEvasaoSemPresenca([FromQuery] FiltroGraficoFrequenciaTurmaEvasaoDto filtro,
            [FromServices] IObterDashboardFrequenciaTurmaEvasaoSemPresencaUseCase useCase)
        {
            return Ok(await useCase.Executar(filtro));
        }
    }
}
