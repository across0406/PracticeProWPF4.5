using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Chapter2XAML
{
    public partial class UnCompliedEightBallWindow : Window, IComponentConnector
    {
        #region Internal Enumeration

        public enum UncompiledEightBallWindowContentId
        {
            TXT_QUESTION = 0,
            BTN_ASK = 1,
            TXT_ANSWER = 2
        }

        #endregion Internal Enumeration

        #region Private Member Variables

        private string _xamlFile;
        private bool _isContentLoaded;

        private TextBox txtUncompiledQuestion;
        private Button btnUncompiledAsk;
        private TextBox txtUncompiledAnswer;

        #endregion Private Member Variables

        #region Constructor

        public UnCompliedEightBallWindow()
        {
            _isContentLoaded = false;
            _xamlFile = "../../../../Chapter2XAML/UnCompiledEightBallWindow.xaml";
            InitializeComponent();
        }

        public UnCompliedEightBallWindow( string xamlFile )
        {
            this.Title = "UnCompiledEightBallWindow Dynamically loaded XAML";
            this.Height = 328;
            this.Width = 412;

            // Get the XAML content fromm an external file.
            DependencyObject rootElement;

            using ( FileStream fs = new FileStream( xamlFile, FileMode.Open ) )
            {
                rootElement = (DependencyObject)XamlReader.Load( fs );
            }

            // Insert the markup into this window.
            this.Content = rootElement;

            // Find the control with the appropriate name.
            btnUncompiledAsk = (Button)LogicalTreeHelper.FindLogicalNode( rootElement, "btnUncompiledAsk" );
            txtUncompiledQuestion = (TextBox)LogicalTreeHelper.FindLogicalNode( rootElement, "txtUncompiledQuestion" );
            txtUncompiledAnswer = (TextBox)LogicalTreeHelper.FindLogicalNode( rootElement, "txtUncompiledAnswer" );
            btnUncompiledAsk.Click += AskClick;
        }

        #endregion Constructor

        #region Public Methods

        public void Connect( int connectionId, object target )
        {
            switch ( connectionId )
            {
                case (int)UncompiledEightBallWindowContentId.TXT_QUESTION:
                    txtUncompiledQuestion = (System.Windows.Controls.TextBox)target;
                    this._isContentLoaded = true;
                    break;

                case (int)UncompiledEightBallWindowContentId.BTN_ASK:
                    btnUncompiledAsk = (System.Windows.Controls.Button)target;
                    btnUncompiledAsk.Click += new System.Windows.RoutedEventHandler(AskClick);
                    this._isContentLoaded = true;
                    break;

                case (int)UncompiledEightBallWindowContentId.TXT_ANSWER:
                    txtUncompiledAnswer = (System.Windows.Controls.TextBox)target;
                    this._isContentLoaded = true;
                    break;

                default:
                    this._isContentLoaded = false;
                    break;
            }
        }

        public void InitializeComponent()
        {
            if ( _isContentLoaded )
            {
                return;
            }

            _isContentLoaded = true;

            this.Title = "UnCompiledEightBallWindow Dynamically loaded XAML";
            this.Height = 328;
            this.Width = 412;

            // Get the XAML content fromm an external file.
            DependencyObject rootElement;

            using ( FileStream fs = new FileStream( _xamlFile, FileMode.Open ) )
            {
                rootElement = (DependencyObject)XamlReader.Load( fs );
            }

            // Insert the markup into this window.
            this.Content = rootElement;

            btnUncompiledAsk = (Button)LogicalTreeHelper.FindLogicalNode( rootElement, "btnUncompiledAsk" );
            txtUncompiledQuestion = (TextBox)LogicalTreeHelper.FindLogicalNode( rootElement, "txtUncompiledQuestion" );
            txtUncompiledAnswer = (TextBox)LogicalTreeHelper.FindLogicalNode( rootElement, "txtUncompiledAnswer" );
            btnUncompiledAsk.Click += AskClick;
        }

        private void AskClick( object sender, RoutedEventArgs e )
        {
            this.Cursor = Cursors.Wait;

            // Dramatic delay
            System.Threading.Thread.Sleep( TimeSpan.FromSeconds( 3 ) );

            AnswerGenerator generator = new AnswerGenerator();
            txtUncompiledAnswer.Text = generator.GetRandomAnswer( txtUncompiledQuestion.Text );

            this.Cursor = null;
        }

        #endregion Public Methods
    }
}
