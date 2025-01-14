﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SME.SGP.Api.Filtros;
using SME.SGP.Aplicacao.Interfaces;
using SME.SGP.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SGP.Api.Controllers
{
    [ApiController]
    [Route("api/v1/acompanhamento/alunos")]
    [ValidaDto]
    [Authorize("Bearer")]
    public class AcompanhamentoAlunoController : Controller
    {
        [HttpPost("semestres")]
        [ProducesResponseType(typeof(IEnumerable<AcompanhamentoAlunoSemestreAuditoriaDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [Permissao(Permissao.AFQ_C,Policy = "Bearer")]
        public async Task<IActionResult> Salvar([FromServices] ISalvarAcompanhamentoAlunoUseCase useCase, [FromBody] AcompanhamentoAlunoDto dto)
        {
            return Ok(await useCase.Executar(dto));
        }

        [HttpGet]
        [ProducesResponseType(typeof(AcompanhamentoAlunoTurmaSemestreDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        [Permissao(Permissao.AFQ_C, Policy = "Bearer")]
        public async Task<IActionResult> ObterAcompanhamentoAluno([FromQuery] long turmaId, string alunoId, int semestre, long componenteCurricularId, [FromServices] IObterAcompanhamentoAlunoUseCase useCase)
        {
            return Ok(await useCase.Executar(new FiltroAcompanhamentoTurmaAlunoSemestreDto(turmaId, alunoId, semestre, componenteCurricularId)));
        }

        [HttpDelete("semestres/{acompanhamentoAlunoSemestreId}/fotos/{codigoFoto}")]
        [ProducesResponseType(typeof(AuditoriaDto), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        public async Task<IActionResult> DeletarFotos(Guid codigoFoto, [FromServices] IExcluirFotoAlunoUseCase useCase)
        {
            return Ok(await useCase.Executar(codigoFoto));
        }



        [HttpPost("semestres/upload")]
        [ProducesResponseType(typeof(IEnumerable<AuditoriaDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 400)]
        [ProducesResponseType(typeof(RetornoBaseDto), 601)]
        [RequestSizeLimit(5 * 1024 * 1024)]
        public async Task<IActionResult> UploadFoto([FromForm][FromBody] AcompanhamentoAlunoDto dto, [FromServices] ISalvarFotoAcompanhamentoAlunoUseCase useCase)
        {
            if (dto.File.Length > 0)
                return Ok(await useCase.Executar(dto));

            return BadRequest();
        }

        [HttpGet("semestres/{acompanhamentoAlunoSemestreId}/fotos")]
        [ProducesResponseType(typeof(IEnumerable<ArquivoDto>), 200)]
        [ProducesResponseType(typeof(RetornoBaseDto), 500)]
        [ProducesResponseType(typeof(RetornoBaseDto), 400)]
        public async Task<IActionResult> ObterFotos(long acompanhamentoAlunoSemestreId, [FromServices] IObterFotosSemestreAlunoUseCase useCase)
        {
            return Ok(await useCase.Executar(acompanhamentoAlunoSemestreId));
        }
    }
}