using BackEndMonografia.Models;
using BackEndMonografia.Repositories.Interfaces;
using Dapper;
using System;

namespace BackEndMonografia.Repositories
{
    public class DescriptionRepository : IDescriptionRepository
    {
        private readonly IDbConector dbConector;

        public DescriptionRepository(IDbConector dbConector)
        {
            this.dbConector = dbConector;
        }

        public async Task<IEnumerable<DescriptionModel>> GetByTypeId(int typeId)
        {
            var param = new { TYPEID = typeId };

            var query = @"SELECT [ID_DESC] AS DescriptionId
                              ,TB_TIPOS.ID_TIPO AS TypeId
							  ,TB_TIPOS.TXT_TIPO AS TypeDescription
                              ,[TXT_DESCRICAO] AS DescriptionText
                          FROM [dbo].[TB_DESCRICOES]
						  LEFT JOIN TB_TIPOS ON TB_TIPOS.ID_TIPO = TB_DESCRICOES.ID_TIPO
                          WHERE TB_TIPOS.ID_TIPO = @TYPEID ";

            return await this.dbConector.Connection.QueryAsync<DescriptionModel>(query, param);
        }

        public async Task<IEnumerable<DescriptionModel>> GetAllAsync()
        {

            var query = @"SELECT TOP (1000) [ID_DESC] AS DescriptionId
                              ,[TXT_DESCRICAO] AS DescriptionText
                              ,[TB_DESCRICOES].[ID_TIPO] AS TypeId
	                          ,TB_TIPOS.TXT_TIPO AS TypeDescription
                          FROM [DB_ATD_CLIENTES].[dbo].[TB_DESCRICOES]
                          LEFT JOIN TB_TIPOS ON  TB_TIPOS.ID_TIPO = [TB_DESCRICOES].ID_TIPO";

            return await this.dbConector.Connection.QueryAsync<DescriptionModel>(query);
        }

        public async Task<DescriptionModel> InsertAsync(DescriptionModel model)
        {
            var param = new { TypeId = model.TypeId, DescriptionText = model.DescriptionText };

            var query = @"INSERT INTO [dbo].[TB_DESCRICOES]
                                       ([ID_TIPO]
                                       ,[TXT_DESCRICAO])
                                 OUTPUT INSERTED.*
                                 VALUES
                                       (@TypeId
                                       ,@DescriptionText)";

            var retorno = await this.dbConector.Connection.QueryAsync<DescriptionModel>(query, param);

            return retorno.First();
        }
    }
}
