using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Root
{
    /// <summary>Интерфейс Модели для корневых элементов.</summary>
    public interface IRootLogic
    {
        /// <summary>Метод возвращающий все корневые элементы.</summary>
        /// <returns>Все корневые элементы.</returns>
        Task<IEnumerable<RootDTO>> GetRoots();

        /// <summary>Метод возвращающий корневой по его Id.</summary>
        /// <param name="rootId">Id корневого элемента.</param>
        /// <returns>Корневой элемент с указанным <see cref="RootDTO.ID"/>.</returns>
        /// <exception cref="ArgumentException">Выкидывается когда элемента
        /// с указанным <paramref name="rootId"/> нет.</exception>
        Task<RootDTO> GetRoot(int rootId);

        /// <summary>Метод возвращающий корневой по его title.</summary>
        /// <returns>Корневой элемент с указанным <see cref="RootDTO.Title"/>.</returns>
        /// <exception cref="ArgumentException">Выкидывается когда элемента
        /// с указанным <paramref name="title"/> нет.</exception>
        Task<RootDTO> GetRoot(string title);
    }
}
