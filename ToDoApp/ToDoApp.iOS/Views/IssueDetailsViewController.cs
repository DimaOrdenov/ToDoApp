using System;

using UIKit;
using Foundation;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using ToDoApp.ViewModels;

namespace ToDoApp.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class IssueDetailsViewController : MvxViewController<IssueDetailsViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

