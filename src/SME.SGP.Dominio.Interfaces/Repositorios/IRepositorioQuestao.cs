﻿using SME.SGP.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.SGP.Dominio.Interfaces
{
    public interface IRepositorioQuestao : IRepositorioBase<Questao>
    {
        Task<bool> VerificaObrigatoriedade(long questaoId);
    }
}
