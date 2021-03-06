﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelWithMe.WaetherService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WaetherService.IWeatherForecast")]
    public interface IWeatherForecast {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeatherForecast/getForecast", ReplyAction="http://tempuri.org/IWeatherForecast/getForecastResponse")]
        string[] getForecast(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWeatherForecast/getForecast", ReplyAction="http://tempuri.org/IWeatherForecast/getForecastResponse")]
        System.Threading.Tasks.Task<string[]> getForecastAsync(string zipcode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWeatherForecastChannel : TravelWithMe.WaetherService.IWeatherForecast, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WeatherForecastClient : System.ServiceModel.ClientBase<TravelWithMe.WaetherService.IWeatherForecast>, TravelWithMe.WaetherService.IWeatherForecast {
        
        public WeatherForecastClient() {
        }
        
        public WeatherForecastClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WeatherForecastClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherForecastClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherForecastClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] getForecast(string zipcode) {
            return base.Channel.getForecast(zipcode);
        }
        
        public System.Threading.Tasks.Task<string[]> getForecastAsync(string zipcode) {
            return base.Channel.getForecastAsync(zipcode);
        }
    }
}
