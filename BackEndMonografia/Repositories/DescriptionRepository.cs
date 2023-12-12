using BackEndMonografia.Models.System;
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

            var query = @"SELECT [DescriptionId]
                              ,TypeTable.[TypeId]
							  ,TypeTable.TypeDescription
                              ,[DescriptionText]
                          FROM [dbo].[DescriptionTable]
						  LEFT JOIN TypeTable ON TypeTable.TypeId = [DescriptionTable].TypeId
                          WHERE TypeTable.[TypeId] = @TYPEID ";

            return await this.dbConector.Connection.QueryAsync<DescriptionModel>(query, param);
        }

        public async Task<IEnumerable<DescriptionModel>> GetAllAsync()
        {

            var query = @"SELECT [DescriptionId]
                              ,TypeTable.[TypeId]
							  ,TypeTable.TypeDescription
                              ,[DescriptionText]
                          FROM [dbo].[DescriptionTable]
						  LEFT JOIN TypeTable ON TypeTable.TypeId = [DescriptionTable].TypeId";

            return await this.dbConector.Connection.QueryAsync<DescriptionModel>(query);
        }

        public async Task<DescriptionModel> InsertAsync(DescriptionModel model)
        {
            var param = new { TypeId = model.TypeId, DescriptionText = model.DescriptionText };

            var query = @"INSERT INTO [dbo].[DescriptionTable]
                                       ([TypeId]
                                       ,[DescriptionText])
                                 OUTPUT INSERTED.*
                                 VALUES
                                       (@TypeId
                                       ,@DescriptionText)";

            var retorno = await this.dbConector.Connection.QueryAsync<DescriptionModel>(query, param);

            return retorno.First();
        }
    }
}
