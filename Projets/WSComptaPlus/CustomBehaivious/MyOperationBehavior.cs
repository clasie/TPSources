using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace WSComptaPlus.CustomBehaivious
{
    public class MyOperationBehavior : Attribute, IOperationBehavior
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region IOperationBehavior Members

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            log.Info("AddBindingParameters");

        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            log.Info("ApplyClientBehavior");
        }
 

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            log.Info("ApplyDispatchBehavior");
        }


        public void Validate(OperationDescription operationDescription)
        {
            log.Info("Validate");
        }

        #endregion
    }
}