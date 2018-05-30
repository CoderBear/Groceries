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

            ListsDataSource tableDs = new ListsDataSource(this);
            groceryListTableView.Source = tableDs;

            AppData.curUser = new UserClass()
            {
                Name = "Joe",
                Email = "defEmail",
                Uid = "defUid"
            };
            PrepareFirstLists.Prepare();
            groceryListTableView.ReloadData();
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