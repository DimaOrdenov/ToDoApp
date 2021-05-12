using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using UIKit;
using Foundation;
using MvvmCross.Converters;
using MvvmCross.Platforms.Ios.Binding;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using ToDoApp.Definitions.Enums;
using ToDoApp.Extensions;
using ToDoApp.iOS.Styles;
using ToDoApp.ViewModels;

namespace ToDoApp.iOS.Views
{
    [MvxChildPresentation]
    public class IssueDetailsViewController : MvxViewController<IssueDetailsViewModel>
    {
        private UIStackView _stackView;
        private UILabel _titleLabel;
        private UITextField _titleField;
        private UILabel _descriptionLabel;
        private UITextView _descriptionField;
        private UILabel _statusLabel;
        private UIPickerView _statusPicker;
        private UILabel _createdAtLabel;
        private UILabel _updatedAtLabel;
        private UIButton _saveChangesButton;
        private UIButton _deleteIssueButton;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Issue info";
            View.BackgroundColor = Colors.MainBackground;
            EdgesForExtendedLayout = UIRectEdge.None;

            View.AddGestureRecognizer(new UITapGestureRecognizer(() => View.EndEditing(true)) { CancelsTouchesInView = false });

            var toolbar = new UIToolbar
            {
                Items = new[]
                {
                    UIBarButtonItem.FlexibleSpaceItem,
                    new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender, args) => View.EndEditing(true)),
                },
            };
            toolbar.SizeToFit();

            _titleLabel = new UILabel
            {
                Text = "Title:",
            };

            _titleField = new UITextField
            {
                TextColor = Colors.TextOnWhite,
                InputAccessoryView = toolbar,
                BackgroundColor = UIColor.White,
            };

            _descriptionLabel = new UILabel
            {
                Text = "Description:",
            };

            _descriptionField = new UITextView(new CGRect(0, 0, CGRect.Infinite.Width, 100f))
            {
                TextColor = Colors.TextOnWhite,
                InputAccessoryView = toolbar,
            };

            _statusLabel = new UILabel
            {
                Text = "Status:",
            };

            _statusPicker = new UIPickerView();
            var statusPickerModel = new MvxPickerViewModel(_statusPicker)
            {
                ItemsSource = Enum.GetValues(typeof(IssueStatusType)).Cast<IssueStatusType>().Select(x => x.GetEnumString()),
            };
            _statusPicker.Model = statusPickerModel;

            _createdAtLabel = new UILabel
            {
                TextColor = Colors.TextOnWhite,
            };

            _updatedAtLabel = new UILabel
            {
                TextColor = Colors.TextOnWhite,
            };

            _deleteIssueButton = new UIButton
            {
                BackgroundColor = UIColor.SystemRedColor,
            };
            _deleteIssueButton.SetTitle("Delete issue", UIControlState.Normal);
            _deleteIssueButton.SetTitleColor(UIColor.LightGray, UIControlState.Highlighted);

            _saveChangesButton = new UIButton
            {
                BackgroundColor = Colors.Accent,
            };
            _saveChangesButton.SetTitle("Save changes", UIControlState.Normal);
            _saveChangesButton.SetTitleColor(UIColor.LightGray, UIControlState.Highlighted);

            _stackView = new UIStackView
            {
                Axis = UILayoutConstraintAxis.Vertical,
                Spacing = 8,
            };

            var createdAtStackView = new UIStackView
            {
                Axis = UILayoutConstraintAxis.Vertical,
            };
            createdAtStackView.AddArrangedSubview(new UILabel
            {
                Text = "Created:",
            });
            createdAtStackView.AddArrangedSubview(_createdAtLabel);

            var updatedAtStackView = new UIStackView
            {
                Axis = UILayoutConstraintAxis.Vertical,
            };
            updatedAtStackView.AddArrangedSubview(new UILabel
            {
                Text = "Updated:",
            });
            updatedAtStackView.AddArrangedSubview(_updatedAtLabel);

            _stackView.AddArrangedSubview(_titleLabel);
            _stackView.AddArrangedSubview(_titleField);
            _stackView.AddArrangedSubview(_descriptionLabel);
            _stackView.AddArrangedSubview(_descriptionField);
            _stackView.AddArrangedSubview(_statusLabel);
            _stackView.AddArrangedSubview(_statusPicker);
            _stackView.AddArrangedSubview(createdAtStackView);
            _stackView.AddArrangedSubview(updatedAtStackView);
            _stackView.AddArrangedSubview(_saveChangesButton);
            _stackView.AddArrangedSubview(_deleteIssueButton);

            View.AddSubview(_stackView);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _stackView.AtLeftOf(View).Plus(16),
                _stackView.AtTopOf(View).Plus(16),
                _stackView.AtRightOf(View).Minus(16),
                _stackView.AtBottomOf(View).Minus(40)
            );

            var set = CreateBindingSet();

            set.Bind(_titleField)
                .For(x => x.Text)
                .To(vm => vm.Issue.Title);

            set.Bind(_descriptionField)
                .For(x => x.Text)
                .To(vm => vm.Issue.Description);

            set.Bind(statusPickerModel)
                .For(x => x.SelectedItem)
                .To(vm => vm.SelectedStatusStr);

            set.Bind(_createdAtLabel)
                .For(x => x.Text)
                .To(vm => vm.CreatedAtStr);

            set.Bind(_updatedAtLabel)
                .For(x => x.Text)
                .To(vm => vm.UpdatedAtStr);

            set.Bind(createdAtStackView)
                .For(x => x.BindVisibility())
                .To(vm => vm.IsOldIssue)
                .WithConversion(new BoolNegativeConverter());

            set.Bind(updatedAtStackView)
                .For(x => x.BindVisibility())
                .To(vm => vm.Issue.UpdatedAt)
                .WithConversion(new IsNullOrDefaultConverter());

            set.Bind(_deleteIssueButton)
                .For(x => x.BindTap())
                .To(vm => vm.DeleteCommand);

            set.Bind(_saveChangesButton)
                .For(x => x.BindTap())
                .To(vm => vm.SaveChangesCommand);

            set.Bind(_deleteIssueButton)
                .For(x => x.BindVisibility())
                .To(vm => vm.IsOldIssue)
                .WithConversion(new BoolNegativeConverter());

            set.Bind(_saveChangesButton)
                .For(x => x.BindTitle())
                .To(vm => vm.SaveButtonTitle);

            set.Apply();
        }
    }

    public class BoolNegativeConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value;
        }
    }

    public class IsNullOrDefaultConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string strValue)
            {
                return string.IsNullOrEmpty(strValue);
            }

            if (value is DateTimeOffset dateTimeOffsetValue)
            {
                return dateTimeOffsetValue == default;
            }

            return value == null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
