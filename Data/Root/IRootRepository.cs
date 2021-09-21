using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Root
{
    public interface IRootRepository
    {
        /// <summary>
        /// Метод возвращающий все корневые элементы
        /// </summary>
        /// <returns>все корневые элементы</returns>
        Task<List<RootModel>> GetRoots();

        /// <summary>
        /// Метод возвращающий корневой по его Id
        /// </summary>
        /// <returns>корневой</returns>
        Task<RootModel> GetRoot(int rootId);

        /// <summary>
        /// Метод возвращающий корневой по его title
        /// </summary>
        /// <returns>корневой</returns>
        Task<RootModel> GetRoot(string title);

        /// <summary>
        /// Метод обновляющий корневой объект
        /// </summary>
        /// <returns>Флаг успешности обновления</returns>
        Task<bool> UpdateRoot(RootModel updated);
    }
}
