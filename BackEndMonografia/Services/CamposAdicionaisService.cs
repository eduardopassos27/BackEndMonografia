using BackEndMonografia.Dtos;
using BackEndMonografia.Repositories.Interfaces;
using BackEndMonografia.Services.Interfaces;

namespace BackEndMonografia.Services
{
    public class CamposAdicionaisService : ICamposAdicionaisService
    {
        private readonly ICamposAdicionaisRepository _camposAdicionaisRepository;

        public CamposAdicionaisService(ICamposAdicionaisRepository camposAdicionaisRepository)
        {
            _camposAdicionaisRepository = camposAdicionaisRepository;
        }

        public async Task<bool> AdicionarCampoAdicionalAsync(List<CamposAdicionaisDto> dtos)
        {
            foreach(var dto in dtos)
            {
                await _camposAdicionaisRepository.AdicionarCampoAdicionalAsync(dto);
            }
            return true;
        }

        public async Task<IEnumerable<CamposAdicionaisDto>> ObterCamposAsync(int idOrigem, int tipoId, int descricaoId)
        {
            return await _camposAdicionaisRepository.ObterCamposAsync(idOrigem, tipoId, descricaoId);
        }
    }
}
