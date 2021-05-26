using MobilePharmacieApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobilePharmacieApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Accueil();
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
