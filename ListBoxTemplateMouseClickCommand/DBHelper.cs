using ListBoxTemplateMouseClickCommand.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxTemplateMouseClickCommand
{
    public static class DBHelper
    {
        public static List<DataModelRoot> GetRoots()
        {
            List<DataModelRoot> items = new List<DataModelRoot>();
            for (int i = 0; i < 2; i++)
            {
                var newItem = new DataModelRoot() { ID = i, Title = $"Корневой элемент: {DateTime.Now}" };
                items.Add(newItem);
            }
            return items;
        }

        internal static bool SyncRoot(DataModelRoot data)
        {

            try
            {
                #region insert or update DB

                #endregion

                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        internal static List<DataModelChild> GetChildren(int ID)
        {
            List<DataModelChild> items = new List<DataModelChild>();
            for (int i = 0; i < 3; i++)
            {
                var newItem = new DataModelChild() { ID = i, Title = $"Дочерний элемент: {DateTime.Now}", ParentID = ID };
                items.Add(newItem);
            }
            return items;
        }

        internal static bool SyncChild(DataModelChild data)
        {
            try
            {
                #region insert or update DB

                #endregion

                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
    }
}
