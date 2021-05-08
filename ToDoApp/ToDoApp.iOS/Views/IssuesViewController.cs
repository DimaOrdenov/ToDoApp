using Cirrious.FluentLayouts.Touch;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using ToDoApp.iOS.Sources;
using ToDoApp.ViewModels;
using UIKit;

namespace ToDoApp.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class IssuesViewController : MvxViewController<IssuesViewModel>
    {
        private IssuesTableViewSource _source;
        private UITableView _tableView;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Issues";

            _tableView = new UITableView
            {
                RowHeight = UITableView.AutomaticDimension,
            };

            _source = new IssuesTableViewSource(_tableView);
            _tableView.Source = _source;

            View.AddSubviews(_tableView);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _tableView.AtTopOf(View),
                _tableView.AtRightOf(View),
                _tableView.AtLeftOf(View),
                _tableView.AtBottomOf(View));

            View.BringSubviewToFront(_tableView);

            var set = CreateBindingSet();

            set.Bind(_source)
                .For(x => x.ItemsSource)
                .To(vm => vm.Issues);

            set.Bind(_source)
                .For(x => x.SelectionChangedCommand)
                .To(vm => vm.IssueTapCommand);

            set.Apply();
        }
    }
}
