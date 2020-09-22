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

        private bool _writeXFlag;
        private bool _writeYFlag;
        private string _flagButtonContent;

        private ManualResetEvent _writeXSignal;
        private ManualResetEvent _writeYSignal;

        #endregion Private Member Methods

        #region Private Methods

        private void WriteX()
        {
            int i = 0;

            while ( _writeXFlag && i < 20 )
            {
                if ( i % 2 == 0 )
                {
                    DataX += "X Wait\n";
                    _writeXSignal.WaitOne();
                    DataX += "Y Set\n";
                    _writeYSignal.Set();
                }

                DataX += i.ToString() + "\n";
                ++i;
            }
        }

        private void WriteY()
        {
            int i = 0;

            _writeYSignal.WaitOne();
            DataY += "Y Wait\n";

            while ( _writeYFlag && i < 20 )
            {
                if ( i % 2 == 0 )
                {
                    DataY += "Y Wait\n";
                    _writeYSignal.WaitOne();
                    DataY += "X Set\n";
                    _writeXSignal.Set();
                }

                DataY += ( i * i ).ToString() + "\n";
                ++i;
            }
        }

        #endregion Private Methods

        #region Constructors

        public ThreadTest()
        {
            DataX = string.Empty;
            DataY = string.Empty;

            _writeXThread = new Thread( new ThreadStart( WriteX ) );
            _writeXThread.IsBackground = true;
            _writeXSignal = new ManualResetEvent( false );
            _writeYThread = new Thread( new ThreadStart( WriteY ) );
            _writeYThread.IsBackground = true;
            _writeYSignal = new ManualResetEvent( false );

            _writeXFlag = false;
            _writeYFlag = false;
            FlagButtonContent = "Flag False";


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

        public string FlagButtonContent
        {
            get => _flagButtonContent;
            set
            {
                _flagButtonContent = value;
                OnPropertyChanged( "FlagButtonContent" );
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void OnDoThreads()
        {
            _writeXSignal.Set();

            if ( !_writeXThread.IsAlive )
            {
                _writeXThread = new Thread( new ThreadStart( WriteX ) );
                _writeXThread.IsBackground = true;
            }

            if ( !_writeYThread.IsAlive )
            {
                _writeYThread = new Thread( new ThreadStart( WriteY ) );
                _writeYThread.IsBackground = true;
            }

            _writeXThread.Start();
            _writeYThread.Start();
        }

        public void OnFlagChange()
        {
            _writeXFlag = !_writeXFlag;
            _writeYFlag = !_writeYFlag;

            if ( _writeXFlag )
            {
                FlagButtonContent = "Flag True";
            }
            else
            {
                FlagButtonContent = "Flag False";
            }
        }

        #endregion Public Methods
    }
}
