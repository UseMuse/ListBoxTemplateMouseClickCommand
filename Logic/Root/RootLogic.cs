using DTO;
using Logic.Root;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic
{
    public partial class MainLogic : IRootLogic
    {
        ///// <summary>Метод возвращает <see cref="RootDto"/> с данными из переданного <see cref="RootModel"/>.</summary>
        ///// <param name="item">Экземпляр с данными.</param>
        ///// <returns>Новый экземпляр <see cref="RootDto"/> с данными из переданного <see cref="RootModel"/>.</returns>
        //internal static RootDto Mapper(RootModel item)
        //{
        //    return new RootDto(item.ID, item.Title);
        //}

        ///// <summary>Метод возвращает <see cref="RootModel"/> с данными из переданного <see cref="RootDto"/>.</summary>
        ///// <param name="item">Экземпляр с данными.</param>
        ///// <returns>Новый экземпляр <see cref="RootModel"/> с данными из переданного <see cref="RootDto"/>.</returns>
        //internal static RootModel Mapper(RootDto item)
        //{
        //    return new RootModel() { ID = item.Id ?? 0, Title = item.Title };
        //}

        /// <inheritdoc cref="IRootLogic.GetRootAsync(int)"/>
        public Task<RootDto> GetRootAsync(int rootId)
        {
            //RootModel item = await rootRepository.GetRoot(rootId);
            //if (item == null)
            //    throw new ArgumentException(nameof(rootId));
            //RootDto dto = Mapper(item);
            //return dto;

            return Task.Run(() => rootRepository.GetRoot(rootId));
        }

        /// <inheritdoc cref="IRootLogic.GetRootAsync(string)"/>
        public Task<RootDto> GetRootAsync(string title)
        {
            //RootModel item = await rootRepository.GetRoot(title);
            //if (item == null)
            //    throw new ArgumentException(nameof(title));
            //RootDto dto = Mapper(item);
            //return dto;
            return Task.Run(() => rootRepository.GetRoot(title));
        }

        /// <inheritdoc cref="IRootLogic.GetRootsAsync()"/>
        public Task<IEnumerable<RootDto>> GetRootsAsync()
        {
            //IEnumerable<RootModel> items = await rootRepository.GetRoots();
            ////List<RootDTO> dtos = new List<RootDTO>();
            ////dtos.AddRange((from item in items select map(item)).ToList());
            ////return dtos;
            //return Array.AsReadOnly(items.Select(Mapper).ToArray());
            return Task.Run(rootRepository.GetRoots);
        }

        /// <inheritdoc cref="IRootLogic.UpdateRootAsync(RootDto)"/>
        public Task<RootDto> UpdateRootAsync(RootDto oldRoot, RootDto newRoot)
        {
            return Task.Run(() => rootRepository.UpdateRoot(oldRoot, newRoot));
        }

        /// <inheritdoc cref="IRootLogic.AddRootAsync(RootDto)"/>
        public Task<RootDto> AddRootAsync(RootDto dto)
        {
            return Task.Run(() => rootRepository.AddRoot(dto));
        }
    }
}
