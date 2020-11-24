using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Extra3VariousViewModelDataTemplate
{
    public interface IViewModel
    {

    }

    public class BaseViewModel : INotifyPropertyChanged, IViewModel
    {
        #region INotifyPropertyChanged Implementation

        protected virtual void SetProperty<T>( ref T member, T val, [CallerMemberName] string propertyName = null )
        {
            if ( object.Equals( member, val ) )
            {
                return;
            }

            member = val;
            PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
        }

        protected virtual void OnPropertyChanged( string propertyName )
        {
            PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion INotifyPropertyChanged Implementation

        #region Constructors

        public BaseViewModel()
        {

        }

        #endregion Constructors
    }
}
