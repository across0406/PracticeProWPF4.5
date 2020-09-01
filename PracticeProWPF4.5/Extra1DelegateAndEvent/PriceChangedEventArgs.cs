using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra1DelegateAndEvent
{
    public class PriceChangedEventArgs : EventArgs
    {
        #region Constructors

        public PriceChangedEventArgs( decimal lastPrice, decimal newPrice )
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }

        #endregion Constructors

        #region Public Member Variables

        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        #endregion Public Member Variables
    }
}
