
using BackEndMonografia.Models;

namespace BackEndMonografia.Services.Interfaces
{
    public interface IDescriptionService
    {
        Task<IEnumerable<DescriptionModel>> ObterPorTipoId(int typeId);
        Task<IEnumerable<DescriptionModel>> ObterTodos();
        Task<DescriptionModel> Adicionar(DescriptionModel model);
    }
}
