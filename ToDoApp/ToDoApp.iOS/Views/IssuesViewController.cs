using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using ToDoApp.ViewModels;

namespace ToDoApp.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class IssuesViewController : MvxViewController<IssuesViewModel>
    {
        public IssuesViewController() 
            : base(nameof(IssuesViewController), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}
