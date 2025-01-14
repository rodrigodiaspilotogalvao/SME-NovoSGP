﻿
using System.Collections.Generic;

namespace SME.SGP.Infra
{
    public class NotasConceitosAlunoRetornoDto
    {
        public NotasConceitosAlunoRetornoDto()
        {
            NotasAvaliacoes = new List<NotasConceitosNotaAvaliacaoRetornoDto>();
            NotasBimestre = new List<FechamentoNotaRetornoDto>();
        }

        public string Id { get; set; }
        public MarcadorFrequenciaDto Marcador { get; set; }
        public bool PodeEditar { get; set; }
        public string Nome { get; set; }
        public List<NotasConceitosNotaAvaliacaoRetornoDto> NotasAvaliacoes { get; set; }
        public List<FechamentoNotaRetornoDto> NotasBimestre { get; }
        public int NumeroChamada { get; set; }
        public string PercentualFrequencia { get; set; }
        public bool EhAtendidoAEE { get; set; }
    }
}