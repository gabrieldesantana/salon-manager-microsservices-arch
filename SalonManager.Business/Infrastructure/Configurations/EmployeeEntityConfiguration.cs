using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Infrastructure.Configurations
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(p => p.Id);

            builder.Property(e => e.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(e => e.CompanyId).HasColumnName("CompanyId");

            builder.Property(p => p.Cpf).HasColumnType("varchar(14)").IsRequired();
            builder.Property(p => p.FullName).HasColumnType("varchar(80)").IsRequired();
            builder.Property(p => p.Nickname).HasColumnType("varchar(30)").IsRequired();
            builder.Property(p => p.Gender).HasColumnType("varchar(20)").IsRequired();
            builder.Property(p => p.PhoneNumber).HasColumnType("varchar(20)").IsRequired();

            builder.Property(p => p.BirthDate)
            .HasColumnName("BirthDate")
            .HasColumnType("timestamp without time zone");

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
        }

    }
}
