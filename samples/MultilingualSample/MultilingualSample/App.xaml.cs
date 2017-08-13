using System.Globalization;
using System.Linq;
using MultilingualSample.Views;
using Plugin.Multilingual;
using Xamarin.Forms;

namespace MultilingualSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;
			MainPage = new NavigationPage(new HomePage());
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
