using BackEndMonografia.Models.System;
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

        public Task<DemandModel> Add(DemandModel model)
        {
            return _demandRepository.Add(model);
        }

        public Task<IEnumerable<DemandModel>> GetAll()
        {
            return _demandRepository.GetAll();
        }

        public async Task<IEnumerable<CompleteDemandModel>> GetDemandsByClient(int clientId)
        {
            return await _demandRepository.GetDemandsByClient(clientId);
        }
    }
}
