using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.ThemeSample
{
    public class DarkThemeSamplePage : ContentPage, IDisposable
    {
        public DarkThemeSamplePage()
        {
            Title = "Dark Theme Sample";
            Content = new DarkThemeSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
