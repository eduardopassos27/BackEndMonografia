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

            var sql = @"INSERT INTO [dbo].[DemandTable]
                                    ([TypeId]
                                    ,[DescriptionId]
                                    ,[AreaId]
                                    ,[StartDate]
                                    ,[StatusId]
                                    ,[SystemUser]
                                    ,[ResulutionDeadline]
                                    ,[OpeningComment]
                                    ,[ClientId])
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
                                    ,@ClientId)";

            return dbConector.Connection.Query<DemandModel>(sql, param).First();



        }
    }
}
