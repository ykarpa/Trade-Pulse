﻿using Presentation.Services;
using Presentation.Core;
using Presentation.Views;

namespace Presentation.ViewModels
{
    public class ProfileViewModelModalDialog : ViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChange();
            }
        }

        public RelayCommand NavigateToProfile { get; set; }
        public RelayCommand NavigateToFinance { get; set; }
        public RelayCommand NavigateToMyOrders { get; set; }
        public RelayCommand NavigateToCreateAdvertisement { get; set; }

        public ProfileViewModelModalDialog(INavigationService navService)
        {
            _navigation = navService;
            this.NavigateToProfile = new RelayCommand(_ => true, _ =>
            {
                Navigation.NavigateTo<ProfileViewModel>();
                Navigation.InitParam<ProfileViewModel>(p => p.User = AuthService.CurrentUser);
            });

            this.NavigateToFinance = new RelayCommand(o => true, o =>
            {
                Navigation.NavigateTo<FinanceViewModel>();
            });
            this.NavigateToMyOrders = new RelayCommand(_ => true, _ => { Navigation.NavigateTo<MyOrdersViewModel>(); });
            this.NavigateToCreateAdvertisement = new RelayCommand(_ => true, _ => { Navigation.NavigateTo<CreationAdvertisementViewModel>(); });
        }
    }
}

