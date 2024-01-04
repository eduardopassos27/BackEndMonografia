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

        public async Task<TaxonomyModel> Adicionar(TaxonomyModel model)
        {
            return await _taxonomyRepository.Add(model);
        }

        public async Task<IEnumerable<TaxonomyModel>> ObterTodos()
        {
            return await _taxonomyRepository.GetAll();
        }

        public async Task<IEnumerable<TaxonomyModel>> ObterPorOrigem(int origemId)
        {
            return await _taxonomyRepository.GetByOrigem(origemId);
        }

        public async Task<IEnumerable<TaxonomyModel>> ObterPorTipoIdEOrigemId(int origemId, int typeId)
        {
            return await _taxonomyRepository.GetByOrigemAndType(origemId, typeId);
        }

        public async Task<IEnumerable<TaxonomyModel>> ObterPorTipoIdEOrigemIdEDescricaoId(int origemId, int typeId, int descriptionId)
        {
            return await _taxonomyRepository.GetByOrigemAndTypeAndDescription(origemId, typeId, descriptionId);
        }
    }
}
