using DeviceManager.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson.IO;
using Newtonsoft.Json.Linq;
using MongoDB.Bson.Serialization;

namespace DeviceManager.Controllers
{
    public class UsersController : ApiController
    {

        private string dbName = "DBR";
        private string collectionName = "User";

        // GET api/values
        [HttpGet]
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
        [ActionName("name")]
        public List<JObject> Get(string name)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();
            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            var filter = new BsonDocument("Login", name);
            var documents = collect.Find(filter).ToList();

            List<JObject> dataAll = new List<JObject>();

            for (int i = 0; i < documents.Count; i++)
            {
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                dynamic data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));
                dataAll.Add(data);
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(dataAll);

            return dataAll;
        }

        /*
        // GET api/values/5
        public List<dynamic> Get(int id)
        {
            var bdd = new MongoClient("mongodb://localhost:27017");
            var database = bdd.GetDatabase("DBR");
            var collect = database.GetCollection<BsonDocument>("user");

            var filter = new BsonDocument("Id_User", id);
            var documents = collect.Find(filter).ToList();

            List<dynamic> dataAll = new List<dynamic>();

            for (int i = 0; i < documents.Count; i++)
            {
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                dynamic data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));
                dataAll.Add(data);
            }
            return dataAll;
        }*/

        // POST api/values
        public void Post(User user)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();
            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            var documents = collect.Find(new BsonDocument()).ToList();

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(output);
            collect.InsertOneAsync(document);
        }

        [ActionName("verify")]
        public string Post(string name, string password)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();
            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            string message = "No Existant";
            //var builder = Builders<BsonDocument>.Filter;

            //var filter = builder.Eq("Name", name) & builder.Eq("Password", password);
            var filter = new BsonDocument("Login", name);
        
            var documents = collect.Find(new BsonDocument(filter)).ToList();


            List<dynamic> dataAll = new List<dynamic>();

            for (int i = 0; i < documents.Count; i++)
            {
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part
                dynamic data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));

                if (data.Password == password)
                {
                    message = "ok";
                }

                else
                {
                    message = "no";
                }
            }

            string json = message.ToJson();
            return message;
        }

        // PUT api/values/5
        public void Put(int id, User user)
        {
            BddConnector bddConnector = new BddConnector();

            var myClient = bddConnector.myConnection();
            var database = myClient.GetDatabase(dbName);
            var collect = database.GetCollection<BsonDocument>(collectionName);

            var filter = new BsonDocument("Id_User", id);

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(user);
            BsonDocument document = BsonSerializer.Deserialize<BsonDocument>(output);

            collect.ReplaceOne(filter, document);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
