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

using System;
using System.Windows.Input;

namespace SideClientWebServiceComptaPlus.Core.MVVM
{
    public class BaseCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _method;
        public event EventHandler CanExecuteChanged;

        public BaseCommand(Action<object> method) : this(method, null)
        {
        }

        public BaseCommand(Action<object> method, Predicate<object> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _method.Invoke(parameter);
        }
    }
}
