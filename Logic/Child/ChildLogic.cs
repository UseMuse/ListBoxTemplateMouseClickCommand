using DTO;
using Logic.Child;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic
{
    public partial class MainLogic : IChildLogic
    {
        /// <inheritdoc cref="IChildLogic.AddRootAsync(ChildDto)"/>
        public Task<ChildDto> AddRootAsync(ChildDto dto)
        {
            return Task.Run(() => childRepository.AddRoot(dto));
        }

        /// <inheritdoc cref="IChildLogic.GetChildAsync(int)"/>
        public Task<ChildDto> GetChildAsync(int childId)
        {
            return Task.Run(() => childRepository.GetChild(childId));
        }

        /// <inheritdoc cref="IChildLogic.GetChildAsync(string)"/>
        public Task<ChildDto> GetChildAsync(string title)
        {
            return Task.Run(() => childRepository.GetChild(title));
        }

        /// <inheritdoc cref="IChildLogic.GetChildrenAsync())"/>
        public Task<IEnumerable<ChildDto>> GetChildrenAsync()
        {
            return Task.Run(() => childRepository.GetChildren());
        }

        /// <inheritdoc cref="IChildLogic.GetChildrenAsync(int))"/>
        public Task<IEnumerable<ChildDto>> GetChildrenAsync(int rootId)
        {
            return Task.Run(() => childRepository.GetChildren(rootId));
        }

        /// <inheritdoc cref="IChildLogic.UpdateRoot(ChildDto, ChildDto))"/>
        public Task<ChildDto> UpdateRoot(ChildDto oldChild, ChildDto newChild)
        {
            return Task.Run(() => childRepository.UpdateRoot(oldChild, newChild));
        }
    }
}
