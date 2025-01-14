﻿using Dapper;
using SME.SGP.Dominio;
using SME.SGP.Dominio.Interfaces;
using SME.SGP.Infra;
using SME.SGP.Infra.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SGP.Dados.Repositorios
{
    public class RepositorioComunicadoAluno : RepositorioBase<ComunicadoAluno>, IRepositorioComunicadoAluno
    {
        public RepositorioComunicadoAluno(ISgpContext context, IServicoAuditoria servicoAuditoria) : base(context, servicoAuditoria)
        {

        }

        public async Task<IEnumerable<ComunicadoAluno>> ObterPorComunicado(long comunicadoId)
        {
            var where = "where comunicado_id = @comunicadoId";

            return await database.Conexao.QueryAsync<ComunicadoAluno>($"{Cabecalho} {where}", new { comunicadoId });
        }

        public async Task<bool> RemoverTodosAlunosComunicado(long comunicadoId)
        {
            var update = "update comunicado_aluno set excluido=true where comunicado_id = @comunicadoId";

            return await database.Conexao.ExecuteAsync(update, new { comunicadoId }) != 0;
        }

        public override void Remover(ComunicadoAluno entidade)
        {
            throw new NegocioException("Não é possivel remover aluno do comunicado");
        }

        public override void Remover(long id)
        {
            throw new NegocioException("Não é possivel remover aluno do comunicado");
        }

        private string Cabecalho => @"
                select 
                    id, 
                    aluno_codigo, 
                    comunicado_id, 
                    criado_em, 
                    alterado_em, 
                    excluido,
                    criado_por, 
                    alterado_por, 
                    criado_rf, 
                    alterado_rf 
                from 
                    comunicado_aluno";
    }
}
