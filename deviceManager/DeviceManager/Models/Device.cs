using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceManager.Models
{
    public class Device
    {
        public int Id_Device { get; set; }
        public string Name { get; set; }
        public bool ValueIsInt { get; set; }
        public DateTime Date { get; set; }
        public string Value { get; set; }
        public int? NumberValue { get; set; }
        public double GPSPosition_X { get; set; }
        public double GPSPosition_Y { get; set; }
        public int? Id_User { get; set; }
    }
}