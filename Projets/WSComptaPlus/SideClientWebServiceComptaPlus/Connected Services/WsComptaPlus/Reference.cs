﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SideClientWebServiceComptaPlus.WsComptaPlus {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WsComptaPlus.IServiceComptaPlus")]
    public interface IServiceComptaPlus {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceComptaPlus/GetListPCMN", ReplyAction="http://tempuri.org/IServiceComptaPlus/GetListPCMNResponse")]
        FrameWorkSide.Models.WebServices.Json.PcmnModelJson[] GetListPCMN();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceComptaPlus/GetListPCMN", ReplyAction="http://tempuri.org/IServiceComptaPlus/GetListPCMNResponse")]
        System.Threading.Tasks.Task<FrameWorkSide.Models.WebServices.Json.PcmnModelJson[]> GetListPCMNAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceComptaPlus/GetPCMNById", ReplyAction="http://tempuri.org/IServiceComptaPlus/GetPCMNByIdResponse")]
        FrameWorkSide.Models.WebServices.Json.PcmnModelJson GetPCMNById(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceComptaPlus/GetPCMNById", ReplyAction="http://tempuri.org/IServiceComptaPlus/GetPCMNByIdResponse")]
        System.Threading.Tasks.Task<FrameWorkSide.Models.WebServices.Json.PcmnModelJson> GetPCMNByIdAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceComptaPlus/GetInfoWebService", ReplyAction="http://tempuri.org/IServiceComptaPlus/GetInfoWebServiceResponse")]
        FrameWorkSide.Models.WebServices.Json.WebServiceModelJson GetInfoWebService();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceComptaPlus/GetInfoWebService", ReplyAction="http://tempuri.org/IServiceComptaPlus/GetInfoWebServiceResponse")]
        System.Threading.Tasks.Task<FrameWorkSide.Models.WebServices.Json.WebServiceModelJson> GetInfoWebServiceAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceComptaPlusChannel : SideClientWebServiceComptaPlus.WsComptaPlus.IServiceComptaPlus, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceComptaPlusClient : System.ServiceModel.ClientBase<SideClientWebServiceComptaPlus.WsComptaPlus.IServiceComptaPlus>, SideClientWebServiceComptaPlus.WsComptaPlus.IServiceComptaPlus {
        
        public ServiceComptaPlusClient() {
        }
        
        public ServiceComptaPlusClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceComptaPlusClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceComptaPlusClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceComptaPlusClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public FrameWorkSide.Models.WebServices.Json.PcmnModelJson[] GetListPCMN() {
            return base.Channel.GetListPCMN();
        }
        
        public System.Threading.Tasks.Task<FrameWorkSide.Models.WebServices.Json.PcmnModelJson[]> GetListPCMNAsync() {
            return base.Channel.GetListPCMNAsync();
        }
        
        public FrameWorkSide.Models.WebServices.Json.PcmnModelJson GetPCMNById(string id) {
            return base.Channel.GetPCMNById(id);
        }
        
        public System.Threading.Tasks.Task<FrameWorkSide.Models.WebServices.Json.PcmnModelJson> GetPCMNByIdAsync(string id) {
            return base.Channel.GetPCMNByIdAsync(id);
        }
        
        public FrameWorkSide.Models.WebServices.Json.WebServiceModelJson GetInfoWebService() {
            return base.Channel.GetInfoWebService();
        }
        
        public System.Threading.Tasks.Task<FrameWorkSide.Models.WebServices.Json.WebServiceModelJson> GetInfoWebServiceAsync() {
            return base.Channel.GetInfoWebServiceAsync();
        }
    }
}
