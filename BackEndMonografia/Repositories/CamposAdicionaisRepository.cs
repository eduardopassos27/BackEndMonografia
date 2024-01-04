using BackEndMonografia.Dtos;
using BackEndMonografia.Repositories.Interfaces;
using Dapper;

namespace BackEndMonografia.Repositories
{
    public class CamposAdicionaisRepository : ICamposAdicionaisRepository
    {
        private readonly IDbConector dbConector;

        public CamposAdicionaisRepository(IDbConector dbConector)
        {
            this.dbConector = dbConector;
        }

        public async Task<bool> AdicionarCampoAdicionalAsync(CamposAdicionaisDto dto)
        {
            var param = new { ID_ORIGEM = dto.ID_ORIGEM, ID_TIPO = dto.ID_TIPO, ID_DESC = dto.ID_DESC, DESC_CAMPO = dto.DESC_CAMPO };

            var sql = @"INSERT INTO [dbo].[TB_CAMPOS_ADICIONAIS]
                               ([ID_ORIGEM]
                               ,[ID_TIPO]
                               ,[ID_DESC]
                               ,[DESC_CAMPO])
                         VALUES
                               (@ID_ORIGEM
                               ,@ID_TIPO
                               ,@ID_DESC
                               ,@DESC_CAMPO)";

            return await dbConector.Connection.ExecuteAsync(sql, param) > 0;
        }

        public async Task<IEnumerable<CamposAdicionaisDto>> ObterCamposAsync(int idOrigem, int tipoId, int descricaoId)
        {
            var param = new { ID_ORIGEM =  idOrigem, ID_TIPO = tipoId, ID_DESC = descricaoId };

            var sql = @"SELECT TOP (1000) [ID_CAMPO]
                          ,[ID_ORIGEM]
                          ,[ID_TIPO]
                          ,[ID_DESC]
                          ,[DESC_CAMPO]
                      FROM [DB_ATD_CLIENTES].[dbo].[TB_CAMPOS_ADICIONAIS]
                      WHERE ID_ORIGEM = @ID_ORIGEM AND
                            ID_TIPO = @ID_TIPO AND
                            ID_DESC = @ID_DESC ";

            return await dbConector.Connection.QueryAsync<CamposAdicionaisDto>(sql, param);
        }
    }
}
