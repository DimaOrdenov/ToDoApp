using System;
using MvvmCross.Platforms.Ios.Binding.Views;
using ToDoApp.iOS.Views;
using UIKit;

namespace ToDoApp.iOS.Sources
{
    public class IssuesTableViewSource : MvxSimpleTableViewSource
    {
        public IssuesTableViewSource(UITableView tableView)
            : base(tableView, typeof(IssueItemView))
        {
            DeselectAutomatically = true;
        }
    }
}
