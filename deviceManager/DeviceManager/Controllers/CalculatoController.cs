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
    public class CalculatorController : ApiController
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
        public double GetAvg(int id_device)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();
            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            var filter = new BsonDocument("Id_Device", id_device);
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

        // POST api/values
        public void Post(Device devices)
        {

        }


        // PUT api/values/5
        public void Put(int id, Device device)
        {

        }




        // DELETE api/values/5
        public void Delete()
        {
   
        }
    }
}
