using System;
using Autofac;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;
using XamarinBoilerplate.Core.Services;

namespace XamarinBoilerplate.Core.Pages.AssetSample
{
    public partial class AssetSampleView : ScrollView, IDisposable
    {
        public AssetSampleView()
        {
            InitializeComponent();
            var assetService = IoC.Container.Resolve<IAssetService>();
            var viewModel = new AssetSampleViewModel(assetService);
            BindingContext = viewModel;
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
