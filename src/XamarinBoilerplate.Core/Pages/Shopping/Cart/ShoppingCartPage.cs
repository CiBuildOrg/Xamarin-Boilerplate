using System;
using Autofac;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;
using XamarinBoilerplate.Core.Services;
using XamarinBoilerplate.Core.Services.Shopping;

namespace XamarinBoilerplate.Core.Pages.Shopping.Cart
{
    public class ShoppingCartPage : ContentPage, IDisposable
    {
        public ShoppingCartPage()
        {
            Title = "Shopping Cart Sample";
            var shoppingCartService = IoC.Container.Resolve<IShoppingCartService>();
            var navigationService = IoC.Container.Resolve<INavigationService>();
            Content = new ShoppingCartView();

            BindingContext = new ShoppingCartViewModel(shoppingCartService, navigationService);
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
