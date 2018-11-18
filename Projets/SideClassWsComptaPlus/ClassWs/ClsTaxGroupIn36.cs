// ***********************************************************************************
//
//      Solution            :   WebServiceComptaPlus
//      Projet              :   SideClassWsComptaPlus
//
//      Titre               :   Class TVA.
//                              Interface 36.1 - 36.2 - 36.3
//      Description         :   -
//
//      Démarrage           :   27-09-2018
//      Version langage C#  :   4.0
//
//      Assembly            :   4.5.2 (Version de D365)
//
//
// ***********************************************************************************
//
//      Client              :   Thomas & Piron
//      Projet métier       :   Compta Plus
//
//      Manager projet      :   François Piret
//      Chef de Projet      :   Laurent Mathieu
//
//      CopyRight           :   Side sa
//
// ***********************************************************************************
using SideFrameWork.Enum;
using SideWsComptaPlus.Contracts;
using SideWsComptaPlus.ModelBusiness;
using System;
using System.Collections.Generic;


namespace SideClassWsComptaPlus.ClassWs
{
    /// <summary>
    /// Class    :   Groupe Taxe TVA.
    /// </summary>
    /// <returns></returns>
    /// <remarks>Interface 36.1, 36.2, 36.3 - DC-IN04 - COM09</remarks>
    public class ClsTaxGroupIn36
    {
        /// <summary>
        /// Method  :   un ou plusieurs groupes de taxes envoyés par D365.
        /// </summary>
        /// <param name="dDataIn01">Obtient ou Définit la liste des groupes de taxes.</param>
        /// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        /// <remarks>Interface 36 - DC-IN04 - COM09</remarks>
        /// <example></example>
        public static List<Response> ExecuteTaxGroup(List<TaxGroupIn361> dDataIn03, TypeEnvironment dEnvironnement)
        {
            var ListResponse = new List<Response>();
            foreach (var element in dDataIn03)
            {
                ListResponse.Add(new Response
                {
                    Code = "0",
                    Message = "",
                    ErpOprNumber = Guid.NewGuid(),
                    DynamicsOprNumber = element.DynamicsOprNumber
                });
            }

            return ListResponse;
            //#region Membres
            //#endregion

            //#region Analyse et méthode de travail
            ////------------------------------------------------------------------------------------------------------------------
            ////--- 1.Inscrire dans la table WsQueue pour signaler que le traitement est en cours.
            ////
            ////------------------------------------------------------------------------------------------------------------------
            ////
            ////--- 2. Vérification des valeurs reçue.
            ////
            ////       Test les différents points  :

            ////
            ////------------------------------------------------------------------------------------------------------------------
            ////
            //// --- 3. Vérification si le code de société sont correctes et capture les informations de connexion à SQL SERVER.
            ////
            ////        Company - E500 - cette valeur ne peut pas être vide ou null et le code de la société doit existant.
            ////
            ////------------------------------------------------------------------------------------------------------------------
            ////
            //// --- 4.
            ////------------------------------------------------------------------------------------------------------------------
            //#endregion

            //#region 1. Inscrire dans la table WsQueue pour signaler que le traitement est en cours.
            //#endregion

            //#region Déclaration des variables de la Class.
            //var ListMessageLog = new List<DetailMessageSideModel>();
            //var valueResponse = new Response();
            //var listQuery = new List<SettingsConnectionModel>();
            ////**********************************************************************************
            //// Liste permettant de connaître les sociétés qui ne font pas partie du groupe TP.
            //var ListeError = new List<string>();
            //// Liste des sociétés demandées.
            ////var ListOfCompaniesToProcess = new ObservableCollection<SocieteGestionConnexionModel>();
            //// Paramètres récoltés du fichier APP.CONFIG
            //var configTp = new TpConfiguration();
            //// Identifiant de la transaction (par lot de demande)
            //var GuidGrpTransaction = Guid.NewGuid();
            //#endregion

            //#region Initialisation des valeurs pour la suite du travail à réaliser.
            ////*********************************************************************************
            //// Capture de la chaîne de connexion pour les données commune au groupe TP
            //// Récupération de la configuration de l'application appelante.
            ////*********************************************************************************
            //var strCnxGtp = DataBase.StrConnectionGTPLogService(dEnvironnement, ref configTp);
            //#endregion
            //// Traitement des données.
            //foreach (var Taxe in dDataIn03)
            //{
            //    // Vérification des données reçues.
            //    // Si il y a des erreurs la valeur est à FALSE
            //    if (!TaxeBusinessTools.TestValueTaxeGroupe(Taxe, GuidGrpTransaction, ref ListMessageLog))
            //    {
            //        // Tester si le code société n'est pas vide ou n'existe pas
            //            if (Taxe.Company != "")
            //            {
            //                // Capture d'information a propos de la société demandée
            //                var strCnxSociety = ListSocietyTp.ManagerStrCnxSociety(Taxe.Company,dEnvironnement.ToString(),strCnxGtp, configTp);

            //                switch (Taxe.StatusQuery)
            //                {
            //                    //*************************************************************************
            //                    //  CREATION
            //                    //*************************************************************************
            //                    case SideWsComptaPlus.Enum.StatusQuery.Create:
            //                        var Create = TaxeBusinessTools.CreateTaxeGroupe(Taxe, Taxe.Company, strCnxSociety.ConnexionSociete);
            //                            if (Create.CodeMessage != null)
            //                            {
            //                                //*************** Il y a eu un problème à l'enregistrement.
            //                                Create.IdGroupeTransaction = GuidGrpTransaction;
            //                                // Mémorise Erreur dans le log
            //                                ListMessageLog.Add(Create);
            //                            }
            //                            else
            //                            {
            //                                Create.IdGroupeTransaction = GuidGrpTransaction;
            //                                // Mémorise Erreur dans le log
            //                                ListMessageLog.Add(Create);
            //                            }

            //                            break;
            //                        //*************************************************************************
            //                        //  MODIFICATION
            //                        //*************************************************************************
            //                        case SideWsComptaPlus.Enum.StatusQuery.Update:
            //                            var Update = TaxeBusinessTools.UpdateTaxeGroupe(Taxe, Taxe.Company, strCnxSociety.ConnexionSociete);
            //                            if (Update.CodeMessage != null)
            //                            {
            //                                //*************** Il y a eu un problème à l'enregistrement.
            //                                Update.IdGroupeTransaction = GuidGrpTransaction;
            //                                // Mémorise Erreur dans le log
            //                                ListMessageLog.Add(Update);
            //                            }
            //                            else
            //                            {
            //                                ListMessageLog.Add(Update);
            //                            }

            //                    break;

            //                        case SideWsComptaPlus.Enum.StatusQuery.Delete:
            //                            var Delete = TaxeBusinessTools.DeleteTaxeGroupe(Taxe, Taxe.Company, strCnxSociety.ConnexionSociete);
            //                            if (Delete.CodeMessage != null)
            //                            {
            //                                //*************** Il y a eu un problème à l'enregistrement.
            //                                Delete.IdGroupeTransaction = GuidGrpTransaction;
            //                                //Update.UtilisateurTransactionLog = TypeUserLog.CreateError;
            //                                // Mémorise Erreur dans le log
            //                                ListMessageLog.Add(Delete);
            //                            }
            //                            else
            //                            {
            //                                ListMessageLog.Add(Delete);
            //                            }
            //                    break;
            //                }
            //            }
            //            else
            //            {
            //                //// Mémorise Erreur dans le log
            //                ListMessageLog.Add(new DetailMessageSideModel
            //                {
            //                    BaseMessage = new DetailMessageSideBaseModel
            //                    {
            //                        Message = "",
            //                        ParametreBusiness = new List<string> { Taxe.TaxGroup },
            //                        UtilisateurTransaction = TypeUser.WebErpDev,
            //                        InterfaceTransaction = TypeInterface.InterfaceIn361GroupeTaxe,
            //                        ErpOprNumber = Guid.Empty,
            //                        D365OprNumber = Taxe.DynamicsOprNumber,
            //                        Commentaire = "Nothing",
            //                        TypeMessage = TypeMessage.MessageError

            //                    },
            //                    CodeSociete = Taxe.Company,
            //                    CodeMessage = "1001",
            //                    UtilisateurTransactionLog = TypeUserLog.TestIn,
            //                    StatutQuery = (StatusQuery)Taxe.StatusQuery,
            //                    IdGroupeTransaction = GuidGrpTransaction
            //                });
            //            }
            //    }
            //}

            //#region Mémorisation des log
            //// Écriture des Log
            //foreach (var MsgLog in ListMessageLog)
            //{
            //    var Retour = SwitchLogTransaction.Record(MsgLog, strCnxGtp);

            //    if (Retour != null)
            //    {
            //        // Si il y a une erreur inconnue au système.
            //        // Définition et mémorisation du Message Log.
            //        var CriticalError = new DetailMessageSideModel
            //        {
            //            BaseMessage = new DetailMessageSideBaseModel
            //            {
            //                Message = "Erreur Critique : Inconnue par le système ",
            //                ParametreBusiness = new List<string> { Retour.Message },
            //                UtilisateurTransaction = TypeUser.WebErpDev,
            //                InterfaceTransaction = TypeInterface.interfaceIn01Pcmn,
            //                ErpOprNumber = Guid.NewGuid(),
            //                D365OprNumber = Guid.Empty,
            //                Commentaire = String.Format("Source : {0} \nCible {1}", Retour.Source, Retour.TargetSite),
            //                TypeMessage = TypeMessage.MessageError

            //            },
            //            CodeSociete = "All",
            //            CodeMessage = "9999",
            //            UtilisateurTransactionLog = TypeUserLog.TestIn,
            //            StatutQuery = StatusQuery.Create,
            //            IdGroupeTransaction = GuidGrpTransaction

            //        };
            //        SwitchLogTransaction.Record(CriticalError, strCnxGtp);
            //    }
            //}

            //#endregion

            //// Construction des Responses pour Web Service.
            //var ListResponse = new List<Response>();
            //ListResponse = SwitchLogTransaction.WebServiceResponse(ListMessageLog);

            //return ListResponse;
        }
        /// <summary>
        /// Method  :   un ou plusieurs groupes de taxes envoyés par D365.
        /// </summary>
        /// <param name="dDataIn01">Obtient ou Définit la liste des groupes de taxes.</param>
        /// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        /// <remarks>Interface 36 - DC-IN04 - COM09</remarks>
        /// <example></example>
        public static List<Response> ExecuteTaxGroupArticle(List<TaxItemGroupIn362> dDataIn03, TypeEnvironment dEnvironnement)
        {
            var ListResponse = new List<Response>();
            foreach (var element in dDataIn03)
            {
                ListResponse.Add(new Response
                {
                    Code = "0",
                    Message = "",
                    ErpOprNumber = Guid.NewGuid(),
                    DynamicsOprNumber = element.DynamicsOprNumber
                });
            }

            return ListResponse;
        }
            
        public static List<Response> ExecuteTaxGroupCode(List<TaxCodeIn363> dDataIn03, TypeEnvironment dEnvironnement)
        {
            var ListResponse = new List<Response>();
            foreach (var element in dDataIn03)
            {
                ListResponse.Add(new Response
                {
                    Code = "0",
                    Message = "",
                    ErpOprNumber = Guid.NewGuid(),
                    DynamicsOprNumber = element.DynamicsOprNumber
                });
            }

            return ListResponse;

            #region Old
            //#region Membres
            //#endregion

            //#region Analyse et méthode de travail
            ////------------------------------------------------------------------------------------------------------------------
            ////--- 1.Inscrire dans la table WsQueue pour signaler que le traitement est en cours.
            ////
            ////------------------------------------------------------------------------------------------------------------------
            ////
            ////--- 2. Vérification des valeurs reçue.
            ////
            ////       Test les différents points  :

            ////
            ////------------------------------------------------------------------------------------------------------------------
            ////
            //// --- 3. Vérification si le code de société sont correctes et capture les informations de connexion à SQL SERVER.
            ////
            ////        Company - E500 - cette valeur ne peut pas être vide ou null et le code de la société doit existant.
            ////
            ////------------------------------------------------------------------------------------------------------------------
            ////
            //// --- 4.
            ////------------------------------------------------------------------------------------------------------------------
            //#endregion

            //#region 1. Inscrire dans la table WsQueue pour signaler que le traitement est en cours.
            //#endregion

            //#region Déclaration des variables de la Class.
            //var ListMessageLog = new List<DetailMessageSideModel>();
            //var valueResponse = new Response();
            //var listQuery = new List<SettingsConnectionModel>();
            ////**********************************************************************************
            //// Liste permettant de connaître les sociétés qui ne font pas partie du groupe TP.
            //var ListeError = new List<string>();
            //// Liste des sociétés demandées.
            ////var ListOfCompaniesToProcess = new ObservableCollection<SocieteGestionConnexionModel>();
            //// Paramètres récoltés du fichier APP.CONFIG
            //var configTp = new TpConfiguration();
            //// Identifiant de la transaction (par lot de demande)
            //var GuidGrpTransaction = Guid.NewGuid();
            //#endregion

            //#region Initialisation des valeurs pour la suite du travail à réaliser.
            ////*********************************************************************************
            //// Capture de la chaîne de connexion pour les données commune au groupe TP
            //// Récupération de la configuration de l'application appelante.
            ////*********************************************************************************
            //var strCnxGtp = DataBase.StrConnectionGTPLogService(dEnvironnement, ref configTp);
            //#endregion
            //// Traitement des données.
            //foreach (var Taxe in dDataIn03)
            //{
            //    // Vérification des données reçues.
            //    // Si il y a des erreurs la valeur est à FALSE
            //    if (!TaxeBusinessTools.TestValueCodeTaxe(Taxe, GuidGrpTransaction, ref ListMessageLog))
            //    {
            //        // Tester si le code société n'est pas vide ou n'existe pas
            //        if (Taxe.Company != "")
            //        {
            //            // Capture d'information a propos de la société demandée
            //            var strCnxSociety = ListSocietyTp.ManagerStrCnxSociety(Taxe.Company, dEnvironnement.ToString(), strCnxGtp, configTp);

            //            switch (Taxe.StatusQuery)
            //            {
            //                //*************************************************************************
            //                //  CREATION
            //                //*************************************************************************
            //                case SideWsComptaPlus.Enum.StatusQuery.Create:
            //                    var Create = TaxeBusinessTools.CreateCodeTaxe(Taxe, Taxe.Company, strCnxSociety.ConnexionSociete);
            //                    if (Create.CodeMessage != null)
            //                    {
            //                        //*************** Il y a eu un problème à l'enregistrement.
            //                        Create.IdGroupeTransaction = GuidGrpTransaction;
            //                        // Mémorise Erreur dans le log
            //                        ListMessageLog.Add(Create);
            //                    }
            //                    else
            //                    {
            //                        Create.IdGroupeTransaction = GuidGrpTransaction;
            //                        // Mémorise Erreur dans le log
            //                        ListMessageLog.Add(Create);
            //                    }

            //                    break;
            //                //*************************************************************************
            //                //  MODIFICATION
            //                //*************************************************************************
            //                case SideWsComptaPlus.Enum.StatusQuery.Update:
            //                    var Update = TaxeBusinessTools.UpdateCodeTaxe(Taxe, Taxe.Company, strCnxSociety.ConnexionSociete);
            //                    if (Update.CodeMessage != null)
            //                    {
            //                        //*************** Il y a eu un problème à l'enregistrement.
            //                        Update.IdGroupeTransaction = GuidGrpTransaction;
            //                        // Mémorise Erreur dans le log
            //                        ListMessageLog.Add(Update);
            //                    }
            //                    else
            //                    {
            //                        ListMessageLog.Add(Update);
            //                    }

            //                    break;

            //                case SideWsComptaPlus.Enum.StatusQuery.Delete:
            //                    var Delete = TaxeBusinessTools.DeleteCodeTaxe(Taxe, Taxe.Company, strCnxSociety.ConnexionSociete);
            //                    if (Delete.CodeMessage != null)
            //                    {
            //                        //*************** Il y a eu un problème à l'enregistrement.
            //                        Delete.IdGroupeTransaction = GuidGrpTransaction;
            //                        //Update.UtilisateurTransactionLog = TypeUserLog.CreateError;
            //                        // Mémorise Erreur dans le log
            //                        ListMessageLog.Add(Delete);
            //                    }
            //                    else
            //                    {
            //                        ListMessageLog.Add(Delete);
            //                    }
            //                    break;
            //            }
            //        }
            //        else
            //        {
            //            //// Mémorise Erreur dans le log
            //            ListMessageLog.Add(new DetailMessageSideModel
            //            {
            //                BaseMessage = new DetailMessageSideBaseModel
            //                {
            //                    Message = "",
            //                    ParametreBusiness = new List<string> { Taxe.TaxCode },
            //                    UtilisateurTransaction = TypeUser.WebErpDev,
            //                    InterfaceTransaction = TypeInterface.InterfaceIn363CodeTaxe,
            //                    ErpOprNumber = Guid.Empty,
            //                    D365OprNumber = Taxe.DynamicsOprNumber,
            //                    Commentaire = "Nothing",
            //                    TypeMessage = TypeMessage.MessageError

            //                },
            //                CodeSociete = Taxe.Company,
            //                CodeMessage = "1001",
            //                UtilisateurTransactionLog = TypeUserLog.TestInError,
            //                StatutQuery = (StatusQuery)Taxe.StatusQuery,
            //                IdGroupeTransaction = GuidGrpTransaction
            //            });
            //        }
            //    }
            //}

            //#region Mémorisation des log
            //// Écriture des Log
            //foreach (var MsgLog in ListMessageLog)
            //{
            //    var Retour = SwitchLogTransaction.Record(MsgLog, strCnxGtp);

            //    if (Retour != null)
            //    {
            //        // Si il y a une erreur inconnue au système.
            //        // Définition et mémorisation du Message Log.
            //        var CriticalError = new DetailMessageSideModel
            //        {
            //            BaseMessage = new DetailMessageSideBaseModel
            //            {
            //                Message = "Erreur Critique : Inconnue par le système ",
            //                ParametreBusiness = new List<string> { Retour.Message },
            //                UtilisateurTransaction = TypeUser.WebErpDev,
            //                InterfaceTransaction = TypeInterface.interfaceIn01Pcmn,
            //                ErpOprNumber = Guid.NewGuid(),
            //                D365OprNumber = Guid.Empty,
            //                Commentaire = String.Format("Source : {0} \nCible {1}", Retour.Source, Retour.TargetSite),
            //                TypeMessage = TypeMessage.MessageError

            //            },
            //            CodeSociete = "All",
            //            CodeMessage = "9999",
            //            UtilisateurTransactionLog = TypeUserLog.TestIn,
            //            StatutQuery = StatusQuery.Create,
            //            IdGroupeTransaction = GuidGrpTransaction

            //        };
            //        SwitchLogTransaction.Record(CriticalError, strCnxGtp);
            //    }
            //}

            //#endregion

            //// Construction des Responses pour Web Service.
            //var ListResponse = new List<Response>();
            //ListResponse = SwitchLogTransaction.WebServiceResponse(ListMessageLog);

            //return ListResponse;
            #endregion
        }




        //TODO: A FAIRE
        /// <summary>
        /// Method  :   un ou plusieurs groupes de taxes envoyés par D365.
        /// </summary>
        /// <param name="dDataIn01">Obtient ou Définit la liste des groupes de taxes.</param>
        /// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        /// <remarks>Interface 36 - DC-IN04 - COM09</remarks>
        /// <example></example>
        public static List<Response> ExecuteTaxCodeTaxGroup(List<TaxCodeTaxGroupIn364> dDataIn03, TypeEnvironment dEnvironnement)
        {
            var ListResponse = new List<Response>();
            foreach (var element in dDataIn03)
            {
                ListResponse.Add(new Response
                {
                    Code = "0",
                    Message = "",
                    ErpOprNumber = Guid.NewGuid(),
                    DynamicsOprNumber = element.DynamicsOprNumber
                });
            }

            return ListResponse;
        }
        /// <summary>
        /// Method  :   un ou plusieurs groupes de taxes envoyés par D365.
        /// </summary>
        /// <param name="dDataIn01">Obtient ou Définit la liste des groupes de taxes.</param>
        /// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        /// <remarks>Interface 36 - DC-IN04 - COM09</remarks>
        /// <example></example>
        public static List<Response> ExecuteTaxCodeTaxItemGroup(List<TaxCodeTaxItemGroupIN365> dDataIn03, TypeEnvironment dEnvironnement)
        {
            var ListResponse = new List<Response>();
            foreach (var element in dDataIn03)
            {
                ListResponse.Add(new Response
                {
                    Code = "0",
                    Message = "",
                    ErpOprNumber = Guid.NewGuid(),
                    DynamicsOprNumber = element.DynamicsOprNumber
                });
            }

            return ListResponse;
        }
        /// <summary>
        /// Method  :   un ou plusieurs groupes de taxes envoyés par D365.
        /// </summary>
        /// <param name="dDataIn01">Obtient ou Définit la liste des groupes de taxes.</param>
        /// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        /// <remarks>Interface 36 - DC-IN04 - COM09</remarks>
        /// <example></example>
        public static List<Response> ExecuteTaxCodeValue(List<TaxCodeValueIN366> dDataIn03, TypeEnvironment dEnvironnement)
        {
            var ListResponse = new List<Response>();
            foreach (var element in dDataIn03)
            {
                ListResponse.Add(new Response
                {
                    Code = "0",
                    Message = "",
                    ErpOprNumber = Guid.NewGuid(),
                    DynamicsOprNumber = element.DynamicsOprNumber
                });
            }

            return ListResponse;
        }
        /// <summary>
        /// Method  :   un ou plusieurs groupes de taxes envoyés par D365.
        /// </summary>
        /// <param name="dDataIn01">Obtient ou Définit la liste des groupes de taxes.</param>
        /// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        /// <remarks>Interface 36 - DC-IN04 - COM09</remarks>
        /// <example></example>
        public static List<Response> ExecuteTaxCodeLanguageTxt(List<TaxCodeLanguageTxtIN367> dDataIn03, TypeEnvironment dEnvironnement)
        {
            var ListResponse = new List<Response>();
            foreach (var element in dDataIn03)
            {
                ListResponse.Add(new Response
                {
                    Code = "0",
                    Message = "",
                    ErpOprNumber = Guid.NewGuid(),
                    DynamicsOprNumber = element.DynamicsOprNumber
                });
            }

            return ListResponse;
        }



    }
}
