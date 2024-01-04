using BackEndMonografia.Dtos;
using BackEndMonografia.Models;
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

        public Task<ClienteCompleteResponseDto> GetByAccountNumber(int id)
        {
            return _clientRepo.GetByAccountNumber(id);
        }

        public async Task<IEnumerable<ClienteCompleteResponseDto>> GetByDocumentNumber(string documentoNumber)
        {
            var retorno = await _clientRepo.GetByDocumentNumber(documentoNumber);

            retorno = retorno.Distinct<ClienteCompleteResponseDto>();

            return retorno;
        }

        public async Task<IEnumerable<ClienteCompleteResponseDto>> GetByName(string name)
        {
            var retorno =  await _clientRepo.GetByName(name);

            retorno = retorno.DistinctBy(cliente => cliente.ID_CLIENTE);

            return retorno;
        }
    }
}
