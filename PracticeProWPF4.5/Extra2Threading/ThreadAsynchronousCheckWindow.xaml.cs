using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Extra2Threading
{
    /// <summary>
    /// ThreadAsynchronousCheckWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ThreadAsynchronousCheckWindow : Window
    {
        #region Private Methods

        private void GenerateClick( object sender, RoutedEventArgs e )
        {
            DoOperation.Invoke();
        }

        private void FlagButtonClick( object sender, RoutedEventArgs e )
        {
            FlagChange.Invoke();
        }

        private delegate void ThreadsOperation();
        private ThreadsOperation DoOperation;
        private delegate void FlagChangeOperation();
        private FlagChangeOperation FlagChange;

        #endregion Private Methods

        public ThreadAsynchronousCheckWindow()
        {
            InitializeComponent();

            this.DataContext = new ThreadTest();
            DoOperation = ( this.DataContext as ThreadTest ).OnDoThreads;
            FlagChange = ( this.DataContext as ThreadTest ).OnFlagChange;
        }

        
    }
}
