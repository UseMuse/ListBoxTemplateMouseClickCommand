using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Root
{
    public interface IRootLogic
    {
        /// <summary>
        /// Метод возвращающий все корневые элементы
        /// </summary>
        /// <returns>все корневые элементы</returns>
        Task<List<RootDTO>> GetRoots();

        /// <summary>
        /// Метод возвращающий корневой по его Id
        /// </summary>
        /// <returns>корневой</returns>
        Task<RootDTO> GetRoot(int rootId);

        /// <summary>
        /// Метод возвращающий корневой по его title
        /// </summary>
        /// <returns>корневой</returns>
        Task<RootDTO> GetRoot(string title);
    }
}
