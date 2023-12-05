using BackEndMonografia.Models.System;

namespace BackEndMonografia.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClientModel> GetByAccountNumber(int id);
        Task<IEnumerable<ClientModel>> GetByDocumentNumber(string documentoNumber);
        Task<IEnumerable<ClientModel>> GetByName(string name);
    }
}
