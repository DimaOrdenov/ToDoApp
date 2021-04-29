using MvvmCross.Logging;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;

namespace ToDoApp.iOS
{
    public class Setup : MvxIosSetup
    {
        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }
}
