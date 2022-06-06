﻿using System.Collections.Generic;

namespace SME.SGP.Infra
{
    public class ResponsavelEscolasDto : AuditoriaDto
    {
        public ResponsavelEscolasDto()
        {
            Escolas = new List<UnidadeEscolarDto>();
        }

        public List<UnidadeEscolarDto> Escolas { get; set; }
        public string ResponsavelId { get; set; }
        public string Responsavel { get; set; }
        public string TipoResponsavel { get; set; }
    }
}