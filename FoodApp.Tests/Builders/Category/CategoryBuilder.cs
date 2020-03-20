using FoodApp.Domain.Entities;
using System;

namespace FoodApp.UnityTest.Builders.Category
{
    public class CategoryBuilder
    {
        private Guid _id;
        private string _categoryName;
        private string _categoryColor;
        private string _categoryDescription;

        public CategoryBuilder BuildCategoryId(Guid id)
        {
            _id = id;
            return this;
        }
        
        public CategoryBuilder BuildCategoryName(string categoryName)
        {
            _categoryName = categoryName;
            return this;
        }

        public CategoryBuilder BuildCategoryColor(string categoryColor)
        {
            _categoryColor = categoryColor;
            return this;
        }


        public CategoryBuilder BuildCategoryDescription(string description)
        {
            _categoryDescription = description;
            return this;
        }

        public CategoryEntity BuildCategory()
        {
            return new CategoryEntity(_categoryName, _categoryColor, _categoryDescription)
            {
                Id = _id
            };
        }
    }
}
