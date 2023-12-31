﻿using BackEndMonografia.Models.System;

namespace BackEndMonografia.Services
{
    public interface ITypeService
    {
        Task<IEnumerable<TypeModel>> GetAllTypesAsync();
        Task<int> InsertTypeAsync(TypeModel model);
    }
}
