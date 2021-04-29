using System;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using ToDoApp.iOS.Styles;
using UIKit;

namespace ToDoApp.iOS.Views
{
    public class IssueItemView : MvxTableViewCell
    {
        private readonly UILabel _titleLabel;
        private readonly UILabel _statusLabel;
        private readonly UILabel _dateLabel;
        private bool _didSetupConstraints;

        public IssueItemView(IntPtr handle)
            : base(handle)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Default;

            _titleLabel = new UILabel
            {
                TextColor = Colors.TextOnWhite,
                BackgroundColor = UIColor.LightGray,
            };

            _statusLabel = new UILabel
            {
                TextColor = Colors.TextOnWhite,
                BackgroundColor = UIColor.Red,
            };

            _dateLabel = new UILabel
            {
                TextColor = Colors.TextOnWhite,
                BackgroundColor = UIColor.Blue,
            };

            ContentView.AddSubviews(
                _titleLabel,
                _statusLabel
                // ,
                // _dateLabel
                );
            
            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.DelayBind(() =>
            {
                this.AddBindings(_titleLabel, "Text Title");
                this.AddBindings(_statusLabel, "Text StatusStr");
                this.AddBindings(_dateLabel, "Text CreatedAtStr");
            });

            SetNeedsUpdateConstraints();
        }

        public override void UpdateConstraints()
        {
            if (!_didSetupConstraints)
            {
                ContentView.AddConstraints(
                    _titleLabel.AtTopOf(ContentView),
                    _titleLabel.AtLeftOf(ContentView),
                    _titleLabel.AtRightOf(ContentView),
                    _titleLabel.AtBottomOf(_statusLabel),
                    
                    _statusLabel.AtBottomOf(_titleLabel),
                    _statusLabel.AtLeftOf(ContentView),
                    _statusLabel.AtRightOf(ContentView)
                    // ,
                    // _dateLabel.AtBottomOf(_statusLabel),
                    // _dateLabel.AtLeftOf(ContentView),
                    // _dateLabel.AtRightOf(ContentView)
                    );

                _didSetupConstraints = true;
            }

            base.UpdateConstraints();
        }
    }
}
