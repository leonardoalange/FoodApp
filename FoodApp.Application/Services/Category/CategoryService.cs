﻿using AutoMapper;
using FoddApp.Application.Models.CategoryModels;
using FoodApp.Application.Services;
using FoodApp.Application.Services.Notification;
using FoodApp.Domain.Entities;
using FoodApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoddApp.Application.Services.Category
{
    public class CategoryService :AbstractService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,INotificationService notificationService ,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task Create(CategoryRequestModel request)
        {
            var category = _mapper.Map<CategoryEntity>(request);
            if (category.Invalid)
            {
                _notificationService.AddEntityNotification(category.ValidationResult);  
                return;
            }
            await _categoryRepository.Create(category);
        }

        public async Task Delete(Guid id)
        {
            var category = await _categoryRepository.GetById(id);
            if (VerifyEntityExistence<CategoryEntity>(category,_notificationService))
                return;
            category.Disable();
            await _categoryRepository.Update(id, category);
        }

        public Task<IList<CategoryResponseModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponseModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Guid id, CategoryRequestModel request)
        {
            var category = await _categoryRepository.GetById(id);
            if (VerifyEntityExistence<CategoryEntity>(category, _notificationService))
                return;
            category.Update(request.Name, request.Color, request.Description);
            if (category.Invalid)
            {
                _notificationService.AddEntityNotification(category.ValidationResult);
                return;
            }
            await _categoryRepository.Update(id, category);
        }
    }
}
