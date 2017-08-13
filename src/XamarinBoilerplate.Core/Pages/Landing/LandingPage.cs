using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.Landing
{
    public class LandingPage : ContentPage, IDisposable
    {
        public LandingPage()
        {
            Title = "Landing Page Sample";
            Content = new LandingView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
