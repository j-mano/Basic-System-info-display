using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_APIS.DataModells
{
    public class RamModell
    {
        public string RamName { get; set; }
        public float RamAmount { get; set; }
        public int RamType { get; set; } //ddr3 or ddr4 or ddr5
        public int RamSpeed { get; set; } // MHZ
    }
}
