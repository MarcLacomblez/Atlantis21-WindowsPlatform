﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // Base Operation

        [OperationContract]
        int sum(int num1, int num2);
        [OperationContract]
        int substract(int num1, int num2);
        [OperationContract]
        int multiply(int num1, int num2);
        [OperationContract]
        int divide(int num1, int num2);

        //B.I calculator

        [OperationContract]
        int totalsum(int[] num);


        [OperationContract]
        //double avg(string dateMode, string date);
        double avg();
        /*
        [OperationContract]
        double avg(string dateMode, string date, string deviceName);*/


        /*
        [OperationContract]
        string DeviceMax(string dateMode, string date, string deviceName);

        [OperationContract]
        double ValueMax(string dateMode, string date, string deviceName);

        [OperationContract]
        string DeviceMax(string dateMode, string date);

        [OperationContract]
        double ValueMax(string dateMode, string date);*/




        /* [OperationContract]
         Tuple<string, int> max(List<BsonDocument> num);*/


    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfServiceLibrary1.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
