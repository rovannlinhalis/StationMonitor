using StationMonitor.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmApp.Funcoes
{
    public static class Hardware
    {
        
        public static string GetProcessador()
        {
            string r = "";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                ManagementObjectCollection information = searcher.Get();
                foreach (ManagementObject obj in information)
                {
                    r = obj["Manufacturer"].ToString() + " - " + obj["Name"].ToString() + "-" + obj["DataWidth"].ToString() + "-Bits";
                }

            }
            catch
            {
                r = "Erro ao buscar Processador";
            }

            return r;
        }
        public static TemperatureProbe GetTemperature()
        {
            TemperatureProbe t = new TemperatureProbe();
            t.Warning = t.Current = null;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
            ManagementObjectCollection information = searcher.Get();
            if (information != null && information.Count > 0)
            {
                foreach (ManagementObject obj in information)
                {
                    double w = 0;

                    if (obj.Properties["CriticalTripPoint"].Value != null)
                        if (double.TryParse(obj.Properties["CriticalTripPoint"].Value.ToString(), out w))
                        {

                            ///10 -273.15) *1.8 +32
                            ////10 - 273.15
                            t.Warning = (w / 10 - 273.15);// *1.8 + 32;
                        }

                    double c = 0;
                    if (obj.Properties["CriticalTripPoint"].Value != null)
                        if (double.TryParse(obj.Properties["CurrentTemperature"].Value.ToString(), out c))
                        {
                            t.Current = (c / 10 - 273.15);// * 1.8 + 32; 
                        }
                }
            }

            return t;
        }
        public static string GetPlacaMae()
        {
            string r = "";

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                ManagementObjectCollection information = searcher.Get();
                foreach (ManagementObject obj in information)
                {
                    r = obj["Manufacturer"].ToString() + " - " + obj["Product"].ToString();
                }

            }
            catch
            {
                r = "Erro ao buscar MB";

            }

            return r;
        }
        public static UInt64 GetMemRam()
        {
            UInt64 r = 0;
            try
            {
                ManagementObjectSearcher query1 = new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory");
                ManagementObjectCollection queryCollection1 = query1.Get();
                foreach (ManagementObject mo in queryCollection1)
                {
                    r += UInt64.Parse(mo["Capacity"].ToString());
                }
            }
            catch (Exception ex)
            {
                r = 0;
            }
            return r;

            //double r = 0;
            //try
            //{
            //    ManagementObjectSearcher query1 = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            //    ManagementObjectCollection queryCollection1 = query1.Get();
            //    foreach (ManagementObject mo in queryCollection1)
            //    {
            //        r = double.Parse(mo["totalphysicalmemory"].ToString());
            //    }
            //}
            //catch
            //{
            //    r = 0;
            //}
            //return r;
        }
        public static Win32_OperatingSystem GetWin32_OperatingSystem()
        {
            Win32_OperatingSystem obj = new Win32_OperatingSystem();
            try
            {
                ManagementObjectSearcher query1 = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectCollection queryCollection1 = query1.Get();
                foreach (ManagementObject mo in queryCollection1)
                {
                    
                    foreach (System.Reflection.PropertyInfo pr in typeof(Win32_OperatingSystem).GetProperties())
                    {
                        pr.SetValue(obj, mo.GetPropertyValue(pr.Name));
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                
            }
            return obj;

            //double r = 0;
            //try
            //{
            //    ManagementObjectSearcher query1 = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            //    ManagementObjectCollection queryCollection1 = query1.Get();
            //    foreach (ManagementObject mo in queryCollection1)
            //    {
            //        r = double.Parse(mo["totalphysicalmemory"].ToString());
            //    }
            //}
            //catch
            //{
            //    r = 0;
            //}
            //return r;
        }
        public static string GetOS()
        {
            string r = "";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectCollection information = searcher.Get();
                foreach (ManagementObject obj in information)
                {
                    r = obj["Caption"].ToString() + " - " + obj["OSArchitecture"].ToString();
                }

            }
            catch
            {
                try
                {
                    r = Environment.OSVersion.ToString();
                }
                catch
                {
                    r = "Erro ao buscar versão do windows.";
                }
            }

            r = r.Replace("NT 5.1.2600", "XP");
            r = r.Replace("NT 5.2.3790", "Server 2003");


            return r;
        }
        public static string GetArquitetura()
        {
            string r = "";
            try
            {
                string strProcArchi = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
                if (strProcArchi.IndexOf("64") > 0)
                {
                    r = "64";
                }
                else
                {
                    r = "32";
                }
            }
            catch { r = ""; }

            return r;
        }
        public static string GetResolucao()
        {
            string r = SystemInformation.PrimaryMonitorSize.ToString();
            r = r.Replace(@"{Width=", "");
            r = r.Replace(@"Height=", "");
            r = r.Replace(@"}", "");
            r = r.Replace(@" ", "");
            r = r.Replace(@",", "x");
            return r;
        }
        public static List<Driver> GetDrives(Guid estacaoId)
        {
            List<Driver> result = new List<Driver>();
            foreach (DriveInfo inf in DriveInfo.GetDrives())
            {
                if (inf.IsReady)
                {
                    if (inf.DriveType == DriveType.Fixed || inf.DriveType == DriveType.Network)
                    {
                        result.Add(new Driver() { StationId = estacaoId, Format = inf.DriveFormat, Letter = inf.Name, Label = inf.VolumeLabel, FreeSize = inf.TotalFreeSpace, TotalSize = inf.TotalSize, Type = ((StationInterface.Enum.DriveType)inf.DriveType) });
                        

                        //r["Nome"] = inf.Name;
                        //r["Tamanho"] = inf.TotalSize;
                        //r["Livre"] = inf.TotalFreeSpace;
                        //r["Formato"] = inf.DriveFormat;
                        //r["Tipo"] = inf.DriveType.ToString();
                        //r["Etiqueta"] = inf.VolumeLabel.ToString();
                        //r["Windows"] = (inf.RootDirectory.FullName == windir.ToString().Remove(3, windir.Length - 3));
                        //r["Sistema"] = Directory.Exists(inf.RootDirectory.FullName + "Integra\\");

                        
                    }
                }
            }
            return result;
        }
        public static List<Conexao> GetRedes(Guid estacaoId)
        {
            List<Conexao> result = new List<Conexao>();

            NetworkInterface[] adaptadores = NetworkInterface.GetAllNetworkInterfaces();
            int s = 1;
            foreach (NetworkInterface i in adaptadores)
            {
                if (i.NetworkInterfaceType != NetworkInterfaceType.Tunnel && i.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    result.Add(new Conexao() { StationId = estacaoId, Sequence = s, Name = i.Name, Status = i.OperationalStatus.ToString(), Type = i.NetworkInterfaceType.ToString(), Speed = i.Speed });
                    s++;
                    //r["Nome"] = i.Name;
                    //string ip = "";
                    //foreach (UnicastIPAddressInformation ipInfo in i.GetIPProperties().UnicastAddresses)
                    //{
                    //    if (ipInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    //    {
                    //        ip += ipInfo.Address.ToString() + ",";
                    //    }
                    //}
                    //if (ip.Length != 0)
                    //    ip = ip.Remove(ip.Length - 1);

                    //r["IP"] = ip;
                    //r["Velocidade"] = i.Speed;
                    //r["Tipo"] = i.NetworkInterfaceType.ToString();
                    //r["Status"] = i.OperationalStatus.ToString();

                }
            }

            return result;
        }


        public class TemperatureProbe
        {
            public double? Warning { get; set; }
            public double? Current { get; set; }
        }

    }

    public class Win32_OperatingSystem
    {
        public string Caption { get; set; }
        public UInt64? FreePhysicalMemory { get; set; }
        public string InstallDate { get; set; }
        public string LastBootUpTime { get; set; }
        public string LocalDateTime { get; set; }
        public string Manufacturer { get; set; }
        public string OSArchitecture { get; set; }
        public string SerialNumber { get; set; }
        public string Version { get; set; }
        public string WindowsDirectory { get; set; }
    }
}
