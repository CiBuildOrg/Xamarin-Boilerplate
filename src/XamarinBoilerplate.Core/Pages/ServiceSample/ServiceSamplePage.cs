using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.ServiceSample
{
    public class ServiceSamplePage : ContentPage, IDisposable
    {
        public ServiceSamplePage()
        {
            Title = "Service Sample";
            Content = new ServiceSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
