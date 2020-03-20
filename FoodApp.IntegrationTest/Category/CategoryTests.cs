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

        public async Task<List<ValidationErrorResponse>> GetErrorsOnCreate(CategoryRequestModel categoryRequestModel)
        {
            var serializedCategory = JsonConvert.SerializeObject(categoryRequestModel);
            var response = await _client.PostAsync($"/api/category", new StringContent(serializedCategory, Encoding.UTF8,"application/json"));
            return await response.Content.ReadAsAsync<List<ValidationErrorResponse>>();
        }
    }
}
