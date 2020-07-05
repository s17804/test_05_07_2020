﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    IdAction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeedSpecialEquipment = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "Firefighters",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firefighters", x => x.IdFirefighter);
                });

            migrationBuilder.CreateTable(
                name: "FireTrucks",
                columns: table => new
                {
                    IdFireTruck = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SpecialEquipment = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireTrucks", x => x.IdFireTruck);
                });

            migrationBuilder.CreateTable(
                name: "FirefighterActions",
                columns: table => new
                {
                    IdFirefighter = table.Column<int>(type: "int", nullable: false),
                    IdAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirefighterActions", x => new { x.IdFirefighter, x.IdAction });
                    table.ForeignKey(
                        name: "FK_FirefighterActions_Actions_IdAction",
                        column: x => x.IdAction,
                        principalTable: "Actions",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FirefighterActions_Firefighters_IdFirefighter",
                        column: x => x.IdFirefighter,
                        principalTable: "Firefighters",
                        principalColumn: "IdFirefighter",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireTruckActions",
                columns: table => new
                {
                    IdFireTruckAction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAction = table.Column<int>(type: "int", nullable: true),
                    IdFireTruck = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireTruckActions", x => x.IdFireTruckAction);
                    table.ForeignKey(
                        name: "FK_FireTruckActions_Actions_IdAction",
                        column: x => x.IdAction,
                        principalTable: "Actions",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FireTruckActions_FireTrucks_IdFireTruck",
                        column: x => x.IdFireTruck,
                        principalTable: "FireTrucks",
                        principalColumn: "IdFireTruck",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirefighterActions_IdAction",
                table: "FirefighterActions",
                column: "IdAction");

            migrationBuilder.CreateIndex(
                name: "IX_FireTruckActions_IdAction",
                table: "FireTruckActions",
                column: "IdAction");

            migrationBuilder.CreateIndex(
                name: "IX_FireTruckActions_IdFireTruck",
                table: "FireTruckActions",
                column: "IdFireTruck");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirefighterActions");

            migrationBuilder.DropTable(
                name: "FireTruckActions");

            migrationBuilder.DropTable(
                name: "Firefighters");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "FireTrucks");
        }
    }
}
