using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.OrderNumber).HasColumnName("OrderNumber").IsRequired();
        builder.Property(o => o.Totalprice).HasColumnName("Totalprice").IsRequired();
        builder.Property(o => o.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(o => o.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(o => o.PaymentId).HasColumnName("PaymentId").IsRequired();
        builder.Property(o => o.OrderDate).HasColumnName("OrderDate").IsRequired();
        builder.Property(o => o.Status).HasColumnName("Status").IsRequired();
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
    }
}