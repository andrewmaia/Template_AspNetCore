using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.Infrastructure.PostgreSQL.Entities;


namespace ProjectName.Infrastructure.PostgreSQL.Mappings;

internal class OrderMap : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("Order");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status)
            .HasColumnType("order_status")
            .IsRequired();
    }
}