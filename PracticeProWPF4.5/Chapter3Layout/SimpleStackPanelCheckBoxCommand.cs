using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chapter3Layout
{
    public class SimpleStackPanelCheckBoxCommand : ICommand
    {
        private Action<object> _executeMethod;
        private Predicate<object> _canExecuteMethod;

        public SimpleStackPanelCheckBoxCommand( Action<object> executeMethod, Predicate<object> canExecuteMethod )
        {
            if ( executeMethod == null )
            {
                throw new NullReferenceException( "The executeMethod cannot be null." );
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;        
        }

        public bool CanExecute( object parameter )
        {
            return _canExecuteMethod == null ? true : _canExecuteMethod( parameter );
        }

        public void Execute( object parameter )
        {
            _executeMethod.Invoke( parameter );
        }
    }
}
