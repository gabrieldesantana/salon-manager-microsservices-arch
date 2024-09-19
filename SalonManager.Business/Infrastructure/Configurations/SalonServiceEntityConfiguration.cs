using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Infrastructure.Configurations
{
    public class SalonServiceEntityConfiguration : IEntityTypeConfiguration<SalonService>
    {
        public void Configure(EntityTypeBuilder<SalonService> builder)
        {
            builder.ToTable("SalonServices");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasColumnType("varchar(80)").IsRequired();
            builder.Property(p => p.Category).HasColumnType("varchar(40)").IsRequired();
            builder.Property(p => p.Price).HasColumnType("real");

            //BaseEntity

            builder.Property(p => p.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnType("timestamp");

            builder.Property(p => p.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnType("timestamp");

            builder.Property(p => p.TenantId)
                .IsRequired();

            builder.Property(p => p.UserCreatorId)
                .IsRequired();

            builder.Property(p => p.IsActived)
                .HasDefaultValue(true)
                .IsRequired();

            //
        }

    }
}
