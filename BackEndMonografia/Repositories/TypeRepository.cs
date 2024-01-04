using BackEndMonografia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMonografia.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly IBaseRepository<TypeModel> _baseRepository;
        private readonly IDbConector dbConector;
        public TypeRepository(IBaseRepository<TypeModel> baseRepository, IDbConector dbConector)
        {
            _baseRepository = baseRepository;
            this.dbConector = dbConector;
        }
        public async Task<IEnumerable<TypeModel>> GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public async Task<TypeModel> GetById(int id)
        {
            return await _baseRepository.GetById(id);
        }
        public async Task<int> Add(TypeModel model)
        {
            return await _baseRepository.Add(model);
        }
        public async Task<bool> Update(TypeModel entity)
        {
            return await _baseRepository.Update(entity);
        }
    }
}
