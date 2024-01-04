using BackEndMonografia.Dtos;

namespace BackEndMonografia.Repositories.Interfaces
{
    public interface IValorCampoAdicionalRepository
    {
        Task<bool> InsertAsync(ValorCampoAdicionalDto dto);
    }
}
