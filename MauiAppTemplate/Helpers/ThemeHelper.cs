using MauiAppTemplate.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTemplate.Helpers
{
    public static class ThemeHelper
    {
        /// <summary>
        /// There is some problems with status bar color, mostly with ligth status bar and android version >= 30, 
        /// sometime the icon color stay white with light theme
        /// </summary>
        /// <param name="changeStatusBarColor"></param>
        public static void SetTheme(bool changeStatusBarColor = false)
        {
            switch (SettingsHelper.Theme)
            {
                //default
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;
                //light
                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                //dark
                case 2:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }

            var nav = App.Current.MainPage as NavigationPage;
            EnvironmentService environmentService = new();
            if (App.Current.RequestedTheme == OSAppTheme.Dark)
            {
                if (changeStatusBarColor)
                    environmentService.SetStatusBarColor(Colors.Black, false);

                if (nav != null)
                {
                    nav.BarBackgroundColor = Colors.Black;
                    nav.BarTextColor = Colors.White;
                }
            }
            else
            {
                if (changeStatusBarColor)
                    environmentService.SetStatusBarColor(Colors.White, true);

                if (nav != null)
                {
                    nav.BarBackgroundColor = Colors.White;
                    nav.BarTextColor = Colors.Black;
                }
            }
        }
    }
}
