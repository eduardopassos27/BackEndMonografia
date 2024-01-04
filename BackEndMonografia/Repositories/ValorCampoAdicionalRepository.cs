using BackEndMonografia.Dtos;
using BackEndMonografia.Repositories.Interfaces;
using Dapper;
using Microsoft.JSInterop.Infrastructure;

namespace BackEndMonografia.Repositories
{
    public class ValorCampoAdicionalRepository : IValorCampoAdicionalRepository
    {
        private readonly IDbConector _dbConector;

        public ValorCampoAdicionalRepository(IDbConector dbConector)
        {
            _dbConector = dbConector;
        }
        
        public async Task<bool> InsertAsync(ValorCampoAdicionalDto dto)
        {
            var param = new { ID_DEMANDA = dto.ID_DEMANDA, ID_CAMPO = dto.ID_CAMPO, TXT_VALOR = dto.TXT_VALOR };
            
            var sql = @"INSERT INTO [dbo].[TB_VALOR_CAMPO_ADICIONAL]
                                   ([ID_DEMANDA]
                                   ,[ID_CAMPO]
                                   ,[TXT_VALOR])
                             VALUES
                                   (@ID_DEMANDA
                                   ,@ID_CAMPO
                                   ,@TXT_VALOR)";

            return await this._dbConector.Connection.ExecuteAsync(sql, param) > 0;
        }
    }
}
