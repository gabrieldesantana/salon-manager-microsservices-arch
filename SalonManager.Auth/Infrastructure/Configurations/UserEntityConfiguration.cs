using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalonManager.Auth.Core.Entities;

namespace SalonManager.Auth.Infrastructure.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FullName).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Login).HasColumnType("varchar(80)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("varchar(80)").IsRequired();
            builder.Property(p => p.Password).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Role).HasConversion<string>().IsRequired();

            //BaseEntity

            builder.Property(p => p.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnType("timestamp");

            builder.Property(p => p.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnType("timestamp");

            builder.Property(p => p.TenantId)
                .IsRequired();

            builder.Property(p => p.IsActived)
                .HasDefaultValue(true)
                .IsRequired();
            //
        }
    }
}
