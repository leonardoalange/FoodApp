using AutoMapper;
using FoddApp.Application.AutoMappers.CategoryMapper;
using FoddApp.Application.Services.CategoryServices;
using FoodApp.Domain.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodApp.UnityTest.Unit.Application.Services.Category
{
    public class CategoryServiceTest
    {
        private readonly ICategoryRepository _categoriRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryServiceTest()
        {
            _categoriRepository = Substitute.For<ICategoryRepository>();
            _mapper = new Mapper(new MapperConfiguration(configuration =>
            configuration.AddProfile<CatagoryAutoMap>()));
            _categoryService = new CategoryService(_categoriRepository, _mapper);
        }
    }
}
