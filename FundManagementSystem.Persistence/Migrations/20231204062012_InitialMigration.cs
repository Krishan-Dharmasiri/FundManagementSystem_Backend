using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundManagementSystem.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(2023, 12, 4, 11, 50, 12, 550, DateTimeKind.Local).AddTicks(5816), "kush@gmail.com", null, null, "Kushi Saranya" });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "Id", "ClientId", "CreatedBy", "CreatedDate", "EndDate", "LastModifiedBy", "LastModifiedDate", "Name", "StartDate", "Type" },
                values: new object[] { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(2023, 12, 4, 11, 50, 12, 550, DateTimeKind.Local).AddTicks(5964), null, null, null, "Portfolio Two", new DateTime(2023, 12, 4, 11, 50, 12, 550, DateTimeKind.Local).AddTicks(5966), "FIXED_INCOME" });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "Id", "ClientId", "CreatedBy", "CreatedDate", "EndDate", "LastModifiedBy", "LastModifiedDate", "Name", "StartDate", "Type" },
                values: new object[] { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(2023, 12, 4, 11, 50, 12, 550, DateTimeKind.Local).AddTicks(5946), null, null, null, "Portfolio One", new DateTime(2023, 12, 4, 11, 50, 12, 550, DateTimeKind.Local).AddTicks(5952), "EQUITY" });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ClientId",
                table: "Portfolios",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
