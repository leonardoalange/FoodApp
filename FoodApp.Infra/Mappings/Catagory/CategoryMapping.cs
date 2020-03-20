using FoodApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodApp.Infra.Mappings.Catagory
{
    public class CategoryMapping : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.Property(category => category.Name).IsRequired();
            builder.Property(category => category.Color).IsRequired();
            builder.Property(category => category.Description).IsRequired();
            builder.Property(category => category.IsEnabled).IsRequired();
            builder.Property(category => category.CreateDate).IsRequired();
            builder.Property(category => category.ModifyDate).IsRequired();
        }
    }
}
