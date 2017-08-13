using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.AssetSample
{
    public class AssetSamplePage : ContentPage, IDisposable
    {
        public AssetSamplePage()
        {
            Title = "Asset Sample";
            Content = new AssetSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
