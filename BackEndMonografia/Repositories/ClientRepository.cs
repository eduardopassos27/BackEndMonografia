using BackEndMonografia.Dtos;
using BackEndMonografia.Models;
using BackEndMonografia.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace BackEndMonografia.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConector dbConector;

        public ClientRepository(IDbConector dbConector)
        {
            this.dbConector = dbConector;
        }
        public async Task<ClienteCompleteResponseDto> GetByAccountNumber(int id)
        {
            var param = new { NUM_CONTA = id};

            var query = @"SELECT [TB_CLIENTES].[ID_CLIENTE]
                          ,[NOME_CLIENTE]
                          ,[DOCUMENTO]
                          ,[TB_CLIENTES].[ID_SEGMENTO]
	                      ,[TB_SEGMENTOS].NM_SEGMENTO
						  ,TB_AGENCIAS.NM_AGENCIA
                          ,[TB_CLIENTES].[ID_ENDERECO]
                          ,TB_ENDERECO.CIDADE
                          ,TB_ENDERECO.ESTADO
                          ,TB_ENDERECO.LOGRADOURO	  
                          ,TB_ENDERECO.NUMERO

	                    FROM [dbo].[TB_CLIENTES]

	                    LEFT JOIN TB_ENDERECO ON TB_ENDERECO.ID_ENDERECO = [TB_CLIENTES].[ID_ENDERECO]
	                    LEFT JOIN TB_SEGMENTOS ON TB_SEGMENTOS.[ID_SEGMENTO] = [TB_CLIENTES].[ID_SEGMENTO]
	                    LEFT JOIN TB_CONTA_CLIENTES ON TB_CONTA_CLIENTES.ID_CLIENTE = [TB_CLIENTES].[ID_CLIENTE]
						LEFT JOIN TB_AGENCIAS ON TB_AGENCIAS.ID_AGENCIA = TB_CLIENTES.ID_AGENCIA

	                    WHERE TB_CONTA_CLIENTES.NUM_CONTA = @NUM_CONTA";

            return dbConector.Connection.QueryFirst<ClienteCompleteResponseDto>(query, param);

        }

        public async Task<IEnumerable<ClienteCompleteResponseDto>> GetByDocumentNumber(string documentoNumber)
        {
            var param = new { DOC = documentoNumber };

            var query = @$"SELECT [TB_CLIENTES].[ID_CLIENTE]
                          ,[NOME_CLIENTE]
                          ,[DOCUMENTO]
                          ,[TB_CLIENTES].[ID_SEGMENTO]
	                      ,[TB_SEGMENTOS].NM_SEGMENTO
						  ,TB_AGENCIAS.NM_AGENCIA
                          ,[TB_CLIENTES].[ID_ENDERECO]
                          ,TB_ENDERECO.CIDADE
                          ,TB_ENDERECO.ESTADO
                          ,TB_ENDERECO.LOGRADOURO	  
                          ,TB_ENDERECO.NUMERO

	                    FROM [dbo].[TB_CLIENTES]

	                    LEFT JOIN TB_ENDERECO ON TB_ENDERECO.ID_ENDERECO = [TB_CLIENTES].[ID_ENDERECO]
	                    LEFT JOIN TB_SEGMENTOS ON TB_SEGMENTOS.[ID_SEGMENTO] = [TB_CLIENTES].[ID_SEGMENTO]
	                    LEFT JOIN TB_CONTA_CLIENTES ON TB_CONTA_CLIENTES.ID_CLIENTE = [TB_CLIENTES].[ID_CLIENTE]
						LEFT JOIN TB_AGENCIAS ON TB_AGENCIAS.ID_AGENCIA = TB_CLIENTES.ID_AGENCIA

                        WHERE [DOCUMENTO] = @DOC ";

            return dbConector.Connection.Query<ClienteCompleteResponseDto>(query,param);
        }

        public async Task<IEnumerable<ClienteCompleteResponseDto>> GetByName(string name)
        {
            var query = @$"SELECT [TB_CLIENTES].[ID_CLIENTE]
                          ,[NOME_CLIENTE]
                          ,[DOCUMENTO]
                          ,[TB_CLIENTES].[ID_SEGMENTO]
	                      ,[TB_SEGMENTOS].NM_SEGMENTO
						  ,TB_AGENCIAS.NM_AGENCIA
                          ,[TB_CLIENTES].[ID_ENDERECO]
                          ,TB_ENDERECO.CIDADE
                          ,TB_ENDERECO.ESTADO
                          ,TB_ENDERECO.LOGRADOURO	  
                          ,TB_ENDERECO.NUMERO

	                    FROM [dbo].[TB_CLIENTES]

	                    LEFT JOIN TB_ENDERECO ON TB_ENDERECO.ID_ENDERECO = [TB_CLIENTES].[ID_ENDERECO]
	                    LEFT JOIN TB_SEGMENTOS ON TB_SEGMENTOS.[ID_SEGMENTO] = [TB_CLIENTES].[ID_SEGMENTO]
	                    LEFT JOIN TB_CONTA_CLIENTES ON TB_CONTA_CLIENTES.ID_CLIENTE = [TB_CLIENTES].[ID_CLIENTE]
						LEFT JOIN TB_AGENCIAS ON TB_AGENCIAS.ID_AGENCIA = TB_CLIENTES.ID_AGENCIA

                        WHERE NOME_CLIENTE LIKE '%{name}%' ";

            return dbConector.Connection.Query<ClienteCompleteResponseDto>(query);
        }
    }
}
