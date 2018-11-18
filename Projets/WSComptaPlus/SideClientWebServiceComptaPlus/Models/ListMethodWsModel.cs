//-----------------------------------------------------------------------------------
//
//  Application     :   Gestion des méthodes du Web Services (partie client)
//
//  Langage         :   C# 7.0 sous Visual Studio 2017 Community
//
//  FrameWork       :   4.6.1.1.
//
//  Projet          :   DLL FrameWorkSide (informations communes)
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

using System;
using System.ComponentModel;
using FrameWorkSide.Enum;

namespace SideClientWebServiceComptaPlus.Models
{
    /// <summary>
    /// Class Business  :   Gère les différents Template et action pour la méthode du service
    /// </summary>
    public class ListMethodWsModel: INotifyPropertyChanged
    {
        #region Membres
        private Guid _id;  
        private string _code;
        private TypeMethodWebService _typeMethod; 
        private string _description;
        private string _lien;
        private bool _isActive;
        #endregion

        #region Propriétés
        /// <summary>
        /// Identifiant 
        /// </summary>
        public Guid Id
        {
            get => _id;
            set
            {
                if (_id == value) return;
                _id = value;
                RaisePropertyChanged("Id");
            }
        }
        /// <summary>
        /// Code de la méthode du Web Services
        /// </summary>
        public string Code
        {
            get => _code;
            set
            {
                if (_code == value) return;
                _code = value;
                RaisePropertyChanged("Code");
            }
        }
        /// <summary>
        /// Type de méthode du Web Services
        /// </summary>
        public TypeMethodWebService TypeMethod
        {
            get => _typeMethod;
            set
            {
                if (_typeMethod == value) return;
                _typeMethod = value;
                RaisePropertyChanged("TypeMethod");
            }
        }
        /// <summary>
        /// Description de la méthode
        /// </summary>
        public string Description
        {
            get => _description;
            set
            {
                if (_description == value) return;
                _description = value;
                RaisePropertyChanged("Description");
            }
        }
        /// <summary>
        /// Lien de la méthode
        /// </summary>
        public string Lien
        {
            get => _lien;
            set
            {
                if (_lien == value) return;
                _lien = value;
                RaisePropertyChanged("Lien");
            }
        }
        /// <summary>
        /// Méthode activée
        /// </summary>
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive == value) return;
                _isActive = value;
                RaisePropertyChanged("IsActive");
            }
        }
        
        #endregion

        #region Evènement des propriétés.
        private void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}