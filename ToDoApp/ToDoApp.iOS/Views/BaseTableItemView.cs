using System;
using MvvmCross.Platforms.Ios.Binding.Views;

namespace ToDoApp.iOS.Views
{
    public class BaseTableViewCell : MvxTableViewCell
    {
        private bool _didSetupConstraints;

        public BaseTableViewCell(IntPtr handle)
            : base(handle)
        {
            CreateView();

            SetNeedsUpdateConstraints();
        }

        public override void UpdateConstraints()
        {
            base.UpdateConstraints();

            if (_didSetupConstraints)
            {
                return;
            }

            CreateConstraints();

            _didSetupConstraints = true;
        }

        protected virtual void CreateView()
        {
        }

        protected virtual void CreateConstraints()
        {
        }
    }
}
