using BackEndMonografia.Dtos;

namespace BackEndMonografia.Services.Interfaces
{
    public interface IValorCampoAdicionalService
    {
        Task<bool> Adicionar(List<ValorCampoAdicionalDto> dto);
    }
}
