﻿using Dapper;
using SME.SGP.Dominio;
using SME.SGP.Dominio.Interfaces;
using SME.SGP.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SGP.Dados
{
    public class RepositorioPendenciaDevolutiva : IRepositorioPendenciaDevolutiva
    {
		private readonly ISgpContextConsultas database;

		public RepositorioPendenciaDevolutiva(ISgpContextConsultas database)
        {
			this.database = database ?? throw new ArgumentNullException(nameof(database));
		}


		public async Task Salvar(PendenciaDevolutiva pendenciaDevolutiva)
		{
			await database.Conexao.InsertAsync(pendenciaDevolutiva);
		}

		public async Task ExcluirPorTurmaComponente(long turmaId, long componenteId)
		{
			await database.Conexao.ExecuteScalarAsync(@"DELETE FROM pendencia_devolutiva WHERE turma_id = @turmaId AND componente_curricular_id =@componenteId", new { turmaId, componenteId });
		}

		public async Task ExcluirPorId(long id)
		{
			await database.Conexao.ExecuteScalarAsync(@"DELETE FROM pendencia_devolutiva WHERE id =@id", new { id });
		}


		public async Task<IEnumerable<PendenciaDevolutiva>> ObterPendenciasDevolutivaPorPendencia(long pendenciaId)
        {
            var query = $@"SELECT
							pd.*, 
							p.*,
							cc.*,
							t.*
						FROM
							pendencia_devolutiva pd
						INNER JOIN pendencia p ON
							pd.pendencia_Id = p.id
						INNER JOIN componente_curricular cc ON
							pd.componente_curricular_id = cc.id
						INNER JOIN turma t ON
							pd.turma_id = t.id
						WHERE
							pd.pendencia_Id = @pendenciaId ";

            return await database.Conexao.QueryAsync<PendenciaDevolutiva>(query, new { pendenciaId});
        }

        public async Task<IEnumerable<PendenciaDevolutiva>> ObterPendenciasDevolutivaPorTurmaComponente(long turmaId, long componenteId)
        {
			var query = @"SELECT
							pd.*, 
							p.*,
							cc.*,
							t.*
						FROM
							pendencia_devolutiva pd
						INNER JOIN pendencia p ON
							pd.pendencia_Id = p.id
						INNER JOIN componente_curricular cc ON
							pd.componente_curricular_id = cc.id
						INNER JOIN turma t ON
							pd.turma_id = t.id
						WHERE pd.componente_curricular_id  = @componenteId 
						AND pd.turma_id  = @turmaId";

			return await database.Conexao.QueryAsync<PendenciaDevolutiva>(query,new { turmaId, componenteId });
		}

        public async Task<IEnumerable<string>> ObterCodigoComponenteComDiarioBordoSemDevolutiva(long turmaId, string ueId)
        {
			var query = @"
							SELECT 
								DISTINCT  db.componente_curricular_id AS ComponenteCodigo
							FROM
								diario_bordo db
							INNER JOIN aula a ON
								db.aula_id = a.id
							WHERE
								db.devolutiva_id ISNULL
								AND db.turma_id = @turmaId
								AND a.ue_id  = @ueId ";

			return await database.Conexao.QueryAsync<string>(query, new { turmaId, ueId });
		}
    }
}