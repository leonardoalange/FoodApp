using FoodApp.Domain.Entities;
using FoodApp.UnityTest.Builders.Category;
using System;
using Xunit;
using FluentAssertions;

namespace FoodApp.UnityTest.Unit.Domain.Category
{
    public class CategoryTest
    {
        [Fact]
        public void ShuoldCreateCategory()
        {
            var category = new CategoryEntity("Asian", "red","Spice food");
            category.Color.Should().Be("red");
            category.Name.Should().Be("Asian");
            category.Description.Should().Be("Spice food");
            category.IsEnabled.Should().BeTrue();
        }

        [Fact]
        public void ShuoldUpdateCategory()
        {
            var category = new CategoryEntity("Asian", "red", "Spice food");

            category.Update("German", "blue", "Traditional food");

            category.Color.Should().Be("blue");
            category.Name.Should().Be("German");
            category.Description.Should().Be("Traditional food");
        }

        [Fact]
        public void ShuoldDisableCategory()
        {
            var category = new CategoryEntity("Asian", "red", "Spice food");
            category.Disable();
            category.Color.Should().Be("red");
            category.Name.Should().Be("Asian");
            category.Description.Should().Be("Spice food");
            category.IsEnabled.Should().BeFalse();
        }
    }
}
