using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra1DelegateAndEvent
{
    public class Stock
    {
        #region Private Member Variables

        private string _symbol;
        private decimal _price;

        #endregion Private Member Variables

        #region Protected Methods

        protected virtual void OnPriceChanged( PriceChangedEventArgs e )
        {
            PriceChanged?.Invoke( this, e );
        }

        protected virtual void OnPriceChangedNonGeneric( EventArgs e )
        {
            PriceChangedNonGeneric?.Invoke( this, e );
        }

        #endregion Protected Methods

        #region Constructors

        public Stock( string symbol )
        {
            Symbol = symbol;
        }

        #endregion Constructors

        #region Public Properties

        public string Symbol
        {
            get => _symbol;
            set => _symbol = value;
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if ( _price == value )
                {
                    return;
                }

                decimal old = _price;
                _price = value;
                OnPriceChanged( new PriceChangedEventArgs( old, _price ) );
            }
        }

        public decimal PriceNonGeneric
        {
            get => _price;
            set
            {
                if ( _price == value )
                {
                    return;
                }

                _price = value;
                OnPriceChangedNonGeneric( EventArgs.Empty );
            }
        }

        #endregion Public Properties

        #region Public Methods

        public event EventHandler<PriceChangedEventArgs> PriceChanged;
        public event EventHandler PriceChangedNonGeneric;

        #endregion Public Methods
    }
}
