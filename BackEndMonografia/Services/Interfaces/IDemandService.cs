using BackEndMonografia.Models.System;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Services.Interfaces
{
    public interface IDemandService
    {
        Task<IEnumerable<DemandModel>> GetAll();
        Task<DemandModel> Add(DemandModel model);
        Task<IEnumerable<CompleteDemandModel>> GetDemandsByClient(int clientId);
    }
}
