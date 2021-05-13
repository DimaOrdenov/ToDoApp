using System;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Binding;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using ToDoApp.Converters;
using ToDoApp.Definitions.Enums;
using ToDoApp.Extensions;
using ToDoApp.ViewModels;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace ToDoApp.Android.Views
{
    [MvxActivityPresentation]
    [Activity]
    public class IssueDetailsView : MvxActivity<IssueDetailsViewModel>, View.IOnClickListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.IssueDetailsView);

            var toolbar = FindViewById<Toolbar>(Resource.Id.issueDetails_toolbar);
            var titleLabel = FindViewById<TextView>(Resource.Id.issueDetails_title);
            var descriptionLabel = FindViewById<TextView>(Resource.Id.issueDetails_description);
            var statusSpinner = FindViewById<MvxSpinner>(Resource.Id.issueDetails_statusSpinner);
            var createdAtStack = FindViewById<LinearLayout>(Resource.Id.issueDetails_createdAtStack);
            var createdAtLabel = FindViewById<TextView>(Resource.Id.issueDetails_createdAtLabel);
            var updatedAtStack = FindViewById<LinearLayout>(Resource.Id.issueDetails_updatedAtStack);
            var updatedAtLabel = FindViewById<TextView>(Resource.Id.issueDetails_updatedAtLabel);
            var saveChangesButton = FindViewById<Button>(Resource.Id.issueDetails_saveButton);
            var deleteButton = FindViewById<Button>(Resource.Id.issueDetails_deleteButton);

            toolbar.SetNavigationIcon(Resource.Drawable.ic_arrow_back);
            toolbar.SetNavigationOnClickListener(this);

            statusSpinner.ItemsSource = Enum.GetValues(typeof(IssueStatusType)).Cast<IssueStatusType>().Select(x => x.GetEnumString());

            var set = CreateBindingSet();

            set.Bind(titleLabel)
                .For(t => t.Text)
                .To(vm => vm.Issue.Title);

            set.Bind(descriptionLabel)
                .For(t => t.Text)
                .To(vm => vm.Issue.Description);

            set.Bind(statusSpinner)
                .For(t => t.SelectedItem)
                .To(vm => vm.SelectedStatusStr);

            set.Bind(createdAtStack)
                .For(t => t.BindVisible())
                .To(vm => vm.IsOldIssue);

            set.Bind(createdAtLabel)
                .For(t => t.Text)
                .To(vm => vm.CreatedAtStr);

            set.Bind(updatedAtStack)
                .For(t => t.BindVisible())
                .To(vm => vm.UpdatedAtStr)
                .WithConversion<IsNotNullOrDefaultConverter>();

            set.Bind(updatedAtLabel)
                .For(t => t.Text)
                .To(vm => vm.UpdatedAtStr);

            set.Bind(saveChangesButton)
                .For(t => t.BindClick())
                .To(vm => vm.SaveChangesCommand);

            set.Bind(saveChangesButton)
                .For(t => t.Text)
                .To(vm => vm.SaveButtonTitle);

            set.Bind(deleteButton)
                .For(t => t.BindClick())
                .To(vm => vm.DeleteCommand);

            set.Bind(deleteButton)
                .For(t => t.BindVisible())
                .To(vm => vm.IsOldIssue);

            set.Apply();
        }

        public void OnClick(View v)
        {
            Finish();
        }
    }
}
