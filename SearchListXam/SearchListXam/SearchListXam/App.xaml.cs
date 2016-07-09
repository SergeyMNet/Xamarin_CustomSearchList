using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchListXam.Pages;
using Xamarin.Forms;

namespace SearchListXam
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TabbedPage()
            {
                Children =
                {
                    new TestPage1() {Title = "String"},
                    new TestPage2() {Title = "Object"},
                }
            };
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
