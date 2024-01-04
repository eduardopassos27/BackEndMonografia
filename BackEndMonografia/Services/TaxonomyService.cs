using BackEndMonografia.Models;
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

        public async Task<IEnumerable<TaxonomyModel>> GetByOrigem(int origemId)
        {
            return await _taxonomyRepository.GetByOrigem(origemId);
        }

        public async Task<IEnumerable<TaxonomyModel>> GetByOrigemAndType(int origemId, int typeId)
        {
            return await _taxonomyRepository.GetByOrigemAndType(origemId, typeId);
        }

        public async Task<IEnumerable<TaxonomyModel>> GetByOrigemAndTypeAndDescription(int origemId, int typeId, int descriptionId)
        {
            return await _taxonomyRepository.GetByOrigemAndTypeAndDescription(origemId, typeId, descriptionId);
        }
    }
}
