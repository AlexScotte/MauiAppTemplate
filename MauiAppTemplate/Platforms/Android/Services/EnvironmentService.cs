using Android.OS;
using Android.Views;
using AndroidX.Core.View;
using MauiAppTemplate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTemplate.Services
{
    public partial class EnvironmentService
    {
        public partial void SetStatusBarColor(Microsoft.Maui.Graphics.Color color, bool isLight)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
                return;

            var androidColor = new Android.Graphics.Color((int)color.Red, (int)color.Green, (int)color.Blue, (int)color.Alpha);
            var activity = Platform.CurrentActivity;
            var window = activity.Window;

            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.SetStatusBarColor(androidColor);

            if ((int)Build.VERSION.SdkInt < 30)
            {
#pragma warning disable CS0618 // Type or member is obsolete. Using new API for Sdk 30+
                window.DecorView.SystemUiVisibility = isLight ? (StatusBarVisibility)(SystemUiFlags.LightStatusBar) : 0;
#pragma warning restore CS0618 // Type or member is obsolete
            }
            else
            {
                var lightStatusBars = isLight ? WindowInsetsControllerAppearance.LightStatusBars : 0;
#pragma warning disable CA1416 // Validate platform compatibility
                window.InsetsController?.SetSystemBarsAppearance((int)lightStatusBars, (int)lightStatusBars);
#pragma warning restore CA1416 // Validate platform compatibility
            }

        }
    }
}
