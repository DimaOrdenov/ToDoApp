using System.Threading.Tasks;
using Android.App;
using Android.Content;
using ToDoApp.Definitions.Options;
using ToDoApp.Services;

namespace ToDoApp.Android.Services
{
    public class DialogService : IDialogService
    {
        public Task DisplayAlertAsync(DisplayAlertOptions options)
        {
            var alertDialog = new AlertDialog.Builder(Xamarin.Essentials.Platform.CurrentActivity)
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
