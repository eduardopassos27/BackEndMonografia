
using BackEndMonografia.Models.System;

namespace BackEndMonografia.Services.Interfaces
{
    public interface IDescriptionService
    {
        Task<IEnumerable<DescriptionModel>> GetByTypeId(int typeId);
        Task<IEnumerable<DescriptionModel>> GetAllAsync();
        Task<DescriptionModel> InsertAsync(DescriptionModel model);
    }
}
