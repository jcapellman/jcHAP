using System;
using System.Collections.Generic;

using Windows.UI.Xaml.Controls;

using jcHAP.Pages;

namespace jcHAP.ViewModels.Pages
{
    public class MenuItem
    {
        public Symbol Icon { get; set; }
        public string Name { get; set; }
        public Type PageType { get; set; }
    }

    public class MainPageViewModel : BasePageViewModel
    {
        public List<MenuItem> _menuItems;

        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; OnPropertyChanged(); }
        }

        public List<MenuItem> _optionMenuItems;

        public List<MenuItem> OptionMenuItems
        {
            get { return _optionMenuItems; }
            set { _optionMenuItems = value; OnPropertyChanged(); }
        }

        public void Load()
        {
            var menuItems = new List<MenuItem>
            {
                new MenuItem() {Icon = Symbol.Home, Name = "Home", PageType = typeof(DashboardPage)}
            };
            
            MenuItems = menuItems;

            var optionMenuItems = new List<MenuItem>
            {
                new MenuItem() {Icon = Symbol.Setting, Name = "Settings", PageType = typeof(SettingsPage)}
            };

            OptionMenuItems = optionMenuItems;
        }
    }
}