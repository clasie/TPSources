//-----------------------------------------------------------------------------------
//
//  Application     :   Simulateur du Web Service du ERP TP
//
//  Langage         :   C# 7.0 sous Visual Studio 2017
//
//  FrameWork       :   4.6.1.1.
//
//  Projet          :   DLL SideClientWebServiceComptaPlus
//
//  Date            :   07/09/2018
//
//  Copyright       :   Side SA - 2018
//
//  Client          :   Thomas & Piron
//
//-----------------------------------------------------------------------------------
//
//  Détail Release  :   Version VS | Version C# | Version FrameWork | Version release 
//
//
//
//  V.17.07.461.00          CMA     Démarrage.
//
//
//-----------------------------------------------------------------------------------

using FrameWorkSide.Enum;
using SideClientWebServiceComptaPlus.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;


namespace SideClientWebServiceComptaPlus.Data
{
    /// <summary>
    /// Documentation du Web Service: Les méthodes.
    /// </summary>
    public class LoadingMethodWebServices
    {
        public static ObservableCollection<ListMethodWsModel> Run()
        {
            try
            {
                return new ObservableCollection<ListMethodWsModel>
                    {
                        // Informations générales.
                        new ListMethodWsModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "3", Description = "--- Informations sur Web Service (Test)", 
                            Lien = "", 
                            TypeMethod = TypeMethodWebService.WsPut,
                            IsActive = true,
                        },
                        // PCMN.
                        new ListMethodWsModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "1", Description = "Ajouter, modifier ou suspendre un Compte du PCMN - Interface 1", 
                            Lien = "/pcmn/element", 
                            TypeMethod = TypeMethodWebService.WsPut,
                            IsActive = true,
                        },
                        new ListMethodWsModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "2", Description = "Ajouter, modifier ou suspende plusieurs Comptes du PCMN - Interface 1", 
                            Lien = "/pcmn/list}", 
                            TypeMethod = TypeMethodWebService.WsPut,
                            IsActive = true,
                        },
                        new ListMethodWsModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "4", Description = "Recevoir un enregistrement du Segment (Fournisseur) - Interface 29.1", 
                            Lien = "/segment/element", 
                            TypeMethod = TypeMethodWebService.WsGet,
                            IsActive = true,
                        },
                        new ListMethodWsModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "5", Description = "Recevoir 10 enregistrements factice du Segment (test) - Interface 29.1", 
                            Lien = "/segment/list", 
                            TypeMethod = TypeMethodWebService.WsGet,
                            IsActive = true,
                        },
                        new ListMethodWsModel
                        {
                            Id = Guid.NewGuid(),
                            Code = "6", Description = "Recevoir 10 000 enregistrements du Segment (test) - Interface 29.1", 
                            Lien = "/segment/list1000", 
                            TypeMethod = TypeMethodWebService.WsGet,
                            IsActive = true,
                        },
                    };
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new ObservableCollection<ListMethodWsModel>();
            }
        }
    }
}