using ERPDynamics;
using SideWsComptaPlus.Contracts;
using SideWsComptaPlus.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Web;
using TokenHandler;
using TokenHandler.CertificateWorkAround;
using TokenHandler.Constants;
using TokenHandler.Models;
using ClientConfiguration = SideWsComptaPlus.Tools.ClientConfiguration;
using ServiceRequestAttribute = SideWsComptaPlus.Attributes.ServiceRequestAttribute;

namespace SideWsComptaPlus.Services
{
    public class TableReferenceService
    {
        #region Système.
        /// <summary>
        ///
        /// </summary>
        private readonly ClientConfiguration _clientConfiguration;
        /// <summary>
        ///
        /// </summary>
        /// <param name="clientConfiguration"></param>
        public TableReferenceService(ClientConfiguration clientConfiguration)
        {
            _clientConfiguration = clientConfiguration;
        }
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TRequestContractType"></typeparam>
        /// <typeparam name="TResultType"></typeparam>
        /// <param name="dRequest"></param>
        /// <returns></returns>
        public List<TResultType> CallService<TRequestContractType, TResultType>(List<TRequestContractType> dRequest)
            where TResultType:ModelBusiness.Response
            where TRequestContractType:Contracts.BaseContract
        {
            var attribute = typeof(TRequestContractType).GetCustomAttributes(true).OfType<ServiceRequestAttribute>().FirstOrDefault();
            if (attribute == null)
            {
                //--------------------------------------------------------------
                // Erreur dans la réponse
                //--------------------------------------------------------------
                var resultError = new List<TResultType>();
                foreach (var r in dRequest)
                {
                    var resp = Activator.CreateInstance<TResultType>();
                    resp.Code = "9005";
                    resp.Message = "Attribut RequestContractType manquant pour le type " + typeof(TRequestContractType).Name;
                    resp.ErpOprNumber = Guid.Empty;
                    resp.DynamicsOprNumber = Guid.Empty;
                    resultError.Add(resp);
                }
                return resultError;
            }

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(_clientConfiguration.UriString + "\\"  + attribute.Url );
                //httpWebRequest.Timeout = (httpWebRequest.Timeout * 10);
                //httpWebRequest.Timeout = (120);
                httpWebRequest.ContentType = "application/json; charset=utf-8; ";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + TokenKey.GeneratedKeyToTest); // "0123456789");

                var json =  JsonHelp.JsonSerialize(dRequest);

                // Envoyer les données au service.
                using (var streamWriter =
                    new StreamWriter(httpWebRequest.GetRequestStream())){streamWriter.Write(json);}

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    //--------------------------------------------------------------
                    // Erreur dans la réponse
                    //--------------------------------------------------------------
                    var resultError = new List<TResultType>();
                    foreach (var r in dRequest)
                    {
                        var resp = Activator.CreateInstance<TResultType>();
                        resp.Code = "9004";
                        resp.Message = "Aucune réponse : " + httpResponse.StatusCode.ToString();
                        resp.ErpOprNumber = Guid.Empty;
                        resp.DynamicsOprNumber = Guid.Empty;
                        resultError.Add(resp);
                    }
                    return resultError;
                }

                List<TResultType> result;
                using (var respStream = httpResponse.GetResponseStream())
                {
                    if (respStream == null) return null;
                    var reader = new StreamReader(respStream);
                    var rep = @reader.ReadToEnd().Trim();
                    try
                    {
                        result = (List<TResultType>)JsonHelp.JsonDeserialize<List<TResultType>>(rep);
                    }
                    catch (Exception e)
                    {
                        //-----------------------------------------------------------------
                        // Erreur dans le message de retour = Renvoi du message FrameWork
                        //-----------------------------------------------------------------
                        var resultError = new List<TResultType>();
                        foreach (var r in dRequest)
                        {
                            var resp = Activator.CreateInstance<TResultType>();
                            resp.Code = "9999";
                            resp.Message = e.Message;
                            resp.ErpOprNumber = Guid.Empty;
                            resp.DynamicsOprNumber = Guid.Empty;
                            resultError.Add(resp);
                        }
                        return resultError;
                    }
                }
                return result;
            }
            catch (WebException e)
            {
                var resultError = new List<TResultType>();
                foreach (var r in dRequest)
                {
                    var resp = Activator.CreateInstance<TResultType>();
                    resp.Code = "9000";
                    resp.Message = e.Message;
                    resp.ErpOprNumber = Guid.Empty;
                    resp.DynamicsOprNumber = Guid.Empty;
                    resultError.Add(resp);
                }
                return resultError;
            }
            catch (UriFormatException e)
            {
                var resultError = new List<TResultType>();
                foreach (var r in dRequest)
                {
                    var resp = Activator.CreateInstance<TResultType>();
                    resp.Code = "9001";
                    resp.Message = e.Message;
                    resp.ErpOprNumber = Guid.Empty;
                    resp.DynamicsOprNumber = Guid.Empty;
                    resultError.Add(resp);
                }
                return resultError;
            }
            catch (Exception e)
            {
                //-----------------------------------------------------------------
                // Erreur générale du Web Service le message de retour =
                // Renvoi du message FrameWork
                //-----------------------------------------------------------------
                var resultError = new List<TResultType>();
                foreach (var r in dRequest)
                {
                    var resp = Activator.CreateInstance<TResultType>();
                    resp.Code = "9999";
                    resp.Message = e.Message;
                    resp.ErpOprNumber = Guid.Empty;
                    resp.DynamicsOprNumber = Guid.Empty;
                    resultError.Add(resp);
                }
                return resultError;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequestContractType"></typeparam>
        /// <typeparam name="TResultType"></typeparam>
        /// <param name="dRequest"></param>
        /// <returns></returns>
        public List<TResultType> CallServiceERP<TRequestContractType, TResultType>(List<TRequestContractType> dRequest)
            where TResultType : ModelBusiness.Response
            where TRequestContractType : Contracts.BaseContractERP
        {
            var attribute = typeof(TRequestContractType).GetCustomAttributes(true).OfType<ServiceRequestAttribute>().FirstOrDefault();
            if (attribute == null)
            {
                //--------------------------------------------------------------
                // Erreur dans la réponse
                //--------------------------------------------------------------
                var resultError = new List<TResultType>();
                foreach (var r in dRequest)
                {
                    var resp = Activator.CreateInstance<TResultType>();
                    resp.Code = "9005";
                    resp.Message = "Attribut RequestContractType manquant pour le type " + typeof(TRequestContractType).Name;
                    resp.ErpOprNumber = Guid.Empty;
                    resp.DynamicsOprNumber = Guid.Empty;
                    resultError.Add(resp);
                }
                return resultError;
            }

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(_clientConfiguration.UriString + "\\" + attribute.Url);
                //httpWebRequest.Timeout = (httpWebRequest.Timeout * 10);
                //httpWebRequest.Timeout = (120);
                httpWebRequest.ContentType = "application/json; charset=utf-8; ";
                httpWebRequest.Method = "POST";
                //httpWebRequest.Headers.Add("Authorization", "Bearer " + "0123456789"); 
                httpWebRequest.Headers.Add("Authorization", "Bearer " + TokenKey.GeneratedKeyToTest); // "0123456789");

                var json = JsonHelp.JsonSerialize(dRequest);

                // Envoyer les données au service.
                using (var streamWriter =
                    new StreamWriter(httpWebRequest.GetRequestStream())) { streamWriter.Write(json); }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    //--------------------------------------------------------------
                    // Erreur dans la réponse
                    //--------------------------------------------------------------
                    var resultError = new List<TResultType>();
                    foreach (var r in dRequest)
                    {
                        var resp = Activator.CreateInstance<TResultType>();
                        resp.Code = "9004";
                        resp.Message = "Aucune réponse : " + httpResponse.StatusCode.ToString();
                        resp.ErpOprNumber = Guid.Empty;
                        resp.DynamicsOprNumber = Guid.Empty;
                        resultError.Add(resp);
                    }
                    return resultError;
                }

                List<TResultType> result;
                using (var respStream = httpResponse.GetResponseStream())
                {
                    if (respStream == null) return null;
                    var reader = new StreamReader(respStream);
                    var rep = @reader.ReadToEnd().Trim();
                    try
                    {
                        result = (List<TResultType>)JsonHelp.JsonDeserialize<List<TResultType>>(rep);
                    }
                    catch (Exception e)
                    {
                        //-----------------------------------------------------------------
                        // Erreur dans le message de retour = Renvoi du message FrameWork
                        //-----------------------------------------------------------------
                        var resultError = new List<TResultType>();
                        foreach (var r in dRequest)
                        {
                            var resp = Activator.CreateInstance<TResultType>();
                            resp.Code = "9999";
                            resp.Message = e.Message;
                            resp.ErpOprNumber = Guid.Empty;
                            resp.DynamicsOprNumber = Guid.Empty;
                            resultError.Add(resp);
                        }
                        return resultError;
                    }
                }
                return result;
            }
            catch (WebException e)
            {
                var resultError = new List<TResultType>();
                foreach (var r in dRequest)
                {
                    var resp = Activator.CreateInstance<TResultType>();
                    resp.Code = "9000";
                    resp.Message = e.Message;
                    resp.ErpOprNumber = Guid.Empty;
                    resp.DynamicsOprNumber = Guid.Empty;
                    resultError.Add(resp);
                }
                return resultError;
            }
            catch (UriFormatException e)
            {
                var resultError = new List<TResultType>();
                foreach (var r in dRequest)
                {
                    var resp = Activator.CreateInstance<TResultType>();
                    resp.Code = "9001";
                    resp.Message = e.Message;
                    resp.ErpOprNumber = Guid.Empty;
                    resp.DynamicsOprNumber = Guid.Empty;
                    resultError.Add(resp);
                }
                return resultError;
            }
            catch (Exception e)
            {
                //-----------------------------------------------------------------
                // Erreur générale du Web Service le message de retour =
                // Renvoi du message FrameWork
                //-----------------------------------------------------------------
                var resultError = new List<TResultType>();
                foreach (var r in dRequest)
                {
                    var resp = Activator.CreateInstance<TResultType>();
                    resp.Code = "9999";
                    resp.Message = e.Message;
                    resp.ErpOprNumber = Guid.Empty;
                    resp.DynamicsOprNumber = Guid.Empty;
                    resultError.Add(resp);
                }
                return resultError;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequestContractType"></typeparam>
        /// <typeparam name="TResultType"></typeparam>
        /// <param name="dRequest"></param>
        /// <returns></returns>
        public TResultType CallServiceLogin<TRequestContractType, TResultType>(TRequestContractType dRequest)
           where TResultType : TokenHandler.Models.LoginResponse
           where TRequestContractType : TokenHandler.Models.LoginRequest
        {
            var attribute = typeof(TRequestContractType).GetCustomAttributes(true).OfType<TokenHandler.Attributes.ServiceRequestAttribute>().FirstOrDefault();
            //to corrige
            if (attribute == null)
            {
                //--------------------------------------------------------------
                // Erreur dans la réponse
                //--------------------------------------------------------------
                //var resultError = new List<TResultType>();
                //foreach (var r in dRequest)
                //{
                    var resp = Activator.CreateInstance<TResultType>();
                    resp.Code = "10001";
                    resp.Message = "Attribut RequestContractType manquant pour le type " + typeof(TRequestContractType).Name;
                    //resp.HttpResponseMsg = null;
                    resp.ResponseMsg = null;
                    //resultError.Add(resp);
                //}
                return resp;
            }

            try
            {
                //System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                //(se, cert, chain, sslerror) =>
                //{
                //    return true;
                //};

                //ServicePointManager.ServerCertificateValidationCallback = new
                //RemoteCertificateValidationCallback
                //(
                //   delegate { return true; }
                //);

                //ServicePointManager.CertificatePolicy = new CustomCertificatePolicy();

                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(_clientConfiguration.UriString + "\\" + attribute.Url); // "login/ws");

                //httpWebRequest.Timeout = (httpWebRequest.Timeout * 10);
                //httpWebRequest.Timeout = (120);
                httpWebRequest.ContentType = "application/json; charset=utf-8; ";
                httpWebRequest.Method = "POST";
                //httpWebRequest.Headers.Add("Authorization", "Bearer " + "0123456789"); 
                //httpWebRequest.Headers.Add("Authorization", "Bearer " + TokenKey.GeneratedKeyToTest); // "0123456789");
                var json = JsonHelp.JsonSerialize(dRequest);

                // Envoyer les données au service.
                using (var streamWriter =
                    new StreamWriter(httpWebRequest.GetRequestStream())) { streamWriter.Write(json); }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    //--------------------------------------------------------------
                    // Erreur dans la réponse
                    //--------------------------------------------------------------
                    //var resultError = new TResultType();
                    //foreach (var r in dRequest)
                    //{
                        //var resp = Activator.CreateInstance<TResultType>();
                        //resp.Code = "9004";
                        //resp.Message = "Aucune réponse : " + httpResponse.StatusCode.ToString();
                        //resp.ErpOprNumber = Guid.Empty;
                        //resp.DynamicsOprNumber = Guid.Empty;
                        //resultError.Add(resp);

                        var resp = Activator.CreateInstance<TResultType>();
                        resp.Code = "10002";
                        //resp.HttpResponseMsg = null;
                        resp.ResponseMsg = "Aucune réponse : " + httpResponse.StatusCode.ToString(); 
                        //resultError.Add(resp);
                    //}
                    return resp;
                }

                //List<TResultType> result;
                var result = Activator.CreateInstance<TResultType>();
                using (var respStream = httpResponse.GetResponseStream())
                {
                    if (respStream == null) return null;
                    var reader = new StreamReader(respStream);
                    var rep = @reader.ReadToEnd().Trim();
                    try
                    {
                        result = (TResultType)JsonHelp.JsonDeserialize<TResultType>(rep);
                    }
                    catch (Exception e)
                    {
                        //-----------------------------------------------------------------
                        // Erreur dans le message de retour = Renvoi du message FrameWork
                        //-----------------------------------------------------------------
                        //var resultError = new List<TResultType>();
                        //foreach (var r in dRequest)
                        //{
                            var resp = Activator.CreateInstance<TResultType>();
                            //resp.Code = "9999";
                            //resp.Message = e.Message;
                            //resp.ErpOprNumber = Guid.Empty;
                            //resp.DynamicsOprNumber = Guid.Empty;
                            //resultError.Add(resp);

                            resp.Code = "10003";
                            //resp.HttpResponseMsg = null;
                            resp.ResponseMsg = e.Message;
                            //resultError.Add(resp);
                        //}
                        return resp;
                    }
                }
                return result;
            }
            catch (WebException e)
            {
                //var resultError = new List<TResultType>();
                //foreach (var r in dRequest)
                //{
                    var resp = Activator.CreateInstance<TResultType>();
                    //resp.Code = "9000";
                    //resp.Message = e.Message;
                    //resp.ErpOprNumber = Guid.Empty;
                    //resp.DynamicsOprNumber = Guid.Empty;
                    //resultError.Add(resp);

                    resp.Code = "10004";
                    //resp.HttpResponseMsg = null;
                    resp.ResponseMsg = e.Message;
                    //resultError.Add(resp);
                //}
                return resp;
            }
            catch (UriFormatException e)
            {
                //var resultError = new List<TResultType>();
                //foreach (var r in dRequest)
                //{
                    var resp = Activator.CreateInstance<TResultType>();
                    //resp.Code = "9001";
                    //resp.Message = e.Message;
                    //resp.ErpOprNumber = Guid.Empty;
                    //resp.DynamicsOprNumber = Guid.Empty;
                    //resultError.Add(resp);

                    resp.Code = "10005";
                    //resp.HttpResponseMsg = null;
                    resp.ResponseMsg = e.Message;
                    //resultError.Add(resp);
               // }
                return resp;
            }
            catch (Exception e)
            {
                //-----------------------------------------------------------------
                // Erreur générale du Web Service le message de retour =
                // Renvoi du message FrameWork
                //-----------------------------------------------------------------
                //var resultError = new List<TResultType>();
                //foreach (var r in dRequest)
                //{
                    var resp = Activator.CreateInstance<TResultType>();
                    //resp.Code = "9999";
                    //resp.Message = e.Message;
                    //resp.ErpOprNumber = Guid.Empty;
                    //resp.DynamicsOprNumber = Guid.Empty;
                    //resultError.Add(resp);

                    resp.Code = "10006";
                    //resp.HttpResponseMsg = null;
                    resp.ResponseMsg = e.Message;
                    //resultError.Add(resp);
                //}
                return resp;
            }
        }
        #endregion

        #region Les interfaces (Métiers)

        #region CashDiscERP
        /// <summary>
        /// Interface Business  :   CashDiscERP
        /// </summary>
        /// <param name="dobject"></param>
        /// <returns></returns>
        public List<ModelBusiness.Response> CashDisc(List<CashDiscERP> dobject)
        {
            return CallServiceERP<CashDiscERP, ModelBusiness.Response>(dobject);
        }
        #endregion

        #region BusRelSegmentGroupERB
        /// <summary>
        /// Interface Business  :   BusRelSegmentGroupERB
        /// </summary>
        /// <param name="dobject"></param>
        /// <returns></returns>
        public List<ModelBusiness.Response> BusRelSegmentGroup(List<BusRelSegmentGroupERB> dobject)
        {
            return CallServiceERP<BusRelSegmentGroupERB, ModelBusiness.Response>(dobject);
        }
        #endregion

        #region Login
        /// <summary>
        /// Interface Business  :   CashDiscERP
        /// </summary>
        /// <param name="dobject"></param>
        /// <returns></returns>
        public TokenHandler.Models.LoginResponse Login(TokenHandler.Models.LoginRequest dobject)
        {
            return CallServiceLogin<LoginRequest, LoginResponse>(dobject);
        }
        #endregion

        #endregion
    }
}
