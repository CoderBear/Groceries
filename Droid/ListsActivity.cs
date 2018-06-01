
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Groceries.Droid
{
    [Activity(Label = "ListsActivity", MainLauncher = true, Icon = "@mipmap/icon")]
    public class ListsActivity : Activity
    {
        Button newListButton;
        ListView groceryListView;
        Button profileButton;
        ListRowCustomAdapter groceryAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListsLayout);

            InterfaceBuilder();

            AppData.GetInstance();
            AppData.curUser = new UserClass()
            {
                Name = "Joe",
                Email = "defEmail",
                Uid = "defUid"
            };
            PrepareFirstLists.Prepare();

            groceryAdapter = new ListRowCustomAdapter(this, AppData.currentLists);
            groceryListView.Adapter = groceryAdapter;
        }

        void InterfaceBuilder()
        {
            newListButton = FindViewById<Button>(Resource.Id.newListButton_id);
            newListButton.Click += NewListAlertView;

            groceryListView = FindViewById<ListView>(Resource.Id.groceryListView_id);
            groceryListView.ItemClick += GotoItems;
            groceryListView.ItemLongClick += DeleteListAlert;

            profileButton = FindViewById<Button>(Resource.Id.profileButton_id);
            profileButton.Click += ProfileAction;
        }

        void DeleteListAlert(object sender, AdapterView.ItemLongClickEventArgs e)
        {
        }

        void GotoItems(object sender, AdapterView.ItemClickEventArgs e)
        {
        }

        void NewListAlertView(object sender, EventArgs e)
        {
            AlertDialog.Builder alert;
            alert = new AlertDialog.Builder(this);
            alert.SetTitle("New List");
            alert.SetMessage("Please enter the name of your new list");

            EditText input = new EditText(this)
            {
                TextSize = 22,
                Gravity = GravityFlags.Center,
                Hint = "New List"
            };
            input.SetSingleLine(true);
            alert.SetView(input);

            alert.SetPositiveButton("Save",
                                    (senderAleert, eAlert) => NewListSave(input.Text));
            alert.SetNegativeButton("Cancel",
                                    (senderAlert, eAlert) => { });
            
            Dialog dialog = alert.Create();
            dialog.Show();
        }

        void NewListSave(string inpListName)
        {
            GroceryListClass newList = new GroceryListClass()
            {
                Name = inpListName,
                Owner = AppData.curUser,
                Items = new List<ItemClass>()
            };

            AppData.currentLists.Add(newList);
            groceryAdapter.NotifyDataSetChanged();
        }

        void ProfileAction(object sender, EventArgs e)
        {
        }
    }
}
