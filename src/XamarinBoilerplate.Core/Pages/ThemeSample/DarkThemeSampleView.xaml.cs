using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.ThemeSample
{
    public partial class DarkThemeSampleView : ScrollView, IDisposable
    {
        public DarkThemeSampleView()
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
