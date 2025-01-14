﻿using Dapper;
using SME.SGP.Dominio;
using SME.SGP.Dominio.Enumerados;
using SME.SGP.Dominio.Interfaces;
using SME.SGP.Infra.Interface;
using SME.SGP.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace SME.SGP.Dados.Repositorios
{
    public class RepositorioNotaTipoValorConsulta : RepositorioBase<NotaTipoValor>, IRepositorioNotaTipoValorConsulta
    {
        public RepositorioNotaTipoValorConsulta(ISgpContextConsultas database, IServicoAuditoria servicoAuditoria) : base(database, servicoAuditoria)
        {
        }
        public async Task<NotaTipoValor> ObterPorCicloIdDataAvalicacao(long cicloId, DateTime dataAvalicao)
        {
            var sql = @"select ntv.* from notas_tipo_valor ntv
                        inner join notas_conceitos_ciclos_parametos nccp
                        on nccp.tipo_nota = ntv.id
                        where nccp.ciclo = @cicloId and @dataAvalicao >= nccp.inicio_vigencia
                        and (nccp.ativo = true or @dataAvalicao <= nccp.fim_vigencia)
                        order by nccp.id asc";

            var parametros = new { cicloId, dataAvalicao };

            return await database.QueryFirstOrDefaultAsync<NotaTipoValor>(sql, parametros);
        }

        public NotaTipoValor ObterPorTurmaId(long turmaId, TipoTurma tipoTurma = TipoTurma.Regular)
        {
            var sql = tipoTurma == TipoTurma.EdFisica ?
                    $@"select *
	                      from notas_conceitos_ciclos_parametos
                       where tipo_nota = {(int)TipoNota.Nota}
                       limit 1;" :
                    @"select
	                    nccp.*
                    from
	                    turma t
                    inner join tipo_ciclo_ano tca on
	                    (
		                    (t.ano = 'S' and tca.ano = '1') OR
    	                    (tca.ano = t.ano)
                        )
	                    and tca.modalidade = t.modalidade_codigo
                    inner join tipo_ciclo tc on
	                    tca.tipo_ciclo_id = tc.id
                    inner join notas_conceitos_ciclos_parametos nccp on
	                    nccp.ciclo = tc.id
                    where
	                    t.id = @turmaId";

            return database.QueryFirstOrDefault<NotaTipoValor>(sql, new { turmaId });
        }

        public async Task<NotaTipoValor> ObterPorTurmaIdAsync(long turmaId, TipoTurma tipoTurma = TipoTurma.Regular)
        {
            var sql = tipoTurma == TipoTurma.EdFisica ?
                    $@"select *
	                      from notas_conceitos_ciclos_parametos
                       where tipo_nota = {(int)TipoNota.Nota}
                       limit 1;" :
                    @"select
	                    nccp.*
                    from
	                    turma t
                    inner join tipo_ciclo_ano tca on
	                    (
		                    (t.ano = 'S' and tca.ano = '1') OR
    	                    (tca.ano = t.ano)
                        )
	                    and tca.modalidade = t.modalidade_codigo
                    inner join tipo_ciclo tc on
	                    tca.tipo_ciclo_id = tc.id
                    inner join notas_conceitos_ciclos_parametos nccp on
	                    nccp.ciclo = tc.id
                    where
	                    t.id = @turmaId";

            return await database.QueryFirstOrDefaultAsync<NotaTipoValor>(sql, new { turmaId });
        }
    }
}