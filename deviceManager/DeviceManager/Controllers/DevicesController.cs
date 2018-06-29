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
using MongoDB.Bson.IO;
using Newtonsoft.Json.Linq;

namespace DeviceManager.Controllers
{
    public class DevicesController : ApiController
    {
        // GET api/values
        public List<dynamic> Get()
        {

            var bdd = new MongoClient("mongodb://localhost:27017");
            var database = bdd.GetDatabase("DBR");
            var collect = database.GetCollection<BsonDocument>("device");

            var documents = collect.Find(new BsonDocument()).ToList();

            List<dynamic> dataAll = new List<dynamic>();

            for (int i = 0; i < documents.Count; i++)
            {

                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                dynamic data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));
                dataAll.Add(data);
            }
            return dataAll;
        }


        // GET api/values/5
        public List<dynamic> Get(int id)
        {
            var bdd = new MongoClient("mongodb://localhost:27017");
            var database = bdd.GetDatabase("DBR");
            var collect = database.GetCollection<BsonDocument>("device");

            var filter = new BsonDocument("Id_Device", id);
            var documents = collect.Find(filter).ToList();

            List<dynamic> dataAll = new List<dynamic>();

            for (int i = 0; i < documents.Count; i++)
            {
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                dynamic data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));
                dataAll.Add(data);
            }
            return dataAll;
        }
        /*
        public List<dynamic> GetbyName(string name)
        {
            var bdd = new MongoClient("mongodb://localhost:27017");
            var database = bdd.GetDatabase("DBR");
            var collect = database.GetCollection<BsonDocument>("device");

            var filter = new BsonDocument("Name", name);
            var documents = collect.Find(filter).ToList();

            List<dynamic> dataAll = new List<dynamic>();
            double[] myTab = new double[documents.Count];

            for (int i = 0; i < documents.Count; i++)
            {
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                dynamic data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));
                dataAll.Add(data);
            }
            return dataAll;
        }*/

        // POST api/values
        public void Post(Device device)
        {

            var bdd = new MongoClient("mongodb://localhost:27017");
            var database = bdd.GetDatabase("DBR");
            var collect = database.GetCollection<BsonDocument>("device");

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(device);
            BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(output);
            collect.InsertOneAsync(document);

        }

        // PUT api/values/5
        public void Put(int id, Device device)
        {
            var bdd = new MongoClient("mongodb://localhost:27017");
            var database = bdd.GetDatabase("DBR");
            var collect = database.GetCollection<BsonDocument>("device");

            var filter = new BsonDocument("Id_Device", id);
            
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(device);
            BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(output);

            collect.ReplaceOne(filter, document);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
