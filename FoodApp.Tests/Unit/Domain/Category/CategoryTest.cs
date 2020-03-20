using FoodApp.Domain.Entities;
using FoodApp.UnityTest.Builders.Category;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace FoodApp.Tests.Unit.Domain.Category
{
   public class CategoryTest
    {
        [Fact]
        public void ShouldDisableCategory()
        {
            var category = CreateCategory(Guid.NewGuid());

            category.Disable();

            category.IsEnabled.Should().BeFalse();
        }

        [Fact]
        public void ShouldUpdateCategory()
        {
            var categoryId = Guid.NewGuid();
            var category = CreateCategory(categoryId);

            category.Update("German", "blue", "With Beer");

            category.Name.Should().Be("German");
            category.Color.Should().Be("blue");
            category.Description.Should().Be("With Beer");
            category.Id.Should().Be(categoryId);
        }

        public CategoryEntity CreateCategory(Guid id)
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
