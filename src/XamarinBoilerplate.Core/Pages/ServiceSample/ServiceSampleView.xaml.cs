using System;
using Autofac;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;
using XamarinBoilerplate.Core.Services;

namespace XamarinBoilerplate.Core.Pages.ServiceSample
{
    public partial class ServiceSampleView : ScrollView, IDisposable
    {
        public ServiceSampleView()
        {
            InitializeComponent();
            var sampleService = IoC.Container.Resolve<ISampleService>();
            BindingContext = new ServiceSampleViewModel(sampleService);
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
