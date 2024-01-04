using BackEndMonografia.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Services.Interfaces
{
    public interface IDemandService
    {
        Task<IEnumerable<DemandModel>> ObterTodas();
        Task<DemandModel> Adicionar(DemandModel model);
        Task<IEnumerable<CompleteDemandModel>> ObterDemandasPorClienteId(int clientId);
    }
}
