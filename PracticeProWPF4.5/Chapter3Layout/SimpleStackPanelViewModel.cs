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
        private double _controlMargin;
        private double _controlMinWidth;
        private double _controlMaxWidth;
        private double _windowMinWidth;
        private double _windowMinHeight;

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
            ControlMargin = 5;
            ControlMinWidth = 100;
            ControlMaxWidth = 200;
            WindowMinWidth = 354;
            WindowMinHeight = 223;
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

        public double ControlMargin
        {
            get => _controlMargin;
            set
            {
                _controlMargin = value;
                OnPropertyChanged( "ControlMargin" );
            }
        }

        public double ControlMinWidth
        {
            get => _controlMinWidth;
            set
            {
                _controlMinWidth = value;
                OnPropertyChanged( "ControlMinWidth" );
            }
        }

        public double ControlMaxWidth
        {
            get => _controlMaxWidth;
            set
            {
                _controlMaxWidth = value;
                OnPropertyChanged( "ControlMaxWidth" );
            }
        }

        public double WindowMinWidth
        {
            get => _windowMinWidth;
            set
            {
                _windowMinWidth = value;
                OnPropertyChanged( "WindowMinWidth" );
            }
        }
        public double WindowMinHeight
        {
            get => _windowMinHeight;
            set
            {
                _windowMinHeight = value;
                OnPropertyChanged( "WindowMinHeight" );
            }
        }

        #endregion Public Properties

        #region Public Event Handler

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #endregion Public Event Handler
    }
}
