
using BackEndMonografia.Dtos;

namespace BackEndMonografia.Services.Interfaces
{
    public interface ICamposAdicionaisService
    {
        Task<bool> InsertCampoAdicionalAsync(List<CamposAdicionaisDto> dtos);
        Task<IEnumerable<CamposAdicionaisDto>> ObterCamposAsync(int idOrigem, int tipoId, int descricaoId);
    }
}
