using Xamarin.Forms;
using XamarinBoilerplate.Core.Services;

namespace XamarinBoilerplate.Droid.Service
{
    public class SampleServiceDroid : SampleService
    {
        public SampleServiceDroid(INavigationService navigationService) : base(navigationService)
        {
        }

        public override string PlatformText { get; } = "Open an Android-specific Page";

        public override void PlatformCommand()
        {
            NavigationService.Push(new ContentPage
            {
                Title = "Droid Page",
                Content = new Label
                {
                    Text = "This is a page popped up for Android!",
                    TextColor = Color.Yellow
                },
                BackgroundColor = Color.Green
            });
        }
    }
}