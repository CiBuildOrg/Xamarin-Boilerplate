using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.CopySample
{
    public partial class CopySampleView : ScrollView, IDisposable
    {
        public CopySampleView()
        {
            InitializeComponent();
            var viewModel = new CopySampleViewModel();
            BindingContext = viewModel;
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
