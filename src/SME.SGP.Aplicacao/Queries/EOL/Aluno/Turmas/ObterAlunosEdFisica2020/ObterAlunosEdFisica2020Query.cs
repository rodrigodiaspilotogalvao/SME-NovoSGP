﻿using MediatR;
using SME.SGP.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SGP.Aplicacao
{
    public class ObterAlunosEdFisica2020Query : IRequest<IEnumerable<FechamentoAlunoComponenteDTO>>
    {
    }
}
