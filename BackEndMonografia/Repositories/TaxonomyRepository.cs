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

            return await dbConector.Connection.QueryAsync<TaxonomyModel>(sql);
        }

        public async Task<IEnumerable<TaxonomyModel>> GetByOrigem(int origemId)
        {
            var param = new { OriginId = origemId };


            var sql = @"
                        SELECT [TaxonomyTable].[AreaId]
                            ,AreaName
						    ,[TaxonomyTable].[DescriptionId]
						    ,DescriptionText
						    ,[TaxonomyTable].[OriginId]
                            ,OriginDescription
                            ,TypeDescription
						    ,[TaxonomyTable].[TypeId]
                            ,[ResulutionDeadline]
                            ,[UsedFor]
                        FROM [dbo].[TaxonomyTable]
                        LEFT JOIN [AreaTable] ON [AreaTable].AreaId = [TaxonomyTable].AreaId
					    LEFT JOIN DescriptionTable ON DescriptionTable.DescriptionId = [TaxonomyTable].DescriptionId
					    LEFT JOIN OriginTable ON OriginTable.OriginId = [TaxonomyTable].OriginId
					    LEFT JOIN TypeTable ON TypeTable.[TypeId] = [TaxonomyTable].[TypeId]
                       WHERE TaxonomyTable.OriginId = @OriginId";

           return await dbConector.Connection.QueryAsync<TaxonomyModel>(sql, param);
        }

        public async Task<IEnumerable<TaxonomyModel>> GetByOrigemAndType(int origemId, int typeId)
        {
            var param = new { OriginId = origemId, TypeId = typeId };


            var sql = @"
                        SELECT [TaxonomyTable].[AreaId]
                            ,AreaName
						    ,[TaxonomyTable].[DescriptionId]
						    ,DescriptionText
						    ,[TaxonomyTable].[OriginId]
                            ,OriginDescription
                            ,TypeDescription
						    ,[TaxonomyTable].[TypeId]
                            ,[ResulutionDeadline]
                            ,[UsedFor]
                        FROM [dbo].[TaxonomyTable]
                        LEFT JOIN [AreaTable] ON [AreaTable].AreaId = [TaxonomyTable].AreaId
					    LEFT JOIN DescriptionTable ON DescriptionTable.DescriptionId = [TaxonomyTable].DescriptionId
					    LEFT JOIN OriginTable ON OriginTable.OriginId = [TaxonomyTable].OriginId
					    LEFT JOIN TypeTable ON TypeTable.[TypeId] = [TaxonomyTable].[TypeId]
                       WHERE TaxonomyTable.OriginId = @OriginId 
                            and TaxonomyTable.TypeId = @TypeId ";

            return await dbConector.Connection.QueryAsync<TaxonomyModel>(sql, param);
        }

        public async Task<IEnumerable<TaxonomyModel>> GetByOrigemAndTypeAndDescription(int origemId, int typeId, int descriptionId)
        {
            var param = new { OriginId = origemId, TypeId = typeId, DescriptionId = descriptionId };


            var sql = @"
                        SELECT [TaxonomyTable].[AreaId]
                            ,AreaName
						    ,[TaxonomyTable].[DescriptionId]
						    ,DescriptionText
						    ,[TaxonomyTable].[OriginId]
                            ,OriginDescription
                            ,TypeDescription
						    ,[TaxonomyTable].[TypeId]
                            ,[ResulutionDeadline]
                            ,[UsedFor]
                        FROM [dbo].[TaxonomyTable]
                        LEFT JOIN [AreaTable] ON [AreaTable].AreaId = [TaxonomyTable].AreaId
					    LEFT JOIN DescriptionTable ON DescriptionTable.DescriptionId = [TaxonomyTable].DescriptionId
					    LEFT JOIN OriginTable ON OriginTable.OriginId = [TaxonomyTable].OriginId
					    LEFT JOIN TypeTable ON TypeTable.[TypeId] = [TaxonomyTable].[TypeId]
                       WHERE TaxonomyTable.OriginId = @OriginId 
                            and TaxonomyTable.TypeId = @TypeId 
                            and TaxonomyTable.DescriptionId = @DescriptionId";

            return await dbConector.Connection.QueryAsync<TaxonomyModel>(sql, param);
        }
    }
}
