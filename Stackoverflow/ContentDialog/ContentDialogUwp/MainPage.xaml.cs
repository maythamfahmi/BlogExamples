using System;
using System.Collections.Generic;
using Windows.System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ContentDialogUwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.GetForCurrentView().SuppressSystemOverlays = true;
            ApplicationView.GetForCurrentView().FullScreenSystemOverlayMode = FullScreenSystemOverlayMode.Minimal;
            ApplicationView.GetForCurrentView().TryEnterFullScreenMode();

            ShowMessage();
        }

        private async void ShowMessage()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Updates are available",
                Content = "Required updates need to be downloaded.",
                Width = 200,
                Height = 600,
                Background = new SolidColorBrush(Colors.CornflowerBlue),
                Foreground = new SolidColorBrush(Colors.White),
                BorderThickness = new Thickness(1),
                BorderBrush = new SolidColorBrush(Colors.White),
                CloseButtonText = "Close",
            };

            await dialog.ShowAsync();
        }

        public async void MinimizeApp()
        {
            IList<AppDiagnosticInfo> infos = await AppDiagnosticInfo.RequestInfoForAppAsync();
            IList<AppResourceGroupInfo> resourceInfos = infos[0].GetResourceGroups();
            await resourceInfos[0].StartSuspendAsync();
        }

        public async void ShowMessage1()
        {
            MessageDialog dialog = new MessageDialog("Yes or no?");
            dialog.Commands.Add(new UICommand("Yes", null));
            dialog.Commands.Add(new UICommand("No", null));
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;
            var cmd = await dialog.ShowAsync();

            if (cmd.Label == "Yes")
            {
                // do something
            }
        }




    }
}
