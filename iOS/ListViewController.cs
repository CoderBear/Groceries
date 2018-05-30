using Foundation;
using System;
using UIKit;

namespace Groceries.iOS
{
    public partial class ListViewController : UIViewController
    {
        public ListViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        partial void NewListButton_TouchUpInside(UIButton sender)
        {
            throw new NotImplementedException();
        }

        partial void ProfileButton_TouchUpInside(UIButton sender)
        {
            throw new NotImplementedException();
        }
    }
}