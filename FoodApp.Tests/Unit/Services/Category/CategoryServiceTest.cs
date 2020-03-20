using AutoMapper;
using FoddApp.Application.Models.CategoryModels;
using FoddApp.Application.Services.Category;
using FoodApp.Application.Mappers.Category;
using FoodApp.Application.Services.Notification;
using FoodApp.Domain.Entities;
using FoodApp.Domain.Interfaces;
using FoodApp.UnityTest.Builders.Category;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FoodApp.UnityTest.Unit.Application.Services.Category
{
    public class CategoryServiceTest
    {
        private readonly ICategoryRepository _categoriRepository;
        private readonly ICategoryService _categoryService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public CategoryServiceTest()
        {
            _categoriRepository = Substitute.For<ICategoryRepository>();
            _notificationService = Substitute.For<INotificationService>();
            _mapper = new Mapper(new MapperConfiguration(configuration =>
            configuration.AddProfile<CatagoryAutoMap>()));
            _categoryService = new CategoryService(_categoriRepository, _notificationService, _mapper);
        }

        [Fact]
        public async Task ShouldCreateCategory()
        {
            var model = new CategoryRequestModel()
            {
                Name = "Asian",
                Color= "red",
                Description = "Spice food"
            };

            await _categoryService
                .Create(model);

            await _categoriRepository
                .Received(1)
                .Create(Arg.Is<CategoryEntity>(category => category.Name == "Asian"
                                                        && category.Color == "red"
                                                        && category.Description == "Spice food"
                                                        && category.IsEnabled == true));
        }

        [Fact]
        public async Task ShouldDeleteCategory()
        {
            var categoryId = Guid.NewGuid();
           var category = CreateCategory(categoryId);
          
            _categoriRepository
                .GetById(categoryId)
                .Returns(category);

          await  _categoryService
                .Delete(categoryId);

            await _categoriRepository.Received(1).Update(categoryId,Arg.Is<CategoryEntity>(category => category.Name == "Asian"
                                                        && category.Color == "red"
                                                        && category.Description == "Spice food"
                                                        && category.IsEnabled == false));

        }

        private CategoryEntity CreateCategory(Guid id)
        {
            return new CategoryBuilder()
                .BuildCategoryName("Asian")
                .BuildCategoryColor("red")
                .BuildCategoryDescription("Spice food")
                .BuildCategoryId(id)
                .BuildCategory();
        }
    }
}
