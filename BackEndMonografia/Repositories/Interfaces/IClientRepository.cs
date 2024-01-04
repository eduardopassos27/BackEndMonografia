using BackEndMonografia.Dtos;
using BackEndMonografia.Models;

namespace BackEndMonografia.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<ClienteCompleteResponseDto> GetByAccountNumber(int id);
        Task<IEnumerable<ClienteCompleteResponseDto>> GetByDocumentNumber(string documentoNumber);
        Task<IEnumerable<ClienteCompleteResponseDto>> GetByName(string name);
    }
}
