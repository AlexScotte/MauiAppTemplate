using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Foundation;
using MauiAppTemplate.Services;

namespace MauiAppTemplate.Platforms
{
    public partial class EnvironmentService : IEnvironmentService
    {
        public void SetStatusBarColor(Color color, bool darkStatusBarTint)
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                var statusBar = new UIView(UIApplication.SharedApplication.KeyWindow.WindowScene.StatusBarManager.StatusBarFrame);
                var iosColor = new UIColor((int)color.Red, (int)color.Green, (int)color.Blue, (int)color.Alpha);
                statusBar.BackgroundColor = iosColor;
                UIApplication.SharedApplication.KeyWindow.AddSubview(statusBar);
            }
            else
            {
                var statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
                if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
                {
                    var iosColor = new UIColor((int)color.Red, (int)color.Green, (int)color.Blue, (int)color.Alpha);
                    statusBar.BackgroundColor = iosColor;
                }
            }
            var style = darkStatusBarTint ? UIStatusBarStyle.DarkContent : UIStatusBarStyle.LightContent;
            UIApplication.SharedApplication.SetStatusBarStyle(style, false);
            Platform.GetCurrentUIViewController()?.SetNeedsStatusBarAppearanceUpdate();
        }
    }
}
