﻿using SME.SGP.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SGP.Dominio.Interfaces
{
    public interface IRepositorioConselhoClasseAluno : IRepositorioBase<ConselhoClasseAluno>
    {
        Task<IEnumerable<NotaConceitoFechamentoConselhoFinalDto>> ObterNotasFinaisAlunoAsync(string[] turmasCodigos, string alunoCodigo);
    }
}