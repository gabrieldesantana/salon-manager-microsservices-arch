using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SalonManager.Appointments.Core.Entities;

namespace SalonManager.Appointments.Infrastructure.Configurations
{
    public class AppointmentEntityConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(p => p.Id);

            builder.Property(e => e.CustomerAppointmentId).IsRequired();
            builder.Property(e => e.ServiceAppointmentId).IsRequired();
            builder.Property(e => e.EmployeeAppointmentId).IsRequired();

            builder.Property(p => p.AppointmentDate)
            .HasColumnType("timestamp");

            builder.Property(p => p.FinishedDate)
            .HasColumnType("timestamp");

            builder.Property(p => p.Status).HasConversion<string>().IsRequired();
            builder.Property(p => p.Details).HasColumnType("varchar(150)").IsRequired();
            builder.Property(p => p.PaymentWay).HasColumnType("varchar(50)");
            builder.Property(p => p.PaymentMethod).HasColumnType("varchar(50)");
            builder.Property(p => p.Earnings).HasColumnType("numeric");
            builder.Property(p => p.Finished).HasDefaultValue(false).IsRequired();

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
