﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestForLoadAndStress.CustomerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Customer", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceHost.Model")]
    [System.SerializableAttribute()]
    public partial class Customer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CompanyNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContactNameField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CompanyName {
            get {
                return this.CompanyNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CompanyNameField, value) != true)) {
                    this.CompanyNameField = value;
                    this.RaisePropertyChanged("CompanyName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ContactName {
            get {
                return this.ContactNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ContactNameField, value) != true)) {
                    this.ContactNameField = value;
                    this.RaisePropertyChanged("ContactName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CustomerService.IServiceClass")]
    public interface IServiceClass {
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IServiceClass/UpdateCustomer", ReplyAction="http://tempuri.org/IServiceClass/UpdateCustomerResponse")]
        void UpdateCustomer(TestForLoadAndStress.CustomerService.Customer request, System.Guid cacheId);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IServiceClass/UpdateCustomer", ReplyAction="http://tempuri.org/IServiceClass/UpdateCustomerResponse")]
        System.Threading.Tasks.Task UpdateCustomerAsync(TestForLoadAndStress.CustomerService.Customer request, System.Guid cacheId);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IServiceClass/GetCustomer", ReplyAction="http://tempuri.org/IServiceClass/GetCustomerResponse")]
        TestForLoadAndStress.CustomerService.GetCustomerResponse GetCustomer(TestForLoadAndStress.CustomerService.GetCustomerRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IServiceClass/GetCustomer", ReplyAction="http://tempuri.org/IServiceClass/GetCustomerResponse")]
        System.Threading.Tasks.Task<TestForLoadAndStress.CustomerService.GetCustomerResponse> GetCustomerAsync(TestForLoadAndStress.CustomerService.GetCustomerRequest request);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IServiceClass/CompareGuidForCaching", ReplyAction="http://tempuri.org/IServiceClass/CompareGuidForCachingResponse")]
        bool CompareGuidForCaching(System.Guid clientguid);
        
        [System.ServiceModel.OperationContractAttribute(ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Action="http://tempuri.org/IServiceClass/CompareGuidForCaching", ReplyAction="http://tempuri.org/IServiceClass/CompareGuidForCachingResponse")]
        System.Threading.Tasks.Task<bool> CompareGuidForCachingAsync(System.Guid clientguid);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetCustomer", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetCustomerRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Guid lastUpdate;
        
        public GetCustomerRequest() {
        }
        
        public GetCustomerRequest(System.Guid lastUpdate) {
            this.lastUpdate = lastUpdate;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetCustomerResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetCustomerResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public TestForLoadAndStress.CustomerService.Customer GetCustomerResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public System.Guid lastUpdate;
        
        public GetCustomerResponse() {
        }
        
        public GetCustomerResponse(TestForLoadAndStress.CustomerService.Customer GetCustomerResult, System.Guid lastUpdate) {
            this.GetCustomerResult = GetCustomerResult;
            this.lastUpdate = lastUpdate;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceClassChannel : TestForLoadAndStress.CustomerService.IServiceClass, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClassClient : System.ServiceModel.ClientBase<TestForLoadAndStress.CustomerService.IServiceClass>, TestForLoadAndStress.CustomerService.IServiceClass {
        
        public ServiceClassClient() {
        }
        
        public ServiceClassClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClassClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClassClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClassClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void UpdateCustomer(TestForLoadAndStress.CustomerService.Customer request, System.Guid cacheId) {
            base.Channel.UpdateCustomer(request, cacheId);
        }
        
        public System.Threading.Tasks.Task UpdateCustomerAsync(TestForLoadAndStress.CustomerService.Customer request, System.Guid cacheId) {
            return base.Channel.UpdateCustomerAsync(request, cacheId);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TestForLoadAndStress.CustomerService.GetCustomerResponse TestForLoadAndStress.CustomerService.IServiceClass.GetCustomer(TestForLoadAndStress.CustomerService.GetCustomerRequest request) {
            return base.Channel.GetCustomer(request);
        }
        
        public TestForLoadAndStress.CustomerService.Customer GetCustomer(ref System.Guid lastUpdate) {
            TestForLoadAndStress.CustomerService.GetCustomerRequest inValue = new TestForLoadAndStress.CustomerService.GetCustomerRequest();
            inValue.lastUpdate = lastUpdate;
            TestForLoadAndStress.CustomerService.GetCustomerResponse retVal = ((TestForLoadAndStress.CustomerService.IServiceClass)(this)).GetCustomer(inValue);
            lastUpdate = retVal.lastUpdate;
            return retVal.GetCustomerResult;
        }
        
        public System.Threading.Tasks.Task<TestForLoadAndStress.CustomerService.GetCustomerResponse> GetCustomerAsync(TestForLoadAndStress.CustomerService.GetCustomerRequest request) {
            return base.Channel.GetCustomerAsync(request);
        }
        
        public bool CompareGuidForCaching(System.Guid clientguid) {
            return base.Channel.CompareGuidForCaching(clientguid);
        }
        
        public System.Threading.Tasks.Task<bool> CompareGuidForCachingAsync(System.Guid clientguid) {
            return base.Channel.CompareGuidForCachingAsync(clientguid);
        }
    }
}