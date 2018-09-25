using System;
using Xamarin.Forms;
using shashin.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace shashin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            //MainPage = new MainPage();
            Current.MainPage = new PasscodePage();
            //MainPage = new NavigationPage(new unsplashPhotos());
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
