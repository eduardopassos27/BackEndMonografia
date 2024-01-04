using BackEndMonografia.Models;
using BackEndMonografia.Repositories;
using BackEndMonografia.Services.Interfaces;

namespace BackEndMonografia.Services
{
    public class DemandService : IDemandService
    {
        private readonly IDemandRepository _demandRepository;

        public DemandService(IDemandRepository demandRepository)
        {
            _demandRepository = demandRepository;
        }

        public Task<DemandModel> Adicionar(DemandModel model)
        {
            return _demandRepository.Add(model);
        }

        public Task<IEnumerable<DemandModel>> ObterTodas()
        {
            return _demandRepository.GetAll();
        }

        public async Task<IEnumerable<CompleteDemandModel>> ObterDemandasPorClienteId(int clientId)
        {
            return await _demandRepository.GetDemandsByClient(clientId);
        }
    }
}
