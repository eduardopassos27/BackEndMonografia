using BackEndMonografia.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMonografia.Repositories
{
    public interface ITypeRepository : IBaseRepository<TypeModel>
    {

        //private readonly IBaseRepository<TypeModel> _baseRepository;
        //public TypeRepository(IBaseRepository<TypeModel> baseRepository )
        //{
        //    _baseRepository = baseRepository;
        //}

        //public async Task<IEnumerable<TypeModel>> GetAll()
        //{
        //    return await _baseRepository.GetAll();
        //}

        //public async Task<TypeModel> GetById(int id)
        //{
        //    return await _baseRepository.GetById(id);
        //}
        //public async Task<int> Create(TypeModel model)
        //{
        //    return await _baseRepository.Add(model);
        //}
        //public async Task<IEnumerable<TypeModel>> Update()
        //{
        //    return await _baseRepository.GetAll();
        //}
        //public async Task<IEnumerable<TypeModel>> GetAll()
        //{
        //    return await _baseRepository.GetAll();
        //}
    }
}
