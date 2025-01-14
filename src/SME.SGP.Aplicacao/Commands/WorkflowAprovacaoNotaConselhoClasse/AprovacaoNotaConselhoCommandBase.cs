﻿using MediatR;
using Microsoft.Extensions.Logging;
using SME.SGP.Dominio;
using SME.SGP.Infra;
using SME.SGP.Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SGP.Aplicacao
{
    public abstract class AprovacaoNotaConselhoCommandBase<T> : AsyncRequestHandler<T> where T : IRequest
    {
        protected readonly IMediator mediator;
        protected List<WFAprovacaoNotaConselho> WFAprovacoes;
        protected List<Ue> Ues;
        protected List<TurmasDoAlunoDto> Alunos;
        protected List<ComponenteCurricularDescricaoDto> ComponentesCurriculares;
        protected List<Usuario> Usuarios;
        protected List<Conceito> Conceitos;

        public AprovacaoNotaConselhoCommandBase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected abstract string ObterTexto(Ue ue, Turma turma, PeriodoEscolar periodoEscolar);

        protected abstract string ObterTitulo(Ue ue, Turma turma);

        protected async Task IniciarAprovacao(IEnumerable<WFAprovacaoNotaConselho> wfAprovacoes)
        {
            WFAprovacoes = wfAprovacoes.ToList();
            if (WFAprovacoes == null || !WFAprovacoes.Any()) return;

            await CarregarTodasUes();
            await CarregarTodosAlunos();
            await CarregarTodosComponentes();
            await CarregarTodosUsuarios();
            await CarregarConceitos();
        }

        protected async Task<string> ObterMensagem(Ue ue, Turma turma, List<WFAprovacaoNotaConselho> aprovacoesPorTurma)
        {
            var periodoEscolar = aprovacoesPorTurma.FirstOrDefault().ConselhoClasseNota.ConselhoClasseAluno.ConselhoClasse.FechamentoTurma.PeriodoEscolar;
            var descricao = new StringBuilder(ObterTexto(ue, turma, periodoEscolar));

            descricao.Append(await ObterTabelaDosAlunos(aprovacoesPorTurma, turma));

            return descricao.ToString();
        }

        private async Task<string> ObterTabelaDosAlunos(List<WFAprovacaoNotaConselho> aprovacoesPorTurma, Turma turma)
        {
            var descricao = new StringBuilder();
            descricao.AppendLine("<table style='margin-left: auto; margin-right: auto; margin-top: 10px' border='2' cellpadding='5'>");
            descricao.AppendLine("<tbody>");
            descricao.AppendLine("<tr>");
            descricao.AppendLine("<td style='padding: 3px;'><strong>Componente curricular</strong></td>");
            descricao.AppendLine("<td style='padding: 3px;'><strong>Estudante</strong></td>");
            descricao.AppendLine("<td style='padding: 3px;'><strong>Valor anterior</strong></td>");
            descricao.AppendLine("<td style='padding: 3px;'><strong>Novo valor</strong></td>");
            descricao.AppendLine("<td style='padding: 3px;'><strong>Usuário que alterou</strong></td>");
            descricao.AppendLine("<td style='padding: 3px;'><strong>Data da alteração</strong></td>");
            descricao.AppendLine("</tr>");

            var aprovacoesPorTurmaDto = aprovacoesPorTurma.Select(async aprovacao => await MapearParaDTO(aprovacao, turma))
                                                          .Select(_task => _task.Result)
                                                          .OrderBy(parecer => parecer.NomeAluno)
                                                          .ThenBy(parecer => parecer.DescricaoComponenteCurricular);

            foreach (var aprovacao in aprovacoesPorTurmaDto)
                descricao.AppendLine(ObterLinhaDoAluno(aprovacao, turma));

            descricao.AppendLine("<tbody>");
            descricao.AppendLine("</table>");

            return descricao.ToString();
        }

        private string ObterLinhaDoAluno(WFAprovacaoNotaPosConselhoAlunoComponenteTurmaDto aprovacao, Turma turma)
        {
            var notas = ObterValoresNotasNovoAnterior(aprovacao.ConceitoIdConselhoClasse, aprovacao.NotaConselhoClasse, aprovacao.ConceitoId, aprovacao.Nota);
            return $@"<tr>
                           <td style='padding: 3px;'>{aprovacao.DescricaoComponenteCurricular}</td>
                           <td style='padding: 3px;'>{aprovacao.NumeroAlunoChamada} - {aprovacao.NomeAluno} ({aprovacao.CodigoAluno})</td>
                           <td style='padding: 3px;'>{notas.Item1}</td>
                           <td style='padding: 3px;'>{notas.Item2}</td>
                           <td style='padding: 3px;'>{aprovacao.NomeUsuarioSolicitante} ({aprovacao.CodigoRfUsuarioSolicitante})</td>
                           <td style='padding: 3px;'>{aprovacao.CriadoEm.ToString("dd/MM/yyy HH:mm")}</td>
                      </tr>";
        }

        private (string, string) ObterValoresNotasNovoAnterior(long? conceitoIdConselhoClasse, double? notaConselhoClasse, long? conceitoId, double? nota)
        {
            var valorAnterior = string.Empty;
            var valorNovo = string.Empty;

            if (conceitoId.HasValue || conceitoIdConselhoClasse.HasValue)
            {
                if (conceitoIdConselhoClasse.HasValue)
                    valorAnterior = Conceitos.FirstOrDefault(a => a.Id == conceitoIdConselhoClasse)?.Valor;

                if (conceitoId.HasValue)
                    valorNovo = Conceitos.FirstOrDefault(a => a.Id == conceitoId)?.Valor;
            }
            else
            {
                valorAnterior = notaConselhoClasse?.ToString() ?? string.Empty;
                valorNovo = nota?.ToString() ?? string.Empty;
            }

            return (valorAnterior, valorNovo);
        }

        private async Task<(long?, double?)> ObterConceitoNotaFechamentoAluno(long fechamentoTurmaId, string codigoAluno, long componenteCurricularId)
        {

            var fechamentoNotas = await mediator.Send(new ObterPorFechamentoTurmaAlunoDisciplinaQuery(fechamentoTurmaId,
                                                                                                      codigoAluno,
                                                                                                      componenteCurricularId));
            if (fechamentoNotas != null && fechamentoNotas.Any())
            {
                var fechamentoNota = fechamentoNotas.FirstOrDefault();
                return (fechamentoNota.ConceitoId, fechamentoNota.Nota);
            }

            return (null,null);
        }

        private async Task<WFAprovacaoNotaPosConselhoAlunoComponenteTurmaDto> MapearParaDTO(WFAprovacaoNotaConselho aprovacao, Turma turma)
        {
            var aluno = Alunos.Find(aluno => aluno.CodigoAluno.ToString() == aprovacao.ConselhoClasseNota.ConselhoClasseAluno.AlunoCodigo && aluno.CodigoTurma.ToString() == turma.CodigoTurma);
            var componenteCurricular = ComponentesCurriculares.Find(componente => componente.Id == aprovacao.ConselhoClasseNota.ComponenteCurricularCodigo);
            var usuario = Usuarios.Find(usuario => usuario.Id == aprovacao.UsuarioSolicitanteId);

            var retorno = new WFAprovacaoNotaPosConselhoAlunoComponenteTurmaDto {
                CriadoEm = aprovacao.CriadoEm,
                UsuarioSolicitanteId = aprovacao.UsuarioSolicitanteId,
                NomeUsuarioSolicitante = usuario.Nome,
                CodigoRfUsuarioSolicitante = usuario.CodigoRf,
                CodigoAluno = aluno.CodigoAluno,
                NomeAluno = aluno.NomeAluno,
                NumeroAlunoChamada = aluno.NumeroAlunoChamada,
                CodigoTurma = turma.CodigoTurma,
                CodigoComponenteCurricular = aprovacao.ConselhoClasseNota.ComponenteCurricularCodigo,
                DescricaoComponenteCurricular = componenteCurricular.Descricao,
                Nota = aprovacao.Nota,
                ConceitoId = aprovacao.ConceitoId,
                NotaConselhoClasse = aprovacao.ConselhoClasseNota.Nota,
                ConceitoIdConselhoClasse = aprovacao.ConselhoClasseNota.ConceitoId
            };

            if (!retorno.NotaConselhoClasse.HasValue && !retorno.ConceitoIdConselhoClasse.HasValue)
            {
                var notaConceitoFechamento = await ObterConceitoNotaFechamentoAluno(aprovacao.ConselhoClasseNota.ConselhoClasseAluno.ConselhoClasse.FechamentoTurmaId,
                                                                                    aprovacao.ConselhoClasseNota.ConselhoClasseAluno.AlunoCodigo,
                                                                                    aprovacao.ConselhoClasseNota.ComponenteCurricularCodigo);
                retorno.ConceitoIdConselhoClasse = notaConceitoFechamento.Item1;
                retorno.NotaConselhoClasse = notaConceitoFechamento.Item2;
            }

            return retorno;
        }

        private async Task CarregarTodasUes()
        {
            var ueIds = WFAprovacoes.Select(wf => wf.ConselhoClasseNota.ConselhoClasseAluno.ConselhoClasse.FechamentoTurma.Turma.UeId).Distinct().ToArray();

            Ues = (await ObterUes(ueIds)).ToList();
        }

        private async Task CarregarTodosAlunos()
        {
            var codigos = WFAprovacoes.Select(wf => long.Parse(wf.ConselhoClasseNota.ConselhoClasseAluno.AlunoCodigo)).ToArray();
            var anoLetivo = WFAprovacoes.FirstOrDefault().ConselhoClasseNota.ConselhoClasseAluno.ConselhoClasse.FechamentoTurma.Turma.AnoLetivo;

            Alunos = (await ObterAlunos(codigos, anoLetivo)).ToList();
        }

        private async Task CarregarTodosComponentes()
        {
            var codigos = WFAprovacoes.Select(wf => wf.ConselhoClasseNota.ComponenteCurricularCodigo).Distinct().ToArray();

            ComponentesCurriculares = (await ObterComponentes(codigos)).ToList();
        }

        private async Task CarregarTodosUsuarios()
        {
            var ids = WFAprovacoes.Select(wf => wf.UsuarioSolicitanteId).Distinct().ToArray();

            Usuarios = (await ObterUsuarios(ids)).ToList();
        }

        private async Task CarregarConceitos()
        {
            Conceitos = (await mediator.Send(new ObterConceitosValoresQuery())).ToList();
        }

        private async Task<IEnumerable<Ue>> ObterUes(long[] ueIds)
            => await mediator.Send(new ObterUesPorIdsQuery(ueIds));

        private async Task<IEnumerable<ComponenteCurricularDescricaoDto>> ObterComponentes(long[] codigos)
            => await mediator.Send(new ObterDescricaoComponentesCurricularesPorIdsQuery(codigos));

        private async Task<IEnumerable<TurmasDoAlunoDto>> ObterAlunos(long[] codigos, int anoLetivo)
            => await mediator.Send(new ObterAlunosEolPorCodigosEAnoQuery(codigos, anoLetivo));

        private async Task<IEnumerable<Usuario>> ObterUsuarios(long[] ids)
            => await mediator.Send(new ObterUsuarioPorIdsSemPerfilQuery(ids));
    }
}
