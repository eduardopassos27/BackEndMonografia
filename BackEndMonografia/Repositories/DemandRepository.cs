using BackEndMonografia.Models;
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
            var sql = @"SELECT * FROM [dbo].TB_DEMANDAS";

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

            var sql = @"INSERT INTO [dbo].[TB_DEMANDAS]
                                       ([ID_TIPO]
                                       ,[ID_DESC]
                                       ,[ID_AREA]
                                       ,[DT_INICIO]
                                       ,[ID_STATUS]
                                       ,[PRAZO_RESOLUCAO]
                                       ,[COMENTARIO_ABERTURA]
                                       ,[ID_CLIENTE]
                                       ,[ID_ORIGEM])
                                     OUTPUT INSERTED.ID_DEMANDA AS DemandId
                                VALUES
                                    (@TypeId
                                    ,@DescriptionId
                                    ,@AreaId
                                    ,GETDATE()
                                    ,1
                                    ,@ResulutionDeadline
                                    ,@OpeningComment
                                    ,@ClientId
                                    ,@OriginId)";

            return dbConector.Connection.Query<DemandModel>(sql, param).First();



        }

        public async Task<IEnumerable<CompleteDemandModel>> GetDemandsByClient(int clientId)
        {
            var param = new {clientId =  clientId};

            var query = @" SELECT [ID_DEMANDA] as DemandId
                          ,demand.[ID_TIPO] as TypeId
	                      ,[TXT_TIPO] as TypeDescription
                          ,demand.[ID_ORIGEM] as OriginId
	                      ,[NM_ORIGEM] as OriginDescription
                          ,demand.[ID_DEMANDA] as DescriptionId
	                      ,[TXT_DESCRICAO] as DescriptionText
                          ,demand.[ID_AREA] as AreaId
	                      ,[NM_AREA] as AreaName
                          ,demand.[DT_INICIO] as StartDate
                          ,DT_FIM as EndDate
                          ,demand.[ID_STATUS] as StatusId
	                      ,[NM_STATUS] as StatusDescription
                          ,[PRAZO_RESOLUCAO] as ResulutionDeadline
                          ,[COMENTARIO_ABERTURA] as OpeningComment
                          ,[COMENTARIO_FINAL] as FinalComment
                          ,[ID_CLIENTE] as ClientId
                      FROM TB_DEMANDAS as demand
                      LEFT JOIN  [dbo].[TB_AREAS] on demand.ID_AREA = [TB_AREAS].[ID_AREA]
                      LEFT JOIN [dbo].[TB_DESCRICOES] on demand.[ID_DESC] = [TB_DESCRICOES].[ID_DESC]
                      LEFT JOIN [dbo].[TB_TIPOS] on demand.[ID_TIPO] = TB_TIPOS.[ID_TIPO]
                      LEFT JOIN TB_STATUS on demand.[ID_STATUS] = [TB_STATUS].[ID_STATUS]
                      LEFT JOIN [dbo].[TB_ORIGENS] on demand.[ID_ORIGEM] = TB_ORIGENS.[ID_ORIGEM]
                      where demand.[ID_CLIENTE] = @clientId";

            return dbConector.Connection.Query<CompleteDemandModel>(query, param);

        }
    }
}
