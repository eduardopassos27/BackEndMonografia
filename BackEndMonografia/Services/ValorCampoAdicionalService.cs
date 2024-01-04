using BackEndMonografia.Dtos;
using BackEndMonografia.Repositories.Interfaces;
using BackEndMonografia.Services.Interfaces;

namespace BackEndMonografia.Services
{
    public class ValorCampoAdicionalService : IValorCampoAdicionalService
    {
        private readonly IValorCampoAdicionalRepository _valorCampoAdicionalRepository;

        public ValorCampoAdicionalService(IValorCampoAdicionalRepository valorCampoAdicionalRepository)
        {
            _valorCampoAdicionalRepository = valorCampoAdicionalRepository;
        }

        public async Task<bool> Adicionar(List<ValorCampoAdicionalDto> dtos)
        {
            var listReturn = new List<bool>();

            foreach (var dto in dtos)
            {
                var retorno =  await _valorCampoAdicionalRepository.InsertAsync(dto);
            }

            return !listReturn.Contains(false);
        }
    }
}
