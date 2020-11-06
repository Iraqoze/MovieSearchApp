using System;
using Xamarin.Forms;
using UIApp.Views;
using Xamarin.Forms.Xaml;

namespace UIApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SearchView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
