using MvvmCross.ViewModels;
using ToDoApp.ViewModels;

namespace ToDoApp
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<IssuesViewModel>();
        }
    }
}
