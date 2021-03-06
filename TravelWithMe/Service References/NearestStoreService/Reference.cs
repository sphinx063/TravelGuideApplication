﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelWithMe.NearestStoreService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NearestStoreService.INearestStore")]
    public interface INearestStore {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INearestStore/DoWork", ReplyAction="http://tempuri.org/INearestStore/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INearestStore/DoWork", ReplyAction="http://tempuri.org/INearestStore/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INearestStore/findNearestStore", ReplyAction="http://tempuri.org/INearestStore/findNearestStoreResponse")]
        string findNearestStore(string location, string term);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INearestStore/findNearestStore", ReplyAction="http://tempuri.org/INearestStore/findNearestStoreResponse")]
        System.Threading.Tasks.Task<string> findNearestStoreAsync(string location, string term);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INearestStoreChannel : TravelWithMe.NearestStoreService.INearestStore, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NearestStoreClient : System.ServiceModel.ClientBase<TravelWithMe.NearestStoreService.INearestStore>, TravelWithMe.NearestStoreService.INearestStore {
        
        public NearestStoreClient() {
        }
        
        public NearestStoreClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NearestStoreClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NearestStoreClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NearestStoreClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public string findNearestStore(string location, string term) {
            return base.Channel.findNearestStore(location, term);
        }
        
        public System.Threading.Tasks.Task<string> findNearestStoreAsync(string location, string term) {
            return base.Channel.findNearestStoreAsync(location, term);
        }
    }
}
