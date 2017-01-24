using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuickMonServer.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActiveDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 250, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    Enable = table.Column<bool>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Fax = table.Column<string>(maxLength: 50, nullable: true),
                    LicenseKey = table.Column<string>(nullable: true),
                    MaxBranch = table.Column<int>(nullable: false),
                    MaxDivision = table.Column<int>(nullable: false),
                    MaxManager = table.Column<int>(nullable: false),
                    MaxStaff = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    State = table.Column<string>(maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(maxLength: 100, nullable: true),
                    BranchName = table.Column<string>(maxLength: 250, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    Fax = table.Column<string>(maxLength: 50, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    State = table.Column<string>(maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(maxLength: 50, nullable: true),
                    UseCompanyInfo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branch_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    DivisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Address2 = table.Column<string>(maxLength: 100, nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    DivisionName = table.Column<string>(maxLength: 250, nullable: true),
                    Fax = table.Column<string>(maxLength: 50, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    State = table.Column<string>(maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(maxLength: 50, nullable: true),
                    UseBranchInfo = table.Column<bool>(nullable: false),
                    UseCompanyInfo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionId);
                    table.ForeignKey(
                        name: "FK_Division_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DivisionId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<string>(maxLength: 20, nullable: true),
                    Lastname = table.Column<string>(maxLength: 100, nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Computer",
                columns: table => new
                {
                    ComputerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BiosBIOSVersion = table.Column<string>(maxLength: 50, nullable: true),
                    BiosBuildNumber = table.Column<string>(maxLength: 50, nullable: true),
                    BiosCaption = table.Column<string>(maxLength: 50, nullable: true),
                    BiosManufacturer = table.Column<string>(maxLength: 50, nullable: true),
                    BiosSerialNumber = table.Column<string>(maxLength: 50, nullable: true),
                    BiosStatus = table.Column<string>(maxLength: 50, nullable: true),
                    BoardManufacturer = table.Column<string>(maxLength: 50, nullable: true),
                    BoardModel = table.Column<string>(maxLength: 50, nullable: true),
                    BoardPartNumber = table.Column<string>(maxLength: 50, nullable: true),
                    BoardSerialNumber = table.Column<string>(maxLength: 50, nullable: true),
                    BoardStatus = table.Column<string>(maxLength: 50, nullable: true),
                    CPU = table.Column<string>(maxLength: 50, nullable: true),
                    CPUCurrentClock = table.Column<int>(nullable: false),
                    CPUMaxClockSpeed = table.Column<int>(nullable: false),
                    CPUStatus = table.Column<string>(maxLength: 50, nullable: true),
                    ChassisSKUNumber = table.Column<string>(maxLength: 50, nullable: true),
                    DivisionId = table.Column<int>(nullable: false),
                    Domain = table.Column<string>(maxLength: 50, nullable: true),
                    Manufacturer = table.Column<string>(maxLength: 50, nullable: true),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    NumberOfLogicalProcessors = table.Column<int>(nullable: false),
                    NumberOfProcessors = table.Column<int>(nullable: false),
                    PCSystemType = table.Column<string>(maxLength: 50, nullable: true),
                    ThermalState = table.Column<string>(maxLength: 50, nullable: true),
                    TotalPhysicalMemory = table.Column<long>(nullable: false),
                    WindowsActivationRequired = table.Column<int>(nullable: false),
                    WindowsBuildNumber = table.Column<string>(maxLength: 50, nullable: true),
                    WindowsCaption = table.Column<string>(maxLength: 50, nullable: true),
                    WindowsCurrentTimeZone = table.Column<short>(maxLength: 50, nullable: false),
                    WindowsDirectory = table.Column<string>(maxLength: 50, nullable: true),
                    WindowsFirewallEnabled = table.Column<bool>(nullable: false),
                    WindowsFreePhysicalMemory = table.Column<long>(nullable: false),
                    WindowsFreeSpaceInPagingFiles = table.Column<long>(nullable: false),
                    WindowsFreeVirtualMemory = table.Column<long>(nullable: false),
                    WindowsInstallDate = table.Column<string>(maxLength: 50, nullable: true),
                    WindowsIsNotificationOn = table.Column<int>(nullable: false),
                    WindowsLocalDateTime = table.Column<string>(maxLength: 50, nullable: true),
                    WindowsLocale = table.Column<string>(maxLength: 50, nullable: true),
                    WindowsOSArchitecture = table.Column<string>(maxLength: 50, nullable: true),
                    WindowsOSLanguage = table.Column<int>(maxLength: 50, nullable: false),
                    WindowsOperatingSystemSKU = table.Column<int>(nullable: false),
                    WindowsProductID = table.Column<string>(maxLength: 50, nullable: true),
                    WindowsRemainingEvaluationPeriod = table.Column<int>(nullable: false),
                    WindowsRemainingGracePeriod = table.Column<int>(nullable: false),
                    WindowsSerialNumber = table.Column<string>(maxLength: 50, nullable: true),
                    WindowsStatus = table.Column<string>(maxLength: 50, nullable: true),
                    WindowsSystemDirectory = table.Column<string>(maxLength: 50, nullable: true),
                    WindowsSystemDrive = table.Column<string>(maxLength: 50, nullable: true),
                    WindowsTotalSwapSpaceSize = table.Column<long>(nullable: false),
                    WindowsTotalVirtualMemorySize = table.Column<long>(nullable: false),
                    WindowsTotalVisibleMemorySize = table.Column<long>(nullable: false),
                    Workgroup = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computer", x => x.ComputerId);
                    table.ForeignKey(
                        name: "FK_Computer_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AntiVirusProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComputerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntiVirusProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AntiVirusProduct_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(maxLength: 50, nullable: true),
                    ComputerId = table.Column<int>(nullable: false),
                    InterfaceType = table.Column<string>(maxLength: 50, nullable: true),
                    Manufacturer = table.Column<string>(maxLength: 50, nullable: true),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Size = table.Column<long>(nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disk_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComputerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Driver_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ErrorException",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComputerId = table.Column<int>(nullable: false),
                    Exception = table.Column<string>(maxLength: 50, nullable: true),
                    InnerException = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorException", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErrorException_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FirewallProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComputerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirewallProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FirewallProduct_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Harddisk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(maxLength: 50, nullable: true),
                    Capacity = table.Column<double>(maxLength: 50, nullable: false),
                    ComputerId = table.Column<int>(nullable: false),
                    FreeSpace = table.Column<double>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    SerialNo = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harddisk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harddisk_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogicalDisk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(maxLength: 50, nullable: true),
                    ComputerId = table.Column<int>(nullable: false),
                    DriveType = table.Column<string>(maxLength: 50, nullable: true),
                    FileSystem = table.Column<string>(maxLength: 50, nullable: true),
                    FreeSpace = table.Column<long>(nullable: false),
                    Size = table.Column<long>(nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogicalDisk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogicalDisk_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankLabel = table.Column<string>(maxLength: 50, nullable: true),
                    Capacity = table.Column<long>(nullable: false),
                    Caption = table.Column<string>(maxLength: 50, nullable: true),
                    ComputerId = table.Column<int>(nullable: false),
                    DeviceLocator = table.Column<string>(maxLength: 50, nullable: true),
                    Manufacturer = table.Column<string>(maxLength: 50, nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memory_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NetworkAdapter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(maxLength: 50, nullable: true),
                    ComputerId = table.Column<int>(nullable: false),
                    DHCPEnabled = table.Column<bool>(nullable: false),
                    DHCPServer = table.Column<string>(maxLength: 50, nullable: true),
                    DefaultIPGateway = table.Column<string>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    IPEnabled = table.Column<bool>(nullable: false),
                    IPSubnet = table.Column<string>(nullable: true),
                    MACAddress = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkAdapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkAdapter_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AntiVirusProduct_ComputerId",
                table: "AntiVirusProduct",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DivisionId",
                table: "AspNetUsers",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CompanyId",
                table: "Branch",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_DivisionId",
                table: "Computer",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Disk_ComputerId",
                table: "Disk",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_BranchId",
                table: "Division",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_ComputerId",
                table: "Driver",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorException_ComputerId",
                table: "ErrorException",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_FirewallProduct_ComputerId",
                table: "FirewallProduct",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Harddisk_ComputerId",
                table: "Harddisk",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_LogicalDisk_ComputerId",
                table: "LogicalDisk",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Memory_ComputerId",
                table: "Memory",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkAdapter_ComputerId",
                table: "NetworkAdapter",
                column: "ComputerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AntiVirusProduct");

            migrationBuilder.DropTable(
                name: "Disk");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "ErrorException");

            migrationBuilder.DropTable(
                name: "FirewallProduct");

            migrationBuilder.DropTable(
                name: "Harddisk");

            migrationBuilder.DropTable(
                name: "LogicalDisk");

            migrationBuilder.DropTable(
                name: "Memory");

            migrationBuilder.DropTable(
                name: "NetworkAdapter");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Computer");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
