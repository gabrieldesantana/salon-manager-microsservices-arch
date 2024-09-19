using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalonManager.Customers.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_customer_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: false),
                    FullName = table.Column<string>(type: "varchar(80)", nullable: false),
                    Nickname = table.Column<string>(type: "varchar(30)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(20)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    LastServiceName = table.Column<string>(type: "text", nullable: true),
                    LastServiceDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimesVisited = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserCreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    IsActived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
