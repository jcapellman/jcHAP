using Windows.UI.Xaml.Controls;

using jcHAP.ViewModels.Pages;

namespace jcHAP.Pages
{
    public sealed partial class MainPage : BasePage
    {
        private MainPageViewModel viewModel => (MainPageViewModel) DataContext;

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = new MainPageViewModel();

            viewModel.Load();
        }

        private void HamburgerMenu_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = e.ClickedItem as MenuItem;
            contentFrame.Navigate(menuItem.PageType);
        }
    }
}