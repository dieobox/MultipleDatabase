using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickMonServer.Migrations
{
    public partial class UpdateDatabase001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "FirewallProduct",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductState",
                table: "FirewallProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DeviceClass",
                table: "Driver",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "Driver",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriverVersion",
                table: "Driver",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Driver",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Driver",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AntiVirusProduct",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductState",
                table: "AntiVirusProduct",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "FirewallProduct");

            migrationBuilder.DropColumn(
                name: "ProductState",
                table: "FirewallProduct");

            migrationBuilder.DropColumn(
                name: "DeviceClass",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "DriverVersion",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AntiVirusProduct");

            migrationBuilder.DropColumn(
                name: "ProductState",
                table: "AntiVirusProduct");
        }
    }
}
