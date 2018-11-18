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

using CommonVariables.Models.Application;
using CommonVariables.Models.D365;
using FrameWorkSide.Enum;
using FrameWorkSide.Models.WebServices.Json;
using SideClientWebServiceComptaPlus.Core.MVVM;
using SideClientWebServiceComptaPlus.Data;
using SideClientWebServiceComptaPlus.GetWebService;
using SideClientWebServiceComptaPlus.Models;
using SideClientWebServiceComptaPlus.PutPostWebService;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SideClientWebServiceComptaPlus.ViewModels
{
    /// <summary>
    /// Class   :   est le View-Model (Liaison entre l'interface graphique et le code Behind)
    /// pour la gestion du simulateur du Web service ERP
    /// </summary>
    public class WebServicePutD365ViewModel: ViewModelBase
    {
        #region Membres         
        private object _selectedObj;
        private string _isEditable;
        private object _selectedSociete;
        private object _selectedMethod;
        private string _lienMethodSelec ;
        private string _lienService;
        // Attention cette IP est réservé que pour l'accès de 4 autres IP de NSI.
        //private string _urlWsBase = "http://194.78.49.211:51170/ServiceComptaPlus.svc";
        private string _urlWsBase;

        private bool _modeProduction;
        private bool _modeDeveloppement;
        
        private string _actionWs;
        private readonly int _compteur = 1;
        private DateTime _infoCapturee;
        
        // Grille de données.
        private Visibility _isVisibleLoadModel;
        private Visibility _isVisibleImportExcel;
        private Visibility _isVisibleDataAuto;

        private Visibility _isVisibleGridIn01;
        private Visibility _isVisibleGridIn02;
               
        /// <summary>
        /// Mode de Travail
        /// </summary>
        private TypeManagerButton _etatButton = TypeManagerButton.Aucun;  

        private ObservableCollection<PcmnD365Model> _obcTablesIn01 = 
            new ObservableCollection<PcmnD365Model>();
        private ObservableCollection<FieldTableErpModel> _obcTablesIn02 = 
            new ObservableCollection<FieldTableErpModel>();

        private ObservableCollection<ListMethodWsModel> _cmbMethod = 
            new ObservableCollection<ListMethodWsModel>();
        private ObservableCollection<ListeSideTypeA> _listeRetourInfoWs = 
            new ObservableCollection<ListeSideTypeA>();
        
        #endregion

        #region Les commandes
        /// <summary>
        /// Command :   Charger le modèle en rapport du choix de la liste de méthodes.
        /// </summary>
        public ICommand LoadListMethodCommand { get; set; }
        /// <summary>
        /// Command :   Importer les données venant d'un fichier Excel.
        /// </summary>
        public ICommand ImportExcelCommand { get; set; }
        /// <summary>
        /// Command :   Encodage automatique des données.
        /// </summary>
        public ICommand DataAutoCommand { get; set; }
        /// <summary>
        /// Command :   Envoyer la méthode au Web Services du ERP.
        /// </summary>
        public ICommand GoWsCommand { get; set; }
        #endregion

        #region Propriétés
        /// <summary>
        /// Sélection d'une ligne
        /// </summary>
        public object SelectedObj
        {
            get => _selectedObj;
            set
            {
                if (_selectedObj == value) return;
                _selectedObj = value;
                RaisePropertyChanged("SelectedObj");
            }
        }
        /// <summary>
        /// Sélection d'une société
        /// </summary>        
        public object SelectedSociete
        {
            get => _selectedSociete;
            set
            {
                if (_selectedSociete == value) return;
                _selectedSociete = value;
                RaisePropertyChanged("SelectedSociete");
            }
        }
        /// <summary>
        /// Sélection d'une méthode
        /// </summary>        
        public object SelectedMethod
        {
            get => _selectedMethod;
            set
            {
                if (_selectedMethod == value) return;
                _selectedMethod = value;

                var cMethod = (ListMethodWsModel)SelectedMethod;        // Contenu de la sélection
                LienMethodSelec = _lienService + cMethod.Lien;          // Lien complète du Web Service
                LoadListMethodOperation(null);                          // Charge du modèle
                

                RaisePropertyChanged("SelectedMethod");
            }
        }

        /// <summary>
        /// Sélection d'une méthode
        /// </summary>        
        public string LienMethodSelec
        {
            get => _lienMethodSelec;
            set
            {
                if (_lienMethodSelec == value) return;
                _lienMethodSelec = value;

                RaisePropertyChanged("LienMethodSelec");
            }
        }
        /// <summary>
        /// Sélection du Web Services
        /// </summary>        
        public string LienService
        {
            get => _lienService;
            set
            {
                if (_lienService == value) return;
                _lienService = value;
                
                RaisePropertyChanged("LienService");
            }
        }

        /// <summary>
        /// Définit Url de base du Web Service.
        /// </summary>
        public string UrlBaseWs
        {
            get => _urlWsBase;
            set
            {
                if (_urlWsBase == value) return;
                _urlWsBase = value;
                RaisePropertyChanged("UrlBaseWs");
            }
        }

        /// <summary>
        /// Mode de travail en Production
        /// </summary>        
        public bool ModeProduction
        {
            get => _modeProduction;
            set
            {
                if (_modeProduction == value) return;
                _modeProduction = value;
                
                RaisePropertyChanged("ModeProduction");
            }
        }
        /// <summary>
        /// Mode de travail en Developpement
        /// </summary>        
        public bool ModeDeveloppement
        {
            get => _modeDeveloppement;
            set
            {
                if (_modeDeveloppement == value) return;
                _modeDeveloppement = value;
                
                RaisePropertyChanged("ModeDeveloppement");
            }
        }
    

        /// <summary>
        /// Information sur la commande vers Web Service.
        /// </summary>        
        public string ActionWs
        {
            get => _actionWs;
            set
            {
                if (_actionWs == value) return;
                _actionWs = value;
                
                RaisePropertyChanged("ActionWs");
            }
        }
        
        /// <summary>
        /// Class Business  :   Test à Supprimer
        /// </summary>        
        public ObservableCollection<ListeSideTypeA> ListeRetourInfoWs 
        {
            get => _listeRetourInfoWs;
            set
            {
                if (_listeRetourInfoWs == value) return;
                _listeRetourInfoWs = value;
                RaisePropertyChanged("ListeRetourInfoWs");
            }
        }
        
        /// <summary>
        /// Class Business  :   Liste de méthode PUT
        /// </summary>        
        public ObservableCollection<ListMethodWsModel> CmbMethod
        {
            get => _cmbMethod;
            set
            {
                if (_cmbMethod == value) return;
                _cmbMethod = value;
                RaisePropertyChanged("CmbMethod");
            }
        }
        /// <summary>
        /// Class Business  :   PCMN - Interface 01
        /// </summary>        
        public ObservableCollection<PcmnD365Model> ObcTablesIn01   
        {
            get => _obcTablesIn01;
            set
            {
                if (_obcTablesIn01 == value) return;
                _obcTablesIn01 = value;
                RaisePropertyChanged("ObcTablesIn01");
            }
        }
        /// <summary>
        /// Class Business  :   Test à Supprimer
        /// </summary>        
        public ObservableCollection<FieldTableErpModel> ObcTablesIn02 
        {
            get => _obcTablesIn02;
            set
            {
                if (_obcTablesIn02 == value) return;
                _obcTablesIn02 = value;
                RaisePropertyChanged("ObcTables");
            }
        }
        
        #region Paramètres
        /// <summary>
        /// Définit si le tableau de Fields est éditable
        /// </summary>
        public string IsEditable
        {
            get => _isEditable;
            set
            {
                if (_isEditable == value) return;
                _isEditable = value;
                RaisePropertyChanged("IsEditable");
            }
        }
        
        /// <summary>
        /// Définit si le bouton lecture du modèle en rapport de la méthode choisie.
        /// </summary>
        public Visibility IsVisibleLoadModel
        {
            get => _isVisibleLoadModel;
            set
            {
                if (_isVisibleLoadModel == value) return;
                _isVisibleLoadModel = value;
                RaisePropertyChanged("IsVisibleLoadModel");
            }
        }
        /// <summary>
        /// Définit si le bouton d'importation des données dans le tableau via un fichier EXCEL.
        /// </summary>
        public Visibility IsVisibleImportExcel
        {
            get => _isVisibleImportExcel;
            set
            {
                if (_isVisibleImportExcel == value) return;
                _isVisibleImportExcel = value;
                RaisePropertyChanged("IsVisibleImportExcel");
            }
        }
        /// <summary>
        /// Définit si le bouton d'encodage automatique  est visible.
        /// </summary>
        public Visibility IsVisibleDataAuto
        {
            get => _isVisibleDataAuto;
            set
            {
                if (_isVisibleDataAuto == value) return;
                _isVisibleDataAuto = value;
                RaisePropertyChanged("IsVisibleDataAuto");
            }
        }

        /// <summary>
        /// Définit si la grille de données PCMN est visible.
        /// </summary>
        public Visibility IsVisibleGridIn01
        {
            get => _isVisibleGridIn01;
            set
            {
                if (_isVisibleGridIn01 == value) return;
                _isVisibleGridIn01 = value;
                RaisePropertyChanged("IsVisibleGridIn01");
            }
        }
        /// <summary>
        /// Définit si la grille de données  est visible.
        /// </summary>
        public Visibility IsVisibleGridIn02
        {
            get => _isVisibleGridIn02;
            set
            {
                if (_isVisibleGridIn02 == value) return;
                _isVisibleGridIn02 = value;
                RaisePropertyChanged("IsVisibleGridIn02");
            }
        }

        #endregion
            
        #endregion

        #region Constructeur
        /// <summary>
        /// Instance Principale
        /// </summary>
        public WebServicePutD365ViewModel()
        {
            try
            { 
                UrlBaseWs = "http://10.250.16.90:51170/ServiceComptaPlus.svc";
                _urlWsBase = UrlBaseWs;

                // Définir les variables par défaut.
                //TODO: A définir dans les paramètres
                _lienService = _urlWsBase;
                ActionWs = "En attente d'instruction...";

               
                ModeDeveloppement = true;
                ModeProduction = false;
                
               // ListeRetourInfoWs.Add("Actuellement aucune réponse du Web Service du ERP");

                // Les commandes
                LoadListMethodCommand = new BaseCommand(LoadListMethodOperation);
                ImportExcelCommand = new BaseCommand(ImportExcelOperation);
                DataAutoCommand = new BaseCommand(DataAutoOperation);
                GoWsCommand = new BaseCommand(GoWsOperation);

                // Chargement des méthodes du Web Service et remplissage du COMBO de sélection.
                CmbMethod = LoadingMethodWebServices.Run();

                // Initialisation des objets                
                _etatButton = TypeManagerButton.Annuler;
                ManagerObject();
            }
            catch
            {
                // ignoré
            }
        }
        #endregion

        #region Méthodes
        
        /// <summary>
        /// Bouton  :   Charger le modèle en rapport de la méthode.
        /// </summary>
        private void LoadListMethodOperation(object obj)
        {
            IsVisibleGridIn01 = Visibility.Visible;
            IsVisibleGridIn02 = Visibility.Hidden;
            
        }
        /// <summary>
        /// Bouton  :   Importation fichier Excel.
        /// </summary>
        private void ImportExcelOperation(object obj)
        {
        }

        /// <summary>
        /// Bouton  :   Encodage automatique des données.
        /// </summary>
        private void DataAutoOperation(object obj)
        {
            var cMethod = (ListMethodWsModel)SelectedMethod;        // Contenu de la sélection
            ObcTablesIn01 = LoadingDataDummy.LoadingPcmnList(_compteur, 50, 1400 + _compteur, 99);
        }

        /// <summary>
        /// Bouton  :   Envoyer la commande au Web Services du ERP.
        /// </summary>
        private void GoWsOperation(object obj)
        {
            var cMethod = (ListMethodWsModel)SelectedMethod;        // Contenu de la sélection
            _infoCapturee = DateTime.Now;
           
            var element = new ListeSideTypeA();
            ListeRetourInfoWs = new ObservableCollection<ListeSideTypeA>();
            
            // Définit le mode en rapport du choix de l'utilisateur
            var modeWork = ModeCnxEnvironmentTp.ModeDeveloppement;
            if (ModeProduction == true) modeWork = ModeCnxEnvironmentTp.ModeProduction;
           
            ActionWs = "Méthode envoyée au Web Services du ERP : " + _infoCapturee  + ", un instant svp...";
            
            // Capture du choix de la méthode.
            var selectMethodeUtilisateur = (ListMethodWsModel) SelectedMethod;
            switch (selectMethodeUtilisateur.Code)
            {
                case "1": // PCMN seulement un compte à la fois.
                    #region Envoyer les informations pour les traiter dans le ERP.
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "?",
                        LabelList = "Résultat de la demande : Envoyer les informations du PCMN pour les traiter dans le ERP "
                    });
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList = ""
                    });

                    var choixMethodPcmn = MethodPcmnIn01.ElementPcmn365( new PcmnD365Model
                    {
                        RecId = 78050,
                        Compagny = new string[] {"001", "009", "030", "040"},
                        IdTransaction = 145600045,
                        IsSuspended = false,
                        MainAccountId = "600000",
                        MessageError = "",
                        Name = "Compte achat 600000",
                        QueryStatut = StatusQuery.DeleteElement

                    }, modeWork, UrlBaseWs);

                    var codeEtat = "P";

                    if (choixMethodPcmn.Code != "0") {codeEtat = "O";}
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = codeEtat,
                        LabelList = choixMethodPcmn.Code + " - " + choixMethodPcmn.Message
                    });
                    #endregion
                    break;
                case "2": // PCMN une liste un compte à la fois.
                    #region Envoyer les informations pour les traiter dans le ERP.
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "?",
                        LabelList = "Résultat de la demande : Envoyer une liste d'informations du PCMN pour les traiter dans le ERP "
                    });
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList = ""
                    });

                    var listMethodPcmn = MethodPcmnIn01.ListPcmn365(ObcTablesIn01, modeWork, UrlBaseWs);

                    const string codeEtat1 = "P";

                    if (listMethodPcmn.Code != "0") {codeEtat = "O";}
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = codeEtat1,
                        LabelList = listMethodPcmn.Code + " - " + listMethodPcmn.Message
                    });
                    #endregion
                    break;
                case "3":  // Informations sur le Web Services (Test)
                    #region Info sur Web Service.
                    ListeRetourInfoWs.Clear();

                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "?",
                        LabelList = "Résultat de la demande : Info sur le Web Service :"
                    });
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList = ""
                    });

                    var choixMethod = (WebServiceModelJson) MethodInfoWebServices.Run(UrlBaseWs);
                    
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList = choixMethod.Id.ToString()
                    });
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList = choixMethod.NomWs
                    });
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList = choixMethod.DescriptionWs

                    });
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList = choixMethod.CopyRightWs

                    });
                    #endregion
                    break;
                case "4":  // Recevoir un Segment du Service
                    #region Recevoir un sgement du service.
                    ListeRetourInfoWs.Clear();

                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "?",
                        LabelList = "Résultat de la demande : Recevoir un segment (fournisseur) venant du service :"
                    });
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList = ""
                    });

                    var elementSegmentMethod = (SegmentModelJson) MethodSegmentGetErp.RunElement(UrlBaseWs);
                    
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList =  "Segment Id : " + elementSegmentMethod.SegmentId + "\n"
                    });
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList =  "Description : " + elementSegmentMethod.Description + "\n"
                    });
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList =  "N° Opération du ERP : " + elementSegmentMethod.OprNumberErp + "\n"

                    });
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList =  "Statut pour le mode Query : " + elementSegmentMethod.StatutQuery.ToString() + "\n"

                    });
                    #endregion
                    break;
                case "5":  // Recevoir 10 Segments du Service
                    #region Recevoir 10 sgements du service.
                    ListeRetourInfoWs.Clear();

                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "?",
                        LabelList = "Résultat de la demande : Recevoir 10 segments (fournisseur) venant du service :"
                    });
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList = ""
                    });

                    var list1000SegmentMethod = (ObservableCollection<SegmentModelJson>) 
                        MethodSegmentGetErp.RunList(UrlBaseWs);

                    var cpt10 = 0;
                    foreach (var elementSegment in list1000SegmentMethod)
                    {
                        cpt10++;
                        ListeRetourInfoWs.Add(new ListeSideTypeA
                        {
                            EtatLine = "",
                            LabelList =  "\n --- Enregistrement : " + cpt10.ToString() + "\n"
                        });


                        ListeRetourInfoWs.Add(new ListeSideTypeA
                        {
                            EtatLine = "",
                            LabelList =  "Segment Id : " + elementSegment.SegmentId + "\n"
                        });
                        
                        ListeRetourInfoWs.Add(new ListeSideTypeA
                        {
                            EtatLine = "",
                            LabelList =  "Description : " + elementSegment.Description + "\n"
                        });
                        
                        ListeRetourInfoWs.Add(new ListeSideTypeA
                        {
                            EtatLine = "",
                            LabelList =  "N° Opération du ERP : " + elementSegment.OprNumberErp + "\n"
                        });
                        
                        ListeRetourInfoWs.Add(new ListeSideTypeA
                        {
                            EtatLine = "",
                            LabelList =  "Statut pour le mode Query : " + elementSegment.StatutQuery.ToString() + "\n"
                        });
                    }
                    #endregion
                    break;
                case "6":  // Recevoir 1000 Segments du Service
                    #region Recevoir 1000 sgements du service.

                    var demarrage = DateTime.Now;
                    DateTime fin;
                    TimeSpan temps;
                    

                    ListeRetourInfoWs.Clear();

                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "?",
                        LabelList = "Résultat de la demande : Recevoir 1000 segments venant du service :"
                    });
                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList = ""
                    });

                    var listSegmentMethod = (ObservableCollection<SegmentModelJson>) MethodSegmentGetErp.RunList1000(UrlBaseWs);

                    var cpt1000 = 0;
                    foreach (var elementSegment in listSegmentMethod)
                    {
                        cpt1000++;
                        ListeRetourInfoWs.Add(new ListeSideTypeA
                        {
                            EtatLine = "",
                            LabelList =  "\n --- Enregistrement : " + cpt1000.ToString() + "\n"
                        });


                        ListeRetourInfoWs.Add(new ListeSideTypeA
                        {
                            EtatLine = "",
                            LabelList =  "Segment Id : " + elementSegment.SegmentId + "\n"
                        });
                        
                        ListeRetourInfoWs.Add(new ListeSideTypeA
                        {
                            EtatLine = "",
                            LabelList =  "Description : " + elementSegment.Description + "\n"
                        });
                        
                        ListeRetourInfoWs.Add(new ListeSideTypeA
                        {
                            EtatLine = "",
                            LabelList =  "N° Opération du ERP : " + elementSegment.OprNumberErp + "\n"
                        });
                        
                        ListeRetourInfoWs.Add(new ListeSideTypeA
                        {
                            EtatLine = "",
                            LabelList =  "Statut pour le mode Query : " + elementSegment.StatutQuery.ToString() + "\n"
                        });
                    }
                    fin = DateTime.Now;
                    temps = (DateTime) demarrage - fin;

                    ListeRetourInfoWs.Add(new ListeSideTypeA
                    {
                        EtatLine = "",
                        LabelList =  "--- Temps de travail : " + temps.ToString() + " ------"
                    });

                    #endregion
                    break;
                default:
                    break;
            }
            
            ActionWs = "Méthode du " + _infoCapturee  + " terminée avec succès. Voir info de retour si " +
                       "dessous ou le journal de transaction.";
        }
     
        /// <summary>
        /// Affichage des objects en rapport du mode de travail.
        /// </summary>
        private void ManagerObject ()
        {
            switch (_etatButton)
            {
                case TypeManagerButton.Annuler:
                    IsEditable = "True";

                    IsVisibleLoadModel = Visibility.Visible;
                    IsVisibleImportExcel = Visibility.Visible;
                    IsVisibleDataAuto = Visibility.Visible;

                    IsVisibleGridIn01 = Visibility.Hidden;
                    IsVisibleGridIn02 = Visibility.Hidden;
                    break;
                 case TypeManagerButton.Validation:
                    IsEditable = "True";        
                    
                     IsVisibleLoadModel = Visibility.Visible;
                     IsVisibleImportExcel = Visibility.Visible;
                     IsVisibleDataAuto = Visibility.Visible;
                    break;
                case TypeManagerButton.Aucun:                    
                    IsEditable = "True";
           
                    IsVisibleLoadModel = Visibility.Visible;
                    IsVisibleImportExcel = Visibility.Visible;
                    IsVisibleDataAuto = Visibility.Visible;

                    IsVisibleGridIn01 = Visibility.Visible;
                    IsVisibleGridIn02 = Visibility.Visible;
                    break;
                case TypeManagerButton.Nouveau:
                    IsEditable = "False";
                    
                    IsVisibleLoadModel = Visibility.Visible;
                    IsVisibleImportExcel = Visibility.Hidden;
                    IsVisibleDataAuto = Visibility.Hidden;

                    IsVisibleGridIn01 = Visibility.Visible;
                    IsVisibleGridIn02 = Visibility.Visible;
                    break;
                case TypeManagerButton.Modifier:
                    IsEditable = "False";
                    
                    IsVisibleLoadModel = Visibility.Visible;
                    IsVisibleImportExcel = Visibility.Hidden;
                    IsVisibleDataAuto = Visibility.Hidden;
                    break;
                case TypeManagerButton.Supprimer:
                    IsEditable = "True";
                    
                    IsVisibleLoadModel = Visibility.Visible;
                    IsVisibleImportExcel = Visibility.Hidden;
                    IsVisibleDataAuto = Visibility.Hidden;
                    break;

                case TypeManagerButton.Executer:
                    break;
                case TypeManagerButton.Query:
                    break;
                case TypeManagerButton.Go:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        #endregion
    }
}
