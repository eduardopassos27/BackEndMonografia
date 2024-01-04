using BackEndMonografia.Models;
using BackEndMonografia.Repositories.Interfaces;
using BackEndMonografia.Services.Interfaces;
using System;

namespace BackEndMonografia.Services
{
    public class DescriptionService : IDescriptionService
    {
        private readonly IDescriptionRepository _descriptionRepository;

        public DescriptionService(IDescriptionRepository descriptionRepository)
        {
            _descriptionRepository = descriptionRepository;
        }

        public async Task<IEnumerable<DescriptionModel>> ObterTodos()
        {
            return await _descriptionRepository.GetAllAsync();
        }

        public async Task<IEnumerable<DescriptionModel>> ObterPorTipoId(int typeId)
        {
            return await _descriptionRepository.GetByTypeId(typeId);
        }

        public async Task<DescriptionModel> Adicionar(DescriptionModel model)
        {
            return await _descriptionRepository.InsertAsync(model);
        }
    }
}
