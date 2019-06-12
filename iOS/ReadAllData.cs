using System;
namespace Groceries.iOS
{
    public static class ReadAllData
    {
        public static void Read(ListViewController thisView)
        {
            ReadWrite.ReadUser();
            if(AppData.curUser == null)
            {
                AppData.curUser = new UserClass()
                {
                    Name = "Me",
                    Email = "defEmail",
                    Uid = "defUid"
                };

                PrepareFirstLists.Prepare();
                ReadWrite.WriteUser();
                ReadWrite.WriteData();
            }
            else
            {
                ReadWrite.ReadData();
                AppData.currentLists = AppData.offlineLists;
            }
        }
    }
}
