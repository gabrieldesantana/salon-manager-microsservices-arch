using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalonManager.Business.Core.Entities;

namespace SalonManager.Business.Infrastructure.Configurations
{
    public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(p => p.CNPJ).HasColumnType("varchar(18)").IsRequired();

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
