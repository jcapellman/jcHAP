using System.Linq;

using Windows.UI.Xaml.Controls;

using jcHAP.ViewModels.Pages;

namespace jcHAP.Pages
{
    public sealed partial class MainPage
    {
        private MainPageViewModel ViewModel => (MainPageViewModel) DataContext;

        public MainPage()
        {
            InitializeComponent();

            DataContext = new MainPageViewModel();

            ViewModel.Load();

            if (!ViewModel.MenuItems.Any())
            {
                return;
            }

            LoadContent(ViewModel.MenuItems.First());
        }

        private void HamburgerMenu_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = e.ClickedItem as MenuItem;

            if (menuItem == null)
            {
                return;
            }

            LoadContent(menuItem);
        }

        private void LoadContent(MenuItem menuItem)
        {
            contentFrame.Navigate(menuItem.PageType);
        }
    }
}