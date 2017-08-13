using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.ThemeSample
{
    public class CustomThemeSamplePage : ContentPage, IDisposable
    {
        public CustomThemeSamplePage()
        {
            Title = "Custom Theme Sample";
            Content = new CustomThemeSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
