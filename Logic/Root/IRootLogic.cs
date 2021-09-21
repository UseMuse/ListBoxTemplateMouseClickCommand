using DTO;
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
        Task<IEnumerable<RootDto>> GetRootsAsync();

        /// <summary>Метод возвращающий корневой по его Id.</summary>
        /// <param name="rootId">Id корневого элемента.</param>
        /// <returns>Корневой элемент с указанным <see cref="RootDto.Id"/>.</returns>
        /// <exception cref="ArgumentException">Выкидывается когда элемента
        /// с указанным <paramref name="rootId"/> нет.</exception>
        Task<RootDto> GetRootAsync(int rootId);

        /// <summary>Метод возвращающий корневой по его title.</summary>
        /// <returns>Корневой элемент с указанным <see cref="RootDto.Title"/>.</returns>
        /// <exception cref="ArgumentException">Выкидывается когда элемента
        /// с указанным <paramref name="title"/> нет.</exception>
        Task<RootDto> GetRootAsync(string title);

        /// <summary>
        /// Метод обновляющий корневой объект
        /// </summary>
        /// <returns>Флаг успешности обновления. Любая ошибка распознаётся как не успех</returns>
        Task<RootDto> UpdateRootAsync(RootDto oldRoot, RootDto newRoot);

        /// <summary>Добавляет корневой объект.</summary>
        /// <param name="dto">Экземпляр с данными для нового корневого элемента.</param>
        /// <returns>Новый экземпляр <see cref="RootDto"/> с данными добавленного элемента.</returns>
        Task<RootDto> AddRootAsync(RootDto dto);
    }
}
