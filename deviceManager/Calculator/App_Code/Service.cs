using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;

using Calculator.Controllers;

using Newtonsoft.Json.Linq;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{

    private string dbName = "DBR";
    private string collectionName = "Device";

    public double avgAll(string name)
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

    public double avg(string name_device, int id_device)
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

    public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
}
