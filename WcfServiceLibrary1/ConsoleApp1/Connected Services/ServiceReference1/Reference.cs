﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp1.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary1")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        ConsoleApp1.ServiceReference1.CompositeType GetDataUsingDataContract(ConsoleApp1.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<ConsoleApp1.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(ConsoleApp1.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sum", ReplyAction="http://tempuri.org/IService1/sumResponse")]
        int sum(int num1, int num2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sum", ReplyAction="http://tempuri.org/IService1/sumResponse")]
        System.Threading.Tasks.Task<int> sumAsync(int num1, int num2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/substract", ReplyAction="http://tempuri.org/IService1/substractResponse")]
        int substract(int num1, int num2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/substract", ReplyAction="http://tempuri.org/IService1/substractResponse")]
        System.Threading.Tasks.Task<int> substractAsync(int num1, int num2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/multiply", ReplyAction="http://tempuri.org/IService1/multiplyResponse")]
        int multiply(int num1, int num2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/multiply", ReplyAction="http://tempuri.org/IService1/multiplyResponse")]
        System.Threading.Tasks.Task<int> multiplyAsync(int num1, int num2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/divide", ReplyAction="http://tempuri.org/IService1/divideResponse")]
        int divide(int num1, int num2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/divide", ReplyAction="http://tempuri.org/IService1/divideResponse")]
        System.Threading.Tasks.Task<int> divideAsync(int num1, int num2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/totalsum", ReplyAction="http://tempuri.org/IService1/totalsumResponse")]
        int totalsum(int[] num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/totalsum", ReplyAction="http://tempuri.org/IService1/totalsumResponse")]
        System.Threading.Tasks.Task<int> totalsumAsync(int[] num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/avg", ReplyAction="http://tempuri.org/IService1/avgResponse")]
        double avg(double[] num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/avg", ReplyAction="http://tempuri.org/IService1/avgResponse")]
        System.Threading.Tasks.Task<double> avgAsync(double[] num);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ConsoleApp1.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ConsoleApp1.ServiceReference1.IService1>, ConsoleApp1.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public ConsoleApp1.ServiceReference1.CompositeType GetDataUsingDataContract(ConsoleApp1.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<ConsoleApp1.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(ConsoleApp1.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public int sum(int num1, int num2) {
            return base.Channel.sum(num1, num2);
        }
        
        public System.Threading.Tasks.Task<int> sumAsync(int num1, int num2) {
            return base.Channel.sumAsync(num1, num2);
        }
        
        public int substract(int num1, int num2) {
            return base.Channel.substract(num1, num2);
        }
        
        public System.Threading.Tasks.Task<int> substractAsync(int num1, int num2) {
            return base.Channel.substractAsync(num1, num2);
        }
        
        public int multiply(int num1, int num2) {
            return base.Channel.multiply(num1, num2);
        }
        
        public System.Threading.Tasks.Task<int> multiplyAsync(int num1, int num2) {
            return base.Channel.multiplyAsync(num1, num2);
        }
        
        public int divide(int num1, int num2) {
            return base.Channel.divide(num1, num2);
        }
        
        public System.Threading.Tasks.Task<int> divideAsync(int num1, int num2) {
            return base.Channel.divideAsync(num1, num2);
        }
        
        public int totalsum(int[] num) {
            return base.Channel.totalsum(num);
        }
        
        public System.Threading.Tasks.Task<int> totalsumAsync(int[] num) {
            return base.Channel.totalsumAsync(num);
        }
        
        public double avg(double[] num) {
            return base.Channel.avg(num);
        }
        
        public System.Threading.Tasks.Task<double> avgAsync(double[] num) {
            return base.Channel.avgAsync(num);
        }
    }
}
