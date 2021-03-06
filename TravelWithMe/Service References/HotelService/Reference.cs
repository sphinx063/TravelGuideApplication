﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelWithMe.HotelService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HotelService.IHotelFinder")]
    public interface IHotelFinder {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelFinder/DoWork", ReplyAction="http://tempuri.org/IHotelFinder/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelFinder/DoWork", ReplyAction="http://tempuri.org/IHotelFinder/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelFinder/findHotels", ReplyAction="http://tempuri.org/IHotelFinder/findHotelsResponse")]
        string[] findHotels(string location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelFinder/findHotels", ReplyAction="http://tempuri.org/IHotelFinder/findHotelsResponse")]
        System.Threading.Tasks.Task<string[]> findHotelsAsync(string location);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHotelFinderChannel : TravelWithMe.HotelService.IHotelFinder, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HotelFinderClient : System.ServiceModel.ClientBase<TravelWithMe.HotelService.IHotelFinder>, TravelWithMe.HotelService.IHotelFinder {
        
        public HotelFinderClient() {
        }
        
        public HotelFinderClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HotelFinderClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HotelFinderClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HotelFinderClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public string[] findHotels(string location) {
            return base.Channel.findHotels(location);
        }
        
        public System.Threading.Tasks.Task<string[]> findHotelsAsync(string location) {
            return base.Channel.findHotelsAsync(location);
        }
    }
}
