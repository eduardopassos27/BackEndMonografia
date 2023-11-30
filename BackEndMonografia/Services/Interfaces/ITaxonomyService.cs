using BackEndMonografia.Models.System;

namespace BackEndMonografia.Services
{
    public interface ITaxonomyService
    {
        Task<TaxonomyModel> Add(TaxonomyModel model);
        Task<IEnumerable<TaxonomyModel>> GetAll();
    }
}
