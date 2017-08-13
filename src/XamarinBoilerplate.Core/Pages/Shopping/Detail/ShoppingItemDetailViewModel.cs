using System;
using Reactive.Bindings;
using XamarinBoilerplate.Core.Model.Shopping;
using XamarinBoilerplate.Core.Services;
using XamarinBoilerplate.Core.Services.Shopping;

namespace XamarinBoilerplate.Core.Pages.Shopping.Detail
{
    public class ShoppingItemDetailViewModel : ShoppingItemViewModel
    {
        public ReactiveCommand AddToCartCommand { get; }
        private readonly IDisposable _addToCartSubscription;

        protected readonly IShoppingCartService ShoppingCartService;

        public ShoppingItemDetailViewModel(ShoppingItemModel source, IShoppingCartService shoppingCartService, INavigationService navigationService) : base(source, navigationService)
        {
            ShoppingCartService = shoppingCartService;

            AddToCartCommand = new ReactiveCommand();
            _addToCartSubscription = AddToCartCommand.Subscribe(AddToCart);
        }

        private void AddToCart(object parameter)
        {
            ShoppingCartService.AddItem(Item);
        }

        public override void Dispose()
        {
            base.Dispose();
            AddToCartCommand?.Dispose();
            _addToCartSubscription?.Dispose();
        }
    }
}
