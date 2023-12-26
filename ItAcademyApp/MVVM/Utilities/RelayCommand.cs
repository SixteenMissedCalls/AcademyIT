using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ItAcademyApp.MVVM.Utilities
{
    public class RelayCommand : ICommand
    {
        private Action<object> _executeCommand;
        private Predicate<object> _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> executeCommand, Predicate<object> canExecute = null)
        {
            _executeCommand = executeCommand; 
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _executeCommand(parameter);
        }
    }
}
