using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6Controls
{
    public class SimpleExpanderViewModel : INotifyPropertyChanged
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

        #region Private Member Variables

        private bool _isParametersPoppedUp;

        #endregion Private Member Variables

        #region Constructors

        public SimpleExpanderViewModel()
        {
            IsParametersPoppedUp = false;
        }

        #endregion Constructors

        #region Public Properties

        public bool IsParametersPoppedUp
        {
            get => _isParametersPoppedUp;
            set
            {
                _isParametersPoppedUp = value;
                OnPropertyChanged( "IsParametersPoppedUp" );
            }
        }

        #endregion Public Properties
    }
}
