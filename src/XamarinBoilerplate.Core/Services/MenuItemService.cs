using System.Collections.Generic;
using Reactive.Bindings;
using XamarinBoilerplate.Core.Model.Menu;
using XamarinBoilerplate.Core.Pages.AssetSample;
using XamarinBoilerplate.Core.Pages.CopySample;
using XamarinBoilerplate.Core.Pages.FormSample;
using XamarinBoilerplate.Core.Pages.Landing;
using XamarinBoilerplate.Core.Pages.ReactiveSample;
using XamarinBoilerplate.Core.Pages.RendererSample;
using XamarinBoilerplate.Core.Pages.ServiceSample;
using XamarinBoilerplate.Core.Pages.Shopping.Cart;
using XamarinBoilerplate.Core.Pages.Shopping.Grid;
using XamarinBoilerplate.Core.Pages.Shopping.List;
using XamarinBoilerplate.Core.Pages.ThemeSample;

namespace XamarinBoilerplate.Core.Services
{
    public interface IMenuItemService
    {
        IReadOnlyReactiveProperty<IEnumerable<MenuItemModel>> MenuItems { get; }
    }

    public class MenuItemService : IMenuItemService
    {
        private readonly IReactiveProperty<IEnumerable<MenuItemModel>> _menuItemsInternal;
        public IReadOnlyReactiveProperty<IEnumerable<MenuItemModel>> MenuItems { get; }

        public MenuItemService()
        {
            var items = new[]
            {
                new MenuItemModel("Home Sample", "Icon.png", () => new LandingPage()),
                new MenuItemModel("Copy Sample","Icon.png", ()=>new CopySamplePage()),
                new MenuItemModel("Form Sample", "Icon.png", () => new FormSamplePage()),
                new MenuItemModel("Shopping List Sample", "Icon.png", () => new ShoppingListPage()),
                new MenuItemModel("Shopping Grid Sample", "Icon.png", () => new ShoppingGridPage()),
                new MenuItemModel("Shopping Cart Sample", "Icon.png", () => new ShoppingCartPage()),
                new MenuItemModel("Light Theme Sample", "Icon.png", () => new LightThemeSamplePage()),
                new MenuItemModel("Dark Theme Sample", "Icon.png", () => new DarkThemeSamplePage()),
                new MenuItemModel("Custom Theme Sample", "Icon.png", () => new CustomThemeSamplePage()),
                new MenuItemModel("Service Sample", "Icon.png", () => new ServiceSamplePage()),
                new MenuItemModel("Assets Sample", "Icon.png", () => new AssetSamplePage()),
                new MenuItemModel("Custom Renderer Sample", "Icon.png", () => new RendererSamplePage()),
                new MenuItemModel("Reactive Sample", "Icon.png", () => new ReactiveSamplePage())
            };
            _menuItemsInternal = new ReactiveProperty<IEnumerable<MenuItemModel>>(items);
            MenuItems = _menuItemsInternal.ToReadOnlyReactiveProperty();
        }
    }
}
