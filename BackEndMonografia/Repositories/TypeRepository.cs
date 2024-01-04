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
        public async Task<IEnumerable<TypeModel>> ObterTodos()
        {
            return await _baseRepository.ObterTodos();
        }

        public async Task<TypeModel> ObterPorId(int id)
        {
            return await _baseRepository.ObterPorId(id);
        }
        public async Task<int> Adicionar(TypeModel model)
        {
            return await _baseRepository.Adicionar(model);
        }
        public async Task<bool> Atualizar(TypeModel entity)
        {
            return await _baseRepository.Atualizar(entity);
        }
    }
}
