using MauiAppTemplate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTemplate.Helpers
{
    public static class ThemeHelper
    {
        public static void SetTheme()
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

            var e = DependencyService.Get<IEnvironmentService>();
            if (App.Current.RequestedTheme == OSAppTheme.Dark)
            {
                e?.SetStatusBarColor(Colors.Black, false);
                if (nav != null)
                {
                    nav.BarBackgroundColor = Colors.Black;
                    nav.BarTextColor = Colors.White;
                }
            }
            else
            {
                e?.SetStatusBarColor(Colors.White, true);
                if (nav != null)
                {
                    nav.BarBackgroundColor = Colors.White;
                    nav.BarTextColor = Colors.Black;
                }
            }
        }
    }
}
