using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chapter3Layout
{
    public class SimpleStackPanelViewModel : INotifyPropertyChanged
    {
        #region Private Member Variables

        private bool _isChecked;
        private Orientation _stackPanelOrientation;

        #endregion Private Member Variables

        #region Private Methods

        private void CheckProcess( object sender )
        {

        }

        #endregion Private Methods

        #region Protected Methods

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

        #endregion Protected Methods

        #region Constructors

        public SimpleStackPanelViewModel()
        {
            IsChecked = false;
        }

        #endregion Constructors

        #region Public Properties

        public SimpleStackPanelCheckBoxCommand CheckBoxCommand
        {
            get;
            set;
        }
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;

                if ( _isChecked )
                {
                    StackPanelOrientation = Orientation.Horizontal;
                }
                else
                {
                    StackPanelOrientation = Orientation.Vertical;
                }

                OnPropertyChanged( "IsChecked" );
            }
        }

        public Orientation StackPanelOrientation
        {
            get => _stackPanelOrientation;
            set
            {
                _stackPanelOrientation = value;
                OnPropertyChanged( "StackPanelOrientation" );
            }
        }

        #endregion Public Properties

        #region Public Event Handler

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion Public Event Handler
    }
}
