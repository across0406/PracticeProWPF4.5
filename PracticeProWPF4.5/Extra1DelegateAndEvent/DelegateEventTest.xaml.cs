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
    public partial class DelegateEventTest : Window, INotifyPropertyChanged
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
        private IntegerCollection _anotherTransformedXs;
        private Stock _stock;
        private decimal _newPrice;

        #endregion Private Member Variables

        #region Private Methods

        private int Square( int x ) => x * x;
        // private int Square( SoleParameterInteger x ) => x.X * x.X;
        private int Cubic( int x ) => x * x * x;
        private int SquareFunc( int x ) => x * x + 1;
        private int CubicFunc( int x ) => x * x * x + 1;

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

            if ( AnotherTransformedXs == null )
            {
                AnotherTransformedXs = new IntegerCollection();
            }
            else
            {
                AnotherTransformedXs.Clear();
            }

            int[][] temp = new int[ t.GetInvocationList().Length ][];

            for ( int i = 0; i < t.GetInvocationList().Length; ++i )
            {
                temp[ i ] = new int[ values.Length ];

                Parallel.For( 0, values.Length, j =>
                {
                    var tempDelegate = t.GetInvocationList()[ i ];
                    temp[ i ][ j ] = (int)tempDelegate.DynamicInvoke( j );
                } );
            }

            for ( int i = 0; i < t.GetInvocationList().Length; ++i )
            {
                if ( i == 0 )
                {
                    for ( int j = 0; j < values.Length; ++j )
                    {
                        TransformedXs.Add( new SoleParameterInteger { X = temp[ i ][ j ] } );
                    }
                }
                else if ( i == 1 )
                {
                    for ( int j = 0; j < values.Length; ++j )
                    {
                        AnotherTransformedXs.Add( new SoleParameterInteger { X = temp[ i ][ j ] } );
                    }
                }
            }
        }

        private void Transform<T>( T[] values, Func<T, T> transformer ) where T : struct
        {
            if ( TransformedXs == null )
            {
                TransformedXs = new IntegerCollection();
            }
            else
            {
                TransformedXs.Clear();
            }

            if ( AnotherTransformedXs == null )
            {
                AnotherTransformedXs = new IntegerCollection();
            }
            else
            {
                AnotherTransformedXs.Clear();
            }

            int[][] temp = new int[ transformer.GetInvocationList().Length ][];

            for ( int i = 0; i < transformer.GetInvocationList().Length; ++i )
            {
                temp[ i ] = new int[ values.Length ];

                Parallel.For( 0, values.Length, j =>
                {
                    var tempDelegate = transformer.GetInvocationList()[ i ];
                    temp[ i ][ j ] = (int)tempDelegate.DynamicInvoke( j );
                } );
            }

            for ( int i = 0; i < transformer.GetInvocationList().Length; ++i )
            {
                if ( i == 0 )
                {
                    for ( int j = 0; j < values.Length; ++j )
                    {
                        TransformedXs.Add( new SoleParameterInteger { X = temp[ i ][ j ] } );
                    }
                }
                else if ( i == 1 )
                {
                    for ( int j = 0; j < values.Length; ++j )
                    {
                        AnotherTransformedXs.Add( new SoleParameterInteger { X = temp[ i ][ j ] } );
                    }
                }
            }
        }

        private void OnParamXsListViewDoubleClick( object sender, MouseButtonEventArgs e )
        {

        }

        private void OnTransformersClick( object sender, RoutedEventArgs e )
        {
            Transform( ParamXs.ToArray(), new Delegates.Transformer<int>( Square ) );
        }

        private void OnDoubleTransformersClick( object sender, RoutedEventArgs e )
        {
            Delegates.Transformer<int> t = new Delegates.Transformer<int>( Square );
            t += new Delegates.Transformer<int>( Cubic );

            Transform( ParamXs.ToArray(), t );
        }

        private void OnTransformersAsFuncClick( object sender, RoutedEventArgs e )
        {
            Delegates.Transformer<int> t = new Delegates.Transformer<int>( SquareFunc );
            t += new Delegates.Transformer<int>( CubicFunc );

            Transform( ParamXs.ToArray(), t );
        }

        private void OnAddXClick( object sender, RoutedEventArgs e )
        {
            if ( ParamXs == null )
            {
                ParamXs = new IntegerCollection();
            }

            ParamXs.Add( new SoleParameterInteger() );
        }

        private void StockPriceChanged( object sender, PriceChangedEventArgs e )
        {
            if ( e.LastPrice == 0 )
            {
                if ( e.NewPrice > 0 )
                {
                    MessageBox.Show( "Just increase!" );
                }
                else if ( e.NewPrice < 0 )
                {
                    MessageBox.Show( "Just decrease!" );
                }
                // Need decimal zero equal judegement.
                else
                {
                    MessageBox.Show( "Just Zero!" );
                }
            }
            else if ( ( ( e.NewPrice - e.LastPrice ) / e.LastPrice ) > 0.1M )
            {
                MessageBox.Show( "Alert, 10% stock price increase!" );
            }
        }

        private void StockPriceChangedNonGeneric( object sender, EventArgs e )
        {
            MessageBox.Show( "NewPrice is assigned!" );
        }

        private void OnPriceAssignmentClick( object sender, RoutedEventArgs e )
        {
            if ( _stock == null )
            {
                throw new Exception( "Stock object is null!" );
            }

            OldPrice = NewPrice;            
        }

        private void OnPriceAssignmentNonGenericClick( object sender, RoutedEventArgs e )
        {
            if ( _stock == null )
            {
                throw new Exception( "Stock object is null!" );
            }

            _stock.PriceNonGeneric = NewPrice;
            OnPropertyChanged( "OldPrice" );
        }

        #endregion Private Methods

        #region Constructors

        public DelegateEventTest()
        {
            InitializeComponent();

            ParamX = 0;
            TransformedX = 0;

            ParamXs = new IntegerCollection();
            TransformedXs = new IntegerCollection();
            AnotherTransformedXs = new IntegerCollection();

            for ( int i = 0; i < 10; ++i )
            {
                ParamXs.Add( new SoleParameterInteger( i ) );
            }

            _stock = new Stock( "THPW" );
            _stock.Price = 27.10M;
            _stock.PriceChanged += StockPriceChanged;
            _stock.PriceChangedNonGeneric += StockPriceChangedNonGeneric;

            this.DataContext = this;
        }

        #endregion Constructors

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
                OnPropertyChanged( "TransformedX" );
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

        public IntegerCollection AnotherTransformedXs
        {
            get => _anotherTransformedXs;
            set
            {
                _anotherTransformedXs = value;
                OnPropertyChanged( "AnotherTransformedXs" );
            }
        }

        public decimal OldPrice
        {
            get
            {
                if ( _stock == null )
                {
                    throw new Exception( "Stock object is null!" );
                }

                return _stock.Price;
            }

            set
            {
                if ( _stock == null )
                {
                    throw new Exception( "Stock object is null!" );
                }

                _stock.Price = value;
                OnPropertyChanged( "OldPrice" );
            }
        }

        public decimal NewPrice
        {
            get => _newPrice;
            set
            {
                _newPrice = value;
                OnPropertyChanged( "NewPrice" );
            }
        }


        #endregion Public Properties

        #region Public Methods



        #endregion Public Methods
    }
}
