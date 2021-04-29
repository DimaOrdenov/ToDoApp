using System.Threading.Tasks;
using Android.Content;
using AndroidX.AppCompat.App;
using MvvmCross.Platforms.Android;
using MvvmCross.Platforms.Android.Views;
using ToDoApp.Definitions.Options;
using ToDoApp.Services;

namespace ToDoApp.Android.Services
{
    public class DialogService : IDialogService
    {
        public Task DisplayAlertAsync(DisplayAlertOptions options)
        {
            var alertDialog = new global::Android.App.AlertDialog.Builder(global::Android.App.Application.Context)
                .Create();

            alertDialog.SetTitle(options.Title);
            alertDialog.SetMessage(options.Message);

            if (string.IsNullOrEmpty(options.AcceptButton))
            {
                alertDialog.SetButton((int)DialogButtonType.Positive, options.AcceptButton, (o, args) => options.AcceptButtonCommand?.Execute());
            }

            alertDialog.SetButton((int)DialogButtonType.Negative, options.CancelButton, (o, args) => options.CancelButtonCommand?.Execute());

            alertDialog.Show();

            return Task.CompletedTask;
        }
    }
}
