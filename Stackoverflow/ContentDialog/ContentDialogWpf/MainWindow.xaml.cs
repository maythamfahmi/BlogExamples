using System.Windows;
using System.Windows.Media;

namespace ContentDialogWpf
{
    public partial class MainWindow : Window
    {
        private readonly string _title;
        private readonly string _message;

        public MainWindow()
        {
            _title = "Updates are available";
            _message = "Required updates need to be downloaded.";
            InitializeComponent();

            string[]? args = App.Args;
            if (args != null && args.Length > 0)
            {
                _title = args[0];
                _message = args[1];
            }

            MinimizedMainWindow();
            ShowContentDialog();
        }

        protected void MinimizedMainWindow()
        {
            AllowsTransparency = true;
            WindowStyle = WindowStyle.None;
            WindowState = WindowState.Maximized;
            Background = Brushes.Transparent;
            Topmost = true;
        }

        public void ShowContentDialog()
        {
            ContentDialog dialog = new ContentDialog
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0066CC")),
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF")),
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStyle = WindowStyle.None,
                Padding = new Thickness(20),
                Margin = new Thickness(0),
                ResizeMode = ResizeMode.NoResize,
                Width = 600,
                Height = 400,
                Title = { Text = _title },
                Message = { Text = _message }
            };

            dialog.Show();
        }
    }
}
