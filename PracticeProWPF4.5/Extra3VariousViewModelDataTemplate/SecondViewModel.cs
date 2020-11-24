using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Extra3VariousViewModelDataTemplate
{
    public class SecondViewModel : BaseViewModel
    {
        #region Private Member Variables

        private string _name;

        #endregion Private Member Variables

        #region Constructors

        public SecondViewModel()
        {
            Name = "Second";
        }

        #endregion Constructors

        #region Public Properties

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged( "Name" );
            }
        }

        #endregion Public Properties
    }
}
