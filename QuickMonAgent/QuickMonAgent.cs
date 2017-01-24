using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Management;


namespace QuickMonService
{
    public partial class QuickMonAgent : ServiceBase
    {
        private int eventId;
        public QuickMonAgent()
        {
            InitializeComponent();
            EventLog = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("QuickMon"))
            {
                System.Diagnostics.EventLog.CreateEventSource("QuickMon", "QuickMonAgentLog");
            }
            EventLog.Source = "QuickMon";
            EventLog.Log = "QuickMonAgentLog";
            eventId = 1;
            
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                EventLog.WriteEntry("QuickMon Agent Starting", EventLogEntryType.Information);
                // Set up a timer to trigger every minute.
                System.Timers.Timer Timer = new System.Timers.Timer();
                Timer.Interval = 60000; // 60 seconds
                Timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
                Timer.Start();
                EventLog.WriteEntry("QuickMon Agent Started", EventLogEntryType.Information);
            }
            catch (Exception e)
            {
                EventLog.WriteEntry(e.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("QuickMon Agent Stop");
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            EventLog.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId);
            GetComputerInfo();
        }

        public bool IsProcessOpen(string name)
        {
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    //if the process is found to be running then we
                    //return a true
                    return true;
                }
            }
            //otherwise we return a false
            return false;
        }

        public bool GetComputerInfo()
        {
            var Info = new CompInfo();
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                Info.COMP_Name = (string)mo["Name"];
                Info.COMP_Manufacturer = (string)mo["Manufacturer"];
                Info.COMP_Model = (string)mo["Model"];
                Info.COMP_ChassisSKUNumber = (string)mo["ChassisSKUNumber"];
                Info.COMP_NumberOfProcessors = (uint)mo["NumberOfProcessors"];
                Info.COMP_NumberOfLogicalProcessors = (uint)mo["NumberOfLogicalProcessors"];
                Info.COMP_PCSystemType = (ushort)mo["PCSystemType"];
                Info.COMP_ThermalState = (ushort)mo["ThermalState"];
                Info.COMP_TotalPhysicalMemory = (ulong)mo["TotalPhysicalMemory"];
                Info.COMP_UserName = (string)mo["UserName"];
                Info.COMP_Domain = (string)mo["Domain"];
                Info.COMP_Workgroup = (string)mo["Workgroup"];
                Info.COMP_InstallDate = (DateTime)mo["InstallDate"];
            }

            mc = new ManagementClass("Win32_BIOS");
            moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                Info.BIOS_Caption = (string)mo["Caption"];
                Info.BIOS_Manufacturer = (string)mo["Manufacturer"];
                Info.BIOS_SerialNumber = (string)mo["SerialNumber"];
                Info.BIOS_BIOSVersion = (string)mo["BIOSVersion"];
                Info.BIOS_BuildNumber = (string)mo["BuildNumber"];
                Info.BIOS_Status = (string)mo["Status"];
            }

            mc = new ManagementClass("Win32_OperatingSystem");
            moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                Info.WIN_Caption = (string)mo["Caption"];
                Info.WIN_BuildNumber = (string)mo["BuildNumber"];
                Info.WIN_CurrentTimeZone = (int)mo["CurrentTimeZone"];
                Info.WIN_InstallDate = (DateTime)mo["InstallDate"];
                Info.WIN_LocalDateTime = (DateTime)mo["LocalDateTime"];
                Info.WIN_Locale = (string)mo["Locale"];
                Info.WIN_OSArchitecture = (string)mo["OSArchitecture"];
                Info.WIN_OSLanguage = (string)mo["OSLanguage"];
                Info.WIN_SystemDirectory = (string)mo["SystemDirectory"];
                Info.WIN_SystemDrive = (string)mo["SystemDrive"];
                Info.WIN_FreePhysicalMemory = (ulong)mo["FreePhysicalMemory"];
                Info.WIN_FreeSpaceInPagingFiles = (ulong)mo["FreeSpaceInPagingFiles"];
                Info.WIN_FreeVirtualMemory = (ulong)mo["FreeVirtualMemory"];
                Info.WIN_Status = (string)mo["Status"];
                Info.WIN_OperatingSystemSKU = (uint)mo["OperatingSystemSKU"];
                Info.WIN_SerialNumber = (string)mo["SerialNumber"];
                Info.WIN_WindowsDirectory = (string)mo["WindowsDirectory"];
                Info.WIN_TotalSwapSpaceSize = (uint)mo["TotalSwapSpaceSize"];
                Info.WIN_TotalVirtualMemorySize = (ulong)mo["TotalVirtualMemorySize"];
                Info.WIN_TotalVisibleMemorySize = (ulong)mo["TotalVisibleMemorySize"];
            }

            mc = new ManagementClass("Win32_OperatingSystem");
            moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                Info.WIN_Caption = (string)mo["Caption"];
                Info.WIN_BuildNumber = (string)mo["BuildNumber"];
                Info.WIN_CurrentTimeZone = (int)mo["CurrentTimeZone"];
                Info.WIN_InstallDate = (DateTime)mo["InstallDate"];
                Info.WIN_LocalDateTime = (DateTime)mo["LocalDateTime"];
                Info.WIN_Locale = (string)mo["Locale"];
                Info.WIN_OSArchitecture = (string)mo["OSArchitecture"];
                Info.WIN_OSLanguage = (string)mo["OSLanguage"];
                Info.WIN_SystemDirectory = (string)mo["SystemDirectory"];
                Info.WIN_SystemDrive = (string)mo["SystemDrive"];
                Info.WIN_FreePhysicalMemory = (ulong)mo["FreePhysicalMemory"];
                Info.WIN_FreeSpaceInPagingFiles = (ulong)mo["FreeSpaceInPagingFiles"];
                Info.WIN_FreeVirtualMemory = (ulong)mo["FreeVirtualMemory"];
                Info.WIN_Status = (string)mo["Status"];
                Info.WIN_OperatingSystemSKU = (uint)mo["OperatingSystemSKU"];
                Info.WIN_SerialNumber = (string)mo["SerialNumber"];
                Info.WIN_WindowsDirectory = (string)mo["WindowsDirectory"];
                Info.WIN_TotalSwapSpaceSize = (uint)mo["TotalSwapSpaceSize"];
                Info.WIN_TotalVirtualMemorySize = (ulong)mo["TotalVirtualMemorySize"];
                Info.WIN_TotalVisibleMemorySize = (ulong)mo["TotalVisibleMemorySize"];
            }

            return false;
        }

        public  string GetOSVersion()
        {
                ManagementClass wmi = new ManagementClass("Win32_OperatingSystem");
                ManagementObjectCollection allConfigs = wmi.GetInstances();
                string Osversion = string.Empty;

                foreach (ManagementObject configuration in allConfigs)
                {
                    Osversion = configuration["Version"] == null ? string.Empty : configuration["Version"].ToString();

                    if (Osversion.Length > 0)
                        break;
                }

                return Osversion;
        }

        /// Retrieving Network IP
        private string[] GetDefaultIPWithSubnet()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string[] ipSubnet = new string[2];
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"])
                {
                    try
                    {
                        string[] ips = (string[])mo["IPAddress"];
                        string[] subnets = (string[])mo["IPSubnet"];
                        ipSubnet[0] = ips[0].ToString();
                        ipSubnet[1] = subnets[0].ToString();
                        break;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
            return ipSubnet;
        }

        /// Retrieving Network Gateway
        public string GetDefaultIPGateway()
        {
            //create out management class object using the
            //Win32_NetworkAdapterConfiguration class to get the attributes
            //of the network adapter
            ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //create our ManagementObjectCollection to get the attributes with
            ManagementObjectCollection objCol = mgmt.GetInstances();
            string gateway = String.Empty;
            //loop through all the objects we find
            foreach (ManagementObject obj in objCol)
            {
                if (gateway == String.Empty)  // only return MAC Address from first card
                {
                    //grab the value from the first network adapter we find
                    //you can change the string to an array and get all
                    //network adapters found as well
                    //check to see if the adapter's IPEnabled
                    //equals true
                    if ((bool)obj["IPEnabled"] == true)
                    {
                        gateway = obj["DefaultIPGateway"].ToString();
                    }
                }
                //dispose of our object
                obj.Dispose();
            }
            //replace the ":" with an empty space, this could also
            //be removed if you wish
            gateway = gateway.Replace(":", "");
            //return the mac address
            return gateway;
        }

        /// Retrieving MAC Address
        public string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == String.Empty)
                {
                    if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }

            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
        }

        /// Retrieving Processor Information.
        public static String GetProcessorInformation()
        {
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String info = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                string name = (string)mo["Name"];
                name = name.Replace("(TM)", "™").Replace("(tm)", "™").Replace("(R)", "®").Replace("(r)", "®").Replace("(C)", "©").Replace("(c)", "©").Replace("    ", " ").Replace("  ", " ");

                info = name + ", " + (string)mo["Caption"] + ", " + (string)mo["SocketDesignation"];
                //mo.Properties["Name"].Value.ToString();
                //break;
            }
            return info;
        }

        ///Get Processor Manufacturer.
        public string GetCPUManufacturer()
        {
            string cpuMan = String.Empty;
            //create an instance of the Managemnet class with the
            //Win32_Processor class
            ManagementClass mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            ManagementObjectCollection objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach (ManagementObject obj in objCol)
            {
                if (cpuMan == String.Empty)
                {
                    // only return manufacturer from first CPU
                    cpuMan = obj.Properties["Manufacturer"].Value.ToString();
                }
            }
            return cpuMan;
        }

        /// Retrieving Processor Id.
        public string GetProcessorId()
        {

            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject mo in moc)
            {

                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return Id;
        }
        
        /// Retrieve CPU Current Speed.
        public int GetCPUCurrentClockSpeed()
        {
            int cpuClockSpeed = 0;
            //create an instance of the Managemnet class with the
            //Win32_Processor class
            ManagementClass mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            ManagementObjectCollection objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach (ManagementObject obj in objCol)
            {
                if (cpuClockSpeed == 0)
                {
                    // only return cpuStatus from first CPU
                    cpuClockSpeed = Convert.ToInt32(obj.Properties["CurrentClockSpeed"].Value.ToString());
                }
            }
            //return the status
            return cpuClockSpeed;
        }

        /// Retrieve CPU MAX Speed.
        public static double? GetCpuSpeedInGHz()
        {
            double? GHz = null;
            using (ManagementClass mc = new ManagementClass("Win32_Processor"))
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    GHz = 0.001 * (UInt32)mo.Properties["CurrentClockSpeed"].Value;
                    break;
                }
            }
            return GHz;
        }

        /// Retrieving HDD Serial No.
        public string GetHDDSerialNo()
        {
            ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection mcol = mangnmt.GetInstances();
            string result = "";
            foreach (ManagementObject strt in mcol)
            {
                result += Convert.ToString(strt["VolumeSerialNumber"]);
            }
            return result;
        }

        /// Retrieving Motherboard Manufacturer.
        public string GetBoardMaker()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }

                catch { }

            }
            return "Board Maker: Unknown";
        }

        /// Retrieving Motherboard Product Id.
        public string GetBoardProductId()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Product").ToString();

                }

                catch { }

            }

            return "Product: Unknown";

        }

        public string GetBIOSmaker()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();

                }

                catch { }

            }

            return "BIOS Maker: Unknown";

        }

        /// Retrieving BIOS Serial No.
        public string GetBIOSserNo()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("SerialNumber").ToString();

                }

                catch { }

            }

            return "BIOS Serial Number: Unknown";

        }

        /// Retrieving BIOS Caption.
        public string GetBIOScaption()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Caption").ToString();

                }
                catch { }
            }
            return "BIOS Caption: Unknown";
        }

        /// Retrieving CD-DVD Drive Path.
        public string GetCdRomDrive()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_CDROMDrive");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Drive").ToString();

                }

                catch { }

            }
            return "CD ROM Drive Letter: Unknown";
        }


        /// Retrieving Physical Memory.
        public string GetPhysicalMemory()
        {
            ManagementScope oMs = new ManagementScope();
            ObjectQuery oQuery = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
            ManagementObjectCollection oCollection = oSearcher.Get();

            long MemSize = 0;
            long mCap = 0;

            // In case more than one Memory sticks are installed
            foreach (ManagementObject obj in oCollection)
            {
                mCap = Convert.ToInt64(obj["Capacity"]);
                MemSize += mCap;
            }
            MemSize = (MemSize / 1024) / 1024;
            return MemSize.ToString() + "MB";
        }

        /// Retrieving No of Ram Slot on Motherboard.
        public string GetNoRamSlots()
        {

            int MemSlots = 0;
            ManagementScope oMs = new ManagementScope();
            ObjectQuery oQuery2 = new ObjectQuery("SELECT MemoryDevices FROM Win32_PhysicalMemoryArray");
            ManagementObjectSearcher oSearcher2 = new ManagementObjectSearcher(oMs, oQuery2);
            ManagementObjectCollection oCollection2 = oSearcher2.Get();
            foreach (ManagementObject obj in oCollection2)
            {
                MemSlots = Convert.ToInt32(obj["MemoryDevices"]);

            }
            return MemSlots.ToString();
        }


        // Check Antivirus Name if exist.
        public ManagementObjectCollection AntivirusInstalled()
        {
            string wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter2";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
                ManagementObjectCollection instances = searcher.Get();
                return instances;
            }
            catch (Exception e)
            {
                EventLog.WriteEntry("QuickMon Agent Error : " + e.Message + " " + e.InnerException, EventLogEntryType.Error);
            }
            return null;
        }




    }
}
