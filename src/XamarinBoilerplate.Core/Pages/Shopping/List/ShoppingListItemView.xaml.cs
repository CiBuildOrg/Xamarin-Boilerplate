using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.Shopping.List
{
    public partial class ShoppingListItemView : StackLayout, IDisposable
    {
        public ShoppingListItemView()
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
