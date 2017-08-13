using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.ReactiveSample
{
    public partial class ReactiveSampleView : ScrollView, IDisposable
    {
        public ReactiveSampleView()
        {
            InitializeComponent();
            BindingContext = new ReactiveSampleViewModel();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
