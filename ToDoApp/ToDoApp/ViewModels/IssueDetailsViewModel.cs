using System;
using System.Linq;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using ToDoApp.Definitions.Entities;
using ToDoApp.Definitions.Enums;
using ToDoApp.Definitions.Options;
using ToDoApp.Extensions;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class IssueDetailsViewModel : MvxViewModel<Issue, bool>
    {
        public IssueDetailsViewModel(IIssueRepository issueRepository, IDialogService dialogService, IMvxNavigationService navigationService)
        {
            SaveChangesCommand = new MvxCommand(
                async () =>
                {
                    Issue.Status = (int)Enum.GetValues(typeof(IssueStatusType))
                        .Cast<IssueStatusType>()
                        .First(x => x.GetEnumString() == SelectedStatusStr);

                    try
                    {
                        if (IsOldIssue)
                        {
                            issueRepository.Update(Issue);
                        }
                        else
                        {
                            issueRepository.Create(Issue);
                        }

                        await navigationService.Close(this, true);
                    }
                    catch (Exception ex)
                    {
                        await dialogService.DisplayAlertAsync(new DisplayAlertOptions("Exception", ex.Message, "Ok"));
                    }
                });

            DeleteCommand = new MvxCommand(() =>
                dialogService.DisplayAlertAsync(
                    new DisplayAlertOptions(string.Empty, "Do you really want to delete the issue?", "No", "Yes")
                    {
                        AcceptButtonCommand = new MvxCommand(
                            async () =>
                            {
                                try
                                {
                                    issueRepository.Delete(Issue.Id);
                                    await navigationService.Close(this, true);
                                }
                                catch (Exception ex)
                                {
                                    await dialogService.DisplayAlertAsync(new DisplayAlertOptions("Exception", ex.Message, "Ok"));
                                }
                            }),
                    }));
        }

        public IMvxCommand SaveChangesCommand { get; }

        public IMvxCommand DeleteCommand { get; }

        public Issue Issue { get; private set; }

        public string SelectedStatusStr { get; set; }

        public string CreatedAtStr => Issue.CreatedAt.ToString("HH:mm dd.MM.yyyy");

        public string UpdatedAtStr => Issue.UpdatedAt?.ToString("HH:mm dd.MM.yyyy");

        public bool IsOldIssue { get; private set; }

        public string SaveButtonTitle => IsOldIssue ? "Save changes" : "Create issue";

        public override void Prepare(Issue parameter)
        {
            Issue = parameter ?? new Issue();
            IsOldIssue = parameter != null;

            SelectedStatusStr = ((IssueStatusType)Issue.Status).GetEnumString();
        }
    }
}
