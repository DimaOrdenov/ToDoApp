using MvvmCross.Commands;

namespace ToDoApp.Definitions.Options
{
    public class DisplayAlertOptions
    {
        public DisplayAlertOptions(string title, string message, string cancelButton, string acceptButton)
        {
            Title = title;
            Message = message;
            CancelButton = cancelButton;
            AcceptButton = acceptButton;
        }

        public DisplayAlertOptions(string title, string message, string cancelButton)
            : this(title, message, cancelButton, string.Empty)
        {
            Title = title;
            Message = message;
            CancelButton = cancelButton;
        }

        public string Title { get; }

        public string Message { get; }

        public string CancelButton { get; }

        public string AcceptButton { get; }

        public IMvxCommand AcceptButtonCommand { get; set; }

        public IMvxCommand CancelButtonCommand { get; set; }
    }
}
