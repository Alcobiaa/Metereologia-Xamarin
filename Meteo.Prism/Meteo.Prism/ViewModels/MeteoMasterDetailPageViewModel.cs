using Meteo.Prism.Helpers;
using Meteo.Prism.ItemViewModels;
using Meteo.Prism.Models;
using Meteo.Prism.Resources;
using Meteo.Prism.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Meteo.Prism.ViewModels
{
    public class MeteoMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly User _user;

        public MeteoMasterDetailPageViewModel(INavigationService navigationService,
            User user) : base(navigationService)
        {
            _navigationService = navigationService;
            _user = user;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        public DelegateCommand LogoutCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    _user.Password = "";
                    _user.Username = "";

                    await NavigationService.NavigateAsync($"/NavigationPage/LoginPage");
                });
            }
        }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "tempo",
                    PageName = $"{nameof(MeteoPage)}",
                    Title = Languages.Meteorology,
                    IsLoginRequired = true
                },

                new Menu
                {
                    Icon = "edit_user",
                    PageName = $"{nameof(ModifyUserPage)}",
                    Title = Languages.ModifyUser,
                    IsLoginRequired = true
                },

                new Menu
                {
                    Icon = "aboutus",
                    PageName = $"{nameof(AboutUsPage)}",
                    Title = Languages.AboutUs,
                    IsLoginRequired = true
                },
            };

            Menus = new ObservableCollection<MenuItemViewModel>
                (menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title,
                    IsLoginRequired = m.IsLoginRequired
                }).ToList());
        }


    }
}
