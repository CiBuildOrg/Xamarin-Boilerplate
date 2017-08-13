using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.Shopping.Grid
{
    public class ShoppingGridPage : ContentPage, IDisposable
    {
        public ShoppingGridPage()
        {
            Title = "Shopping Grid Sample";
            Content = new ShoppingGridView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
