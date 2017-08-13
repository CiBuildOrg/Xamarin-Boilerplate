using Autofac;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Services;
using XamarinBoilerplate.Core.Services.Shopping;

namespace XamarinBoilerplate.Core.Pages.Shopping
{
    public partial class ShoppingBarView : StackLayout
    {
        public ShoppingBarView()
        {
            InitializeComponent();

            var shoppingCartService = IoC.Container.Resolve<IShoppingCartService>();
            var navigationService = IoC.Container.Resolve<INavigationService>();
            BindingContext = new ShoppingBarViewModel(shoppingCartService,navigationService);
        }
    }
}
