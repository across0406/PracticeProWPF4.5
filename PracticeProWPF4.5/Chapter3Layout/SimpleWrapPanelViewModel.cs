using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chapter3Layout
{
    public class SimpleWrapPanelViewModel : INotifyPropertyChanged
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

        private bool _wrapPanelOrientationFlag;
        private Orientation _wrapPanelOrientation;

        #endregion Private Member Variables

        #region Constructors

        public SimpleWrapPanelViewModel()
        {
            WrapPanelOrientationFlag = false;
        }

        #endregion Constructors

        #region Public Properties

        public bool WrapPanelOrientationFlag
        {
            get => _wrapPanelOrientationFlag;
            set
            {
                _wrapPanelOrientationFlag = value;

                if ( _wrapPanelOrientationFlag )
                {
                    WrapPanelOrientation = Orientation.Vertical;
                }
                else
                {
                    WrapPanelOrientation = Orientation.Horizontal;
                }

                OnPropertyChanged( "WrapPanelOrientationFlag" );
            }
        }

        public Orientation WrapPanelOrientation
        {
            get => _wrapPanelOrientation;
            set
            {
                _wrapPanelOrientation = value;
                OnPropertyChanged( "WrapPanelOrientation" );
            }
        }

        #endregion Public Properties
    }
}
