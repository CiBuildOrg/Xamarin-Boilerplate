using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Reactive.Bindings;
using XamarinBoilerplate.Core.Services;
using XamarinBoilerplate.Core.Services.Shopping;

namespace XamarinBoilerplate.Core.Pages.Shopping
{
    public class ShoppingViewModel : IDisposable
    {
        public IReadOnlyReactiveProperty<IEnumerable<ShoppingItemViewModel>> ShoppingItems { get; }

        public ShoppingViewModel(IShoppingItemService shoppingItemService, INavigationService navigationService)
        {
            ShoppingItems = shoppingItemService.Inventory.Select(x => x.Select(y => new ShoppingItemViewModel(y, navigationService))).ToReadOnlyReactiveProperty(Enumerable.Empty<ShoppingItemViewModel>());
        }

        public void Dispose()
        {
            ShoppingItems?.Dispose();
        }
    }
}
