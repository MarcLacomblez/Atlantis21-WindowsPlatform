using DeviceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MongoDB.Driver;
using MongoDB.Bson;
//using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;




namespace DeviceManager.Controllers
{
    public class DevicesController : ApiController
    {
        // GET api/values
        public List<Device> Get()
        {
             var ctlr = new SimationDeviceController();
             var r = new Random();
             var listDevice = new List<Device>();
             var nbValue = r.Next(1, 20);
             for (var i = 0; i <= nbValue; i++)
             {
                 var device = ctlr.GetDevice();
                 listDevice.Add(device);
             }

            return listDevice;
        }

        // GET api/values/5
        public Device Get(int id)
        {
            var ctlr = new SimationDeviceController();
            var device = ctlr.GetDevice();


            return device;
        }

        // POST api/values
        public void Post(Device device)
        {

            string output = JsonConvert.SerializeObject(device);

            var bdd = new MongoClient("mongodb://localhost:27017");
            var database = bdd.GetDatabase("DBR");
            var collect = database.GetCollection<BsonDocument>("device");

            BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(output);
            collect.InsertOneAsync(document);

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
