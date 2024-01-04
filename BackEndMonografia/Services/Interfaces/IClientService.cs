using BackEndMonografia.Dtos;
using BackEndMonografia.Models;

namespace BackEndMonografia.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClienteCompleteResponseDto> GetByAccountNumber(int id);
        Task<IEnumerable<ClienteCompleteResponseDto>> GetByDocumentNumber(string documentoNumber);
        Task<IEnumerable<ClienteCompleteResponseDto>> GetByName(string name);
    }
}
