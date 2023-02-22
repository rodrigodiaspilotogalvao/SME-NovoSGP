﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.SGP.Aplicacao;
using SME.SGP.Aplicacao.Interfaces;
using SME.SGP.Dominio;
using SME.SGP.Infra;
using SME.SGP.TesteIntegracao.PendenciaFechamento.ServicosFakes;
using SME.SGP.TesteIntegracao.Setup;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SGP.TesteIntegracao.PendenciaFechamento.Base
{
    public abstract class PendenciaFechamentoBase : TesteBaseComuns
    {
        protected long PENDENCIA_ID_1 = 1;
        protected long FECHAMENTO_TURMA_ID_1 = 1;
        protected long FECHAMENTO_TURMA_DISCIPLINA_ID_1 = 1;

        protected PendenciaFechamentoBase(CollectionFixture collectionFixture) : base(collectionFixture)
        {
        }

        protected override void RegistrarFakes(IServiceCollection services)
        {
            base.RegistrarFakes(services);

            services.Replace(new ServiceDescriptor(typeof(IRequestHandler<ObterProfessoresTitularesDasTurmasQuery, IEnumerable<string>>), typeof(ObterProfessoresTitularesDasTurmasQueryHandlerFake), ServiceLifetime.Scoped));
            services.Replace(new ServiceDescriptor(typeof(IRequestHandler<ProfessoresTurmaDisciplinaQuery, IEnumerable<ProfessorAtribuidoTurmaDisciplinaDTO>>), typeof(ProfessoresTurmaDisciplinaQueryHandlerFakeProfessorPortugues), ServiceLifetime.Scoped));
        }

        protected IGerarPendenciasFechamentoUseCase ObterUseCaseGerarPendencia()
        {
            return ServiceProvider.GetService<IGerarPendenciasFechamentoUseCase>();
        }

        protected async Task CriarDadosBasicos(FiltroPendenciaFechamentoDto filtro)
        {
            await CriarTipoCalendario(filtro.TipoCalendario);

            await CriarDreUePerfilComponenteCurricular();

            await CriarPeriodoEscolar();

            await CriarPeriodoAbertura();

            CriarClaimUsuario(ObterPerfilProfessor());

            await CriarUsuarios();

            await CriarTurma(filtro.Modalidade);

            await CriarAula(DateTimeExtension.HorarioBrasilia().AddDays(-1), RecorrenciaAula.AulaUnica, TipoAula.Normal, USUARIO_PROFESSOR_CODIGO_RF_2222222, TURMA_CODIGO_1, UE_CODIGO_1, filtro.ComponenteCurricularCodigo, TIPO_CALENDARIO_1);

            await CriaFechamento(filtro.ComponenteCurricularCodigo);

            await CriarParametrosSistema();
        }

        private async Task CriarPeriodoEscolar()
        {
            var dataReferencia = DateTimeExtension.HorarioBrasilia();

            await CriarPeriodoEscolar(dataReferencia.AddDays(-20), DateTimeExtension.HorarioBrasilia(), BIMESTRE_2, TIPO_CALENDARIO_1);
        }

        private async Task CriarPeriodoAbertura()
        {
            var dataReferencia = DateTimeExtension.HorarioBrasilia();

            await InserirNaBase(new PeriodoFechamento()
            { CriadoEm = DateTime.Now, CriadoPor = SISTEMA_NOME, CriadoRF = SISTEMA_CODIGO_RF });

            await InserirNaBase(new PeriodoFechamentoBimestre()
            {
                PeriodoEscolarId = PERIODO_ESCOLAR_CODIGO_1,
                PeriodoFechamentoId = 1,
                InicioDoFechamento = dataReferencia,
                FinalDoFechamento = dataReferencia.AddDays(4)
            });
        }

        protected async Task CriaPendenciaPorTipo(TipoPendencia tipoPendencia)
        {
            await InserirNaBase(new Pendencia()
            {
                Tipo = tipoPendencia,
                Situacao = SituacaoPendencia.Pendente,
                Descricao = "pendência",
                Titulo = "pendência",
                CriadoPor = "",
                CriadoRF = "",
                CriadoEm = new DateTime(DateTimeExtension.HorarioBrasilia().Year, 03, 01)
            });
        }

        protected async Task CriarPendenciaAula(long aulaId, long pendenciaId)
        {
            await InserirNaBase(new Dominio.PendenciaAula()
            {
                AulaId = aulaId,
                PendenciaId = pendenciaId
            });
        }

        protected async Task CriaFechamento(string componenteCurricular)
        {
            await CriarFechamentoTurma(PERIODO_ESCOLAR_CODIGO_1);

            await CriarFechamentoTurmaDisciplina(long.Parse(componenteCurricular), FECHAMENTO_TURMA_ID_1);

            await CriarFechamentoTurmaAluno(FECHAMENTO_TURMA_DISCIPLINA_ID_1);
        }

        private async Task CriarFechamentoTurmaAluno(long fechamentoTurmaDisciplinaId)
        {
            await InserirNaBase(new FechamentoAluno()
            {
                FechamentoTurmaDisciplinaId = fechamentoTurmaDisciplinaId,
                AlunoCodigo = CODIGO_ALUNO_1,
                CriadoEm = DateTime.Now,
                CriadoPor = SISTEMA_NOME,
                CriadoRF = SISTEMA_CODIGO_RF
            });
        }

        protected async Task CriarFechamentoTurmaDisciplina(long componenteCurricular, long fechamentoTurmaId)
        {
            await InserirNaBase(new FechamentoTurmaDisciplina()
            {
                DisciplinaId = componenteCurricular,
                FechamentoTurmaId = fechamentoTurmaId,
                CriadoEm = DateTime.Now,
                CriadoPor = SISTEMA_NOME,
                CriadoRF = SISTEMA_CODIGO_RF
            });
        }

        private async Task CriarFechamentoTurma(long? periodoEscolarId)
        {
            await InserirNaBase(new FechamentoTurma()
            {
                PeriodoEscolarId = periodoEscolarId == 0 ? null : periodoEscolarId,
                TurmaId = TURMA_ID_1,
                Excluido = false,
                CriadoEm = DateTime.Now,
                CriadoPor = SISTEMA_NOME,
                CriadoRF = SISTEMA_CODIGO_RF
            });
        }

        private async Task CriarParametrosSistema()
        {
            await InserirNaBase(new ParametrosSistema
            {
                Nome = "PercentualAlunosInsuficientes",
                Tipo = TipoParametroSistema.PercentualAlunosInsuficientes,
                Descricao = "Percentual de alunos com nota/conceito insuficientes para exigência de justificativa",
                Valor = "50",
                Ano = DateTimeExtension.HorarioBrasilia().Year,
                CriadoEm = DateTimeExtension.HorarioBrasilia(),
                CriadoPor = SISTEMA_NOME,
                CriadoRF = SISTEMA_CODIGO_RF,
                Ativo = true
            });
        }

        protected class FiltroPendenciaFechamentoDto
        {
            public Modalidade Modalidade { get; set; }
            public ModalidadeTipoCalendario TipoCalendario { get; set; } 
            public string ComponenteCurricularCodigo { get; set; }
        }
    }


}