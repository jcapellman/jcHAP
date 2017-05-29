using System;

using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace jcHAP.Pages
{
    public class BasePage : Page
    {
        public async void ShowMessage(string message)
        {
            var dialog = new MessageDialog(message);

            await dialog.ShowAsync();
        }
    }
}