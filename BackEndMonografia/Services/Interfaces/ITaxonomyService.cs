using BackEndMonografia.Models;

namespace BackEndMonografia.Services
{
    public interface ITaxonomyService
    {
        Task<TaxonomyModel> Adicionar(TaxonomyModel model);
        Task<IEnumerable<TaxonomyModel>> ObterTodos();
        Task<IEnumerable<TaxonomyModel>> ObterPorOrigem(int origemId);
        Task<IEnumerable<TaxonomyModel>> ObterPorTipoIdEOrigemId(int origemId, int typeId);
        Task<IEnumerable<TaxonomyModel>> ObterPorTipoIdEOrigemIdEDescricaoId(int origemId, int typeId, int descriptionId);
    }
}
