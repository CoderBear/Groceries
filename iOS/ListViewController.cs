using Foundation;
using System;
using System.Collections.Generic;
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
            UIAlertController alert;
            alert = UIAlertController.Create("New List",
                                            "Please enter a name",
                                             UIAlertControllerStyle.Alert);

            alert.AddTextField((field) =>
            {
                field.Placeholder = "list name";
                field.KeyboardType = UIKeyboardType.Default;
                field.Font = UIFont.SystemFontOfSize(22);
                field.TextAlignment = UITextAlignment.Center;
            });

            UIAlertAction saveAction;
            saveAction = UIAlertAction.Create("Save",
                                              UIAlertActionStyle.Default,
                                              (obj) => SaveAction(alert.TextFields[0].Text));
            alert.AddAction(saveAction);
            alert.AddAction(UIAlertAction.Create("Cancel",
                                                 UIAlertActionStyle.Cancel,
                                                 null));

            PresentViewController(alert, true, null);
        }

        void SaveAction(string inpListName)
        {
            GroceryListClass newList = new GroceryListClass()
            {
                Name = inpListName,
                Owner = AppData.curUser,
                Items = new List<ItemClass>()
            };

            AppData.currentLists.Add(newList);

            groceryListTableView.ReloadData();
        }

        partial void ProfileButton_TouchUpInside(UIButton sender)
        {
            throw new NotImplementedException();
        }
    }
}