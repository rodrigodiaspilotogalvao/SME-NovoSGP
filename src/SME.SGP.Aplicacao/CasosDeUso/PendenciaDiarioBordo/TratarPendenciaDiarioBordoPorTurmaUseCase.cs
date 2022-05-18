﻿using MediatR;
using SME.SGP.Dominio;
using SME.SGP.Dominio.Enumerados;
using SME.SGP.Infra;
using SME.SGP.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SGP.Aplicacao
{
    public class TratarPendenciaDiarioBordoPorTurmaUseCase : AbstractUseCase, ITratarPendenciaDiarioBordoPorTurmaUseCase
    {
        public TratarPendenciaDiarioBordoPorTurmaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit param)
        {
            var turmaId = param.ObterObjetoMensagem<string>();

            var turmasDreUe = await mediator.Send(new ObterTurmasDreUePorCodigosQuery(new string[] { turmaId }));

            var professoresEComponentes = new List<ProfessorEComponenteInfantilDto>();
            Guid perfilProfessorInfantil = Guid.Parse(PerfilUsuario.PROFESSOR_INFANTIL.ObterNome());

            var professoresDaTurma = await mediator.Send(new ObterProfessoresTitularesDaTurmaQuery(turmaId));

            var componentesSgp = await mediator.Send(new ObterComponentesCurricularesQuery());

            if (professoresDaTurma != null)
            {
                string[] professoresSeparados = professoresDaTurma.FirstOrDefault().Split(',');

                var componentesDaTurma = new List<long>();

                foreach (var professor in professoresSeparados)
                {
                    var codigoRfProfessor = professor.Trim();
                    if (!string.IsNullOrEmpty(codigoRfProfessor))
                    {
                        var componentesCurricularesEolProfessor = await mediator.Send(new ObterComponentesCurricularesDoProfessorNaTurmaQuery(turmaId, codigoRfProfessor, perfilProfessorInfantil));

                        professoresEComponentes.AddRange(componentesCurricularesEolProfessor.Select(s => new ProfessorEComponenteInfantilDto()
                        {
                            CodigoRf = codigoRfProfessor,
                            DisciplinaId = s.Codigo,
                            DescricaoComponenteCurricular = componentesSgp.FirstOrDefault(f=> f.Codigo.Equals(s.Codigo.ToString())).Descricao,
                        }));
                    }
                }
                await BuscaPendenciaESalva(turmasDreUe.FirstOrDefault(), professoresEComponentes);
            }

            return true;
        }

        public async Task BuscaPendenciaESalva(Turma turmaComDreUe, List<ProfessorEComponenteInfantilDto> professoresEComponentes)
        {
            try
            {
                var aulas = await mediator.Send(new ObterPendenciasDiarioBordoQuery(turmaComDreUe.CodigoTurma, professoresEComponentes.Select(d => d.DisciplinaId).ToArray()));

                var professoresParaGerarPendencia = new List<ProfessorEComponenteInfantilDto>();

                var pendenciasComponentes = await CadastraPendenciaGeral(turmaComDreUe, professoresEComponentes);

                foreach (var aula in aulas)
                {
                    if (aula.ComponenteId > 0)
                    {
                        professoresParaGerarPendencia = professoresEComponentes.Where(w => w.DisciplinaId != aula.ComponenteId).ToList();

                        var componentesComAula = aulas.Where(w => w.Id == aula.Id).Select(s => s.ComponenteId).ToList();

                        professoresParaGerarPendencia = professoresParaGerarPendencia.Where(w => !componentesComAula.Contains(w.DisciplinaId)).ToList();
                    }
                    else
                        professoresParaGerarPendencia = professoresEComponentes;

                    if (professoresParaGerarPendencia.Any())
                    {
                        var filtroPendenciaDiarioBordoTurmaAula = new FiltroPendenciaDiarioBordoTurmaAulaDto()
                        {
                            ProfessoresComponentes = professoresParaGerarPendencia,
                            Aula = aula,
                            CodigoTurma = turmaComDreUe.CodigoTurma,
                            PendenciasIds = pendenciasComponentes
                        };

                        await mediator.Send(new PublicarFilaSgpCommand(RotasRabbitSgp.RotaExecutaPendenciasAulaDiarioBordoTurmaAulaComponente, filtroPendenciaDiarioBordoTurmaAula));
                    }
                }
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand("Gerar pendências de diário de bordo por turma", LogNivel.Critico, LogContexto.Pendencia, ex.Message));
            }
        }

        private async Task<List<PendenciaComponenteCurricularDto>> CadastraPendenciaGeral(Turma turmaComDreUe, List<ProfessorEComponenteInfantilDto> professoresEComponentes)
        {
            var lstPendenciaComponente = new List<PendenciaComponenteCurricularDto>();

            foreach (var item in professoresEComponentes)
            {
                var turmaComModalidade = turmaComDreUe.NomeComModalidade();
                
                var nomeEscola = turmaComDreUe.ObterEscola();

                var descricao = PendenciaConstants.ObterDescricaoPendenciaDiarioBordo(item.DescricaoComponenteCurricular, turmaComModalidade, nomeEscola);
                
                var pendenciaIdExistente = await mediator.Send(new ObterPendenciaPorDescricaoTipoQuery(descricao, TipoPendencia.DiarioBordo));

                if (pendenciaIdExistente == 0)
                    pendenciaIdExistente = await mediator.Send(MapearPendencia(TipoPendencia.DiarioBordo, item.DescricaoComponenteCurricular, turmaComModalidade, nomeEscola));

                lstPendenciaComponente.Add(new PendenciaComponenteCurricularDto() { PendenciaId = pendenciaIdExistente, ComponenteCurricularId = item.DisciplinaId });
            }

            return lstPendenciaComponente;
        }

        

        private SalvarPendenciaCommand MapearPendencia(TipoPendencia tipoPendencia, string descricaoComponenteCurricular, string turmaAnoComModalidade, string descricaoUeDre)
        {
            return new SalvarPendenciaCommand
            {
                TipoPendencia = tipoPendencia,
                DescricaoComponenteCurricular = descricaoComponenteCurricular,
                TurmaAnoComModalidade = turmaAnoComModalidade,
                DescricaoUeDre = descricaoUeDre,
            };
        }

        
    }
}