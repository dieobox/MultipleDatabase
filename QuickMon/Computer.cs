using System;
using System.Collections.Generic;
using System.Management;
using NetFwTypeLib;
using System.Threading.Tasks;

namespace QuickMonTray
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

    public class Computer
    {
        public Computer()
        {
        }
        public async Task UpdateAsync()
        {
            await Task.Run(() => GetComputerInfomation());
        }
        public async Task UpdateAccount(string username)
        {
            await Task.Run(() => UpdateAccountInfomation(username));
        }
        private void UpdateAccountInfomation(string username)
        {
            AccountName = username;
        }
        private void GetComputerInfomation()
        {
            ManagementClass mc = null;
            ManagementObjectCollection moc = null;
            ErrorExceptions = new List<ErrorException>();

            try
            {
                mc = new ManagementClass("Win32_ComputerSystem");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    Name = (string)mo["Name"];
                    Manufacturer = (string)mo["Manufacturer"];
                    Model = (string)mo["Model"];
                    ChassisSKUNumber = (string)mo["ChassisSKUNumber"];
                    NumberOfProcessors = (uint)mo["NumberOfProcessors"];
                    NumberOfLogicalProcessors = (uint)mo["NumberOfLogicalProcessors"];
                    PCSystemType = ((SystemType)Convert.ToInt16(mo["PCSystemType"])).ToString();
                    ThermalState = ((ThermalState)Convert.ToInt16(mo["ThermalState"])).ToString();
                    TotalPhysicalMemory = (ulong)mo["TotalPhysicalMemory"];
                    Domain = (string)mo["Domain"];
                    Workgroup = (string)mo["Workgroup"];
                }
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }

            try
            {
                mc = new ManagementClass("Win32_BaseBoard");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    BoardManufacturer = (string)mo["Manufacturer"] ?? "";
                    BoardModel = (string)mo["Model"] ?? "";
                    BoardPartNumber = (string)mo["PartNumber"] ?? "";
                    BoardSerialNumber = (string)mo["SerialNumber"] ?? "";
                    BoardStatus = (string)mo["Status"] ?? "";
                }
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }

            try
            {
                mc = new ManagementClass("Win32_BIOS");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    BiosCaption = (string)mo["Caption"] ?? "";
                    BiosManufacturer = (string)mo["Manufacturer"] ?? "";
                    BiosBIOSVersion = ((string[])mo["BIOSVersion"])[0];
                    BiosBuildNumber = (string)mo["BuildNumber"] ?? "";
                    BiosSerialNumber = (string)mo["SerialNumber"] ?? "";
                    BiosStatus = (string)mo["Status"] ?? "";
                }
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }


            try
            {
                mc = new ManagementClass("win32_processor");
                moc = mc.GetInstances();
                String info = String.Empty;
                foreach (ManagementObject mo in moc)
                {
                    string name = (string)mo["Name"];
                    name = name.Replace("(TM)", "™").Replace("(tm)", "™").Replace("(R)", "®").Replace("(r)", "®").Replace("(C)", "©").Replace("(c)", "©").Replace("    ", " ").Replace("  ", " ");
                    CPU = name + " " + (string)mo["Caption"];
                    // only return cpuStatus from first CPU
                    CPUCurrentClock = mo["CurrentClockSpeed"].ToString();
                    CPUMaxClockSpeed = mo["MaxClockSpeed"].ToString();
                    CPUStatus = mo["Status"].ToString();
                }
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }

            try
            {
                mc = new ManagementClass("Win32_OperatingSystem");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    WindowsCaption = (string)mo["Caption"] ?? "";
                    WindowsBuildNumber = (string)mo["BuildNumber"] ?? "";
                    WindowsCurrentTimeZone = (short)mo["CurrentTimeZone"];
                    WindowsInstallDate = (string)mo["InstallDate"];
                    WindowsLocalDateTime = (string)mo["LocalDateTime"];
                    WindowsLocale = (string)mo["Locale"] ?? "";
                    WindowsOSArchitecture = (string)mo["OSArchitecture"] ?? "";
                    WindowsOSLanguage = (uint)mo["OSLanguage"];
                    WindowsSystemDirectory = (string)mo["Caption"] ?? "";
                    WindowsSystemDrive = (string)mo["SystemDrive"] ?? "";
                    WindowsFreePhysicalMemory = (ulong)mo["FreePhysicalMemory"];
                    WindowsFreeSpaceInPagingFiles = (ulong)mo["FreeSpaceInPagingFiles"];
                    WindowsFreeVirtualMemory = (ulong)mo["FreeVirtualMemory"];
                    WindowsStatus = (string)mo["Status"] ?? "";
                    WindowsOperatingSystemSKU = (uint)mo["OperatingSystemSKU"];
                    WindowsSerialNumber = (string)mo["SerialNumber"] ?? "";
                    WindowsDirectory = (string)mo["WindowsDirectory"] ?? "";
                    WindowsTotalVirtualMemorySize = (UInt64)mo["TotalVirtualMemorySize"];
                    WindowsTotalVisibleMemorySize = (UInt64)mo["TotalVisibleMemorySize"];
                }
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }




            Memories = new List<Memory>();
            try
            {
                mc = new ManagementClass("Win32_PhysicalMemory");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {

                    Memories.Add(new Memory(
                        (string)mo["Caption"],
                        (string)mo["Manufacturer"],
                        (string)mo["SerialNumber"],
                        (UInt64)mo["Capacity"],
                        (string)mo["BankLabel"],
                        (string)mo["DeviceLocator"],
                        (string)mo["Status"]));
                }
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }

            Disks = new List<Disk>();
            try
            {
                mc = new ManagementClass("Win32_DiskDrive");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    var a1 = (string)mo["Caption"];
                    var a2 = (string)mo["Manufacturer"];
                    var a3 = (string)mo["SerialNumber"];
                    var a4 = (string)mo["Name"];
                    var a5 = (string)mo["Model"];
                    var a6 = (UInt64)mo["Size"];
                    var a7 = (string)mo["InterfaceType"];
                    var a9 = (string)mo["Status"];


                    Disks.Add(new Disk(
                        (string)mo["Caption"],
                        (string)mo["Manufacturer"],
                        (string)mo["SerialNumber"],
                        (string)mo["Name"],
                        (string)mo["Model"],
                        (UInt64)mo["Size"],
                        (string)mo["InterfaceType"],
                        (string)mo["Status"]));
                }
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }

            LogicalDisks = new List<LogicalDisk>();
            try
            {
                mc = new ManagementClass("Win32_LogicalDisk");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    LogicalDisks.Add(new LogicalDisk(
                        (string)mo["Caption"],
                        (DriveType)Convert.ToInt16(mo["DriveType"]),
                        (string)mo["FileSystem"],
                        (UInt64)mo["FreeSpace"],
                        (UInt64)mo["Size"],
                        (string)mo["Status"]));
                }
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }



            Networks = new List<NetworkAdapter>();
            try
            {
                mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    Networks.Add(new NetworkAdapter(
                        (string)mo["Caption"],
                        (bool)mo["DHCPEnabled"],
                        (string)mo["DHCPServer"],
                        (bool)mo["IPEnabled"],
                        (string[])mo["IPAddress"],
                        (string[])mo["IPSubnet"],
                        (string[])mo["DefaultIPGateway"],
                        (string)mo["MACAddress"]));

                }
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }


            Drivers = new List<Driver>();
            try
            {
                mc = new ManagementClass("Win32_PnPSignedDriver");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    Drivers.Add(new Driver(
                        (string)mo["DeviceName"],
                        (string)mo["DeviceClass"],
                        (string)mo["Manufacturer"],
                        (string)mo["DriverVersion"],
                        (string)mo["Status"]
                        ));
                }
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }

            string wmipathstr = "";
            ManagementObjectSearcher searcher = null;
            ManagementObjectCollection instances = null;

            Antivirus = new List<AntiVirusProduct>();
            try
            {
                wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter2";
                searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
                instances = searcher.Get();
                foreach (var instance in instances)
                {

                    var displayName = (string)instance.GetPropertyValue("displayName");
                    var productState = (uint)instance.GetPropertyValue("productState");
                    Antivirus.Add(new AntiVirusProduct(displayName, productState));
                }
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }

            Firewall = new List<FirewallProduct>();
            try
            {
                wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter2";
                searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM FirewallProduct ");
                instances = searcher.Get();
                foreach (var instance in instances)
                {
                    Firewall.Add(new FirewallProduct((string)instance.GetPropertyValue("displayName"), (UInt32)instance.GetPropertyValue("productState")));
                }
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }

            try
            {
                Type NetFwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr", false);
                INetFwMgr mgr = (INetFwMgr)Activator.CreateInstance(NetFwMgrType);
                WindowsFirewallEnabled = mgr.LocalPolicy.CurrentProfile.FirewallEnabled;
            }
            catch (Exception e)
            {
                ErrorExceptions.Add(new ErrorException(e.Message, e.InnerException.Message));
            }

        }
        // Win32_ComputerSystem
        public string AccountName { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string ChassisSKUNumber { get; set; }
        public string CPU { get; set; }
        public string CPUCurrentClock { get; set; }
        public string CPUMaxClockSpeed { get; set; }
        public string CPUStatus { get; set; }
        public uint NumberOfProcessors { get; set; }
        public uint NumberOfLogicalProcessors { get; set; }
        public string PCSystemType { get; set; }
        public string ThermalState { get; set; }
        public ulong TotalPhysicalMemory { get; set; }
        public string BoardManufacturer { get; set; }
        public string BoardModel { get; set; }
        public string BoardPartNumber { get; set; }
        public string BoardSerialNumber { get; set; }
        public string BoardStatus { get; set; }
        public string Domain { get; set; }
        public string Workgroup { get; set; }

        // Win32_BIOS
        public string BiosCaption { get; set; }
        public string BiosManufacturer { get; set; }
        public string BiosBIOSVersion { get; set; }
        public string BiosBuildNumber { get; set; }
        public string BiosSerialNumber { get; set; }
        public string BiosStatus { get; set; }

        // Win32_OperatingSystem
        public string WindowsCaption { get; set; }
        public string WindowsBuildNumber { get; set; }
        public short WindowsCurrentTimeZone { get; set; }
        public string WindowsInstallDate { get; set; }
        public string WindowsLocalDateTime { get; set; }
        public string WindowsLocale { get; set; }
        public string WindowsOSArchitecture { get; set; }
        public UInt32 WindowsOSLanguage { get; set; }
        public string WindowsSystemDirectory { get; set; }
        public string WindowsSystemDrive { get; set; }
        public UInt64 WindowsFreePhysicalMemory { get; set; }
        public UInt64 WindowsFreeSpaceInPagingFiles { get; set; }
        public UInt64 WindowsFreeVirtualMemory { get; set; }
        public string WindowsStatus { get; set; }
        public UInt32 WindowsOperatingSystemSKU { get; set; }
        public string WindowsSerialNumber { get; set; }
        public string WindowsDirectory { get; set; }
        public UInt64 WindowsTotalSwapSpaceSize { get; set; }
        public UInt64 WindowsTotalVirtualMemorySize { get; set; }
        public UInt64 WindowsTotalVisibleMemorySize { get; set; }
        public bool WindowsFirewallEnabled { get; set; }

        // Win32_WindowsProductActivation
        public UInt32 WindowsActivationRequired { get; set; }
        public UInt32 WindowsIsNotificationOn { get; set; }
        public string WindowsProductID { get; set; }
        public UInt32 WindowsRemainingEvaluationPeriod { get; set; }
        public UInt32 WindowsRemainingGracePeriod { get; set; }


        public List<Harddisk> Harddisks {get; set;}
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
