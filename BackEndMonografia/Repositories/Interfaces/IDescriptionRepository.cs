using BackEndMonografia.Models;

namespace BackEndMonografia.Repositories.Interfaces
{
    public interface IDescriptionRepository
    {
        Task<IEnumerable<DescriptionModel>> GetByTypeId(int typeId);
        Task<IEnumerable<DescriptionModel>> GetAllAsync();
        Task<DescriptionModel> InsertAsync(DescriptionModel model);
    }
}
