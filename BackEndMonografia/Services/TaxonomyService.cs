using BackEndMonografia.Models.System;
using BackEndMonografia.Repositories;

namespace BackEndMonografia.Services
{
    public class TaxonomyService : ITaxonomyService
    {
        private readonly ITaxonomyRepository _taxonomyRepository;

        public TaxonomyService(ITaxonomyRepository taxonomyRepository)
        {
            _taxonomyRepository = taxonomyRepository;
        }

        public async Task<TaxonomyModel> Add(TaxonomyModel model)
        {
            return await _taxonomyRepository.Add(model);
        }

        public async Task<IEnumerable<TaxonomyModel>> GetAll()
        {
            return await _taxonomyRepository.GetAll();
        }
    }
}
