using System;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using ToDoApp.Definitions.Enums;
using ToDoApp.Definitions.Options;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class IssuesViewModel : MvxViewModel
    {
        private MvxObservableCollection<IssueItemViewModel> _issues;

        public IssuesViewModel(IMvxNavigationService navigationService, IDialogService dialogService)
        {
            IssueTapCommand = new MvxCommand<IssueItemViewModel>(
                item => dialogService.DisplayAlertAsync(new DisplayAlertOptions($"{item.Status} issue", item.Title, "Ok")));

            Issues = new MvxObservableCollection<IssueItemViewModel>
            {
                new IssueItemViewModel
                {
                    Title = "Issue 1",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas tellus diam, blandit eget sem a, posuere aliquet erat. " +
                                  "Suspendisse non felis sit amet felis sollicitudin sagittis in nec felis. Nullam tristique malesuada consectetur. Mauris gravida dapibus enim, ",
                    Status = IssueStatusType.Open,
                    CreatedAt = DateTimeOffset.Now.AddDays(-2),
                },
                new IssueItemViewModel
                {
                    Title = "Issue 2",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas tellus diam, blandit eget sem a, posuere aliquet erat. " +
                                  "Suspendisse non felis sit amet felis sollicitudin sagittis in nec felis. Nullam tristique malesuada consectetur. Mauris gravida dapibus enim, ",
                    Status = IssueStatusType.InProgress,
                    CreatedAt = DateTimeOffset.Now.AddDays(-5),
                },
                new IssueItemViewModel
                {
                    Title = "Issue 3",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas tellus diam, blandit eget sem a, posuere aliquet erat. " +
                                  "Suspendisse non felis sit amet felis sollicitudin sagittis in nec felis. Nullam tristique malesuada consectetur. Mauris gravida dapibus enim, ",
                    Status = IssueStatusType.Done,
                    CreatedAt = DateTimeOffset.Now.AddDays(-10),
                },
            };
        }

        public IMvxCommand<IssueItemViewModel> IssueTapCommand { get; }

        public MvxObservableCollection<IssueItemViewModel> Issues
        {
            get => _issues;
            set => SetProperty(ref _issues, value);
        }
    }
}
