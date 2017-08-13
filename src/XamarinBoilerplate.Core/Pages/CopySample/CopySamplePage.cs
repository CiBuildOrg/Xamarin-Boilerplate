using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.CopySample
{
    public class CopySamplePage : ContentPage, IDisposable
    {
        public CopySamplePage()
        {
            Title = "Copy Sample";
            Content = new CopySampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
