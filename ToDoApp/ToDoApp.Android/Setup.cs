using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;
using ToDoApp.Android.Services;
using ToDoApp.Services;

namespace ToDoApp.Android
{
    public class Setup : MvxAndroidSetup<App>
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
