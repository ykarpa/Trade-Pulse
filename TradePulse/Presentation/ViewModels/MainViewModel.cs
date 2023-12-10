﻿using Presentation.Services;
using Presentation.Core;
using Presentation.Views;

namespace Presentation.ViewModels
{
    public class MainViewModel : ViewModel
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

        public RelayCommand NavigateToCategories { get; set; }
        public RelayCommand NavigateToProfile { get; set; }

        public MainViewModel(INavigationService navService)
        {
            _navigation = navService;
            this.NavigateToCategories = new RelayCommand(o => true, o => { Navigation.NavigateTo<CategoriesViewModel>(); });
            this.NavigateToProfile = new RelayCommand(o => true, o => { Navigation.NavigateTo<ProfileViewModel>(); });
        }
    }
}
