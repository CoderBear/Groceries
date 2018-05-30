using System;
using System.Collections.Generic;

namespace Groceries
{
    public static class PrepareFirstLists
    {
        public static void Prepare()
        {
            AppData.currentLists = new List<GroceryListClass>();

            AppData.currentLists.Add(new GroceryListClass()
            {
                Name = "Sample List",
                Owner = AppData.curUser,
                Items = new List<ItemClass>()
            });
        }
    }
}
