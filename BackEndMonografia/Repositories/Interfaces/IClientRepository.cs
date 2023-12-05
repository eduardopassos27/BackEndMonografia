using BackEndMonografia.Models.System;

namespace BackEndMonografia.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<ClientModel> GetByAccountNumber(int id);
        Task<IEnumerable<ClientModel>> GetByDocumentNumber(string documentoNumber);
        Task<IEnumerable<ClientModel>> GetByName(string name);
    }
}
