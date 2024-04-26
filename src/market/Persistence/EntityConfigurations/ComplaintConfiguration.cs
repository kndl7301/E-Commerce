using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ComplaintConfiguration : IEntityTypeConfiguration<Complaint>
{
    public void Configure(EntityTypeBuilder<Complaint> builder)
    {
        builder.ToTable("Complaints").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Title).HasColumnName("Title").IsRequired();
        builder.Property(c => c.ComplaintText).HasColumnName("ComplaintText").IsRequired();
        builder.Property(c => c.ComplaintDate).HasColumnName("ComplaintDate").IsRequired();
        builder.Property(c => c.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(c => c.CustomerEmail).HasColumnName("CustomerEmail").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}