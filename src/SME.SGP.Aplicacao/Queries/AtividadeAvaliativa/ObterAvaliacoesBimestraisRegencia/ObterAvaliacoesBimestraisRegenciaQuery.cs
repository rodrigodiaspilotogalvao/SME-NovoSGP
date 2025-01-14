﻿using FluentValidation;
using MediatR;
using SME.SGP.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.SGP.Aplicacao
{
    public class ObterAvaliacoesBimestraisRegenciaQuery : IRequest<IEnumerable<AtividadeAvaliativaRegencia>>
    {
        public long TipoCalendarioId { get; set; }
        public string TurmaId { get; set; }
        public string DisciplinaId { get; set; }
        public int Bimestre { get; set; }

        public ObterAvaliacoesBimestraisRegenciaQuery(long tipoCalendarioId, string turmaId, string disciplinaId, int bimestre)
        {
            TipoCalendarioId = tipoCalendarioId;
            TurmaId = turmaId;
            DisciplinaId = disciplinaId;
            Bimestre = bimestre;
        }
    }

    public class ObterAvaliacoesBimestraisRegenciaQueryValidator : AbstractValidator<ObterAvaliacoesBimestraisRegenciaQuery>
    {
        public ObterAvaliacoesBimestraisRegenciaQueryValidator()
        {
            RuleFor(a => a.TipoCalendarioId)
                .NotEmpty().WithMessage("É necessário informar o id do tipo de calendário para obter as avaliações bimestrais de regência");
            RuleFor(a => a.TurmaId)
                .NotEmpty().WithMessage("É necessário informar o id da turma para obter as avaliações bimestrais de regência");
            RuleFor(a => a.DisciplinaId)
                .NotEmpty().WithMessage("É necessário informar o id da disciplina para obter as avaliações bimestrais de regência");
            RuleFor(a => a.Bimestre)
                .NotEmpty().WithMessage("É necessário informar o bimestre para obter as avaliações bimestrais de regência");
        }
    }
}
