using WPF.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF
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
        /// <summary>
        /// Обновление или добавление данных
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static bool SyncRoot(DataModelRoot data)
        {

            try
            {
                #region insert or update DB

                Random rand = new Random();

                if (rand.Next(0, 2) == 0)
                {
                    throw new Exception($"Ошибка SyncRoot. {DateTime.Now}");
                }
                else //данные успешно обвновлены/добавлены
                {

                }
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
        /// <summary>
        /// Обновление или добавление данных
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static bool SyncChild(DataModelChild data)
        {
            try
            {
                #region insert or update DB

                Random rand = new Random();

                if (rand.Next(0, 2) == 0)
                {
                    throw new Exception($"Ошибка SyncChild. {DateTime.Now}");
                }
                else //данные успешно обвновлены/добавлены
                {

                }

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
