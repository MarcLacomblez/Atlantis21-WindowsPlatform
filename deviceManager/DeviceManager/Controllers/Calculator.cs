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
    public class Calculator : ApiController
    {

        private string dbName = "DBR";
        private string collectionName = "Device";

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return null;
        }

        [ActionName("AvgAll")]
        public double Get(string name)
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
                //Console.WriteLine(doc[i].ToJson());

                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part

                dynamic data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));
                //Console.WriteLine(data.Value);

                myTable[i] = data.Value;
            }


            double myresult = myTable.Average();

            
            return myresult;


        }

        [ActionName("Avg")]
        public double Get(string name_device, int id_device)
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
                //Console.WriteLine(doc[i].ToJson());

                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part

                dynamic data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));
                //Console.WriteLine(data.Value);

                myTable[i] = data.Value;
            }


            double myresult = myTable.Average();

            return myresult;


        }
    }
}