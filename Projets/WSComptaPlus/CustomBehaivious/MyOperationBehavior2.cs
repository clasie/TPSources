using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Web;
using TokenHandler.Constants;

namespace WSComptaPlus.CustomBehaivious
{
    public class MyOperationBehavior2 : Attribute, IOperationBehavior
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            log.Info("Validate 5");
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            log.Info("Validate 6");
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            log.Info("Validate 7"); throw new NotImplementedException();
        }

        public void Validate(OperationDescription operationDescription)
        {
            try
            {
                string myHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
                log.Info("Validate 8.0 ");
                //var x = HttpContext.Current.Request;
                //IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            }
            catch (Exception ex)
            {
                log.Info("Validate 8.1 "  + ex.ToString()); throw new NotImplementedException();
            }
        }
    }
}