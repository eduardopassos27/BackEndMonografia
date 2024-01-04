using BackEndMonografia.Dtos;

namespace BackEndMonografia.Repositories.Interfaces
{
    public interface ICamposAdicionaisRepository
    {
        Task<bool> InsertCampoAdicionalAsync(CamposAdicionaisDto dto);
        Task<IEnumerable<CamposAdicionaisDto>> ObterCamposAsync(int idOrigem, int tipoId, int descricaoId);
    }
}
