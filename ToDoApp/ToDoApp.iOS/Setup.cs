using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using ToDoApp.iOS.Services;
using ToDoApp.Services;

namespace ToDoApp.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
        
        protected override IMvxIoCProvider InitializeIoC()
        {
            var provider = base.InitializeIoC();

            provider.ConstructAndRegisterSingleton<IDialogService, DialogService>();

            return provider;
        }
    }
}
