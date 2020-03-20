using FoddApp.Application.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoddApp.Application.Services.Category
{
    public interface ICategoryService
    {
        Task Create(CategoryRequestModel request);
        Task Update(Guid id, CategoryRequestModel request);
        Task Delete(Guid id);
        Task<CategoryResponseModel> GetById(Guid id);
        Task<IList<CategoryResponseModel>> GetAll();
    }
}
