﻿using MediatR;
using SME.SGP.Dominio.Enumerados;
using SME.SGP.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SGP.Aplicacao
{
    public class ValidaAusenciaParaConciliacaoFrequenciaTurmaCommandHandler : IRequestHandler<ValidaAusenciaParaConciliacaoFrequenciaTurmaCommand, bool>
    {
        private readonly IMediator mediator;

        public ValidaAusenciaParaConciliacaoFrequenciaTurmaCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(ValidaAusenciaParaConciliacaoFrequenciaTurmaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var alunosAusentes = await mediator.Send(new ObterAlunosAusentesPorTurmaNoPeriodoQuery(request.TurmaCodigo, request.DataInicio, request.DataFim, request.ComponenteCurricularId));

                if (alunosAusentes != null && alunosAusentes.Any())
                    await IncluirFilaCalculoFrequenciaAlunosPorComponenteETurma(request.TurmaCodigo, request.DataFim, alunosAusentes);

                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"Erro na consolidação de Frequência da turma.", LogNivel.Negocio, LogContexto.Frequencia, ex.Message));
                throw;
            }
        }

        private async Task IncluirFilaCalculoFrequenciaAlunosPorComponenteETurma(string turmaCodigo, DateTime dataFim, IEnumerable<AlunoComponenteCurricularDto> alunosAusentes)
        {
            var alunosPorComponentes = alunosAusentes.GroupBy(a => a.ComponenteCurricularId);

            foreach (var alunosNoComponente in alunosPorComponentes)
            {
                var alunosCodigo = alunosNoComponente.Select(a => a.AlunoCodigo).ToList();

                var comando = new CalcularFrequenciaPorTurmaCommand(alunosCodigo, dataFim, turmaCodigo, alunosNoComponente.Key);
                await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgpFrequencia.RotaConciliacaoCalculoFrequenciaPorTurmaComponente, comando, Guid.NewGuid(), null));
            }

        }
    }
}
