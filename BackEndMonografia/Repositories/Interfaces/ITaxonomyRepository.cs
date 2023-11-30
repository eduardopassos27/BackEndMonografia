using BackEndMonografia.Models.System;
using System.Collections.Generic;

namespace BackEndMonografia.Repositories
{
    public interface ITaxonomyRepository
    {
        Task<TaxonomyModel> Add(TaxonomyModel model);

        Task<IEnumerable<TaxonomyModel>> GetAll();
    }
}
