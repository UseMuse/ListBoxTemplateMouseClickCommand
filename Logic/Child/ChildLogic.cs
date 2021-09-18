using Data.Child;
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
        private readonly IChildRepository _childRepository;

        public MainLogic(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        /// <summary>Метод возвращает <see cref="ChildDTO"/> с данными из переданного <see cref="ChildModel"/>.</summary>
        /// <param name="item">Экземпляр с данными.</param>
        /// <returns>Новый экземпляр <see cref="ChildDTO"/> с данными из переданного <see cref="ChildModel"/>.</returns>
        internal static ChildDTO Mapper(ChildModel item)
        {
            return new ChildDTO(item.ID, item.Title, item.ParentID);
        }

        /// <inheritdoc cref="IChildLogic.GetChild(int)"/>
        public async Task<ChildDTO> GetChild(int childId)
        {
            ChildModel item = await _childRepository.GetChild(childId);
            if (item == null)
                throw new ArgumentException(nameof(childId));
            ChildDTO dto = Mapper(item);
            return dto;
        }

        /// <inheritdoc cref="IChildLogic.GetChild(string)"/>
        public async Task<ChildDTO> GetChild(string title)
        {
            ChildModel item = await _childRepository.GetChild(title);
            if (item == null)
                throw new ArgumentException(nameof(title));
            ChildDTO dto = Mapper(item);
            return dto;
        }

        /// <inheritdoc cref="IChildLogic.GetChildren()"/>
        public async Task<IEnumerable<ChildDTO>> GetChildren()
        {
            IEnumerable<ChildModel> items = await _childRepository.GetChildren();
            //List<ChildDTO> dtos = new List<ChildDTO>();
            //dtos.AddRange((from item in items select Mapper(item)).ToList());
            //return dtos;
            return Array.AsReadOnly(items.Select(Mapper).ToArray());
        }

        /// <inheritdoc cref="IChildLogic.GetChildren(int)"/>
        public async Task<IEnumerable<ChildDTO>> GetChildren(int rootId)
        {
            IEnumerable<ChildModel> items = await _childRepository.GetChildren(rootId);
            //List<ChildDTO> dtos = new List<ChildDTO>();
            //dtos.AddRange((from item in items select Mapper(item)).ToList());
            //return dtos;
            return Array.AsReadOnly(items.Select(Mapper).ToArray());
        }
    }
}
