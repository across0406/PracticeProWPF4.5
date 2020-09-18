using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Extra2Threading
{
    public class ThreadTest : INotifyPropertyChanged
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

        #region Private Member Methods

        private Thread _writeXThread;
        private Thread _writeYThread;

        private string _dataX;
        private string _dataY;

        #endregion Private Member Methods

        #region Private Methods

        private void WriteX()
        {
            for ( int i = 0; i < 30; ++i )
            {
                DataX += i.ToString() + "\n";
            }
        }

        private void WriteY()
        {
            for ( int i = 0; i < 30; ++i )
            {
                DataY += ( i * i ).ToString() + "\n";
            }
        }

        #endregion Private Methods

        #region Constructors

        public ThreadTest()
        {
            DataX = string.Empty;
            DataY = string.Empty;
        }

        #endregion Constructors

        #region Public Properties

        public string DataX
        {
            get => _dataX;
            set
            {
                _dataX = value;
                OnPropertyChanged( "DataX" );
            }
        }
        public string DataY
        {
            get => _dataY;
            set
            {
                _dataY = value;
                OnPropertyChanged( "DataY" );
            }
        }

        #endregion Public Properties

        #region Public Methods



        #endregion Public Methods
    }
}
