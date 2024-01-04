using BackEndMonografia.Dtos;
using BackEndMonografia.Models;

namespace BackEndMonografia.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClienteCompleteResponseDto> ObterPeloNumeroDaConta(int id);
        Task<IEnumerable<ClienteCompleteResponseDto>> ObterPeloNumeroDoDocumento(string documentoNumber);
        Task<IEnumerable<ClienteCompleteResponseDto>> ObterPeloNomeDoCliente(string name);
    }
}
