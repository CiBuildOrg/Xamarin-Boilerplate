using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.ThemeSample
{
    public partial class LightThemeSampleView : ScrollView, IDisposable
    {
        public LightThemeSampleView()
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
