using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneratorData
{
    class Program
    {
        static void Main(string[] args)
        {
            var listDevice = new List<Device>();
            var r = new Random();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/DeviceManager");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                for (int i = 0; i < 1; i++)
                {
                    var device1 = new Device()
                    {
                        Id_Device = r.Next(0, 1000),
                        ValueIsInt = true,
                        Date = DateTime.Now,
                        GPSPosition_X = 1.091451,
                        GPSPosition_Y = 49.477107,
                        Name = "Temperature sensor",
                        Value = (RandomNumberBetween(0, 31)).ToString()
                    };
                    listDevice.Add(device1);

                    var device2 = new Device()
                    {
                        Id_Device = r.Next(0, 1000),
                        ValueIsInt = true,
                        Date = DateTime.Now,
                        GPSPosition_X = 1.091451,
                        GPSPosition_Y = 49.477107,
                        Name = "Light sensor",
                    };
                    var typeLight = r.Next(0, 7);
                    switch (typeLight)
                    {
                        case 0:
                            device2.Value = "0.5";
                            break;
                        case 1:
                            device2.Value = r.Next(20, 70).ToString();
                            break;
                        case 2:
                            device2.Value = r.Next(100, 200).ToString();
                            break;
                        case 3:
                            device2.Value = r.Next(200, 400).ToString();
                            break;
                        case 4:
                            device2.Value = r.Next(200, 3000).ToString();
                            break;
                        case 5:
                            device2.Value = r.Next(500, 25000).ToString();
                            break;
                        case 6:
                            device2.Value = r.Next(50000, 100000).ToString();
                            break;
                    }
                    listDevice.Add(device2);

                    var device3 = new Device()
                    {
                        Id_Device = r.Next(0, 1000),
                        ValueIsInt = true,
                        Date = DateTime.Now,
                        GPSPosition_X = 1.091451,
                        GPSPosition_Y = 49.477107,
                        Name = "Atmospheric pressure sensor",
                        Value = (RandomNumberBetween(990, 1040)).ToString()
                    };
                    listDevice.Add(device3);

                    var device4 = new Device()
                    {
                        Id_Device = r.Next(0, 1000),
                        ValueIsInt = true,
                        Date = DateTime.Now,
                        GPSPosition_X = 1.091451,
                        GPSPosition_Y = 49.477107,
                        Name = "Humidity sensor",
                        Value = (RandomNumberBetween(50, 100)).ToString()
                    };
                    listDevice.Add(device4);

                    var device5 = new Device()
                    {
                        Id_Device = r.Next(0, 1000),
                        ValueIsInt = true,
                        Date = DateTime.Now,
                        GPSPosition_X = 1.091451,
                        GPSPosition_Y = 49.477107,
                        Name = "CO2 level sensor",
                        Value = r.Next(400, 2000).ToString()
                    };
                    listDevice.Add(device5);

                    var device6 = new Device()
                    {
                        Id_Device = r.Next(0, 1000),
                        ValueIsInt = true,
                        Date = DateTime.Now,
                        GPSPosition_X = 1.091451,
                        GPSPosition_Y = 49.477107,
                        Name = "Precipitation sensor",
                        Value = r.Next(100, 300).ToString()
                    };
                    listDevice.Add(device6);

                    var device7 = new Device()
                    {
                        Id_Device = r.Next(0, 1000),
                        ValueIsInt = true,
                        Date = DateTime.Now,
                        GPSPosition_X = 1.091451,
                        GPSPosition_Y = 49.477107,
                        Name = "Sound level sensor",
                        Value = r.Next(50, 95).ToString()
                    };
                    listDevice.Add(device7);

                    var device8 = new Device()
                    {
                        Id_Device = r.Next(0, 1000),
                        ValueIsInt = false,
                        Date = DateTime.Now,
                        GPSPosition_X = 1.091451,
                        GPSPosition_Y = 49.477107,
                        Name = "Presence sensor",
                        Value = ((r.Next(0, 1) % 2) == 0).ToString()
                    };
                    listDevice.Add(device8);
                    //Console.WriteLine(listDevice);

                    Console.WriteLine("POST");
                    HttpResponseMessage response;
                    response = client.PostAsJsonAsync("api/Values", device1).Result;
                    Console.WriteLine(response);
                    Thread.Sleep(1000);
                }
            }
            Console.ReadLine();

        }
        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var random = new Random();
            var next = random.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }
    }

    class Device
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
        public string MacAddress { get; set; }
    }
}


