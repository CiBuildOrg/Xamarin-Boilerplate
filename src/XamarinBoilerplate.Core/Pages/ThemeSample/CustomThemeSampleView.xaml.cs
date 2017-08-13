using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.ThemeSample
{
    public partial class CustomThemeSampleView : ScrollView, IDisposable
    {
        public CustomThemeSampleView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }
}
