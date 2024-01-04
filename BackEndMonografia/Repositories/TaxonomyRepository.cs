using BackEndMonografia.Controllers;
using BackEndMonografia.Models;
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

            var sql = @"INSERT INTO [dbo].[TB_TAXONOMIA]
                                   ([ID_ORIGEM]
                                   ,[ID_TIPO]
                                   ,[ID_DESC]
                                   ,[ID_AREA]
                                   ,[RESOLUTION_DEADLINE]
                                   ,[USED_FOR])
									output inserted.*
                                VALUES
                                    (@OriginId
                                    ,@TypeId
                                    ,@DescriptionId
                                    ,@AreaId
                                    ,@ResulutionDeadline
                                    ,@UsedFor)";

            return dbConector.Connection.Query<TaxonomyModel>(sql, param).FirstOrDefault();


        }

        public async Task<IEnumerable<TaxonomyModel>> GetAll()
        {
            var sql = @" SELECT * [ID_ORIGEM] AS OriginId
                              ,[ID_TIPO] AS TypeId
                              ,[ID_DESC] AS DescriptionId
                              ,[ID_AREA] AS AreaId
                              ,[RESOLUTION_DEADLINE] AS ResulutionDeadline
                              ,[USED_FOR] AS UsedFor
                          FROM [DB_ATD_CLIENTES].[dbo].[TB_TAXONOMIA]";

            return await dbConector.Connection.QueryAsync<TaxonomyModel>(sql);
        }

        public async Task<IEnumerable<TaxonomyModel>> GetByOrigem(int origemId)
        {
            var param = new { OriginId = origemId };


            var sql = @" SELECT TB_TAXONOMIA.ID_AREA AS AreaId
		                    ,NM_AREA AS AreaName
	                        ,TB_TAXONOMIA.ID_DESC AS DescriptionId
	                        ,TXT_DESCRICAO AS DescriptionText
	                        ,TB_TAXONOMIA.ID_ORIGEM AS OriginId
		                    ,NM_ORIGEM AS OriginDescription
		                    ,TB_TIPOS.TXT_TIPO AS TypeDescription
	                        ,TB_TAXONOMIA.ID_TIPO AS TypeId
		                    ,RESOLUTION_DEADLINE AS ResulutionDeadline
		                    ,USED_FOR AS UsedFor

                     FROM TB_TAXONOMIA

                     LEFT JOIN TB_AREAS ON TB_AREAS.ID_AREA = TB_TAXONOMIA.ID_AREA
                     LEFT JOIN TB_DESCRICOES ON TB_DESCRICOES.ID_DESC = TB_TAXONOMIA.ID_DESC
                     LEFT JOIN TB_ORIGENS ON TB_ORIGENS.ID_ORIGEM = TB_TAXONOMIA.ID_ORIGEM
                     LEFT JOIN TB_TIPOS ON TB_TIPOS.ID_TIPO = TB_TAXONOMIA.ID_TIPO

                    WHERE TB_TAXONOMIA.ID_ORIGEM = @OriginId ";

           return await dbConector.Connection.QueryAsync<TaxonomyModel>(sql, param);
        }

        public async Task<IEnumerable<TaxonomyModel>> GetByOrigemAndType(int origemId, int typeId)
        {
            var param = new { OriginId = origemId, TypeId = typeId };


            var sql = @"     SELECT TB_TAXONOMIA.ID_AREA AS AreaId
		                    ,NM_AREA AS AreaName
	                        ,TB_TAXONOMIA.ID_DESC AS DescriptionId
	                        ,TXT_DESCRICAO AS DescriptionText
	                        ,TB_TAXONOMIA.ID_ORIGEM AS OriginId
		                    ,NM_ORIGEM AS OriginDescription
		                    ,TB_TIPOS.TXT_TIPO AS TypeDescription
	                        ,TB_TAXONOMIA.ID_TIPO AS TypeId
		                    ,RESOLUTION_DEADLINE AS ResulutionDeadline
		                    ,USED_FOR AS UsedFor

                     FROM TB_TAXONOMIA

                     LEFT JOIN TB_AREAS ON TB_AREAS.ID_AREA = TB_TAXONOMIA.ID_AREA
                     LEFT JOIN TB_DESCRICOES ON TB_DESCRICOES.ID_DESC = TB_TAXONOMIA.ID_DESC
                     LEFT JOIN TB_ORIGENS ON TB_ORIGENS.ID_ORIGEM = TB_TAXONOMIA.ID_ORIGEM
                     LEFT JOIN TB_TIPOS ON TB_TIPOS.ID_TIPO = TB_TAXONOMIA.ID_TIPO

                    WHERE TB_TAXONOMIA.ID_ORIGEM = @OriginId 
                         and TB_TAXONOMIA.ID_TIPO = @TypeId  ";

            return await dbConector.Connection.QueryAsync<TaxonomyModel>(sql, param);
        }

        public async Task<IEnumerable<TaxonomyModel>> GetByOrigemAndTypeAndDescription(int origemId, int typeId, int descriptionId)
        {
            var param = new { OriginId = origemId, TypeId = typeId, DescriptionId = descriptionId };


            var sql = @"     SELECT TB_TAXONOMIA.ID_AREA AS AreaId
		                    ,NM_AREA AS AreaName
	                        ,TB_TAXONOMIA.ID_DESC AS DescriptionId
	                        ,TXT_DESCRICAO AS DescriptionText
	                        ,TB_TAXONOMIA.ID_ORIGEM AS OriginId
		                    ,NM_ORIGEM AS OriginDescription
		                    ,TB_TIPOS.TXT_TIPO AS TypeDescription
	                        ,TB_TAXONOMIA.ID_TIPO AS TypeId
		                    ,RESOLUTION_DEADLINE AS ResulutionDeadline
		                    ,USED_FOR AS UsedFor

                             FROM TB_TAXONOMIA

                             LEFT JOIN TB_AREAS ON TB_AREAS.ID_AREA = TB_TAXONOMIA.ID_AREA
                             LEFT JOIN TB_DESCRICOES ON TB_DESCRICOES.ID_DESC = TB_TAXONOMIA.ID_DESC
                             LEFT JOIN TB_ORIGENS ON TB_ORIGENS.ID_ORIGEM = TB_TAXONOMIA.ID_ORIGEM
                             LEFT JOIN TB_TIPOS ON TB_TIPOS.ID_TIPO = TB_TAXONOMIA.ID_TIPO

                             WHERE TB_TAXONOMIA.ID_ORIGEM = @OriginId 
                             AND TB_TAXONOMIA.ID_TIPO = @TypeId 
                             AND TB_TAXONOMIA.ID_DESC = @DescriptionId";


            return await dbConector.Connection.QueryAsync<TaxonomyModel>(sql, param);
        }
    }
}
