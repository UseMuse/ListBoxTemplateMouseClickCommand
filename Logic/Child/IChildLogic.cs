using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Child
{
    /// <summary>Интерфейс Модели для дочерних элементов.</summary>
    public interface IChildLogic
    {
        /// <summary>Метод возвращающий все дочерние элементы.</summary>
        /// <returns>все дочерние элементы</returns>
        Task<IEnumerable<ChildDTO>> GetChildren();

        /// <summary>Метод возвращающий все дочерние элементы по Id родительского элемента.</summary>
        /// <param name="rootId">Id родительского элемента.</param>
        /// <returns>Все дочерние элементы по Id родительского элемента.</returns>
        Task<IEnumerable<ChildDTO>> GetChildren(int rootId);

        /// <summary>Метод возвращающий дочерний элемент по его Id.</summary>
        /// <param name="childId">Id дочернего элемента.</param>
        /// <returns>Дочерний элемент с указанным <see cref="ChildDTO.ID"/>.</returns>
        /// <exception cref="ArgumentException">Выкидывается когда элемента
        /// с указанным <paramref name="childId"/> нет.</exception>
        Task<ChildDTO> GetChild(int childId);

        /// <summary>Метод возвращающий дочерний элемент по его Title.</summary>
        /// <param name="title">Title дочернего элемента.</param>
        /// <returns>Дочерний элемент с указанным <see cref="ChildDTO.Title"/>.</returns>
        /// <exception cref="ArgumentException">Выкидывается когда элемента
        /// с указанным <paramref name="title"/> нет.</exception>
        Task<ChildDTO> GetChild(string title);
    }
}
