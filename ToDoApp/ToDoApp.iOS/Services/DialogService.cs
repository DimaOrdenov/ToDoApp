using System.Threading.Tasks;
using ToDoApp.Definitions.Options;
using ToDoApp.Services;
using UIKit;

namespace ToDoApp.iOS.Services
{
    public class DialogService : IDialogService
    {
        public Task DisplayAlertAsync(DisplayAlertOptions options)
        {
            var alert = UIAlertController.Create(options.Title, options.Message, UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create(
                options.CancelButton,
                UIAlertActionStyle.Cancel,
                action => options.CancelButtonCommand?.Execute()));

            if (!string.IsNullOrEmpty(options.AcceptButton))
            {
                alert.AddAction(UIAlertAction.Create(
                    options.AcceptButton,
                    UIAlertActionStyle.Default,
                    action => options.AcceptButtonCommand?.Execute()));
            }

            return Xamarin.Essentials.Platform.GetCurrentUIViewController().PresentViewControllerAsync(alert, true);
        }
    }
}
