using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Backend_APIS.GetHardwareInfoAPI;

namespace HardwareInfo
{
    /// <summary>
    /// Interaction logic for TempList.xaml
    /// </summary>
    public partial class TempList : Window
    {
        public TempList()
        {
            InitializeComponent();


            //List<string> cpuSensors = GetCPUInfo.GetCpuSensor();
        }
    }
}
