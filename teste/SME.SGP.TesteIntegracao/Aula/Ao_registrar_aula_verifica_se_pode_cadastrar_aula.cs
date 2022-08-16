﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shouldly;
using SME.SGP.Aplicacao;
using SME.SGP.Dominio;
using SME.SGP.TesteIntegracao.ServicosFakes;
using SME.SGP.TesteIntegracao.Setup;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SME.SGP.TesteIntegracao.PodeCadastrarAula
{
    public class Ao_registrar_aula_verifica_se_pode_cadastrar_aula : AulaTeste
    {
        private const long TIPO_CALENDARIO_999999 = 999999;

        private readonly DateTime DATA_19_06 = new(DateTimeExtension.HorarioBrasilia().Year, 06, 19);        

        public Ao_registrar_aula_verifica_se_pode_cadastrar_aula(CollectionFixture collectionFixture) : base(collectionFixture)
        { }

        protected override void RegistrarFakes(IServiceCollection services)
        {
            base.RegistrarFakes(services);

            services.Replace(new ServiceDescriptor(typeof(IRequestHandler<ObterUsuarioPossuiPermissaoNaTurmaEDisciplinaQuery, bool>), typeof(ObterUsuarioPossuiPermissaoNaTurmaEDisciplinaQueryHandlerComPermissaoFake), ServiceLifetime.Scoped));
        }

        [Fact]
        public async Task Nao_pode_cadastrar_aula_normal_sem_periodo_escolar()
        {
            var mensagemEsperada = "Ocorreu um erro ao solicitar a criação de aulas recorrentes, por favor tente novamente. Detalhes: Não foi possível obter os períodos deste tipo de calendário.";

            await CriarDadosBasicosAula(ObterPerfilProfessor(), Modalidade.Fundamental, ModalidadeTipoCalendario.FundamentalMedio, DATA_02_05, DATA_08_07, BIMESTRE_2, false);

            await CriarPeriodoEscolarEAbertura();

            var excecao = await InserirAulaUseCaseSemValidacaoBasica(TipoAula.Normal, RecorrenciaAula.RepetirBimestreAtual, COMPONENTE_CURRICULAR_PORTUGUES_ID_138, DATA_02_05, false, TIPO_CALENDARIO_999999);

            excecao.ExistemErros.ShouldBeTrue();

            excecao.Mensagens.FirstOrDefault().ShouldNotBeNullOrEmpty();

            excecao.Mensagens.FirstOrDefault().ShouldBeEquivalentTo(mensagemEsperada);
        }

        [Fact]
        public async Task Nao_pode_cadastrar_aula_normal_quando_existe_aula_normal()
        {
            var mensagemEsperada = "Não é possível cadastrar aula do tipo 'Normal' para o dia selecionado!";

            await CriarDadosBasicosAula(ObterPerfilProfessor(), Modalidade.Fundamental, ModalidadeTipoCalendario.FundamentalMedio, DATA_02_05, DATA_08_07, BIMESTRE_1, false);

            await InserirNaBase(new Dominio.Aula() 
            {
                AulaCJ = false,
                UeId = UE_CODIGO_1,
                DisciplinaId = COMPONENTE_CURRICULAR_PORTUGUES_ID_138.ToString(),
                TurmaId = TURMA_CODIGO_1,
                TipoCalendarioId = 1,
                ProfessorRf = USUARIO_PROFESSOR_LOGIN_2222222,
                Quantidade = 1,
                DataAula = DATA_02_05,
                RecorrenciaAula = RecorrenciaAula.AulaUnica,
                TipoAula = TipoAula.Normal,
                CriadoEm = DateTime.Now,
                CriadoPor = SISTEMA_NOME,
                CriadoRF = SISTEMA_CODIGO_RF,
                Status = EntidadeStatus.Aprovado
            });

            await CriarPeriodoEscolarEAbertura();

            var excecao = await Assert.ThrowsAsync<NegocioException>(() => InserirAulaUseCaseSemValidacaoBasica(TipoAula.Normal, RecorrenciaAula.RepetirBimestreAtual, COMPONENTE_CURRICULAR_PORTUGUES_ID_138, DATA_02_05, false, TIPO_CALENDARIO_999999));

            excecao.Message.ShouldNotBeNullOrEmpty();

            excecao.Message.ShouldBeEquivalentTo(mensagemEsperada);
        }

        [Fact]
        public async Task Nao_pode_cadastrar_aula_reposicao_quando_existe_aula_reposicao()
        {
            var mensagemEsperada = "Não é possível cadastrar aula de reposição com recorrência!";

            await CriarDadosBasicosAula(ObterPerfilProfessor(), Modalidade.Fundamental, ModalidadeTipoCalendario.FundamentalMedio, DATA_02_05, DATA_08_07, BIMESTRE_1, false);

            await InserirNaBase(new Dominio.Aula()
            {
                AulaCJ = false,
                UeId = UE_CODIGO_1,
                DisciplinaId = COMPONENTE_CURRICULAR_PORTUGUES_ID_138.ToString(),
                TurmaId = TURMA_CODIGO_1,
                TipoCalendarioId = 1,
                ProfessorRf = USUARIO_PROFESSOR_LOGIN_2222222,
                Quantidade = 1,
                DataAula = DATA_02_05,
                RecorrenciaAula = RecorrenciaAula.AulaUnica,
                TipoAula = TipoAula.Reposicao,
                CriadoEm = DateTime.Now,
                CriadoPor = SISTEMA_NOME,
                CriadoRF = SISTEMA_CODIGO_RF,
                Status = EntidadeStatus.Aprovado
            });

            await CriarPeriodoEscolarEAbertura();

            var excecao = await Assert.ThrowsAsync<NegocioException>(() => InserirAulaUseCaseSemValidacaoBasica(TipoAula.Reposicao, RecorrenciaAula.RepetirBimestreAtual, COMPONENTE_CURRICULAR_PORTUGUES_ID_138, DATA_02_05, false, TIPO_CALENDARIO_999999));

            excecao.Message.ShouldNotBeNullOrEmpty();

            excecao.Message.ShouldBeEquivalentTo(mensagemEsperada);
        }

        [Fact]
        public async Task Nao_pode_cadastrar_aula_normal_quando_nao_encontra_tipo_calendario()
        {
            var mensagemEsperada = "Não é possível cadastrar aula do tipo 'Normal' para o dia selecionado!";

            await CriarDadosBasicosAula(ObterPerfilProfessor(), Modalidade.Fundamental, ModalidadeTipoCalendario.FundamentalMedio, DATA_02_05, DATA_08_07, BIMESTRE_2, false);

            var excecao = await Assert.ThrowsAsync<NegocioException>(() => InserirAulaUseCaseSemValidacaoBasica(TipoAula.Normal,
                                                                     RecorrenciaAula.RepetirBimestreAtual,
                                                                     COMPONENTE_CURRICULAR_PORTUGUES_ID_138,
                                                                     DATA_03_10,
                                                                     TIPO_CALENDARIO_1,
                                                                     TURMA_CODIGO_1,
                                                                     UE_CODIGO_1));

            excecao.Message.ShouldNotBeNullOrEmpty();

            excecao.Message.ShouldBeEquivalentTo(mensagemEsperada);
        }

        [Fact]
        public async Task Nao_pode_cadastrar_aula_reposicao_quando_nao_encontra_tipo_calendario()
        {
            var mensagemEsperada = "Não é possível cadastrar aula de reposição com recorrência!";

            await CriarDadosBasicosAula(ObterPerfilProfessor(), Modalidade.Fundamental, ModalidadeTipoCalendario.FundamentalMedio, DATA_02_05, DATA_08_07, BIMESTRE_1, false);

            await CriarPeriodoEscolarEAbertura();

            var excecao = await Assert.ThrowsAsync<NegocioException>(() => InserirAulaUseCaseSemValidacaoBasica(TipoAula.Reposicao,
                                                                     RecorrenciaAula.RepetirBimestreAtual,
                                                                     COMPONENTE_CURRICULAR_PORTUGUES_ID_138,
                                                                     DATA_03_10,
                                                                     TIPO_CALENDARIO_1,
                                                                     TURMA_CODIGO_1,
                                                                     UE_CODIGO_1));

            excecao.Message.ShouldNotBeNullOrEmpty();

            excecao.Message.ShouldBeEquivalentTo(mensagemEsperada);
        }

        [Fact]
        public async Task Nao_pode_cadastrar_aula_normal_quando_nao_tem_evento_letivo_dia()
        {
            var mensagemEsperada = "Não é possível cadastrar aula do tipo 'Normal' para o dia selecionado!";

            await CriarDadosBasicosAula(ObterPerfilProfessor(), Modalidade.Fundamental, ModalidadeTipoCalendario.FundamentalMedio, DATA_02_05, DATA_08_07, BIMESTRE_1, false);

            await CriarEventoTipoResumido(SUSPENSAO_DE_ATIVIDADES, 
                                          EventoLocalOcorrencia.SMEUE,
                                          false,
                                          EventoTipoData.Unico,
                                          false,
                                          EventoLetivo.Nao,
                                          TIPO_EVENTO_21);

            await CriarEventoResumido(EVENTO_NAO_LETIVO,
                                      DATA_19_06,
                                      DATA_19_06,
                                      EventoLetivo.Nao,
                                      TIPO_CALENDARIO_1,
                                      TIPO_EVENTO_1,
                                      DRE_CODIGO_1,
                                      UE_CODIGO_1,
                                      EntidadeStatus.Aprovado);

            await CriarPeriodoEscolarEAbertura();

            var excecao = await Assert.ThrowsAsync<NegocioException>(() => InserirAulaUseCaseSemValidacaoBasica(TipoAula.Normal,
                                                                     RecorrenciaAula.RepetirBimestreAtual,
                                                                     COMPONENTE_CURRICULAR_PORTUGUES_ID_138,
                                                                     DATA_19_06,
                                                                     TIPO_CALENDARIO_1,
                                                                     TURMA_CODIGO_1,
                                                                     UE_CODIGO_1));

            excecao.Message.ShouldNotBeNullOrEmpty();

            excecao.Message.ShouldBeEquivalentTo(mensagemEsperada);
        }

        [Fact]
        public async Task Nao_pode_cadastrar_aula_reposicao_quando_nao_tem_evento_letivo_dia()
        {
            var mensagemEsperada = "Não é possível cadastrar aula de reposição com recorrência!";

            await CriarDadosBasicosAula(ObterPerfilProfessor(), Modalidade.Fundamental, ModalidadeTipoCalendario.FundamentalMedio, DATA_02_05, DATA_08_07, BIMESTRE_1, false);

            await CriarEventoTipoResumido(SUSPENSAO_DE_ATIVIDADES,
                                          EventoLocalOcorrencia.SMEUE,
                                          false,
                                          EventoTipoData.Unico,
                                          false,
                                          EventoLetivo.Nao,
                                          TIPO_EVENTO_21);

            await CriarEventoResumido(EVENTO_NAO_LETIVO,
                                      DATA_19_06,
                                      DATA_19_06,
                                      EventoLetivo.Nao,
                                      TIPO_CALENDARIO_1,
                                      TIPO_EVENTO_1,
                                      DRE_CODIGO_1,
                                      UE_CODIGO_1,
                                      EntidadeStatus.Aprovado);

            await CriarPeriodoEscolarEAbertura();

            var excecao = await Assert.ThrowsAsync<NegocioException>(() => InserirAulaUseCaseSemValidacaoBasica(TipoAula.Reposicao,
                                                                     RecorrenciaAula.RepetirBimestreAtual,
                                                                     COMPONENTE_CURRICULAR_PORTUGUES_ID_138,
                                                                     DATA_19_06,
                                                                     TIPO_CALENDARIO_1,
                                                                     TURMA_CODIGO_1,
                                                                     UE_CODIGO_1));

            excecao.Message.ShouldNotBeNullOrEmpty();

            excecao.Message.ShouldBeEquivalentTo(mensagemEsperada);
        }

        [Fact]
        public async Task Pode_cadastrar_aula_reposicao_quando_nao_tem_evento_letivo_dia_mas_tem_evento_reposicao_aula()
        {
            await CriarDadosBasicosAula(ObterPerfilProfessor(), Modalidade.Fundamental, ModalidadeTipoCalendario.FundamentalMedio, DATA_02_05, DATA_08_07, BIMESTRE_1, false);

            await CriarEventoTipoResumido(SUSPENSAO_DE_ATIVIDADES,
                                          EventoLocalOcorrencia.SMEUE,
                                          false,
                                          EventoTipoData.Unico,
                                          false,
                                          EventoLetivo.Nao,
                                          TIPO_EVENTO_21);

            await CriarEventoResumido(EVENTO_NAO_LETIVO,
                                      DATA_19_06,
                                      DATA_19_06,
                                      EventoLetivo.Nao,
                                      TIPO_CALENDARIO_1,
                                      TIPO_EVENTO_1,
                                      DRE_CODIGO_1,
                                      UE_CODIGO_1,
                                      EntidadeStatus.Aprovado);

            await CriarEventoTipoResumido(REPOSICAO_AULA,
                                          EventoLocalOcorrencia.UE,
                                          true,
                                          EventoTipoData.Unico,
                                          false,
                                          EventoLetivo.Nao,
                                          TIPO_EVENTO_13);

            await CriarEventoResumido(EVENTO_NAO_LETIVO,
                                      DATA_19_06,
                                      DATA_19_06,
                                      EventoLetivo.Nao,
                                      TIPO_CALENDARIO_1,
                                      TIPO_EVENTO_2,
                                      DRE_CODIGO_1,
                                      UE_CODIGO_1,
                                      EntidadeStatus.Aprovado);

            await CriarPeriodoEscolarEAbertura();

            var retorno = await PodeCadastrarAulaUseCase(TipoAula.Reposicao, TURMA_CODIGO_1, COMPONENTE_CURRICULAR_PORTUGUES_ID_138, DATA_19_06);

            retorno.PodeCadastrarAula.ShouldBeTrue();
        }

        [Fact]
        public async Task Pode_cadastrar_aula_reposicao_quando_nao_tem_evento_letivo_dia_mas_tem_evento_reposicao_dia()
        {
            await CriarDadosBasicosAula(ObterPerfilProfessor(), Modalidade.Fundamental, ModalidadeTipoCalendario.FundamentalMedio, DATA_02_05, DATA_08_07, BIMESTRE_1, false);

            await CriarEventoTipoResumido(SUSPENSAO_DE_ATIVIDADES,
                                          EventoLocalOcorrencia.SMEUE,
                                          false,
                                          EventoTipoData.Unico,
                                          false,
                                          EventoLetivo.Nao,
                                          TIPO_EVENTO_21);

            await CriarEventoResumido(EVENTO_NAO_LETIVO,
                                      DATA_19_06,
                                      DATA_19_06,
                                      EventoLetivo.Nao,
                                      TIPO_CALENDARIO_1,
                                      TIPO_EVENTO_1,
                                      DRE_CODIGO_1,
                                      UE_CODIGO_1,
                                      EntidadeStatus.Aprovado);

            await CriarEventoTipoResumido(REPOSICAO_DIA,
                                          EventoLocalOcorrencia.UE,
                                          true,
                                          EventoTipoData.Unico,
                                          false,
                                          EventoLetivo.Sim,
                                          TIPO_EVENTO_14);

            await CriarEventoResumido(EVENTO_NAO_LETIVO,
                                      DATA_19_06,
                                      DATA_19_06,
                                      EventoLetivo.Sim,
                                      TIPO_CALENDARIO_1,
                                      TIPO_EVENTO_2,
                                      DRE_CODIGO_1,
                                      UE_CODIGO_1,
                                      EntidadeStatus.Aprovado);

            await CriarPeriodoEscolarEAbertura();

            var retorno = await PodeCadastrarAulaUseCase(TipoAula.Reposicao, TURMA_CODIGO_1, COMPONENTE_CURRICULAR_PORTUGUES_ID_138, DATA_19_06);

            retorno.PodeCadastrarAula.ShouldBeTrue();
        }

        private async Task CriarPeriodoEscolarEAbertura()
        {
            await CriarPeriodoEscolar(DATA_03_01_INICIO_BIMESTRE_1, DATA_29_04_FIM_BIMESTRE_1, BIMESTRE_1);

            await CriarPeriodoEscolar(DATA_02_05_INICIO_BIMESTRE_2, DATA_08_07_FIM_BIMESTRE_2, BIMESTRE_2);

            await CriarPeriodoEscolar(DATA_25_07_INICIO_BIMESTRE_3, DATA_30_09_FIM_BIMESTRE_3, BIMESTRE_3);

            await CriarPeriodoEscolar(DATA_03_10_INICIO_BIMESTRE_4, DATA_22_12_FIM_BIMESTRE_4, BIMESTRE_4);

            await CriarPeriodoReabertura(TIPO_CALENDARIO_1);
        }
    }
}