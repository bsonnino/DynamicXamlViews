using System;
using System.Windows.Input;

namespace CustomerApp
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public RelayCommand(Action<object> executeAction) : this(executeAction, null) { }

        public RelayCommand(Action<object> executeAction, Predicate<object> canExecutePredicate)
        {
            if (executeAction == null)
                throw new ArgumentException("ExecuteAction");
            execute = executeAction;
            canExecute = canExecutePredicate;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
                return canExecute(parameter);
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public void Execute(object parameter)
        {
            execute(parameter);
        }

        #endregion
    }

}
