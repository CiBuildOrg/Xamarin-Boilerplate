using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.RendererSample
{
    public partial class RendererSampleView : ScrollView, IDisposable
    {
        public RendererSampleView()
        {
            InitializeComponent();
            var viewModel = new RendererSampleViewModel();
            BindingContext = viewModel;
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
