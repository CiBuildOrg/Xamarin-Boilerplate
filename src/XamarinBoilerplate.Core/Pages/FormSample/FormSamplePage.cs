using System;
using Xamarin.Forms;
using XamarinBoilerplate.Core.Extensions;

namespace XamarinBoilerplate.Core.Pages.FormSample
{
    public class FormSamplePage : ContentPage, IDisposable
    {
        public FormSamplePage()
        {
            Title = "Forms Sample";
            Content = new FormSampleView();
        }

        public void Dispose()
        {
            this.DisposeContent();
            this.DisposeBindingContext();
        }
    }

    public class FormLabel : Label
    {
        public FormLabel()
        {
            HorizontalOptions = LayoutOptions.StartAndExpand;
            VerticalOptions = LayoutOptions.CenterAndExpand;
        }
    }

    public class FormHeader : FormLabel
    {
        public FormHeader()
        {
            HorizontalOptions = LayoutOptions.EndAndExpand;
            FontAttributes = FontAttributes.Bold;
        }
    }
}
