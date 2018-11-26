using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Web;
using TokenHandler.Constants;
using TokenHandler.Utils;
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
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            try
            {
                //Challenge the header Token
                ManageAuthAndToken.Instance.ValidateToken();
            }
            catch (TokenHandler.CustomException.InvalidTokenException ite) {
                //We store complete error message
                log.Error(FormatMessages.getLogMessage(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    ite.ToString()));
                //For security reason we return the minimal info message
                throw new TokenHandler.CustomException.InvalidTokenException(TokenKey.TokenNotFound);
            }
            catch (Exception ex)
            {
                //We store complete error message
                log.Error(FormatMessages.getLogMessage(
                    MethodBase.GetCurrentMethod().DeclaringType.Name,
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    ex.ToString()));
                //For security reason we return the minimal info message
                throw new TokenHandler.CustomException.InvalidTokenException(TokenKey.TokenNotFound);
            }
            return null;
        }
    }
}