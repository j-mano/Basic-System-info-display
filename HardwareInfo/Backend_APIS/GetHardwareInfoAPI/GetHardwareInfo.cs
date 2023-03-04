using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Backend_APIS.DataModells;
using LibreHardwareMonitor.Hardware;

namespace Backend_APIS.GetHardwareInfoAPI
{
    public static class GetCPUInfo
    {
        /// <summary>
        /// This function is return the name and properties of gpus in an list. Each gpu start with an gpu and follow of maximum of 3 properties blankstek before each property/sensor.
        /// windows in an vm are dectected. This feature is not supported in non sys32 operatingsystem like macintosh and linux.
        /// </summary>
        public static async Task<List<string>> GetGpuAsync()
        {
            List<string> returnGpuHardware = new();

            await Task.Run(() =>
            {
                Computer computer = new Computer
                {
                    IsGpuEnabled = true
                };

                computer.Open();
                computer.Accept(new UpdateVisitor());

                // Finding Nvidia gtx, AMD radeon, Intel Arc.
                foreach (IHardware hardware in computer.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.GpuNvidia || hardware.HardwareType == HardwareType.GpuAmd || hardware.HardwareType == HardwareType.GpuIntel)
                    {
                        returnGpuHardware.Add(hardware.Name);
                    }

                    // setting a maximum properties to return on each gpu.
                    int MaxValue = 0;

                    foreach (IHardware subhardware in hardware.SubHardware)
                    {
                            // setting a maximum properties to return on each gpu.
                            MaxValue++;
                            if(MaxValue >= 5) { break; }

                            returnGpuHardware.Add("     Sensor: " + subhardware.Name);
                            returnGpuHardware.Add("         Property: " + subhardware.Properties.ToString());
                    }
                }

                computer.Close();

                try { 
                    // Get GPU name from virtual maskins. // SYS32 windows only.
                    using (var searcher = new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
                    {
                        using (var items = searcher.Get())
                        {
                            foreach (var item in items)
                            {
                                string manufacturer = item["Manufacturer"].ToString().ToLower();
                                if ((manufacturer == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL"))
                                    || manufacturer.Contains("vmware")
                                    || item["Model"].ToString() == "VirtualBox")
                                {
                                    returnGpuHardware.Add(item["Manufacturer"].ToString());
                                    returnGpuHardware.Add("     Model: " + item["Model"].ToString());
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Sys32 does not exist");
                }

                if (returnGpuHardware.Count <= 0)
                {
                    returnGpuHardware.Add("No gpu found.");
                }
            });

            return returnGpuHardware;
        }

        public static async Task<CPUModell> GetCpuAsync()
        {
            string returnCpuHardware = "";
            CPUModell CpuInfoReturn = new CPUModell();

            await Task.Run(() =>
            {
                Computer computer = new Computer
                {
                    IsCpuEnabled = true,
                };

                computer.Open();
                computer.Accept(new UpdateVisitor());

                foreach (IHardware hardware in computer.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.Cpu)
                    {
                        returnCpuHardware = hardware.Name;
                        CpuInfoReturn.CpuName = hardware.Name;
                        //CpuInfoReturn.Cpu_Core_Cunt = hardware.time
                    }

                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        Console.WriteLine("\tSensor: {0}, value: {1}", sensor.Name, sensor.Value);
                        if(sensor.Name == "Core #1")
                        {
                            Console.WriteLine("temp");
                            CpuInfoReturn.Cpu_Core_Cunt = CpuInfoReturn.Cpu_Core_Cunt + 1;
                        }
                    }
                }

                computer.Close();

                Console.WriteLine(returnCpuHardware);
            });

            return CpuInfoReturn;
        }

        public static List<List<string>> GetCpuSensor()
        {
            List < List<string> > returnCpuHardware = new List<List<string>>();

            Computer computer = new Computer
            {
                IsCpuEnabled = true,
            };

            computer.Open();
            computer.Accept(new UpdateVisitor());

            foreach (IHardware hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                {
                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        Console.WriteLine("\tSensor: {0}, value: {1}", sensor.Name, sensor.Value);

                        List<string> TemopList = new List<string>();
                        TemopList.Add(sensor.Name);
                        TemopList.Add(sensor.Value.ToString());

                        returnCpuHardware.Add(TemopList);
                    }
                }
            }

            computer.Close();

            Console.WriteLine(returnCpuHardware);

            return returnCpuHardware;
        }

        public static async Task<RamModell> GetRam()
        {
            RamModell ReturnRamModell = new RamModell();

            await Task.Run(() =>
            {
                Computer computer = new Computer
                {
                    IsMemoryEnabled = true,
                };

                computer.Open();
                computer.Accept(new UpdateVisitor());

                foreach (IHardware hardware in computer.Hardware)
                {
                    if (hardware.HardwareType == HardwareType.Memory)
                    {
                        ReturnRamModell.RamName = hardware.Name;
                    }

                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        if(sensor.Name == "Memory")
                        {
                            ReturnRamModell.RamAmount = (float)sensor.Value;
                        }
                    }
                }

                computer.Close();
            });

            return ReturnRamModell;
        }
    }

    public class UpdateVisitor : IVisitor
    {
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }
        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
        }
        public void VisitSensor(ISensor sensor) { }
        public void VisitParameter(IParameter parameter) { }
    }
}
