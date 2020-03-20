using FoodApp.Domain.Entities;
using FoodApp.Domain.Interfaces;
using FoodApp.Infra.Context;
using FoodApp.Infra.Repositories.Generic;

namespace FoodApp.Infra.Repositories.Category
{
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
