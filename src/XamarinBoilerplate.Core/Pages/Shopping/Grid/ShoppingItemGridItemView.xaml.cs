using System;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.Shopping.Grid
{
    public partial class ShoppingGridItemView : Xamarin.Forms.Grid, IDisposable
    {
        public ShoppingGridItemView()
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
