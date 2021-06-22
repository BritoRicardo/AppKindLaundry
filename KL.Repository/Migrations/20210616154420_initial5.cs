using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KL.Repository.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CodArea1 = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber1 = table.Column<int>(type: "int", nullable: false),
                    CodArea2 = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber2 = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlphaCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Territory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlphaCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CustomersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleService_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerscheduleServices",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    ScheduleServiceId = table.Column<int>(type: "int", nullable: false),
                    CustomerscheduleServiceCustomersId = table.Column<int>(type: "int", nullable: true),
                    CustomerscheduleServiceScheduleServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerscheduleServices", x => new { x.CustomersId, x.ScheduleServiceId });
                    table.ForeignKey(
                        name: "FK_CustomerscheduleServices_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerscheduleServices_CustomerscheduleServices_CustomerscheduleServiceCustomersId_CustomerscheduleServiceScheduleServiceId",
                        columns: x => new { x.CustomerscheduleServiceCustomersId, x.CustomerscheduleServiceScheduleServiceId },
                        principalTable: "CustomerscheduleServices",
                        principalColumns: new[] { "CustomersId", "ScheduleServiceId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerscheduleServices_ScheduleService_ScheduleServiceId",
                        column: x => x.ScheduleServiceId,
                        principalTable: "ScheduleService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerscheduleServices_CustomerscheduleServiceCustomersId_CustomerscheduleServiceScheduleServiceId",
                table: "CustomerscheduleServices",
                columns: new[] { "CustomerscheduleServiceCustomersId", "CustomerscheduleServiceScheduleServiceId" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerscheduleServices_ScheduleServiceId",
                table: "CustomerscheduleServices",
                column: "ScheduleServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleService_CustomersId",
                table: "ScheduleService",
                column: "CustomersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerscheduleServices");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "ScheduleService");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
