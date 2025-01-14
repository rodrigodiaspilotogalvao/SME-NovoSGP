﻿using MediatR;
using SME.SGP.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SGP.Aplicacao
{
    public class AtualizarInformacoesDoEncaminhamentoNAAPAUseCase : AbstractUseCase, IAtualizarInformacoesDoEncaminhamentoNAAPAUseCase
    {
        public AtualizarInformacoesDoEncaminhamentoNAAPAUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit param)
        {
            var encaminhamentos = await mediator.Send(new ObterEncaminhamentosComSituacaoDiferenteDeEncerradoQuery());

            foreach (var encaminhamento in encaminhamentos) 
            {
                await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.ExecutarAtualizacaoDaTurmaDoEncaminhamentoNAAPA, encaminhamento, Guid.NewGuid(), null));
                await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.ExecutarAtualizacaoDoEnderecoDoEncaminhamentoNAAPA, encaminhamento, Guid.NewGuid(), null));
                await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.ExecutarAtualizacaoDasTurmasProgramaDoEncaminhamentoNAAPA, encaminhamento, Guid.NewGuid(), null));
            }

            return true;
        }
    }
}
