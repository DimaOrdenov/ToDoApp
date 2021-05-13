using Android.App;
using Android.OS;
using Android.Views;
using Google.Android.Material.FloatingActionButton;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using ToDoApp.ViewModels;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace ToDoApp.Android.Views
{
    [MvxActivityPresentation]
    [Activity]
    public class IssuesView : MvxActivity<IssuesViewModel>, Toolbar.IOnMenuItemClickListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.IssuesView);

            var toolbar = FindViewById<Toolbar>(Resource.Id.issues_toolbar);
            var issuesListView = FindViewById<MvxRecyclerView>(Resource.Id.issues_recyclerView);
            var fab = FindViewById<FloatingActionButton>(Resource.Id.issues_addIssueFab);

            // toolbar.InflateMenu(Resource.Menu.IssuesViewToolbarMenu);
            // toolbar.SetOnMenuItemClickListener(this);
            
            issuesListView.ItemTemplateId = Resource.Layout.IssueItemView;
            
            var set = CreateBindingSet();

            set.Bind(issuesListView)
                .For(b => b.ItemsSource)
                .To(vm => vm.Issues);

            set.Bind(issuesListView)
                .For(b => b.ItemClick)
                .To(vm => vm.IssueTapCommand);
            
            set.Bind(fab)
                .For(b => b.BindClick())
                .To(vm => vm.AddIssueTapCommand);

            set.Apply();
        }

        public bool OnMenuItemClick(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.issuesToolbarAction_add)
            {
                ViewModel.AddIssueTapCommand.Execute();
            }
            
            return true;
        }
    }
}
