using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2XAML
{
    public class AnswerGenerator
    {
        #region Public Methods

        public string GetRandomAnswer( string question )
        {
            return "<This is RandomAnswerTemplate from " + question + ">";
        }

        #endregion
    }
}
