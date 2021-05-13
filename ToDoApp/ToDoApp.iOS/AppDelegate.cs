using System.Drawing;
using Foundation;
using MvvmCross.Platforms.Ios.Core;
using ToDoApp.iOS.Styles;
using UIKit;

namespace ToDoApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);
            
            // UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = Colors.TextOnPrimary,
                Font = UIFont.SystemFontOfSize(17f, UIFontWeight.Semibold)
            });
            UINavigationBar.Appearance.Translucent = false;
            UINavigationBar.Appearance.BarTintColor = Colors.Primary;
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BackgroundColor = Colors.Primary;
            UINavigationBar.Appearance.BackIndicatorImage = new UIImage();

            UITextField.Appearance.TintColor = Colors.Accent;
            UITextView.Appearance.TintColor = Colors.Accent;
            UIButton.Appearance.SetTitleColor(Colors.Accent, UIControlState.Highlighted);
            
            return result;
        }
    }
}
