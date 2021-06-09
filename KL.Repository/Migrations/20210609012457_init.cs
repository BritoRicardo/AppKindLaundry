﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KL.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CodArea1 = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNumber1 = table.Column<int>(type: "INTEGER", nullable: false),
                    CodArea2 = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNumber2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Adress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Neighborhood = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AlphaCode = table.Column<string>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Territory = table.Column<string>(type: "TEXT", nullable: false),
                    AlphaCode = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<int>(type: "INTEGER", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClientsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleService_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientScheduleServices",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduleServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientScheduleServiceClientsId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientScheduleServiceScheduleServiceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientScheduleServices", x => new { x.ClientsId, x.ScheduleServiceId });
                    table.ForeignKey(
                        name: "FK_ClientScheduleServices_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientScheduleServices_ClientScheduleServices_ClientScheduleServiceClientsId_ClientScheduleServiceScheduleServiceId",
                        columns: x => new { x.ClientScheduleServiceClientsId, x.ClientScheduleServiceScheduleServiceId },
                        principalTable: "ClientScheduleServices",
                        principalColumns: new[] { "ClientsId", "ScheduleServiceId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientScheduleServices_ScheduleService_ScheduleServiceId",
                        column: x => x.ScheduleServiceId,
                        principalTable: "ScheduleService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientScheduleServices_ClientScheduleServiceClientsId_ClientScheduleServiceScheduleServiceId",
                table: "ClientScheduleServices",
                columns: new[] { "ClientScheduleServiceClientsId", "ClientScheduleServiceScheduleServiceId" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientScheduleServices_ScheduleServiceId",
                table: "ClientScheduleServices",
                column: "ScheduleServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleService_ClientsId",
                table: "ScheduleService",
                column: "ClientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientScheduleServices");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "ScheduleService");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}