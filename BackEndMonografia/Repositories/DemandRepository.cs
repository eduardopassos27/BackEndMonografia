using BackEndMonografia.Models.System;
using Dapper;
using System.Data;

namespace BackEndMonografia.Repositories
{
    public class DemandRepository : IDemandRepository
    {
        private readonly IDbConector dbConector;

        public DemandRepository(IDbConector dbConector)
        {
            this.dbConector = dbConector;
        }
        public async Task<IEnumerable<DemandModel>> GetAll()
        {
            var sql = @"SELECT * FROM [dbo].[DemandTable]";

            return dbConector.Connection.Query<DemandModel>(sql);
        }
        public async Task<DemandModel> Add(DemandModel model)
        {
            var param = new DynamicParameters();

            param.Add("TypeId", model.TypeId, DbType.Int32, ParameterDirection.Input);
            param.Add("DescriptionId", model.DescriptionId, DbType.Int32, ParameterDirection.Input);
            param.Add("AreaId", model.AreaId, DbType.Int32, ParameterDirection.Input);
            param.Add("SystemUser", DBNull.Value, DbType.String, ParameterDirection.Input);
            param.Add("ResulutionDeadline", model.ResulutionDeadline, DbType.Int32, ParameterDirection.Input);
            param.Add("OpeningComment", model.OpeningComment, DbType.String, ParameterDirection.Input);
            param.Add("ClientId", model.ClientId, DbType.Int32, ParameterDirection.Input);
            param.Add("OriginId", model.OriginId, DbType.Int32, ParameterDirection.Input);

            var sql = @"INSERT INTO [dbo].[DemandTable]
                                    ([TypeId]
                                    ,[DescriptionId]
                                    ,[AreaId]
                                    ,[StartDate]
                                    ,[StatusId]
                                    ,[SystemUser]
                                    ,[ResulutionDeadline]
                                    ,[OpeningComment]
                                    ,[ClientId]
                                    ,[OriginId])
                                     OUTPUT INSERTED.*
                                VALUES
                                    (@TypeId
                                    ,@DescriptionId
                                    ,@AreaId
                                    ,GETDATE()
                                    ,1
                                    ,@SystemUser
                                    ,@ResulutionDeadline
                                    ,@OpeningComment
                                    ,@ClientId
                                    ,@OriginId)";

            return dbConector.Connection.Query<DemandModel>(sql, param).First();



        }

        public async Task<IEnumerable<CompleteDemandModel>> GetDemandsByClient(int clientId)
        {
            var param = new {clientId =  clientId};

            var query = @" SELECT [DemandId]
                          ,demand.[TypeId]
	                      ,TypeDescription
                          ,demand.[OriginId]
	                      ,OriginDescription
                          ,demand.[DescriptionId]
	                      ,DescriptionText
                          ,demand.[AreaId]
	                      ,AreaName
                          ,demand.[StartDate]
                          ,[EndDate]
                          ,demand.[StatusId]
	                      ,StatusDescription
                          ,[SystemUser]
                          ,[ResulutionDeadline]
                          ,[Solution]
                          ,[OpeningComment]
                          ,[FinalComment]
                          ,[ClientId]
                      FROM [dbo].[DemandTable] as demand
                      LEFT JOIN [dbo].[AreaTable] on demand.AreaId = [AreaTable].AreaId
                      LEFT JOIN [dbo].[DescriptionTable] on demand.DescriptionId = [DescriptionTable].DescriptionId
                      LEFT JOIN [dbo].TypeTable on demand.TypeId = TypeTable.TypeId
                      LEFT JOIN [dbo].StatusTable on demand.StatusId = StatusTable.StatusId
                      LEFT JOIN [dbo].OriginTable on demand.OriginId = OriginTable.OriginId
                      where demand.ClientId = @clientId";

            return dbConector.Connection.Query<CompleteDemandModel>(query, param);

        }
    }
}
