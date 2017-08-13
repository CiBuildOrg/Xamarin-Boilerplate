using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.ThemeSample
{
    public class LightThemeSamplePage : ContentPage, IDisposable
    {
        public LightThemeSamplePage()
        {
            Title = "Light Theme Sample";
            Content = new LightThemeSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
