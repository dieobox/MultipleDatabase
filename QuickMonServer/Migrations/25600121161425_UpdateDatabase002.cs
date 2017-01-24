using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickMonServer.Migrations
{
    public partial class UpdateDatabase002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AntiVirusProduct_Computer_ComputerId",
                table: "AntiVirusProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Division_DivisionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Company_CompanyId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Computer_Division_DivisionId",
                table: "Computer");

            migrationBuilder.DropForeignKey(
                name: "FK_Disk_Computer_ComputerId",
                table: "Disk");

            migrationBuilder.DropForeignKey(
                name: "FK_Division_Branch_BranchId",
                table: "Division");

            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Computer_ComputerId",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_ErrorException_Computer_ComputerId",
                table: "ErrorException");

            migrationBuilder.DropForeignKey(
                name: "FK_FirewallProduct_Computer_ComputerId",
                table: "FirewallProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Harddisk_Computer_ComputerId",
                table: "Harddisk");

            migrationBuilder.DropForeignKey(
                name: "FK_LogicalDisk_Computer_ComputerId",
                table: "LogicalDisk");

            migrationBuilder.DropForeignKey(
                name: "FK_Memory_Computer_ComputerId",
                table: "Memory");

            migrationBuilder.DropForeignKey(
                name: "FK_NetworkAdapter_Computer_ComputerId",
                table: "NetworkAdapter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Division",
                table: "Division");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Computer",
                table: "Computer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branch",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Division",
                newName: "Divisions");

            migrationBuilder.RenameTable(
                name: "Computer",
                newName: "Computers");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "Branch",
                newName: "Branches");

            migrationBuilder.RenameIndex(
                name: "IX_Division_BranchId",
                table: "Divisions",
                newName: "IX_Divisions_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Computer_DivisionId",
                table: "Computers",
                newName: "IX_Computers_DivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_CompanyId",
                table: "Branches",
                newName: "IX_Branches_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Divisions",
                table: "Divisions",
                column: "DivisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computers",
                table: "Computers",
                column: "ComputerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_AntiVirusProduct_Computers_ComputerId",
                table: "AntiVirusProduct",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Divisions_DivisionId",
                table: "AspNetUsers",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Companies_CompanyId",
                table: "Branches",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Divisions_DivisionId",
                table: "Computers",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disk_Computers_ComputerId",
                table: "Disk",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Branches_BranchId",
                table: "Divisions",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Computers_ComputerId",
                table: "Driver",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorException_Computers_ComputerId",
                table: "ErrorException",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FirewallProduct_Computers_ComputerId",
                table: "FirewallProduct",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Harddisk_Computers_ComputerId",
                table: "Harddisk",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogicalDisk_Computers_ComputerId",
                table: "LogicalDisk",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Memory_Computers_ComputerId",
                table: "Memory",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkAdapter_Computers_ComputerId",
                table: "NetworkAdapter",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AntiVirusProduct_Computers_ComputerId",
                table: "AntiVirusProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Divisions_DivisionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Companies_CompanyId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Divisions_DivisionId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Disk_Computers_ComputerId",
                table: "Disk");

            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Branches_BranchId",
                table: "Divisions");

            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Computers_ComputerId",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_ErrorException_Computers_ComputerId",
                table: "ErrorException");

            migrationBuilder.DropForeignKey(
                name: "FK_FirewallProduct_Computers_ComputerId",
                table: "FirewallProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Harddisk_Computers_ComputerId",
                table: "Harddisk");

            migrationBuilder.DropForeignKey(
                name: "FK_LogicalDisk_Computers_ComputerId",
                table: "LogicalDisk");

            migrationBuilder.DropForeignKey(
                name: "FK_Memory_Computers_ComputerId",
                table: "Memory");

            migrationBuilder.DropForeignKey(
                name: "FK_NetworkAdapter_Computers_ComputerId",
                table: "NetworkAdapter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Divisions",
                table: "Divisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Computers",
                table: "Computers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.RenameTable(
                name: "Divisions",
                newName: "Division");

            migrationBuilder.RenameTable(
                name: "Computers",
                newName: "Computer");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "Branch");

            migrationBuilder.RenameIndex(
                name: "IX_Divisions_BranchId",
                table: "Division",
                newName: "IX_Division_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Computers_DivisionId",
                table: "Computer",
                newName: "IX_Computer_DivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_CompanyId",
                table: "Branch",
                newName: "IX_Branch_CompanyId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Division",
                table: "Division",
                column: "DivisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computer",
                table: "Computer",
                column: "ComputerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branch",
                table: "Branch",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_AntiVirusProduct_Computer_ComputerId",
                table: "AntiVirusProduct",
                column: "ComputerId",
                principalTable: "Computer",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Division_DivisionId",
                table: "AspNetUsers",
                column: "DivisionId",
                principalTable: "Division",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Company_CompanyId",
                table: "Branch",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computer_Division_DivisionId",
                table: "Computer",
                column: "DivisionId",
                principalTable: "Division",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disk_Computer_ComputerId",
                table: "Disk",
                column: "ComputerId",
                principalTable: "Computer",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Division_Branch_BranchId",
                table: "Division",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Computer_ComputerId",
                table: "Driver",
                column: "ComputerId",
                principalTable: "Computer",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ErrorException_Computer_ComputerId",
                table: "ErrorException",
                column: "ComputerId",
                principalTable: "Computer",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FirewallProduct_Computer_ComputerId",
                table: "FirewallProduct",
                column: "ComputerId",
                principalTable: "Computer",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Harddisk_Computer_ComputerId",
                table: "Harddisk",
                column: "ComputerId",
                principalTable: "Computer",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogicalDisk_Computer_ComputerId",
                table: "LogicalDisk",
                column: "ComputerId",
                principalTable: "Computer",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Memory_Computer_ComputerId",
                table: "Memory",
                column: "ComputerId",
                principalTable: "Computer",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkAdapter_Computer_ComputerId",
                table: "NetworkAdapter",
                column: "ComputerId",
                principalTable: "Computer",
                principalColumn: "ComputerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
