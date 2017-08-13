using System;
using Autofac;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;
using XamarinBoilerplate.Core.Model.Shopping;
using XamarinBoilerplate.Core.Services;
using XamarinBoilerplate.Core.Services.Shopping;

namespace XamarinBoilerplate.Core.Pages.Shopping.Detail
{
    public class ShoppingItemDetailPage : ContentPage, IDisposable
    {
        public ShoppingItemDetailPage(ShoppingItemModel item)
        {
            Title = item.Name;

            var navigationService = IoC.Container.Resolve<INavigationService>();
            var shoppingCartService = IoC.Container.Resolve<IShoppingCartService>();
            BindingContext = new ShoppingItemDetailViewModel(item, shoppingCartService, navigationService);
            Content = new ShoppingItemDetailView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
