using MvvmCross.Commands;
using MvvmCross.ViewModels;
using ToDoApp.Definitions.Options;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class IssueDetailsViewModel : MvxViewModel
    {
        public IssueDetailsViewModel(IDialogService dialogService)
        {
            DeleteCommand = new MvxCommand(() =>
                dialogService.DisplayAlertAsync(
                    new DisplayAlertOptions(string.Empty, "Do you really want to delete the issue?", "No", "Yes")
                    {
                        AcceptButtonCommand = new MvxCommand(
                            () =>
                            {
                                dialogService.DisplayAlertAsync(
                                    new DisplayAlertOptions(string.Empty, "Issue was deleted", "Ok"));
                            }),
                    }));
        }

        public IMvxCommand DeleteCommand { get; }

        public IMvxCommand EditCommand { get; }
    }
}
