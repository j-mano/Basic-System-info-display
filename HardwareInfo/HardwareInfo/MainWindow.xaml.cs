using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Backend_APIS.DataModells;
using Backend_APIS.GetHardwareInfoAPI;

namespace HardwareInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Update_BTN_Click(object sender, RoutedEventArgs e)
        {
            /*UpdateGpuList();
            PrintOutCpuInfo();*/
            printout();
        }

        private async void printout()
        {
            // Get a list of dedicated GPUS. Getting back alla dedicated gpus in the pc (Nvidia gtx, AMD radeon, Intel Arc, Vmware). Intregrated gpus not found. 
            List<string> hardwareGPU = await GetCPUInfo.GetGpuAsync();

            // Clear the gpu naming list and adding all gpus (plurals) in the list.
            GPU_List.Items.Clear();
            for (int i = 0; i < hardwareGPU.Count; i++)
            {
                GPU_List.Items.Add(hardwareGPU[i]);
            }

            //Printout CPU
            CPUModell CPU = await GetCPUInfo.GetCpuAsync();
            CPUName.Content = CPU.CpuName;
            CPU_AmountOfCore.Content = "Amount of pysical cpu cores: " + CPU.Cpu_Core_Cunt;

            //Printout Ram
            RamModell ram = await GetCPUInfo.GetRam();
            RamLabel.Content = "Ramname: " + ram.RamName + " RamAmount: " + ram.RamAmount;

            List<List<string>> CpuSensors = GetCPUInfo.GetCpuSensor();

            foreach (var item in CpuSensors)
            {
                Console.WriteLine(item.ToString());
            }
        }

        // Filling the list of the GPU List.
        private async void UpdateGpuList()
        {
            // Get a list of dedicated GPUS. Intregrated and vmware gpus not found.
            List<string> hardwareCPU = await GetCPUInfo.GetGpuAsync();
            
            for (int i = 0; i < hardwareCPU.Count; i++)
            {
                GPU_List.Items.Add(hardwareCPU[i]);
            }
        }

        private async void PrintOutCpuInfo()
        {
            //Printout CPU
            CPUModell CPU = await GetCPUInfo.GetCpuAsync();
            CPUName.Content = CPU.CpuName;

            //Printout Ram
            RamModell ram = await GetCPUInfo.GetRam();
            RamLabel.Content = ram.RamName;
        }

        // Getting used to test the front end gpu list
        private List<string> GetGPUList()
        {
            // Example to test list
            List<string> GetGpuList = new List<string>();

            GetGpuList.Add("Nvidia Gtx 1660 super");
            GetGpuList.Add("Nvidia Rtx 2060");
            GetGpuList.Add("AMD HD 5880");

            return GetGpuList;
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TempList win2 = new TempList();
            win2.Show();
        }
    }
}
