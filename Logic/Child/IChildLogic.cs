using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Child
{
    public interface IChildLogic
    {
        /// <summary>
        /// Метод возвращающий все дочерние элементы
        /// </summary>
        /// <returns>все дочерние элементы</returns>
        Task<List<ChildDTO>> GetChildren();

        /// <summary>
        /// Метод возвращающий все дочерние элементы по Id родительского элемента
        /// </summary>
        /// <returns>все дочерние элементы по Id родительского элемента</returns>
        Task<List<ChildDTO>> GetChildren(int rootId);

        /// <summary>
        /// Метод возвращающий дочерний по его Id
        /// </summary>
        /// <returns>корневой</returns>
        Task<ChildDTO> GetChild(int childId);

        /// <summary>
        /// Метод возвращающий дочерний по его Id
        /// </summary>
        /// <returns>корневой</returns>
        Task<ChildDTO> GetChild(string title);
    }
}
