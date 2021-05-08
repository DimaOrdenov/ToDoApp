using System;
using System.IO;
using AutoMapper;
using LiteDB;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using ToDoApp.Services;
using ToDoApp.ViewModels;

namespace ToDoApp
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterSingleton(
                typeof(Lazy<ILiteDatabase>),
                new Lazy<ILiteDatabase>(() => new LiteDatabase(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "local.db"))));

            Mvx.IoCProvider.ConstructAndRegisterSingleton<IIssueRepository, IssueRepository>();
            Mvx.IoCProvider.RegisterSingleton(typeof(IMapper), new Mapper().Build());

            RegisterAppStart<IssuesViewModel>();
        }
    }
}
