using System;
using MobileTemplate.Core.Extensions;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.CopySample
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
