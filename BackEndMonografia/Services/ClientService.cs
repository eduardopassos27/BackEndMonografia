using BackEndMonografia.Models.System;
using BackEndMonografia.Repositories.Interfaces;
using BackEndMonografia.Services.Interfaces;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BackEndMonografia.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepo;

        public ClientService(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public Task<ClientModel> GetByAccountNumber(int id)
        {
            return _clientRepo.GetByAccountNumber(id);
        }

        public async Task<IEnumerable<ClientModel>> GetByDocumentNumber(string documentoNumber)
        {
            return await _clientRepo.GetByDocumentNumber(documentoNumber);
        }

        public async Task<IEnumerable<ClientModel>> GetByName(string name)
        {
            return await _clientRepo.GetByName(name);
        }
    }
}
