using Xamarin.Forms;
using XamarinBoilerplate.Core.Services;

namespace XamarinBoilerplate.iOS.Service
{
    public class SampleServiceiOS : SampleService
    {
        public SampleServiceiOS(INavigationService navigationService) : base(navigationService)
        {
        }

        public override string PlatformText { get; } = "Open an iOS-specific Page";

        public override void PlatformCommand()
        {
            NavigationService.Push(new ContentPage
            {
                Title = "iOS Page",
                Content = new Label
                {
                    Text = "This is a page popped up for iOS!",
                    TextColor = Color.White
                },
                BackgroundColor = Color.Navy
            });
        }
    }
}