﻿using MediatR;
using SME.SGP.Dominio;
using SME.SGP.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SGP.Aplicacao
{
    public class CriarCacheDeAtividadeAvaliativaPorTurmaCommandHandler : IRequestHandler<CriarCacheDeAtividadeAvaliativaPorTurmaCommand, IEnumerable<NotaConceito>>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IRepositorioNotasConceitosConsulta repositorioNotasConceitos;

        public CriarCacheDeAtividadeAvaliativaPorTurmaCommandHandler(IRepositorioCache repositorioCache, IRepositorioNotasConceitosConsulta repositorioNotasConceitos)
        {
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
            this.repositorioNotasConceitos = repositorioNotasConceitos ?? throw new System.ArgumentNullException(nameof(repositorioNotasConceitos));
        }

        public async Task<IEnumerable<NotaConceito>> Handle(CriarCacheDeAtividadeAvaliativaPorTurmaCommand request, CancellationToken cancellationToken)
        {
            var nomeChave = $"Atividade-Avaliativa-{request.CodigoTurma}";

            var atividadeAvaliativas = await repositorioNotasConceitos.ObterNotasPorAlunosAtividadesAvaliativasPorTurmaAsync(request.CodigoTurma);
            await repositorioCache.SalvarAsync(nomeChave, atividadeAvaliativas);

            return atividadeAvaliativas;
        }
    }
}