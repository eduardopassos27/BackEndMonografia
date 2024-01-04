using BackEndMonografia.Dtos;

namespace BackEndMonografia.Services.Interfaces
{
    public interface IValorCampoAdicionalService
    {
        Task<bool> InsertAsync(List<ValorCampoAdicionalDto> dto);
    }
}
