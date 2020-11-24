using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Extra3VariousViewModelDataTemplate
{
    public class MainViewModel : BaseViewModel
    {
        #region Private Member Variables

        private object _contentView;

        #endregion Private Member Variables

        #region Constructors

        public MainViewModel()
        {
            this.ContentView = new SecondViewModel();
        }

        #endregion Constructors

        #region Public Properties

        public object ContentView
        {
            get => _contentView;
            set
            {
                _contentView = value;
                OnPropertyChanged( "ContentView" );
            }
        }

        #endregion Public Properties
    }
}
