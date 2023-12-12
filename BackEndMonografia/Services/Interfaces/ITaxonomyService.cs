using BackEndMonografia.Models.System;

namespace BackEndMonografia.Services
{
    public interface ITaxonomyService
    {
        Task<TaxonomyModel> Add(TaxonomyModel model);
        Task<IEnumerable<TaxonomyModel>> GetAll();
        Task<IEnumerable<TaxonomyModel>> GetByOrigem(int origemId);
        Task<IEnumerable<TaxonomyModel>> GetByOrigemAndType(int origemId, int typeId);
        Task<IEnumerable<TaxonomyModel>> GetByOrigemAndTypeAndDescription(int origemId, int typeId, int descriptionId);
    }
}
