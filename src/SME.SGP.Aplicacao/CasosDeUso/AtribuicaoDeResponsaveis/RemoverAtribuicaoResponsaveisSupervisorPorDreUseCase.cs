﻿using MediatR;
using SME.SGP.Aplicacao.Interfaces;
using SME.SGP.Dominio;
using SME.SGP.Dominio.Enumerados;
using SME.SGP.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SGP.Aplicacao
{
    public class RemoverAtribuicaoResponsaveisSupervisorPorDreUseCase : IRemoverAtribuicaoResponsaveisSupervisorPorDreUseCase
    {
        private readonly IMediator mediator;
        public RemoverAtribuicaoResponsaveisSupervisorPorDreUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit param)
        {
            try
            {
                var codigoDre = param.ObterObjetoMensagem<string>();
                var responsaveisSGP = await mediator.Send(new ObterSupervisoresPorDreAsyncQuery(codigoDre, TipoResponsavelAtribuicao.SupervisorEscolar));

                if (responsaveisSGP.Any())
                {
                    var supervisoresSGPIds = responsaveisSGP.GroupBy(a => a.SupervisorId).Select(a => a.Key);

                    var responsaveisEOL = await mediator.Send(new ObterSupervisorPorCodigoQuery(supervisoresSGPIds.ToArray()));

                    await RemoverSupervisorSemAtribuicao(responsaveisSGP, responsaveisEOL);
                }
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand("Não foi possível executar a remoção da atribuição de responsavel Supervisor por DRE", LogNivel.Critico, LogContexto.AtribuicaoReponsavel, ex.Message));
                return false;
            }
        }

        private async Task<bool> RemoverSupervisorSemAtribuicao(IEnumerable<SupervisorEscolasDreDto> responsaveisSGP, IEnumerable<SupervisoresRetornoDto> responsaveisEOL)
        {
            var responsavelSupervisor = responsaveisSGP;

            if (responsaveisEOL != null)
                responsavelSupervisor = responsavelSupervisor.Where(s => s.TipoAtribuicao == (int)TipoResponsavelAtribuicao.SupervisorEscolar && !responsaveisEOL.Select(e => e.CodigoRf).Contains(s.SupervisorId));

            foreach (var supervisor in responsavelSupervisor)
            {
                var supervisorEntidadeExclusao = MapearDtoParaEntidade(supervisor);
                await mediator.Send(new RemoverAtribuicaoSupervisorCommand(supervisorEntidadeExclusao));
            }
            return true;
        }
        private static SupervisorEscolaDre MapearDtoParaEntidade(SupervisorEscolasDreDto dto)
        {
            return new SupervisorEscolaDre()
            {
                DreId = dto.DreId,
                SupervisorId = dto.SupervisorId,
                EscolaId = dto.EscolaId,
                Id = dto.AtribuicaoSupervisorId,
                Excluido = dto.AtribuicaoExcluida,
                AlteradoEm = dto.AlteradoEm,
                AlteradoPor = dto.AlteradoPor,
                AlteradoRF = dto.AlteradoRF,
                CriadoEm = dto.CriadoEm,
                CriadoPor = dto.CriadoPor,
                CriadoRF = dto.CriadoRF,
                Tipo = dto.TipoAtribuicao
            };
        }
    }
}