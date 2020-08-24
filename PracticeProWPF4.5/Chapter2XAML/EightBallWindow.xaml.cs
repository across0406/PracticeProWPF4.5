using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Chapter2XAML
{
    /// <summary>
    /// EightBallWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EightBallWindow : Window
    {
        public EightBallWindow()
        {
            InitializeComponent();

            // XAML located at Grid.Background will be parsed as these codes.
            // 1. No Collection
            // LinearGradientBrush brush = new LinearGradientBrush();
            // brush.StartPoint = new Point( 0.0, 0.0 );
            // brush.EndPoint = new Point( 1.0, 1.0 );
            // 
            // GradientStop stop = new GradientStop();
            // stop.Offset = 0;
            // stop.Color = Colors.Gray;
            // brush.GradientStops.Add( stop );
            // stop = new GradientStop();
            // stop.Offset = 0.5;
            // stop.Color = Colors.Black;
            // brush.GradientStops.Add( stop );
            // stop = new GradientStop();
            // stop.Offset = 1.0;
            // stop.Color = Colors.Gray;
            // brush.GradientStops.Add( stop );
            // 
            // EightBallGrid.Background = brush;
            // 
            // 2. Collection
            // LinearGradientBrush brush = new LinearGradientBrush();
            // brush.StartPoint = new Point( 0.0, 0.0 );
            // brush.EndPoint = new Point( 1.0, 1.0 );
            // IList<GradientStop> list = brush.GradientStops;
            // 
            // GradientStop stop = new GradientStop();
            // stop.Offset = 0;
            // stop.Color = Colors.Gray;
            // list.Add( stop );
            // stop = new GradientStop();
            // stop.Offset = 0.5;
            // stop.Color = Colors.Black;
            // list.Add( stop );
            // stop = new GradientStop();
            // stop.Offset = 1.0;
            // stop.Color = Colors.Gray;
            // list.Add( stop );
            // 
            // EightBallGrid.Background = brush;

            // XAML located at Foreground of btnAsk will be translated as this code.
            // btnAsk.Foreground = SystemColors.ActiveCaptionBrush;

            // The XAML codes "Grid.Row=" will be parsed as these codes.
            // txtQuestion = new TextBox();
            // EightBallGrid.Children.Add( txtQuestion );
            // btnAsk = new Button();
            // EightBallGrid.Children.Add( btnAsk );
            // txtAnswer = new TextBox();
            // EightBallGrid.Children.Add( txtAnswer );
        }

        // This is the event triggered by clicking btnAsk.
        private void AskClick( object sender, RoutedEventArgs e )
        {
            this.Cursor = Cursors.Wait;

            // Dramatic delay
            System.Threading.Thread.Sleep( TimeSpan.FromSeconds( 3 ) );

            AnswerGenerator generator = new AnswerGenerator();
            txtAnswer.Text = generator.GetRandomAnswer( txtQuestion.Text );

            this.Cursor = null;
        }
    }
}
