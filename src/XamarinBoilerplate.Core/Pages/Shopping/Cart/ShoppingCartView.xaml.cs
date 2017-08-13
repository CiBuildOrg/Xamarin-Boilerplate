using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.Shopping.Cart
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
