using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DeviceManager.ServiceReference1;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using System.Security.Authentication;


namespace Calculator.Controllers
{
    public class BddConnector
    {

        public int port = 10255;
        public string host = "atlantis21device.documents.azure.com";

        private string dbName = "DBR";


        string userName = "atlantis21device";
        string password = "xo7QcynXCpXZ9zCNWlGSF7eOp0AmcCfN8pbiJeJbGskTsdayFajff46gq4DPXh6kBen6da2jKkXoWkKekNFTng==";

        public MongoClient myConnection()
        {


            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress(host, port);
            settings.UseSsl = true;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            MongoIdentity identity = new MongoInternalIdentity(dbName, userName);
            MongoIdentityEvidence evidence = new PasswordEvidence(password);

            settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);

            MongoClient client = new MongoClient(settings);

            return client;

        }

    }
}