using System;
using System.Collections.Generic;
using System.Text;
using UlziUI.Views.Pages;
using Xamarin.Forms;

namespace UlziUI
{
    #region App
    public class App : Application
    {
        public App() : base()
        {
            this.MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }
    }
    #endregion
}
