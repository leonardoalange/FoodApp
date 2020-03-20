using FoodApp.Domain.FluentValidatiors;

namespace FoodApp.Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }

        public CategoryEntity()
        {
        }

        public CategoryEntity(string name, string color, string description)
        {
            Name = name;
            Color = color;
            Description = description;
            Validate(this, new CategoryValidatior());
        }

        public void Update(string name, string color, string description)
        {
            Name = name;
            Color = color;
            Description = description;
            Validate(this, new CategoryValidatior());
        }


    }
}
