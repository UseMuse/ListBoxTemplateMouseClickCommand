using Data.Model;
using DTO;
using System.Collections.Generic;

namespace Data.Root
{
    public interface IRootRepository
    {
        /// <summary>Метод возвращающий все корневые элементы.</summary>
        /// <returns>Все корневые элементы.</returns>
        IEnumerable<RootDto> GetRoots();

        /// <summary>Метод возвращающий корневой по его Id.</summary>
        /// <param name="rootId">Id искомого <see cref="RootDto"/>.</param>
        /// <returns>Корневой, если найден с таким Id, иначе - <see langword="null"/>.</returns>
        RootDto GetRoot(int rootId);

        /// <summary>Метод возвращающий корневой по его title.</summary>
        /// <param name="title">Title искомого <see cref="RootDto"/>.</param>
        /// <returns>Корневой, если найден с таким Title, иначе - <see langword="null"/>.</returns>
        RootDto GetRoot(string title);

        /// <summary>Метод обновляющий корневой объект.</summary>
        /// <param name="oldRoot">Экземпляр, который нужно обновить.</param>
        /// <param name="newRoot">Экземпляр с данными для обновления.</param>
        /// <returns>Новый экземпляр <see cref="RootDto"/> с обновлёнными данными.</returns>
        RootDto UpdateRoot(RootDto oldRoot, RootDto newRoot);

        /// <summary>Добавляет корневой объект.</summary>
        /// <param name="dto">Экземпляр с данными для нового корневого элемента.</param>
        /// <returns>Новый экземпляр <see cref="RootDto"/> с данными добавленного элемента.</returns>
        RootDto AddRoot(RootDto dto);
    }
}
