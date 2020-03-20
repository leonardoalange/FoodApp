using FoodApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace FoodApp.UnityTest.Builders.Category
{
   public class CategoryBuilder
    {
        private string _categoryName;
        private string _categoryColor;
        private string _categoryDescription;

        public void BuildCategoryName(string categoryName)
        {
            _categoryName = categoryName;
        }

        public void BuildCategoryColor(string categoryColor)
        {
            _categoryColor = categoryColor;
        }


        public void BuildDescription(string description)
        {
            _categoryDescription = description;
        }

        public CategoryEntity BuildCategory()
        {
            return new CategoryEntity(_categoryName, _categoryColor,_categoryDescription);
        }
    }
}
