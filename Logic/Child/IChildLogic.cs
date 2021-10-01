using DTO;
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
        Task<IEnumerable<ChildDto>> GetChildrenAsync();

        /// <summary>Метод возвращающий все дочерние элементы по Id родительского элемента.</summary>
        /// <param name="rootId">Id родительского элемента.</param>
        /// <returns>Все дочерние элементы по Id родительского элемента.</returns>
        Task<IEnumerable<ChildDto>> GetChildrenAsync(int rootId);

        /// <summary>Метод возвращающий дочерний элемент по его Id.</summary>
        /// <param name="childId">Id дочернего элемента.</param>
        /// <returns>Дочерний элемент с указанным <see cref="ChildDto.Id"/>.</returns>
        /// <exception cref="ArgumentException">Выкидывается когда элемента
        /// с указанным <paramref name="childId"/> нет.</exception>
        Task<ChildDto> GetChildAsync(int childId);

        /// <summary>Метод возвращающий дочерний элемент по его Title.</summary>
        /// <param name="title">Title дочернего элемента.</param>
        /// <returns>Дочерний элемент с указанным <see cref="ChildDto.Title"/>.</returns>
        /// <exception cref="ArgumentException">Выкидывается когда элемента
        /// с указанным <paramref name="title"/> нет.</exception>
        Task<ChildDto> GetChildAsync(string title);

        /// <summary>Метод обновляющий объект.</summary>
        /// <param name="oldChild">Экземпляр, который нужно обновить.</param>
        /// <param name="newChild">Экземпляр с данными для обновления.</param>
        /// <returns>Новый экземпляр <see cref="ChildDto"/> с обновлёнными данными.</returns>
        /// <exception cref="ArgumentException">Выкидывается когда элемента
        /// с указанным <paramref name="childId"/> нет или когда у него отличается Title.</exception>
        Task<ChildDto> UpdateRoot(ChildDto oldChild, ChildDto newChild);

        /// <summary>Добавляет дочерний объект.</summary>
        /// <param name="dto">Экземпляр с данными для нового дочернего элемента.</param>
        /// <returns>Новый экземпляр <see cref="ChildDto"/> с данными добавленного элемента.</returns>
        Task<ChildDto> AddRootAsync(ChildDto dto);

    }
}
