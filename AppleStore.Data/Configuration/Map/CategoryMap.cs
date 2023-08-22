using AppleStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppleStore.Data.Configuration.Map
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                 .HasKey(key => key.Id);

            builder
                .Property(t => t.Title)
                .HasMaxLength(60)
                .IsRequired();

            builder
                .Property(t => t.Description)
                .HasMaxLength(600)
                .IsRequired();

            builder
                .Property(t => t.ImgUrl)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(p => p.CategoryId);

        }
    }
}
