using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using ToDoApp.ViewModels;

namespace ToDoApp.Android.Views
{
    [MvxActivityPresentation]
    [Activity]
    public class IssuesView : MvxActivity<IssuesViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.IssuesView);

            var issuesListView = FindViewById<MvxRecyclerView>(Resource.Id.issuesListView);
            issuesListView.ItemTemplateId = Resource.Layout.IssueItemView;

            var set = CreateBindingSet();

            set.Bind(issuesListView)
                .For(b => b.ItemsSource)
                .To(vm => vm.Issues);

            set.Bind(issuesListView)
                .For(b => b.ItemClick)
                .To(vm => vm.IssueTapCommand);
            
            set.Apply();
        }
    }
}
