using AutoMapper;
using FoddApp.Application.Models.CategoryModels;
using FoddApp.Application.Services.Category;
using FoodApp.Application.Mappers.Category;
using FoodApp.Application.Services.Notification;
using FoodApp.Domain.Entities;
using FoodApp.Domain.Interfaces;
using NSubstitute;
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
                Description = "Spice Food"
            };

            await _categoryService
                .Create(model);

            await _categoriRepository
                .Received(1)
                .Create(Arg.Is<CategoryEntity>(category => category.Name == "Asian"
                                                        && category.Color == "red"
                                                        && category.Description == "Spice Food"));
        }
    }
}
