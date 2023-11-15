using BackEndMonografia.Models.System;
using BackEndMonografia.Repositories;

namespace BackEndMonografia.Services
{
    public class TypeService : ITypeService
    {
        public ITypeRepository _typeRepository;

        public TypeService (ITypeRepository repo)
        {
            _typeRepository = repo;
        }
        public async Task<IEnumerable<TypeModel>> GetAllTypesAsync()
        {
            return await _typeRepository.GetAll();
        }
    }
}
