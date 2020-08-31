using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Extra1DelegateAndEvent
{
    public class IntegerCollection : ObservableCollection<SoleParameterInteger>
    {
        #region Public Methods

        public int[] ToArray()
        {
            int[] array = new int[ Count ];

            Parallel.For( 0, Count, i =>
            {
                array[ i ] = this[ i ].X;
            } );

            return array;
        }

        #endregion Public Methods
    }

    public class SoleParameterInteger : INotifyPropertyChanged
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

        private int _x;

        #endregion Private Member Variables

        #region Public Properties

        public int X
        {            
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged( "X" );
            }
        }

        #endregion Public Properties
    }
}
