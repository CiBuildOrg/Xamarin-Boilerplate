using Xamarin.Forms;
using XamarinBoilerplate.Core.Pages.Menu;

namespace XamarinBoilerplate.Core
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MasterDetailWrapper();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
