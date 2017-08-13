using System;
using Reactive.Bindings;
using XamarinBoilerplate.Core.Model.Menu;
using XamarinBoilerplate.Core.Services;

namespace XamarinBoilerplate.Core.Pages.Landing
{
    public class LandingMenuItemViewModel : IDisposable
    {
        public IReadOnlyReactiveProperty<string> ImageSource { get; }
        public IReadOnlyReactiveProperty<string> Title { get; }
        public ReactiveCommand Tapped { get; }

        private readonly IDisposable _tappedSubscription;

        public LandingMenuItemViewModel(MenuItemModel viewModel, INavigationService navigationService)
        {
            Title = viewModel.Title.ToReadOnlyReactiveProperty();
            ImageSource = viewModel.ImageSource.ToReadOnlyReactiveProperty();
            Tapped = new ReactiveCommand();
            _tappedSubscription = Tapped.Subscribe((x) => { navigationService.Push(viewModel.CreatePage.Invoke()); });
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
