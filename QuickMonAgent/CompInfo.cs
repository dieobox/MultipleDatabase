using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMonService
{
    public class CompInfo
    {
        public CompInfo()
        {
        }

        // Win32_ComputerSystem
        public string COMP_Name { get; set; }
        public string COMP_Manufacturer { get; set; }
        public string COMP_Model { get; set; }
        public string COMP_ChassisSKUNumber { get; set; }
        public uint COMP_NumberOfProcessors { get; set; }
        public uint COMP_NumberOfLogicalProcessors { get; set; }
        public ushort COMP_PCSystemType { get; set; }
        public ushort COMP_ThermalState { get; set; }
        public string COMP_BootupState { get; set; }
        public ulong COMP_TotalPhysicalMemory { get; set; }
        public string COMP_UserName { get; set; }
        public string COMP_Domain { get; set; }
        public string COMP_Workgroup { get; set; }
        public DateTime COMP_InstallDate { get; set; }

        // W32_BIOS
        public string BIOS_Caption { get; set; }
        public string BIOS_Manufacturer { get; set; }
        public string BIOS_BIOSVersion { get; set; }
        public string BIOS_BuildNumber { get; set; }
        public string BIOS_SerialNumber { get; set; }
        public string BIOS_Status { get; set; }



        // Win32_OperatingSystem
        public string WIN_Caption { get; set; }
        public string WIN_BuildNumber { get; set; }
        public int WIN_CurrentTimeZone { get; set; }
        public DateTime WIN_InstallDate { get; set; }
        public DateTime WIN_LocalDateTime { get; set; }
        public string WIN_Locale { get; set; }
        public string WIN_OSArchitecture { get; set; }
        public string WIN_OSLanguage { get; set; }
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


        // Win32_WindowsProductActivation
        public UInt32 ActivationRequired { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public UInt32 IsNotificationOn { get; set; }
        public string ProductID { get; set; }
        public UInt32 RemainingEvaluationPeriod { get; set; }
        public UInt32 RemainingGracePeriod { get; set; }

        public bool FirewallEnable { get; set; }
        public string AntivirusCaption { get; set; }
        public bool AntivirusEnable { get; set; }
        public bool AutoUpdate { get; set; }
        public ICollection<Harddisk> Harddisks {get; set;}
        public ICollection<NetworkInterface> NetworkInterfaces { get; set; }
        public ICollection<Memory> Memorys { get; set; }
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
        public Memory(string iCaption, string iCapacity,
            int iConfiguredClockSpeed,int iConfiguredVoltage,  
            string iDeviceLocator,DateTime iInstallDate, 
            string iManufacturer,string iSerialNumber,
            string iStatus,string iUsage)
        {
            Caption = iCaption;
            Capacity = iCapacity;
            ConfiguredClockSpeed = iConfiguredClockSpeed;
            ConfiguredVoltage = iConfiguredVoltage;
            DeviceLocator = iDeviceLocator;
            InstallDate = iInstallDate;
            Manufacturer = iManufacturer;
            SerialNumber = iSerialNumber;
            Status = iStatus;
            Usage = iUsage;
        }

        public string Caption { get; set; }
        public string Capacity { get; set; }
        public int ConfiguredClockSpeed { get; set; }
        public int ConfiguredVoltage { get; set; }
        public string DeviceLocator { get; set; }
        public string FormFactor { get; set; }
        public DateTime  InstallDate { get; set; }
        public string Manufacturer { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public string Usage { get; set; }


    }


}
