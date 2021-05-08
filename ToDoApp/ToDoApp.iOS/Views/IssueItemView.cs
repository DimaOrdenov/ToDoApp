using System;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using ToDoApp.iOS.Styles;
using UIKit;

namespace ToDoApp.iOS.Views
{
    public class IssueItemView : BaseTableViewCell
    {
        private UILabel _titleLabel;
        private UILabel _statusLabel;
        private UILabel _dateLabel;

        public IssueItemView(IntPtr handle)
            : base(handle)
        {
        }

        protected override void CreateView()
        {
            base.CreateView();

            SelectionStyle = UITableViewCellSelectionStyle.Default;

            _titleLabel = new UILabel
            {
                TextColor = Colors.TextOnWhite,
            };
            _titleLabel.Font = _titleLabel.Font.WithSize(20);

            _statusLabel = new UILabel
            {
                TextColor = Colors.TextOnWhite,
            };

            _dateLabel = new UILabel
            {
                TextColor = Colors.TextOnWhite,
            };

            ContentView.AddSubviews(
                _titleLabel,
                _statusLabel,
                _dateLabel
            );

            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.DelayBind(() =>
            {
                this.AddBindings(_titleLabel, "Text Item.Title");
                this.AddBindings(_statusLabel, "Text StatusStr");
                this.AddBindings(_dateLabel, "Text CreatedAtStr");
            });
        }

        protected override void CreateConstraints()
        {
            base.CreateConstraints();

            ContentView.AddConstraints(
                _titleLabel.AtTopOf(ContentView).Plus(16),
                _titleLabel.AtLeftOf(ContentView).Plus(16),
                _titleLabel.AtRightOf(ContentView).Minus(16),
                _statusLabel.Below(_titleLabel),
                _statusLabel.WithSameLeft(_titleLabel),
                _statusLabel.WithSameRight(_titleLabel),
                _dateLabel.Below(_statusLabel),
                _dateLabel.WithSameLeft(_titleLabel),
                _dateLabel.WithSameRight(_titleLabel),
                _dateLabel.AtBottomOf(ContentView).Minus(16)
            );
        }
    }
}
