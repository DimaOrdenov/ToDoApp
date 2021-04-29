using System;
using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;

namespace ToDoApp.Android
{
    [Application]
    public class Application : MvxAndroidApplication<Setup, App>
    {
        public Application(IntPtr javaReference, JniHandleOwnership transfer) 
            : base(javaReference, transfer)
        {
        }
    }
}
