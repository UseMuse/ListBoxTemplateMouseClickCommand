using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Child
{
    public interface IChildRepository
    {
        /// <summary>
        /// Метод возвращающий все дочерние элементы
        /// </summary>
        /// <returns>все дочерние элементы</returns>
        Task<List<ChildModel>> GetChildren();

        /// <summary>
        /// Метод возвращающий все дочерние элементы по Id родительского элемента
        /// </summary>
        /// <returns>все дочерние элементы по Id родительского элемента</returns>
         Task<List<ChildModel>> GetChildren(int rootId);

        /// <summary>
        /// Метод возвращающий дочерний по его Id
        /// </summary>
        /// <returns>корневой</returns>
        Task<ChildModel> GetChild(int childId);

        /// <summary>
        /// Метод возвращающий дочерний по его Id
        /// </summary>
        /// <returns>корневой</returns>
        Task<ChildModel> GetChild(string title);
    }
}
