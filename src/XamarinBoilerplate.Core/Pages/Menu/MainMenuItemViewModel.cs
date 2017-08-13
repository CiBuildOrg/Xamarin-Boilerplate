using System;
using Reactive.Bindings;
using XamarinBoilerplate.Core.Model.Menu;
using XamarinBoilerplate.Core.Services;

namespace XamarinBoilerplate.Core.Pages.Menu
{
    public class MainMenuItemViewModel : IDisposable
    {
        public IReadOnlyReactiveProperty<string> ImageSource { get; }
        public IReadOnlyReactiveProperty<string> Title { get; }
        public ReactiveCommand Tapped { get; }

        private readonly IDisposable _tappedSubscription;

        public MainMenuItemViewModel(MenuItemModel viewModel, INavigationService navigationService)
        {
            Title = viewModel.Title.ToReadOnlyReactiveProperty();
            ImageSource = viewModel.ImageSource.ToReadOnlyReactiveProperty();
            Tapped = new ReactiveCommand();
            _tappedSubscription = Tapped.Subscribe((x) => { navigationService.ResetStack(viewModel.CreatePage.Invoke()); });
        }

        public void Dispose()
        {
            ImageSource?.Dispose();
            Title?.Dispose();
            _tappedSubscription?.Dispose();
            Tapped?.Dispose();
        }
    }
}
