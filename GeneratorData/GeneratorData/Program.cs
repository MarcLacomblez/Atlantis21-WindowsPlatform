using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            MainAsync("http://atlantis21.azurewebsites.net");
            Console.ReadLine();
        }

        async static void MainAsync(string url)
        {
            var r = new Random();
            var dateGen = DateTime.Now.AddDays(-4);
            var dataRecup = new DataRecup();
            using (var client = new HttpClient())
            {
                var listIdPres = new List<DataRecup>();
                var listIdLight = new List<DataRecup>();
                var listIdTemp = new List<DataRecup>();
                var listIdAtPres = new List<DataRecup>();
                var listIdHum = new List<DataRecup>();
                var listIdCo2 = new List<DataRecup>();
                var listIdPrecip = new List<DataRecup>();
                var listIdSound = new List<DataRecup>();

                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //put each id from sensor in list
                using (var responseGet = await client.GetAsync("api/Devices/Get"))
                {
                    using (var content = responseGet.Content)
                    {
                        var device = await responseGet.Content.ReadAsStringAsync();
                        var stringSplit = device.Split(new[] { "_id" }, StringSplitOptions.None);
                        stringSplit = stringSplit.Skip(1).ToArray();
                        foreach (var item in stringSplit)
                        {
                            if (item.Contains("Presence sensor"))
                            {
                                var deviceValue = item.Split(',');
                                var deviceGetId = deviceValue[1].Split(':');
                                var finalId = int.Parse(deviceGetId[1]);
                                var userGetId = deviceValue[9].Split(':');
                                var UserId = int.TryParse(userGetId[1], out int outValue) ? (int?)outValue : null;
                                var dataGet = new DataRecup {
                                    Id = finalId,
                                    User_Id = UserId
                                };
                                if (!listIdPres.Any(x => x.Id == dataGet.Id))
                                       listIdPres.Add(dataGet);
                            }
                            if (item.Contains("Light sensor"))
                            {
                                var deviceValue = item.Split(',');
                                var deviceGetId = deviceValue[1].Split(':');
                                var finalId = int.Parse(deviceGetId[1]);
                                var userGetId = deviceValue[9].Split(':');
                                var UserId = int.TryParse(userGetId[1], out int outValue) ? (int?)outValue : null;
                                var dataGet = new DataRecup
                                {
                                    Id = finalId,
                                    User_Id = UserId
                                };
                                if (!listIdLight.Any(x => x.Id == dataGet.Id))
                                    listIdLight.Add(dataGet);
                            }
                            if (item.Contains("Temperature sensor"))
                            {
                                var deviceValue = item.Split(',');
                                var deviceGetId = deviceValue[1].Split(':');
                                var finalId = int.Parse(deviceGetId[1]);
                                var userGetId = deviceValue[9].Split(':');
                                var UserId = int.TryParse(userGetId[1], out int outValue) ? (int?)outValue : null;
                                var dataGet = new DataRecup
                                {
                                    Id = finalId,
                                    User_Id = UserId
                                };
                                if (!listIdTemp.Any(x => x.Id == dataGet.Id))
                                    listIdTemp.Add(dataGet);
                            }
                            if (item.Contains("Atmospheric pressure sensor"))
                            {
                                var deviceValue = item.Split(',');
                                var deviceGetId = deviceValue[1].Split(':');
                                var finalId = int.Parse(deviceGetId[1]);
                                var userGetId = deviceValue[9].Split(':');
                                var UserId = int.TryParse(userGetId[1], out int outValue) ? (int?)outValue : null;
                                var dataGet = new DataRecup
                                {
                                    Id = finalId,
                                    User_Id = UserId
                                };
                                if (!listIdAtPres.Any(x => x.Id == dataGet.Id))
                                    listIdAtPres.Add(dataGet);
                            }
                            if (item.Contains("Humidity sensor"))
                            {
                                var deviceValue = item.Split(',');
                                var deviceGetId = deviceValue[1].Split(':');
                                var finalId = int.Parse(deviceGetId[1]);
                                var userGetId = deviceValue[9].Split(':');
                                var UserId = int.TryParse(userGetId[1], out int outValue) ? (int?)outValue : null;
                                var dataGet = new DataRecup
                                {
                                    Id = finalId,
                                    User_Id = UserId
                                };
                                if (!listIdHum.Any(x => x.Id == dataGet.Id))
                                    listIdHum.Add(dataGet);
                            }
                            if (item.Contains("CO2 level sensor"))
                            {
                                var deviceValue = item.Split(',');
                                var deviceGetId = deviceValue[1].Split(':');
                                var finalId = int.Parse(deviceGetId[1]);
                                var userGetId = deviceValue[9].Split(':');
                                var UserId = int.TryParse(userGetId[1], out int outValue) ? (int?)outValue : null;
                                var dataGet = new DataRecup
                                {
                                    Id = finalId,
                                    User_Id = UserId
                                };
                                if (!listIdCo2.Any(x => x.Id == dataGet.Id))
                                    listIdCo2.Add(dataGet);
                            }
                            if (item.Contains("Precipitation sensor"))
                            {
                                var deviceValue = item.Split(',');
                                var deviceGetId = deviceValue[1].Split(':');
                                var finalId = int.Parse(deviceGetId[1]);
                                var userGetId = deviceValue[9].Split(':');
                                var UserId = int.TryParse(userGetId[1], out int outValue) ? (int?)outValue : null;
                                var dataGet = new DataRecup
                                {
                                    Id = finalId,
                                    User_Id = UserId
                                };
                                if (!listIdPrecip.Any(x => x.Id == dataGet.Id))
                                    listIdPrecip.Add(dataGet);
                            }
                            if (item.Contains("Sound level sensor"))
                            {
                                var deviceValue = item.Split(',');
                                var deviceGetId = deviceValue[1].Split(':');
                                var finalId = int.Parse(deviceGetId[1]);
                                var userGetId = deviceValue[9].Split(':');
                                var UserId = int.TryParse(userGetId[1], out int outValue) ? (int?)outValue : null;
                                var dataGet = new DataRecup
                                {
                                    Id = finalId,
                                    User_Id = UserId
                                };
                                if (!listIdSound.Any(x => x.Id == dataGet.Id))
                                    listIdSound.Add(dataGet);
                            }
                        }
                        Console.WriteLine("END GET");

                    }
                }
                HttpResponseMessage response;
                for (int i = 0; i < 8; i++)
                {
                    var timeSpend = new Stopwatch();
                    timeSpend.Start();
                    //Presence sensor
                    foreach (var item in listIdPres)
                    {
                        var device1 = new Device()
                        {
                            Id_Device = item.Id,
                            ValueIsInt = false,
                            Date = dateGen,
                            GPSPosition_X = 1.091451,
                            GPSPosition_Y = 49.477107,
                            Name = "Presence sensor",
                            Value = r.Next(0, 2) % 2,
                            Id_User = item.User_Id
                        };
                        response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                    }

                    //Light sensor
                    foreach (var item in listIdLight)
                    {
                        var device1 = new Device()
                        {
                            Id_Device = item.Id,
                            ValueIsInt = true,
                            Date = dateGen,
                            GPSPosition_X = 1.091451,
                            GPSPosition_Y = 49.477107,
                            Name = "Light sensor",
                            Id_User = item.User_Id
                        };
                        var typeLight = r.Next(0, 7);
                        switch (typeLight)
                        {
                            case 0:
                                device1.Value = 0.5;
                                break;
                            case 1:
                                device1.Value = r.Next(20, 70);
                                break;
                            case 2:
                                device1.Value = r.Next(100, 200);
                                break;
                            case 3:
                                device1.Value = r.Next(200, 400);
                                break;
                            case 4:
                                device1.Value = r.Next(200, 3000);
                                break;
                            case 5:
                                device1.Value = r.Next(500, 25000);
                                break;
                            case 6:
                                device1.Value = r.Next(50000, 100000);
                                break;
                        }
                        response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                    }

                    //Temperature sensor
                    foreach (var item in listIdTemp)
                    {
                        var device1 = new Device()
                        {
                            Id_Device = item.Id,
                            ValueIsInt = true,
                            Date = dateGen,
                            GPSPosition_X = 1.091451,
                            GPSPosition_Y = 49.477107,
                            Name = "Temperature sensor",
                            Value = RandomNumberBetween(0, 31),
                            Id_User = item.User_Id
                        };
                        response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                    }

                    //Atmospherique presure sensor
                    foreach (var item in listIdAtPres)
                    {
                        var device1 = new Device()
                        {
                            Id_Device = item.Id,
                            ValueIsInt = true,
                            Date = dateGen,
                            GPSPosition_X = 1.091451,
                            GPSPosition_Y = 49.477107,
                            Name = "Atmospheric pressure sensor",
                            Value = RandomNumberBetween(990, 1040),
                            Id_User = item.User_Id
                        };
                        response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                    }

                    //Humidity sensor
                    foreach (var item in listIdHum)
                    {
                        var device1 = new Device()
                        {
                            Id_Device = item.Id,
                            ValueIsInt = true,
                            Date = dateGen,
                            GPSPosition_X = 1.091451,
                            GPSPosition_Y = 49.477107,
                            Name = "Humidity sensor",
                            Value = RandomNumberBetween(50, 100),
                            Id_User = item.User_Id
                        };
                        response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                    }

                    //CO2 level sensor
                    foreach (var item in listIdCo2)
                    {
                        var device1 = new Device()
                        {
                            Id_Device = item.Id,
                            ValueIsInt = true,
                            Date = dateGen,
                            GPSPosition_X = 1.091451,
                            GPSPosition_Y = 49.477107,
                            Name = "CO2 level sensor",
                            Value = r.Next(400, 2000),
                            Id_User = item.User_Id
                        };
                        response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                    }

                    //Precipitation sensor
                    foreach (var item in listIdPrecip)
                    {
                        var device1 = new Device()
                        {
                            Id_Device = item.Id,
                            ValueIsInt = true,
                            Date = dateGen,
                            GPSPosition_X = 1.091451,
                            GPSPosition_Y = 49.477107,
                            Name = "Precipitation sensor",
                            Value = r.Next(100, 300),
                            Id_User = item.User_Id
                        };
                        response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                    }

                    //Sound level sensor
                    foreach (var item in listIdSound)
                    {
                        var device1 = new Device()
                        {
                            Id_Device = item.Id,
                            ValueIsInt = true,
                            Date = dateGen,
                            GPSPosition_X = 1.091451,
                            GPSPosition_Y = 49.477107,
                            Name = "Sound level sensor",
                            Value = r.Next(50, 95),
                            Id_User = item.User_Id
                        };
                        response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                    }
                    timeSpend.Stop();
                    var elapsedMs = Convert.ToInt32(timeSpend.ElapsedMilliseconds);
                    if (elapsedMs < 1000)
                        Thread.Sleep(1000 - elapsedMs);
                    Console.WriteLine("END LOOP");
                }
                Console.WriteLine("END GENERATE");

                ////First generation : set range for each sensor
                //HttpResponseMessage response;
                ////Presence sensor
                //var deviceId = 0;
                //for (int i = 0; i < 17; i++)
                //{
                //    var device1 = new Device()
                //    {
                //        Id_Device = deviceId,
                //        ValueIsInt = false,
                //        Date = dateGen,
                //        GPSPosition_X = 1.091451,
                //        GPSPosition_Y = 49.477107,
                //        Name = "Presence sensor",
                //        Value = r.Next(0, 2) % 2
                //    };
                //    response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                //    Console.WriteLine(response);
                //    deviceId++;
                //}

                ////Light sensor
                //for (int i = 0; i < 20; i++)
                //{
                //    var device1 = new Device()
                //    {
                //        Id_Device = deviceId,
                //        ValueIsInt = true,
                //        Date = dateGen,
                //        GPSPosition_X = 1.091451,
                //        GPSPosition_Y = 49.477107,
                //        Name = "Light sensor",
                //    };
                //    var typeLight = r.Next(0, 7);
                //    switch (typeLight)
                //    {
                //        case 0:
                //            device1.Value = 0.5;
                //            break;
                //        case 1:
                //            device1.Value = r.Next(20, 70);
                //            break;
                //        case 2:
                //            device1.Value = r.Next(100, 200);
                //            break;
                //        case 3:
                //            device1.Value = r.Next(200, 400);
                //            break;
                //        case 4:
                //            device1.Value = r.Next(200, 3000);
                //            break;
                //        case 5:
                //            device1.Value = r.Next(500, 25000);
                //            break;
                //        case 6:
                //            device1.Value = r.Next(50000, 100000);
                //            break;
                //    }
                //    response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                //    deviceId++;
                //}

                ////Temperature sensor
                //for (int i = 0; i < 32; i++)
                //{
                //    var device1 = new Device()
                //    {
                //        Id_Device = deviceId,
                //        ValueIsInt = true,
                //        Date = dateGen,
                //        GPSPosition_X = 1.091451,
                //        GPSPosition_Y = 49.477107,
                //        Name = "Temperature sensor",
                //        Value = RandomNumberBetween(0, 31)
                //    };
                //    response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                //    deviceId++;
                //}

                ////Atmospherique presure sensor
                //for (int i = 0; i < 15; i++)
                //{
                //    var device1 = new Device()
                //    {
                //        Id_Device = deviceId,
                //        ValueIsInt = true,
                //        Date = dateGen,
                //        GPSPosition_X = 1.091451,
                //        GPSPosition_Y = 49.477107,
                //        Name = "Atmospheric pressure sensor",
                //        Value = RandomNumberBetween(990, 1040)
                //    };
                //    response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                //    deviceId++;
                //}
                ////Humidity sensor
                //for (int i = 0; i < 15; i++)
                //{
                //    var device1 = new Device()
                //    {
                //        Id_Device = deviceId,
                //        ValueIsInt = true,
                //        Date = dateGen,
                //        GPSPosition_X = 1.091451,
                //        GPSPosition_Y = 49.477107,
                //        Name = "Humidity sensor",
                //        Value = RandomNumberBetween(50, 100)
                //    };
                //    response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                //    deviceId++;
                //}

                ////CO2 level sensor
                //for (int i = 0; i < 32; i++)
                //{
                //    var device1 = new Device()
                //    {
                //        Id_Device = deviceId,
                //        ValueIsInt = true,
                //        Date = dateGen,
                //        GPSPosition_X = 1.091451,
                //        GPSPosition_Y = 49.477107,
                //        Name = "CO2 level sensor",
                //        Value = r.Next(400, 2000)
                //    };
                //    response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                //    deviceId++;
                //}

                ////Precipitation sensor
                //for (int i = 0; i < 12; i++)
                //{
                //    var device1 = new Device()
                //    {
                //        Id_Device = deviceId,
                //        ValueIsInt = true,
                //        Date = dateGen,
                //        GPSPosition_X = 1.091451,
                //        GPSPosition_Y = 49.477107,
                //        Name = "Precipitation sensor",
                //        Value = r.Next(100, 300)
                //    };
                //    response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                //    deviceId++;
                //}

                ////Sound level sensor
                //for (int i = 0; i < 33; i++)
                //{
                //    var device1 = new Device()
                //    {
                //        Id_Device = deviceId,
                //        ValueIsInt = true,
                //        Date = dateGen,
                //        GPSPosition_X = 1.091451,
                //        GPSPosition_Y = 49.477107,
                //        Name = "Sound level sensor",
                //        Value = r.Next(50, 95)
                //    };
                //    response = await client.PostAsJsonAsync("api/Devices/Post", device1);
                //    deviceId++;
                //}
                //Console.Write("END FIRST GENERATION");
                Console.Write("END");
            }

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
        public double Value { get; set; }
        public int? NumberValue { get; set; }
        public double GPSPosition_X { get; set; }
        public double GPSPosition_Y { get; set; }
        public int? Id_User { get; set; }
        public string MacAddress { get; set; }
    }

    class DataRecup
    {
        public int Id { get; set; }
        public int? User_Id { get; set; }
    }
}


