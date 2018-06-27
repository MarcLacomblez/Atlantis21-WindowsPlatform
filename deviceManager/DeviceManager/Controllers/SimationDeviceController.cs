using DeviceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceManager.Controllers
{
    public class SimationDeviceController : Controller
    {
        // GET: SimationDevice
        public ActionResult Index()
        {
            return View();
        }

        public Device GetDevice()
        {
            var r = new Random();
            var device = new Device()
            {
                Id_Device = r.Next(0, 1000),
                ValueIsInt = (r.Next(0, 100) >= 10),
                Date = DateTime.Now,
                GPSPosition_X = 1.091451,
                GPSPosition_Y = 49.477107,
            };
            if (device.ValueIsInt)
            {
                var choiceDevice = r.Next(0, 7);
                switch (choiceDevice)
                {
                    case 0:
                        device.Name = "Light sensor";
                        var typeLight = r.Next(0, 7);
                        switch (typeLight)
                        {
                            case 0:
                                device.Value = "0.5";
                                break;
                            case 1:
                                device.Value = r.Next(20, 70).ToString();
                                break;
                            case 2:
                                device.Value = r.Next(100, 200).ToString();
                                break;
                            case 3:
                                device.Value = r.Next(200, 400).ToString();
                                break;
                            case 4:
                                device.Value = r.Next(200, 3000).ToString();
                                break;
                            case 5:
                                device.Value = r.Next(500, 25000).ToString();
                                break;
                            case 6:
                                device.Value = r.Next(50000, 100000).ToString();
                                break;
                        }
                        break;
                    case 1:
                        device.Name = "Temperature sensor";
                        device.Value = (RandomNumberBetween(0, 31)).ToString();
                        break;
                    case 2:
                        device.Name = "Atmospheric pressure sensor";
                        device.Value = (RandomNumberBetween(990, 1040)).ToString();
                        break;
                    case 3:
                        device.Name = "Humidity sensor";
                        device.Value = (RandomNumberBetween(50, 100)).ToString();
                        break;
                    case 4:
                        device.Name = "CO2 level sensor";
                        device.Value = r.Next(400, 2000).ToString();
                        break;
                    case 5:
                        device.Name = "Precipitation sensor";
                        device.Value = r.Next(100, 300).ToString();
                        break;
                    case 6:
                        device.Name = "Sound level sensor";
                        device.Value = r.Next(50, 95).ToString();
                        break;
                }
            }
            else
            {
                device.Name = "Presence sensor";
                device.Value = ((r.Next(0, 1) % 2) == 0).ToString();
            }
            return device;
        }

        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var random = new Random();
            var next = random.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }
    }
}