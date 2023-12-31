﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BLL.Services;
using System.Linq;
using Presentation.Core;
using Presentation.Services;
using System;

namespace Presentation.ViewModels
{
    public class ProductsViewModel : ViewModel
    {
        private ObservableCollection<ProductViewModel>? _products;

        public ObservableCollection<ProductViewModel> Products
        {
            get => _products!;
            set
            {
                _products = value;
                OnPropertyChange();
            }
        }

        private string? _category;
        public string Category
        {
            get => _category!;
            set
            {
                _category = value;
                Task.Run(async () => await LoadProducts(_category));
                OnPropertyChange();
            }
        }
        
        public Func<int, RelayCommand> InitNavCommand { get; private set; }
        public ProductService ProductService { get; set; }
        private async Task LoadProducts(string category = "")
        {
            var products = await ProductService.GetProductsList();

            var productViewModels = products.Where(p => p.Category == category).Select(product => new ProductViewModel()
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Model = product.Model!,
                ItemsAvailable = product.ItemsAvailable,
                NavigateToDetails = InitNavCommand(product.ProductId)
            });
            Products = new ObservableCollection<ProductViewModel>(productViewModels);
        }

        public ProductsViewModel(ProductService productService, INavigationService navigation)
        {
            ProductService = productService;
            InitNavCommand = (id) => new RelayCommand(_ => true, _ =>
            {
                navigation.NavigateTo<ProductDetailsViewModel>();
                navigation.InitParam<ProductDetailsViewModel>(p => p.ProductId = id);
            });
        }
    }
}