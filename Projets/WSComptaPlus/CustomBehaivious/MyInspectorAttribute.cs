using log4net;
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
using WSComptaPlus.Process;

namespace WSComptaPlus.CustomBehaivious
{
    public class MyInspectorAttribute : Attribute, IParameterInspector /*IOperationBehavior,*/
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(this);
        }

        public void Validate(OperationDescription operationDescription)
        {
        }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            log.Info("AfterCall");
            //string myHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            //log.Info("Validate 8.0 ");
            //var x = HttpContext.Current.Request;
            //Console.WriteLine("Operation {0} returned: result = {1}", operationName, returnValue);
        }

        public object BeforeCall(string operationName, object[] inputs)
        {


            log.Info("|||||||||||||||||||||||||||||->BeforeCal 2.0");
            OperationContext current = OperationContext.Current;
            //var incomingmessageheaders = current.IncomingMessageHeaders;
            //var outgoingmessageheaders = current.OutgoingMessageHeaders;
            string theAuth = WebOperationContext.Current.IncomingRequest.Headers
                .GetValues("Authorization")[0].ToString();

            try
            {
                ManageAuthAndToken.Instance.ValidateToken();
            }
            catch (Exception ex) {
                log.Info("EXCEPTION 1.0 ---> " + ex.ToString());
            }


            log.Info("Authorization --------> " + theAuth);
            log.Info("|||||||||||||||||||||||||||||<-BeforeCal 2.1");

            throw new WebFaultException<string>("Token issue",HttpStatusCode.Unauthorized);


            //var x = WebOperationContext.Current.IncomingRequest.GetAcceptHeaderElements().ToList();
            //Console.WriteLine(" -1-> Calling {0} with the following parameters:", operationName);
            //foreach (var xelemen in x)
            //{
            //    log.Info(string.Format("--> 1 From list: {0}", xelemen.ToString()));
            //}

            //var authHeader = WebOperationContext.Current.IncomingRequest.Headers.
            //    .GetValues("Authorization")[0].ToString();
            //Console.WriteLine(" -2-> Calling {0} with the following parameters:", operationName);
            //foreach (var xelemen in x2)
            //{
            //    log.Info(string.Format("--> 2 From list: {0}", x2.GetValues("Authorization")[0].ToString()));
            //}

            //log.Info("BeforeCall 2.1");


            //for (int i = 0; i < inputs.Length; i++)
            //{
            //    log.Info(string.Format(" [{0}] = {1}", i, inputs[i]));
            //    //Console.WriteLine(" [{0}] = {1}", i, inputs[i]);
            //}

            return null;
        }
    }
}