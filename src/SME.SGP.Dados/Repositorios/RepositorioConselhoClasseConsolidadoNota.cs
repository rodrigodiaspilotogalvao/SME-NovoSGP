﻿using Dapper;
using SME.SGP.Dominio;
using SME.SGP.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SGP.Dados
{
    public class RepositorioConselhoClasseConsolidadoNota : IRepositorioConselhoClasseConsolidadoNota
    {
        protected readonly ISgpContext database;

        public RepositorioConselhoClasseConsolidadoNota(ISgpContext database)
        {
            this.database = database;
        }

        public Task<ConselhoClasseConsolidadoTurmaAlunoNota> ObterConselhoClasseConsolidadoPorTurmaBimestreAlunoNotaAsync(long consolidadoTurmaAlunoId, int? bimestre, long? componenteCurricularId)
        {
            var query = $@" select id,consolidado_conselho_classe_aluno_turma_id,bimestre,nota,conceito_id,componente_curricular_id    
                            from consolidado_conselho_classe_aluno_turma_nota
                            where consolidado_conselho_classe_aluno_turma_id = @consolidadoTurmaAlunoId ";

            query += (bimestre.HasValue && bimestre.Value > 0) ? " and bimestre = @bimestre " : " and bimestre is null ";

            if (componenteCurricularId.HasValue)
                query += " and componente_curricular_id = @componenteCurricularId";

            return database.Conexao.QueryFirstOrDefaultAsync<ConselhoClasseConsolidadoTurmaAlunoNota>(query, new { consolidadoTurmaAlunoId, bimestre, componenteCurricularId });
        }

        public Task<ConselhoClasseConsolidadoTurmaAlunoNota> ObterConselhoClasseConsolidadoAlunoNotaPorConsolidadoBimestreDisciplinaAsync(long consolidacaoId, int bimestre, long disciplinaId)
        {
            var query = $@" select id,consolidado_conselho_classe_aluno_turma_id,bimestre,nota,conceito_id,componente_curricular_id    
                            from consolidado_conselho_classe_aluno_turma_nota
                            where consolidado_conselho_classe_aluno_turma_id = @consolidacaoId 
                                  {(bimestre == 0 ? " and bimestre is null " : " and bimestre = @bimestre")} 
                                  and componente_curricular_id = @disciplinaId";

            return database.Conexao.QueryFirstOrDefaultAsync<ConselhoClasseConsolidadoTurmaAlunoNota>(query, new { consolidacaoId, bimestre, disciplinaId });
        }

        public async Task<long> SalvarAsync(ConselhoClasseConsolidadoTurmaAlunoNota consolidadoNota)
        {
            try
            {
                if (consolidadoNota.Id > 0)
                {
                    var sucesso = await database.Conexao.UpdateAsync(consolidadoNota);
                    return sucesso ? consolidadoNota.Id : 0;
                }
                else
                    return (long)(await database.Conexao.InsertAsync(consolidadoNota));
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirConsolidacaoConselhoClasseNotaPorIdsConsolidacaoAlunoEBimestre(long[] idsConsolidacao)
        {
            var query = $@"delete from consolidado_conselho_classe_aluno_turma_nota where id = ANY(@idsConsolidacao)";

            return await database.Conexao.ExecuteScalarAsync<bool>(query, new { idsConsolidacao});
        }

        public async Task<IEnumerable<long>> ObterConsolidacoesConselhoClasseNotaIdsPorConsolidacoesAlunoTurmaIds(long[] consolidacoesAlunoTurmaIds, int bimestre = 0)
        {
            var query = $@"select id from consolidado_conselho_classe_aluno_turma_nota where consolidado_conselho_classe_aluno_turma_id = ANY(@consolidacoesAlunoTurmaIds)";

            if (bimestre > 0)
                query += $@" and bimestre = @bimestre";

            return await database.Conexao.QueryAsync<long>(query, new { consolidacoesAlunoTurmaIds, bimestre });
        }

    }
}
