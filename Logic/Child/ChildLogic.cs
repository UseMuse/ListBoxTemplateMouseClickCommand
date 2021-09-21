using Data.Model;
using Logic.Child;
using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic
{
    public partial class MainLogic : IChildLogic
    {

        /// <summary>Метод возвращает <see cref="ChildDto"/> с данными из переданного <see cref="ChildModel"/>.</summary>
        /// <param name="item">Экземпляр с данными.</param>
        /// <returns>Новый экземпляр <see cref="ChildDto"/> с данными из переданного <see cref="ChildModel"/>.</returns>
        internal static ChildDto Mapper(ChildModel item)
        {
            return new ChildDto(item.ID, item.Title, item.ParentID);
        }

        /// <summary>Метод возвращает <see cref="ChildModel"/> с данными из переданного <see cref="ChildDto"/>.</summary>
        /// <param name="item">Экземпляр с данными.</param>
        /// <returns>Новый экземпляр <see cref="ChildModel"/> с данными из переданного <see cref="ChildDto"/>.</returns>
        internal static ChildModel Mapper(ChildDto item)
        {
            return new ChildModel() { ID = item.Id ?? 0, Title = item.Title, ParentID = item.ParentID ?? 0 };
        }

        /// <inheritdoc cref="IChildLogic.GetChild(int)"/>
        public async Task<ChildDto> GetChild(int childId)
        {
            ChildModel item = await childRepository.GetChild(childId);
            if (item == null)
                throw new ArgumentException(nameof(childId));
            ChildDto dto = Mapper(item);
            return dto;
        }

        /// <inheritdoc cref="IChildLogic.GetChild(string)"/>
        public async Task<ChildDto> GetChild(string title)
        {
            ChildModel item = await childRepository.GetChild(title);
            if (item == null)
                throw new ArgumentException(nameof(title));
            ChildDto dto = Mapper(item);
            return dto;
        }

        /// <inheritdoc cref="IChildLogic.GetChildren()"/>
        public async Task<IEnumerable<ChildDto>> GetChildren()
        {
            IEnumerable<ChildModel> items = await childRepository.GetChildren();
            //List<ChildDTO> dtos = new List<ChildDTO>();
            //dtos.AddRange((from item in items select Mapper(item)).ToList());
            //return dtos;
            return Array.AsReadOnly(items.Select(Mapper).ToArray());
        }

        /// <inheritdoc cref="IChildLogic.GetChildren(int)"/>
        public async Task<IEnumerable<ChildDto>> GetChildren(int rootId)
        {
            IEnumerable<ChildModel> items = await childRepository.GetChildren(rootId);
            //List<ChildDTO> dtos = new List<ChildDTO>();
            //dtos.AddRange((from item in items select Mapper(item)).ToList());
            //return dtos;
            return Array.AsReadOnly(items.Select(Mapper).ToArray());
        }

        /// <inheritdoc cref="IChildLogic.UpdateChild(ChildDto)"/>
        public async Task<bool> UpdateChild(ChildDto updated)
        {
            try
            {
                return await childRepository.UpdateChild(Mapper(updated));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
