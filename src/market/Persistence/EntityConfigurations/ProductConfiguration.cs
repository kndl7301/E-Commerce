using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.ProductName).HasColumnName("ProductName").IsRequired();
        builder.Property(p => p.ProductDescription).HasColumnName("ProductDescription").IsRequired();
        builder.Property(p => p.ProductImage).HasColumnName("ProductImage").IsRequired();
        builder.Property(p => p.Price).HasColumnName("Price").IsRequired();
        builder.Property(p => p.Stock).HasColumnName("Stock").IsRequired();
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}