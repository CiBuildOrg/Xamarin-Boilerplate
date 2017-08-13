using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.Shopping.Detail
{
    public partial class ShoppingItemDetailView : StackLayout, IDisposable
    {
        public ShoppingItemDetailView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            this.DisposeChildren();
            this.DisposeBindingContext();
        }
    }
}
