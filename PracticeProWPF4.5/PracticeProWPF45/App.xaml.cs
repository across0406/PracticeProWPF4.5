using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PracticeProWPF45
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStartup( object sender, StartupEventArgs e )
        {
            Window window = null;

            // Test codes for Chapter 2
            // window = new Chapter2XAML.InitialWindow();
            // window.Show();
            // window = new Chapter2XAML.EightBallWindow();
            // window.Show();
            // window = new Chapter2XAML.UnCompliedEightBallWindow( "../../../../Chapter2XAML/UnCompiledEightBallWindow.xaml" );
            // window.Show();
            // window = new Chapter2XAML.UnCompliedEightBallWindow();
            // window.Show();

            // Test codes for Chapter 3
            // window = new Chapter3Layout.SimpleStackPanel();
            // window = new Chapter3Layout.SimpleBorder();
            window = new Chapter3Layout.SimpleWrapPanel();
            window.Show();

            // Test codes for Extra 1
            // window = new Extra1DelegateAndEvent.DelegateEventTest();
            // window.Show();
        }
    }
}
