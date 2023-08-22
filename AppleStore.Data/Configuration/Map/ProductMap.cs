using AppleStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppleStore.Data.Configuration.Map
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
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
              .HasMaxLength(60)
              .IsRequired();

            builder
              .Property(t => t.Price)
              .HasPrecision(10, 2)
              .IsRequired();

            builder
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
