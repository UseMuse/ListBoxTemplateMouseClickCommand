using DTO;
using Logic.Root;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic
{
    public partial class MainLogic : IRootLogic
    {

        /// <inheritdoc cref="IRootLogic.GetRootAsync(int)"/>
        public Task<RootDto> GetRootAsync(int rootId)
        {
            return Task.Run(() => rootRepository.GetRoot(rootId));
        }

        /// <inheritdoc cref="IRootLogic.GetRootAsync(string)"/>
        public Task<RootDto> GetRootAsync(string title)
        {
            return Task.Run(() => rootRepository.GetRoot(title));
        }

        /// <inheritdoc cref="IRootLogic.GetRootsAsync()"/>
        public Task<IEnumerable<RootDto>> GetRootsAsync()
        {
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
