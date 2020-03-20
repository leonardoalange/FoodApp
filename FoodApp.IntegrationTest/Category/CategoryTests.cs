using FoddApp.Application.Models.CategoryModels;
using FoodApp.Domain.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FoodApp.IntegrationTest.Category
{
    public class CategoryTests : IntegrationTestBase
    {
        [Fact]
        public async Task ShouldFailWhenNameInvalid()
        {
            var category = new CategoryRequestModel()
            {
                Name = "",
                Color = "red",
                Description = "Spice Food"
            };
            var validationErrorsMessages = await GetErrorsOnCreate(category);
            Assert.True(validationErrorsMessages[0]._Message == ErrorMessages.ErrorName);
        }

        [Fact]
        public async Task ShouldFailWhenColorInvalid()
        {
            var category = new CategoryRequestModel()
            {
                Name = "Asian",
                Color = "",
                Description = "Spice Food"
            };
            var validationErrorsMessages = await GetErrorsOnCreate(category);
            Assert.True(validationErrorsMessages[0]._Message == ErrorMessages.ErrorColor);
        }

        [Fact]
        public async Task ShouldFailWhenDescriptionInvalid()
        {
            var category = new CategoryRequestModel()
            {
                Name = "Asian",
                Color = "red",
                Description = ""
            };
            var validationErrorsMessages = await GetErrorsOnCreate(category);
            Assert.True(validationErrorsMessages[0]._Message == ErrorMessages.ErrorDescription);
        }

        [Fact]
        public async Task ShouldFailDeleteCategory()
        {
            var validationErrorsMessages = await GetErrorsOnDelete();
            Assert.True(validationErrorsMessages[0]._Key == "CategoryEntityNotFound");
        }

        public async Task<List<ValidationErrorResponse>> GetErrorsOnCreate(CategoryRequestModel categoryRequestModel)
        {
            var serializedCategory = JsonConvert.SerializeObject(categoryRequestModel);
            var response = await _client.PostAsync($"/api/category", new StringContent(serializedCategory, Encoding.UTF8,"application/json"));
            return await response.Content.ReadAsAsync<List<ValidationErrorResponse>>();
        }

        private async Task<List<ValidationErrorResponse>> GetErrorsOnDelete()
        {
            var categoryId = Guid.NewGuid();
            var response = await _client.DeleteAsync($"/api/category/{categoryId}");
            return await response.Content.ReadAsAsync<List<ValidationErrorResponse>>();
        }
    }
}
