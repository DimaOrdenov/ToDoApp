using System;
using System.Threading.Tasks;
using Autofac.Extras.MvvmCross;
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
