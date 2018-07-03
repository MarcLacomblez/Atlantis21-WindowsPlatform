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
using System.Security.Authentication;
using System.IO;
using System.Text;

namespace DeviceManager.Controllers
{
    public class DevicesController : ApiController
    {

        private string dbName = "DBR";
        private string collectionName = "Device";


        // GET api/values
        public List<JObject> Get()
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();

            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

           var documents = collect.Find(new BsonDocument()).ToList();

            
            List<JObject> dataAll = new List<JObject>();

            for (int i = 0; i < documents.Count; i++)
            {
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                var data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));
                dataAll.Add(data);
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(dataAll);

            return dataAll;
        }


        // GET api/values/5
        public List<JObject> Get(int id)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();

            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            var filter = new BsonDocument("Id_Device", id);
            var documents = collect.Find(filter).ToList();

            List<JObject> dataAll = new List<JObject>();

            for (int i = 0; i < documents.Count; i++)
            {
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                var data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));
                dataAll.Add(data);
            }
            return dataAll;
        }



        [ActionName("deviceByUser")]
        public List<JObject> GetDeviceByLogin(int id_user)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();

            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            var filter = new BsonDocument("Id_User", id_user);
            var documents = collect.Find(filter).ToList();

            List<JObject> dataAll = new List<JObject>();

            for (int i = 0; i < documents.Count; i++)
            {
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                var data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));
                dataAll.Add(data);
            }
            return dataAll;
        }

        [ActionName("name")]
        public List<JObject> Get(string name)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();

            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            var filter = new BsonDocument("Name", name);
            var documents = collect.Find(filter).ToList();

            List<JObject> dataAll = new List<JObject>();

            for (int i = 0; i < documents.Count; i++)
            {
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                var data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));
                dataAll.Add(data);
            }
            return dataAll;
        }

        [ActionName("AvgAll")]
        public double GetAvgAll(string name)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();
            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            var filter = new BsonDocument("Name", name);
            var documents = collect.Find(filter).ToList();

            double[] myTable = new double[documents.Count];

            for (int i = 0; i < documents.Count; i++)
            {
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                dynamic data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));
                myTable[i] = data.Value;
            }

            double myresult = myTable.Average();
            return myresult;
        }

        [ActionName("Avg")]
        public double GetAvg(string name_device, int id_device)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();
            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            var filter = new BsonDocument("Name", name_device);
            var documents = collect.Find(filter).ToList();

            double[] myTable = new double[documents.Count];

            for (int i = 0; i < documents.Count; i++)
            {
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                dynamic data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));

                if (data.Id_Device == id_device)
                {
                    myTable[i] = data.Value;
                }

            }

            double myresult = myTable.Average();
            return myresult;

        }

    // POST api/values
    public void Post(Device devices)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();

            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(devices);
            BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(output);
            collect.InsertOneAsync(document);

        }


        [ActionName("Associate")]
        public void Post(int id_device, int id_user)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();

            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            var filter = new BsonDocument("Id_Device", id_device);


            var documents = collect.Find(filter).ToList();

            foreach(var item in documents)
            {

                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                dynamic data = JObject.Parse(item.ToJson(jsonWriterSettings));

                data.Id_User = id_user;
            

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(output);

                collect.ReplaceOne(filter, document);

            }
            


        }

        // PUT api/values/5
        public void Put(int id, Device device)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();

            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            var filter = new BsonDocument("Id_Device", id);

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(device);
            BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(output);

            collect.ReplaceOne(filter, document);
        }

        [ActionName("PutValue")]
        public void Put(int id, double value)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();
            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);
            var filter = new BsonDocument("Id_Device", id);
            var documents = collect.Find(filter).ToList();

            foreach (var item in documents)
            {

                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                dynamic data = JObject.Parse(item.ToJson(jsonWriterSettings));
                data.Value = value;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(output);

                collect.ReplaceOne(filter, document);
            }
        }


        // DELETE api/values/5
        public void Delete()
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();

            var database = myClient.GetDatabase(dbName);
            database.DropCollection(collectionName);

        }
    }
}
