using ERPDynamics;
using SideWsComptaPlus.Contracts;
using SideWsComptaPlus.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using TokenHandler;
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
                httpWebRequest.Headers.Add("Authorization", "Bearer " + "123456789");
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
            //Token protection
            //todo
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
        public List<TokenHandler.Models.LoginResponse> Login(List<TokenHandler.Models.LoginRequest> dobject)
        {
            //Test if Token
            TokenHandler.Token th = new Token();
            HttpRequestMessage httpRequestMessage = HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;

            //var result = th.SendAsyncAccess(httpRequestMessage,null);

            //test if user exists
            //to do
            var tokenCreated = new Token().createToken("myuser");
            string concat = tokenCreated; // "From WS -> UN: " +  dobject.FirstOrDefault().Username + " PW: " + dobject.FirstOrDefault().Password;
            //generates a KEY and get it back
            return new List<TokenHandler.Models.LoginResponse>() { new TokenHandler.Models.LoginResponse { Token = concat } };
        }
        #endregion

        #endregion
    }
}
