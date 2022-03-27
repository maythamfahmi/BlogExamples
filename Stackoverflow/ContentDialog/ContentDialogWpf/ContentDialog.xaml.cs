using System.Windows;

namespace ContentDialogWpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ContentDialog : Window
    {
        public ContentDialog()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}
