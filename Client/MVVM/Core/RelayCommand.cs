using System;
using System.Windows.Input;

// Notes:
// The question mark after the type means it can be set to null
// For a example, int? num = null is valid since ? is after the type.
// This is typically done for when reading in from DBs that have data
// that is undefined

namespace Client.MVVM.Core
{
    internal class RelayCommand : ICommand
    {
        private Action<object?> _execute;
        private Func<object?, bool>? _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
