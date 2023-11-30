using BackEndMonografia.Controllers;
using BackEndMonografia.Models.System;
using Dapper;
using System.Data;

namespace BackEndMonografia.Repositories
{
    public class TaxonomyRepository : ITaxonomyRepository
    {
        private readonly IDbConector dbConector;

        public TaxonomyRepository(IDbConector dbConector)
        {
            this.dbConector = dbConector;
        }

        public async Task<TaxonomyModel> Add(TaxonomyModel model)
        {
            var param = new DynamicParameters();

            param.Add("AreaId", model.AreaId,DbType.Int32, ParameterDirection.Input);
            param.Add("DescriptionId", model.DescriptionId, DbType.Int32, ParameterDirection.Input);
            param.Add("OriginId", model.OriginId, DbType.Int32, ParameterDirection.Input);
            param.Add("TypeId", model.TypeId, DbType.Int32, ParameterDirection.Input);
            param.Add("ResulutionDeadline", model.ResulutionDeadline, DbType.Int32, ParameterDirection.Input);
            param.Add("UsedFor", model.UsedFor, DbType.String, ParameterDirection.Input);

            var sql = @"INSERT INTO [dbo].[TaxonomyTable]
                                    ([AreaId]
                                    ,[DescriptionId]
                                    ,[OriginId]
                                    ,[TypeId]
                                    ,[ResulutionDeadline]
                                    ,[UsedFor])
									output inserted.*
                                VALUES
                                    (@AreaId
                                    ,@DescriptionId
                                    ,@OriginId
                                    ,@TypeId
                                    ,@ResulutionDeadline
                                    ,@UsedFor)";

            return dbConector.Connection.Query<TaxonomyModel>(sql, param).FirstOrDefault();


        }

        public async Task<IEnumerable<TaxonomyModel>> GetAll()
        {
            var sql = @"SELECT * FROM [dbo].[TaxonomyTable]";

            return dbConector.Connection.Query<TaxonomyModel>(sql);
        }
    }
}
