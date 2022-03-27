using System.Windows;

namespace ContentDialogWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string[]? Args;
        void AppStartup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length > 0)
            {
                Args = e.Args;
            }
        }
    }
}
