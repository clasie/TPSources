using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Web;
using TokenHandler.Constants;

namespace WSComptaPlus.CustomBehaivious
{
    public class EndpointBehavior : Attribute, IEndpointBehavior
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            log.Info("Validate 1");
            //throw new NotImplementedException();
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            log.Info("Validate 2");
            //throw new NotImplementedException();
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            log.Info("Validate 3");
            //throw new NotImplementedException();
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            var myService = OperationContext.Current.InstanceContext.GetServiceInstance();
            log.Info("Validate 4");
            //throw new NotImplementedException();
        }
    }
}