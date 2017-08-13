using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.RendererSample
{
    public class RendererSamplePage : ContentPage, IDisposable
    {
        public RendererSamplePage()
        {
            Title = "Renderer Sample";
            Content = new RendererSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
