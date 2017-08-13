using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.Shopping.Cart
{
    public partial class ShoppingCartView : StackLayout, IDisposable
    {
        public ShoppingCartView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            this.DisposeBindingContext();
            this.DisposeChildren();
        }
    }
}
