﻿using log4net;
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
    public class TokenInspector : Attribute, IParameterInspector ,IOperationBehavior
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(TokenKey.NormalLogsNameSpace);
        private static readonly log4net.ILog logInOut = log4net.LogManager.GetLogger(TokenKey.WebInOutLogsNameSpace);
        private static readonly log4net.ILog logTokenAccess = log4net.LogManager.GetLogger(TokenKey.TokenAccessNameSpace);
        

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
        /// <summary>
        /// This method is called prior any methods decorated with 
        /// '[TokenInspector]' defined inside the 'public interface WSComptaPlus.IServiceComptaPlus'
        /// </summary>
        /// <param name="operationName"></param>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public object BeforeCall(string operationName, object[] inputs)
        {
            logTokenAccess.Info("///////Start//////////BeforeCall////////////////////////");
            try
            {
                //Challenge the header Token
                ManageAuthAndToken.Instance.ValidateToken();
            }
            catch (TokenHandler.CustomException.InvalidTokenException ite)
            {
                //we refuse the Token sent in the header for Token calculation reason
                logTokenAccess.Error(FormatMessages.getLogMessage(
                    this.GetType().Name,
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    string.Concat("operationName: ", operationName, " inputs: ", inputs.ToString()),
                    ite.ToString()));
                throw new WebFaultException<string>(TokenKey.TokenIssue, HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                //we refuse the Token sent in the header for Token unexpected reason
                logTokenAccess.Error(FormatMessages.getLogMessage(
                    this.GetType().Name,
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    string.Concat("operationName: ", operationName, " inputs: ", inputs.ToString()),
                    ex.ToString()));
                throw new WebFaultException<string>(TokenKey.TokenIssue, HttpStatusCode.Unauthorized);
            }
            logTokenAccess.Info("///////End//////////BeforeCall////////////////////////");
            return null;
        }
    }
}