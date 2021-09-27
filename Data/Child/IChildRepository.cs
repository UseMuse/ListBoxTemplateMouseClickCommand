using Data.Model;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Child
{
    public interface IChildRepository
    {
        /// <summary>Метод возвращающий дочернии элементы по его родительскому rootId.</summary>
        /// <param name="rootId">rootId родительского.</param>
        /// <returns>Дочернии элементы, если найдены с таким родительским rootId, иначе - <see langword="null"/>.</returns>
        IEnumerable<ChildDto> GetChildren(int rootId);

        /// <summary>Метод возвращающий дочерний по его Id.</summary>
        /// <param name="childId">Id искомого <see cref="ChildDto"/>.</param>
        /// <returns>Дочерний, если найден с таким Id, иначе - <see langword="null"/>.</returns>
        ChildDto GetChild(int childId);

        /// <summary>Метод возвращающий дочерний по его title.</summary>
        /// <param name="title">Title искомого <see cref="ChildDto"/>.</param>
        /// <returns>Дочерний, если найден с таким Title, иначе - <see langword="null"/>.</returns>
        ChildDto GetChild(string title);

        /// <summary>Метод обновляющий объект.</summary>
        /// <param name="oldChild">Экземпляр, который нужно обновить.</param>
        /// <param name="newChild">Экземпляр с данными для обновления.</param>
        /// <returns>Новый экземпляр <see cref="ChildDto"/> с обновлёнными данными.</returns>
        ChildDto UpdateRoot(ChildDto oldChild, ChildDto newChild);
    }
}
