using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuickMonServer.Models
{
    public class Computer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComputerId { get; set; }

        [ForeignKey("Division")]
        public int DivisionId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Manufacturer { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        [MaxLength(50)]
        public string ChassisSKUNumber { get; set; }
        [MaxLength(50)]
        public string CPU { get; set; }
        public int CPUCurrentClock { get; set; }
        public int CPUMaxClockSpeed { get; set; }
        [MaxLength(50)]
        public string CPUStatus { get; set; }

        public int NumberOfProcessors { get; set; }
        public int NumberOfLogicalProcessors { get; set; }
        [MaxLength(50)]
        public string PCSystemType { get; set; }
        [MaxLength(50)]
        public string ThermalState { get; set; }
        public long TotalPhysicalMemory { get; set; }
        [MaxLength(50)]
        public string BoardManufacturer { get; set; }
        [MaxLength(50)]
        public string BoardModel { get; set; }
        [MaxLength(50)]
        public string BoardPartNumber { get; set; }
        [MaxLength(50)]
        public string BoardSerialNumber { get; set; }
        [MaxLength(50)]
        public string BoardStatus { get; set; }
        [MaxLength(50)]
        public string Domain { get; set; }
        [MaxLength(50)]
        public string Workgroup { get; set; }
        [MaxLength(50)]
        public string BiosCaption { get; set; }
        [MaxLength(50)]
        public string BiosManufacturer { get; set; }
        [MaxLength(50)]
        public string BiosBIOSVersion { get; set; }
        [MaxLength(50)]
        public string BiosBuildNumber { get; set; }
        [MaxLength(50)]
        public string BiosSerialNumber { get; set; }
        [MaxLength(50)]
        public string BiosStatus { get; set; }

        // Win32_OperatingSystem
        [MaxLength(50)]
        public string WindowsCaption { get; set; }
        [MaxLength(50)]
        public string WindowsBuildNumber { get; set; }
        [MaxLength(50)]
        public short WindowsCurrentTimeZone { get; set; }
        [MaxLength(50)]
        public string WindowsInstallDate { get; set; }
        [MaxLength(50)]
        public string WindowsLocalDateTime { get; set; }
        [MaxLength(50)]
        public string WindowsLocale { get; set; }
        [MaxLength(50)]
        public string WindowsOSArchitecture { get; set; }
        [MaxLength(50)]
        public int WindowsOSLanguage { get; set; }
        [MaxLength(50)]
        public string WindowsSystemDirectory { get; set; }
        [MaxLength(50)]
        public string WindowsSystemDrive { get; set; }
        public long WindowsFreePhysicalMemory { get; set; }
        public long WindowsFreeSpaceInPagingFiles { get; set; }
        public long WindowsFreeVirtualMemory { get; set; }
        [MaxLength(50)]
        public string WindowsStatus { get; set; }
        public int WindowsOperatingSystemSKU { get; set; }
        [MaxLength(50)]
        public string WindowsSerialNumber { get; set; }
        [MaxLength(50)]
        public string WindowsDirectory { get; set; }
        public long WindowsTotalSwapSpaceSize { get; set; }
        public long WindowsTotalVirtualMemorySize { get; set; }
        public long WindowsTotalVisibleMemorySize { get; set; }
        public bool WindowsFirewallEnabled { get; set; }

        // Win32_WindowsProductActivation
        public int WindowsActivationRequired { get; set; }
        public int WindowsIsNotificationOn { get; set; }
        [MaxLength(50)]
        public string WindowsProductID { get; set; }
        public int WindowsRemainingEvaluationPeriod { get; set; }
        public int WindowsRemainingGracePeriod { get; set; }

        public virtual ICollection<Harddisk> Harddisks { get; set; }
        public virtual ICollection<Memory> Memories { get; set; }
        public virtual ICollection<Disk> Disks { get; set; }
        public virtual ICollection<LogicalDisk> LogicalDisks { get; set; }
        public virtual ICollection<AntiVirusProduct> Antivirus { get; set; }
        public virtual ICollection<NetworkAdapter> Networks { get; set; }
        public virtual ICollection<FirewallProduct> Firewall { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<ErrorException> ErrorExceptions { get; set; }
        public virtual Division Division { get; set; }
    }
    public class Harddisk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [MaxLength(50)]
        public string Brand { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        [MaxLength(50)]
        public string SerialNo { get; set; }
        [MaxLength(50)]
        public double Capacity { get; set; }
        [MaxLength(50)]
        public double FreeSpace { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public virtual Computer Computer { get; set; }
    }
    public class Memory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [MaxLength(50)]
        public string Caption { get; set; }
        public long Capacity { get; set; }
        [MaxLength(50)]
        public string BankLabel { get; set; }
        [MaxLength(50)]
        public string DeviceLocator { get; set; }
        [MaxLength(50)]
        public string Manufacturer { get; set; }
        [MaxLength(50)]
        public string SerialNumber { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public virtual Computer Computer { get; set; }
    }
    public class Disk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [MaxLength(50)]
        public string Caption { get; set; }
        [MaxLength(50)]
        public string Manufacturer { get; set; }
        [MaxLength(50)]
        public string SerialNumber { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        public long Size { get; set; }
        [MaxLength(50)]
        public string InterfaceType { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }

        public virtual Computer Computer { get; set; }

    }
    public class LogicalDisk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [MaxLength(50)]
        public string Caption { get; set; }
        [MaxLength(50)]
        public string DriveType { get; set; }
        [MaxLength(50)]
        public string FileSystem { get; set; }
        public long FreeSpace { get; set; }
        public long Size { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public virtual Computer Computer { get; set; }
    }
    public class NetworkAdapter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [MaxLength(50)]
        public string Caption { get; set; }
        public bool DHCPEnabled { get; set; }
        [MaxLength(50)]
        public string DHCPServer { get; set; }
        public bool IPEnabled { get; set; }
        public string IPAddress { get; set; }
        public string IPSubnet { get; set; }
        public string DefaultIPGateway { get; set; }
        [MaxLength(50)]
        public string MACAddress { get; set; }
        public virtual Computer Computer { get; set; }
    }
    public class AntiVirusProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [MaxLength(50)]
        public string DisplayName { get; set; }
        public int ProductState { get; set; }
        public virtual Computer Computer { get; set; }
    }
    public class FirewallProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [MaxLength(50)]
        public string DisplayName { get; set; }
        public int ProductState { get; set; }
        public virtual Computer Computer { get; set; }
    }
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [MaxLength(50)]
        public string DeviceName { get; set; }
        [MaxLength(50)]
        public string DeviceClass { get; set; }
        [MaxLength(50)]
        public string Manufacturer { get; set; }
        [MaxLength(50)]
        public string DriverVersion { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        public virtual Computer Computer { get; set; }
    }
    public class ErrorException
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Computer")]
        public int ComputerId { get; set; }
        [MaxLength(50)]
        public string Exception { get; set; }
        [MaxLength(50)]
        public string InnerException { get; set; }
        public virtual Computer Computer { get; set; }
    }
}
