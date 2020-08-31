using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Extra1DelegateAndEvent
{
    /// <summary>
    /// TransformerDelegateTest.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TransformerDelegateTest : Window, INotifyPropertyChanged
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

        private int _paramX;
        private int _transformedX;
        private IntegerCollection _paramXs;
        private IntegerCollection _transformedXs;

        #endregion Private Member Variables

        #region Private Methods

        private int Square( int x ) => x * x;
        private int Square( SoleParameterInteger x ) => x.X * x.X;

        private void OnTransformerClick( object sender, RoutedEventArgs e )
        {
            // => Delegates.Transformer t = Square;
            Delegates.Transformer<int> t = new Delegates.Transformer<int>( Square );

            // = > int result = t( ParamX );
            int result = t.Invoke( ParamX );

            TransformedX = result;
        }

        private void Transform<T>( T[] values, Delegates.Transformer<T> t ) where T : struct
        {
            if ( TransformedXs == null )
            {
                TransformedXs = new IntegerCollection();
            }
            else
            {
                TransformedXs.Clear();
            }

            int[] temp = new int[ values.Length ];

            Parallel.For( 0, values.Length, i =>
            {
                temp[ i ] = t( values[ i ] );
            } );

            for ( int i = 0; i < values.Length; ++i )
            {
                TransformedXs.Add( new SoleParameterInteger { X = temp[ i ] } );
            }
        }

        private void OnParamXsListViewDoubleClick( object sender, MouseButtonEventArgs e )
        {
            
        }

        private void OnTransformersClick( object sender, RoutedEventArgs e )
        {
            Transform( ParamXs.ToArray(), new Delegates.Transformer<int>(Square) );
        }

        private void OnAddXClick( object sender, RoutedEventArgs e )
        {
            if ( ParamXs == null )
            {
                ParamXs = new IntegerCollection();
            }

            ParamXs.Add( new SoleParameterInteger { X = 0 } );
        }

        #endregion Private Methods

        #region Constructor

        public TransformerDelegateTest()
        {
            InitializeComponent();

            ParamX = 0;
            TransformedX = 0;

            ParamXs = new IntegerCollection();
            TransformedXs = new IntegerCollection();

            Parallel.For( 0, 10, i =>
            {
                ParamXs.Add( new SoleParameterInteger { X = i } );
            } );

            this.DataContext = this;
        }

        #endregion Constructor

        #region Public Properties

        public int ParamX
        {
            get => _paramX;
            set
            {
                _paramX = value;
                OnPropertyChanged( "ParamX" );
            }
        }

        public int TransformedX
        {
            get => _transformedX;
            set
            {
                _transformedX = value;
                OnPropertyChanged( "TransformerX" );
            }
        }

        public IntegerCollection ParamXs
        {
            get => _paramXs;
            set
            {
                _paramXs = value;
                OnPropertyChanged( "ParamXs" );
            }
        }
        public IntegerCollection TransformedXs
        {
            get => _transformedXs;
            set
            {
                _transformedXs = value;
                OnPropertyChanged( "TransformedXs" );
            }
        }

        #endregion Public Properties

        #region Public Methods



        #endregion Public Methods
    }
}
