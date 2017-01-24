using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QuickMonServer.Models;

namespace QuickMonServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("QuickMonServer.Models.AntiVirusProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComputerId");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(50);

                    b.Property<int>("ProductState");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("AntiVirusProduct");
                });

            modelBuilder.Entity("QuickMonServer.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int?>("DivisionId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("Enable");

                    b.Property<string>("Firstname")
                        .HasMaxLength(100);

                    b.Property<string>("Lastname")
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("QuickMonServer.Models.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("Address2")
                        .HasMaxLength(100);

                    b.Property<string>("BranchName")
                        .HasMaxLength(250);

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<int>("CompanyId");

                    b.Property<string>("Country")
                        .HasMaxLength(50);

                    b.Property<string>("Fax")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDefault");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10);

                    b.Property<string>("State")
                        .HasMaxLength(50);

                    b.Property<string>("Telephone")
                        .HasMaxLength(50);

                    b.Property<bool>("UseCompanyInfo");

                    b.HasKey("BranchId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("QuickMonServer.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActiveDate");

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("Address2")
                        .HasMaxLength(100);

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(250);

                    b.Property<string>("Country")
                        .HasMaxLength(50);

                    b.Property<bool>("Enable");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Fax")
                        .HasMaxLength(50);

                    b.Property<string>("LicenseKey");

                    b.Property<int>("MaxBranch");

                    b.Property<int>("MaxDivision");

                    b.Property<int>("MaxManager");

                    b.Property<int>("MaxStaff");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10);

                    b.Property<string>("State")
                        .HasMaxLength(50);

                    b.Property<string>("Telephone")
                        .HasMaxLength(50);

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("QuickMonServer.Models.Computer", b =>
                {
                    b.Property<int>("ComputerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BiosBIOSVersion")
                        .HasMaxLength(50);

                    b.Property<string>("BiosBuildNumber")
                        .HasMaxLength(50);

                    b.Property<string>("BiosCaption")
                        .HasMaxLength(50);

                    b.Property<string>("BiosManufacturer")
                        .HasMaxLength(50);

                    b.Property<string>("BiosSerialNumber")
                        .HasMaxLength(50);

                    b.Property<string>("BiosStatus")
                        .HasMaxLength(50);

                    b.Property<string>("BoardManufacturer")
                        .HasMaxLength(50);

                    b.Property<string>("BoardModel")
                        .HasMaxLength(50);

                    b.Property<string>("BoardPartNumber")
                        .HasMaxLength(50);

                    b.Property<string>("BoardSerialNumber")
                        .HasMaxLength(50);

                    b.Property<string>("BoardStatus")
                        .HasMaxLength(50);

                    b.Property<string>("CPU")
                        .HasMaxLength(50);

                    b.Property<int>("CPUCurrentClock");

                    b.Property<int>("CPUMaxClockSpeed");

                    b.Property<string>("CPUStatus")
                        .HasMaxLength(50);

                    b.Property<string>("ChassisSKUNumber")
                        .HasMaxLength(50);

                    b.Property<int>("DivisionId");

                    b.Property<string>("Domain")
                        .HasMaxLength(50);

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(50);

                    b.Property<string>("Model")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("NumberOfLogicalProcessors");

                    b.Property<int>("NumberOfProcessors");

                    b.Property<string>("PCSystemType")
                        .HasMaxLength(50);

                    b.Property<string>("ThermalState")
                        .HasMaxLength(50);

                    b.Property<long>("TotalPhysicalMemory");

                    b.Property<int>("WindowsActivationRequired");

                    b.Property<string>("WindowsBuildNumber")
                        .HasMaxLength(50);

                    b.Property<string>("WindowsCaption")
                        .HasMaxLength(50);

                    b.Property<short>("WindowsCurrentTimeZone")
                        .HasMaxLength(50);

                    b.Property<string>("WindowsDirectory")
                        .HasMaxLength(50);

                    b.Property<bool>("WindowsFirewallEnabled");

                    b.Property<long>("WindowsFreePhysicalMemory");

                    b.Property<long>("WindowsFreeSpaceInPagingFiles");

                    b.Property<long>("WindowsFreeVirtualMemory");

                    b.Property<string>("WindowsInstallDate")
                        .HasMaxLength(50);

                    b.Property<int>("WindowsIsNotificationOn");

                    b.Property<string>("WindowsLocalDateTime")
                        .HasMaxLength(50);

                    b.Property<string>("WindowsLocale")
                        .HasMaxLength(50);

                    b.Property<string>("WindowsOSArchitecture")
                        .HasMaxLength(50);

                    b.Property<int>("WindowsOSLanguage")
                        .HasMaxLength(50);

                    b.Property<int>("WindowsOperatingSystemSKU");

                    b.Property<string>("WindowsProductID")
                        .HasMaxLength(50);

                    b.Property<int>("WindowsRemainingEvaluationPeriod");

                    b.Property<int>("WindowsRemainingGracePeriod");

                    b.Property<string>("WindowsSerialNumber")
                        .HasMaxLength(50);

                    b.Property<string>("WindowsStatus")
                        .HasMaxLength(50);

                    b.Property<string>("WindowsSystemDirectory")
                        .HasMaxLength(50);

                    b.Property<string>("WindowsSystemDrive")
                        .HasMaxLength(50);

                    b.Property<long>("WindowsTotalSwapSpaceSize");

                    b.Property<long>("WindowsTotalVirtualMemorySize");

                    b.Property<long>("WindowsTotalVisibleMemorySize");

                    b.Property<string>("Workgroup")
                        .HasMaxLength(50);

                    b.HasKey("ComputerId");

                    b.HasIndex("DivisionId");

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("QuickMonServer.Models.Disk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasMaxLength(50);

                    b.Property<int>("ComputerId");

                    b.Property<string>("InterfaceType")
                        .HasMaxLength(50);

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(50);

                    b.Property<string>("Model")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(50);

                    b.Property<long>("Size");

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("Disk");
                });

            modelBuilder.Entity("QuickMonServer.Models.Division", b =>
                {
                    b.Property<int>("DivisionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("Address2")
                        .HasMaxLength(100);

                    b.Property<int>("BranchId");

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .HasMaxLength(50);

                    b.Property<string>("DivisionName")
                        .HasMaxLength(250);

                    b.Property<string>("Fax")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDefault");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10);

                    b.Property<string>("State")
                        .HasMaxLength(50);

                    b.Property<string>("Telephone")
                        .HasMaxLength(50);

                    b.Property<bool>("UseBranchInfo");

                    b.Property<bool>("UseCompanyInfo");

                    b.HasKey("DivisionId");

                    b.HasIndex("BranchId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("QuickMonServer.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComputerId");

                    b.Property<string>("DeviceClass")
                        .HasMaxLength(50);

                    b.Property<string>("DeviceName")
                        .HasMaxLength(50);

                    b.Property<string>("DriverVersion")
                        .HasMaxLength(50);

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("QuickMonServer.Models.ErrorException", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComputerId");

                    b.Property<string>("Exception")
                        .HasMaxLength(50);

                    b.Property<string>("InnerException")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("ErrorException");
                });

            modelBuilder.Entity("QuickMonServer.Models.FirewallProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComputerId");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(50);

                    b.Property<int>("ProductState");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("FirewallProduct");
                });

            modelBuilder.Entity("QuickMonServer.Models.Harddisk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasMaxLength(50);

                    b.Property<double>("Capacity")
                        .HasMaxLength(50);

                    b.Property<int>("ComputerId");

                    b.Property<double>("FreeSpace")
                        .HasMaxLength(50);

                    b.Property<string>("Model")
                        .HasMaxLength(50);

                    b.Property<string>("SerialNo")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("Harddisk");
                });

            modelBuilder.Entity("QuickMonServer.Models.LogicalDisk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasMaxLength(50);

                    b.Property<int>("ComputerId");

                    b.Property<string>("DriveType")
                        .HasMaxLength(50);

                    b.Property<string>("FileSystem")
                        .HasMaxLength(50);

                    b.Property<long>("FreeSpace");

                    b.Property<long>("Size");

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("LogicalDisk");
                });

            modelBuilder.Entity("QuickMonServer.Models.Memory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankLabel")
                        .HasMaxLength(50);

                    b.Property<long>("Capacity");

                    b.Property<string>("Caption")
                        .HasMaxLength(50);

                    b.Property<int>("ComputerId");

                    b.Property<string>("DeviceLocator")
                        .HasMaxLength(50);

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(50);

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("Memory");
                });

            modelBuilder.Entity("QuickMonServer.Models.NetworkAdapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasMaxLength(50);

                    b.Property<int>("ComputerId");

                    b.Property<bool>("DHCPEnabled");

                    b.Property<string>("DHCPServer")
                        .HasMaxLength(50);

                    b.Property<string>("DefaultIPGateway");

                    b.Property<string>("IPAddress");

                    b.Property<bool>("IPEnabled");

                    b.Property<string>("IPSubnet");

                    b.Property<string>("MACAddress")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("NetworkAdapter");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QuickMonServer.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QuickMonServer.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuickMonServer.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickMonServer.Models.AntiVirusProduct", b =>
                {
                    b.HasOne("QuickMonServer.Models.Computer", "Computer")
                        .WithMany("Antivirus")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickMonServer.Models.ApplicationUser", b =>
                {
                    b.HasOne("QuickMonServer.Models.Division", "Division")
                        .WithMany("Users")
                        .HasForeignKey("DivisionId");
                });

            modelBuilder.Entity("QuickMonServer.Models.Branch", b =>
                {
                    b.HasOne("QuickMonServer.Models.Company", "Company")
                        .WithMany("Branchs")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickMonServer.Models.Computer", b =>
                {
                    b.HasOne("QuickMonServer.Models.Division", "Division")
                        .WithMany("Computers")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickMonServer.Models.Disk", b =>
                {
                    b.HasOne("QuickMonServer.Models.Computer", "Computer")
                        .WithMany("Disks")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickMonServer.Models.Division", b =>
                {
                    b.HasOne("QuickMonServer.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickMonServer.Models.Driver", b =>
                {
                    b.HasOne("QuickMonServer.Models.Computer", "Computer")
                        .WithMany("Drivers")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickMonServer.Models.ErrorException", b =>
                {
                    b.HasOne("QuickMonServer.Models.Computer", "Computer")
                        .WithMany("ErrorExceptions")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickMonServer.Models.FirewallProduct", b =>
                {
                    b.HasOne("QuickMonServer.Models.Computer", "Computer")
                        .WithMany("Firewall")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickMonServer.Models.Harddisk", b =>
                {
                    b.HasOne("QuickMonServer.Models.Computer", "Computer")
                        .WithMany("Harddisks")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickMonServer.Models.LogicalDisk", b =>
                {
                    b.HasOne("QuickMonServer.Models.Computer", "Computer")
                        .WithMany("LogicalDisks")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickMonServer.Models.Memory", b =>
                {
                    b.HasOne("QuickMonServer.Models.Computer", "Computer")
                        .WithMany("Memories")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuickMonServer.Models.NetworkAdapter", b =>
                {
                    b.HasOne("QuickMonServer.Models.Computer", "Computer")
                        .WithMany("Networks")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
