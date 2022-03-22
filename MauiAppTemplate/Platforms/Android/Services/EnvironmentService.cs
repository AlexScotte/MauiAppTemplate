using Android.OS;
using Android.Views;
using MauiAppTemplate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTemplate.Platforms
{
    public partial class EnvironmentService : IEnvironmentService
    {
        public void SetStatusBarColor(Microsoft.Maui.Graphics.Color color, bool darkStatusBarTint)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
                return;

            var activity = Platform.CurrentActivity;
            var window = activity.Window;
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            var androidColor = new Android.Graphics.Color((int)color.Red, (int)color.Green, (int)color.Blue, (int)color.Alpha);
            window.SetStatusBarColor(androidColor);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                var flag = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
                window.DecorView.SystemUiVisibility = darkStatusBarTint ? flag : 0;
            }
        }
    }
}
