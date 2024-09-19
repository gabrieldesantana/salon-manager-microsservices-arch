using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalonManager.Customers.Core.Entities;

namespace SalonManager.Customers.Infrastructure.Configurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(p => p.Id);

            builder.Property(e => e.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(p => p.Cpf).HasColumnType("varchar(14)").IsRequired();
            builder.Property(p => p.FullName).HasColumnType("varchar(80)").IsRequired();
            builder.Property(p => p.Nickname).HasColumnType("varchar(30)").IsRequired();
            builder.Property(p => p.Gender).HasColumnType("varchar(20)").IsRequired();
            builder.Property(p => p.PhoneNumber).HasColumnType("varchar(20)").IsRequired();

            builder.Property(p => p.BirthDate)
            .HasColumnName("BirthDate")
            .HasColumnType("timestamp without time zone");

            builder.Property(p => p.LastServiceName);
            builder.Property(p => p.LastServiceDate);

            builder.Property(p => p.TimesVisited);

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
