using BackEndMonografia.Models.System;
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
        public async Task<ClientModel> GetByAccountNumber(int id)
        {
            var param = new {ID = id};

            var query = @"SELECT * FROM [ClientTable] WHERE [AccountNumber] = @ID";

            return dbConector.Connection.QueryFirst<ClientModel>(query, param);

        }

        public async Task<IEnumerable<ClientModel>> GetByDocumentNumber(string documentoNumber)
        {
            var param = new { DOC = documentoNumber };

            var query = @$"SELECT * FROM [ClientTable] WHERE [Documento] = @DOC ";

            return dbConector.Connection.Query<ClientModel>(query,param);
        }

        public async Task<IEnumerable<ClientModel>> GetByName(string name)
        {
            var query = @$"SELECT * FROM [ClientTable] WHERE ClientName LIKE '%{name}%' ";

            return dbConector.Connection.Query<ClientModel>(query);
        }
    }
}
