using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.ReactiveSample
{
    public class ReactiveSamplePage : ContentPage, IDisposable
    {
        public ReactiveSamplePage()
        {
            Title = "Reactive Sample";
            Content = new ReactiveSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
