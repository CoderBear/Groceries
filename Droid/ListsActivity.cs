﻿
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListsLayout);

            InterfaceBuilder();
        }

        void InterfaceBuilder()
        {
            newListButton = FindViewById<Button>(Resource.Id.newListButton_id);
            newListButton.Click += NewListButton_Click;

            groceryListView = FindViewById<ListView>(Resource.Id.groceryListView_id);
            groceryListView.ItemClick += GotoItems;
            groceryListView.ItemLongClick += DeleteListAlert;

            profileButton = FindViewById<Button>(Resource.Id.profileButton_id);
            profileButton.Click += ProfileButton_Click;
        }

        void DeleteListAlert(object sender, AdapterView.ItemLongClickEventArgs e)
        {
        }

        void GotoItems(object sender, AdapterView.ItemClickEventArgs e)
        {
        }


        void NewListButton_Click(object sender, EventArgs e)
        {
        }

        void ProfileButton_Click(object sender, EventArgs e)
        {
        }

    }
}
