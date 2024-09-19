using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonManager.Appointments.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_appointment_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeAppointmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerAppointmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceAppointmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "varchar(150)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "varchar(50)", nullable: true),
                    PaymentWay = table.Column<string>(type: "varchar(50)", nullable: true),
                    Earnings = table.Column<double>(type: "numeric", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    FinishedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserCreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
