using BackEndMonografia.Models.System;
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

        public async Task<IEnumerable<DescriptionModel>> GetAllAsync()
        {
            return await _descriptionRepository.GetAllAsync();
        }

        public async Task<IEnumerable<DescriptionModel>> GetByTypeId(int typeId)
        {
            return await _descriptionRepository.GetByTypeId(typeId);
        }

        public async Task<DescriptionModel> InsertAsync(DescriptionModel model)
        {
            return await _descriptionRepository.InsertAsync(model);
        }
    }
}
