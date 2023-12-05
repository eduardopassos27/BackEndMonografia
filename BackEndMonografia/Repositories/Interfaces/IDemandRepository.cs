using BackEndMonografia.Models.System;
using System.Threading.Tasks;

namespace BackEndMonografia.Repositories
{
    public interface IDemandRepository
    {
        Task<IEnumerable<DemandModel>> GetAll();
        Task<DemandModel> Add(DemandModel model);
        Task<IEnumerable<CompleteDemandModel>> GetDemandsByClient(int clientId);
    }
}
