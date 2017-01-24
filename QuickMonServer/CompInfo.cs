using System;
using System.Collections.Generic;


namespace QuickMonServer
{
    public enum ThermalState
    {
        Other = 1,
        Unknown,
        Safe,
        Warning,
        Critical,
        Non_Recoverable
    };
    public enum SystemType
    {
        Unspecified,
        Desktop,
        Mobile,
        Workstation,
        Enterprise_Server,
        SOHO_Server,
        Small_Office_Server,
        Appliance_PC,
        Performance_Server,
        Maximum
    };
    public enum DriveType
    {
        Unknown,
        No_Root_Directory,
        Removable_Disk,
        Local_Disk,
        Network_Drive,
        Compact_Disc,
        RAM_Disk
    }

    public class CompInfo
    {
        // Win32_ComputerSystem
        public string COMP_Name { get; set; }
        public string COMP_Manufacturer { get; set; }
        public string COMP_Model { get; set; }
        public string COMP_ChassisSKUNumber { get; set; }
        public string COMP_CPU { get; set; }
        public string COMP_CPUCurrentClock { get; set; }
        public string COMP_CPUMaxClockSpeed { get; set; }
        public string COMP_CPUStatus { get; set; }
        public uint COMP_NumberOfProcessors { get; set; }
        public uint COMP_NumberOfLogicalProcessors { get; set; }
        public string COMP_PCSystemType { get; set; }
        public string COMP_ThermalState { get; set; }
        public ulong COMP_TotalPhysicalMemory { get; set; }
        public string COMP_BoardManufacturer { get; set; }
        public string COMP_BoardModel { get; set; }
        public string COMP_BoardPartNumber { get; set; }
        public string COMP_BoardSerialNumber { get; set; }
        public string COMP_BoardStatus { get; set; }
        public string COMP_Domain { get; set; }
        public string COMP_Workgroup { get; set; }



        // Win32_BIOS
        public string BIOS_Caption { get; set; }
        public string BIOS_Manufacturer { get; set; }
        public string[] BIOS_BIOSVersion { get; set; }
        public string BIOS_BuildNumber { get; set; }
        public string BIOS_SerialNumber { get; set; }
        public string BIOS_Status { get; set; }



        // Win32_OperatingSystem
        public string WIN_Caption { get; set; }
        public string WIN_BuildNumber { get; set; }
        public short WIN_CurrentTimeZone { get; set; }
        public string WIN_InstallDate { get; set; }
        public string WIN_LocalDateTime { get; set; }
        public string WIN_Locale { get; set; }
        public string WIN_OSArchitecture { get; set; }
        public UInt32 WIN_OSLanguage { get; set; }
        public string WIN_SystemDirectory { get; set; }
        public string WIN_SystemDrive { get; set; }
        public UInt64 WIN_FreePhysicalMemory { get; set; }
        public UInt64 WIN_FreeSpaceInPagingFiles { get; set; }
        public UInt64 WIN_FreeVirtualMemory { get; set; }
        public string WIN_Status { get; set; }
        public UInt32 WIN_OperatingSystemSKU { get; set; }
        public string WIN_SerialNumber { get; set; }
        public string WIN_WindowsDirectory { get; set; }
        public UInt64 WIN_TotalSwapSpaceSize { get; set; }
        public UInt64 WIN_TotalVirtualMemorySize { get; set; }
        public UInt64 WIN_TotalVisibleMemorySize { get; set; }
        public bool WIN_WindowsFirewallEnabled { get; set; }

        // Win32_WindowsProductActivation
        public UInt32 WIN_ActivationRequired { get; set; }
        public UInt32 WIN_IsNotificationOn { get; set; }
        public string WIN_ProductID { get; set; }
        public UInt32 WIN_RemainingEvaluationPeriod { get; set; }
        public UInt32 WIN_RemainingGracePeriod { get; set; }


        public List<Harddisk> Harddisks {get; set;}
        public List<NetworkInterface> NetworkInterfaces { get; set; }
        public List<Memory> Memories { get; set; }
        public List<Disk> Disks { get; set; }
        public List<LogicalDisk> LogicalDisks { get; set; }
        public List<AntiVirusProduct> Antivirus { get; set; }
        public List<NetworkAdapter> Networks { get; set; }
        public List<FirewallProduct> Firewall { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<ErrorException> ErrorExceptions { get; set; }
    }
    public class Harddisk
    {
        public Harddisk(string brand,string model,string serial,double capacity,double freespace,string status)
        {
            Brand = brand;
            Model = model;
            SerialNo = serial;
            Capacity = capacity;
            FreeSpace = freespace;
            Status = status;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNo { get; set; }
        public double Capacity { get; set; }
        public double FreeSpace { get; set; }
        public string Status { get; set; }

    }
    public class NetworkInterface
    {
        public NetworkInterface(string interfaceName, string iPAddress, string iPSubnet, double defaultGateway)
        {
            InterfaceName = interfaceName;
            IPAddress = iPAddress;
            IPSubnet = iPSubnet;
            DefaultGateway = defaultGateway;
        }

        public string InterfaceName { get; set; }
        public string IPAddress { get; set; }
        public string IPSubnet { get; set; }
        public double DefaultGateway { get; set; }

    }
    public class Memory
    {
        public Memory(string iCaption, string iManufacturer,string iSerialNumber,
            UInt64 iCapacity,string iBankLabel, string iDeviceLocator, string iStatus)
        {
            Caption = iCaption;
            Capacity = iCapacity;
            BankLabel = iBankLabel;
            DeviceLocator = iDeviceLocator;
            Manufacturer = iManufacturer;
            SerialNumber = iSerialNumber;
            Status = iStatus;
        }

        public string Caption { get; set; }
        public UInt64 Capacity { get; set; }
        public string BankLabel { get; set; }
        public string DeviceLocator { get; set; }
        public string Manufacturer { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }

    }
    public class Disk
    {
        public Disk(string iCaption, string iManufacturer, string iSerialNumber, string iName, string iModel,
            UInt64 iSize, string iInterfaceType, string iStatus)
        {
            Caption = iCaption;
            Manufacturer = iManufacturer;
            SerialNumber = iSerialNumber;
            Name = iName;
            Model = iModel;
            Size = iSize;
            InterfaceType = iInterfaceType;
            Status = iStatus;
        }

        public string Caption { get; set; }
        public string Manufacturer { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public UInt64 Size { get; set; }
        public string InterfaceType { get; set; }
        public string Status { get; set; }

    }
    public class LogicalDisk
    {
        public LogicalDisk(string iCaption, DriveType iDriveType,
            string iFileSystem,UInt64 iFreeSpace, UInt64 iSize, string iStatus)
        {
            Caption = iCaption;
            DriveType = iDriveType.ToString();
            FileSystem = iFileSystem;
            FreeSpace = iFreeSpace;
            Size = iSize;
            Status = iStatus;
        }

        public string Caption { get; set; }
        public string DriveType { get; set; }
        public string FileSystem { get; set; }
        public UInt64 FreeSpace { get; set; }
        public UInt64 Size { get; set; }
        public string Status { get; set; }

    }
    public class NetworkAdapter
    {
        public NetworkAdapter(string iCaption, bool iDHCPEnabled, string iDHCPServer,
           bool iIPEnabled, string[] iIPAddress, string[] iIPSubnet, string[] iDefaultIPGateway, 
           string iMACAddress)
        {
            Caption = iCaption;
            DHCPEnabled = iDHCPEnabled;
            DHCPServer = iDHCPServer;
            IPEnabled = iIPEnabled;
            IPAddress = iIPAddress;
            IPSubnet = iIPSubnet;
            DefaultIPGateway = iDefaultIPGateway;
            MACAddress = iMACAddress;
        }

        public string Caption { get; set; }
        public bool DHCPEnabled { get; set; }
        public string DHCPServer { get; set; }
        public bool IPEnabled { get; set; }
        public string[] IPAddress { get; set; }
        public string[] IPSubnet { get; set; }
        public string[] DefaultIPGateway { get; set; }
        public string MACAddress { get; set; }
    }
    public class AntiVirusProduct
    {
        public AntiVirusProduct(string displayName, UInt32 productState)
        {
            DisplayName = displayName;
            ProductState = productState;
        }
        public string DisplayName;              // Application name
        public UInt32 ProductState;             // Real-time protection & defintion state
    }
    public class FirewallProduct
    {
        public FirewallProduct(string displayName, UInt32 productState)
        {
            DisplayName = displayName;
            ProductState = productState;
        }
        public string DisplayName;              // Application name
        public UInt32 ProductState;             // Real-time protection & defintion state
    }
    public class Driver
    {
        public Driver(string deviceName,string deviceClass, string manufacturer, string driverVersion,string status)
        {
            DeviceName = deviceName;
            DeviceClass = deviceClass;
            Manufacturer = manufacturer;
            DriverVersion = driverVersion;
            Status = status;
        }
        public string DeviceName;
        public string DeviceClass;
        public string Manufacturer;     
        public string DriverVersion;
        public string Status;
    }
    public class ErrorException
    {
        public ErrorException(string exception , string innerException)
        {
            Exception = exception;
            InnerException = innerException;
        }
        public string Exception{get;set;}
        public string InnerException { get; set; }
    }
}
