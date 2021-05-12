using System;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using ToDoApp.Definitions.Entities;
using ToDoApp.Definitions.Enums;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class IssuesViewModel : MvxViewModel
    {
        private readonly IIssueRepository _issueRepository;

        private MvxObservableCollection<IssueItemViewModel> _issues;

        public IssuesViewModel(
            IMvxNavigationService navigationService,
            IDialogService dialogService,
            IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;

            IssueTapCommand = new MvxCommand<IssueItemViewModel>(
                async item =>
                {
                    if (await navigationService.Navigate<IssueDetailsViewModel, Issue, bool>(item.Item))
                    {
                        GetIssues();
                    }
                });

            AddIssueTapCommand = new MvxCommand(
                async () =>
                {
                    if (await navigationService.Navigate<IssueDetailsViewModel, Issue, bool>(null))
                    {
                        GetIssues();
                    }
                });
        }

        public IMvxCommand<IssueItemViewModel> IssueTapCommand { get; }

        public IMvxCommand AddIssueTapCommand { get; }

        public MvxObservableCollection<IssueItemViewModel> Issues
        {
            get => _issues;
            set => SetProperty(ref _issues, value);
        }

        public override Task Initialize()
        {
            if (Xamarin.Essentials.Preferences.Get("FirstLaunch", true))
            {
                _issueRepository.Create(new Issue
                {
                    Title = "Example issue 1",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas tellus diam, blandit eget sem a, posuere aliquet erat. " +
                                  "Suspendisse non felis sit amet felis sollicitudin sagittis in nec felis. Nullam tristique malesuada consectetur. Mauris gravida dapibus enim, ",
                    Status = (int)IssueStatusType.Open,
                    CreatedAt = DateTimeOffset.Now.AddDays(-2),
                });

                _issueRepository.Create(new Issue
                {
                    Title = "Example issue 2",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas tellus diam, blandit eget sem a, posuere aliquet erat. " +
                                  "Suspendisse non felis sit amet felis sollicitudin sagittis in nec felis. Nullam tristique malesuada consectetur. Mauris gravida dapibus enim, ",
                    Status = (int)IssueStatusType.InProgress,
                    CreatedAt = DateTimeOffset.Now.AddDays(-5),
                });

                _issueRepository.Create(new Issue
                {
                    Title = "Example issue 3",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas tellus diam, blandit eget sem a, posuere aliquet erat. " +
                                  "Suspendisse non felis sit amet felis sollicitudin sagittis in nec felis. Nullam tristique malesuada consectetur. Mauris gravida dapibus enim, ",
                    Status = (int)IssueStatusType.Done,
                    CreatedAt = DateTimeOffset.Now.AddDays(-10),
                });

                Xamarin.Essentials.Preferences.Set("FirstLaunch", false);
            }

            GetIssues();

            return base.Initialize();
        }

        private void GetIssues()
        {
            Issues = new MvxObservableCollection<IssueItemViewModel>(
                _issueRepository.Get().Select(x =>
                    new IssueItemViewModel(x)));
        }
    }
}
