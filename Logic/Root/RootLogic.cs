using Data.Model;
using Data.Root;
using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Root
{
    public class RootLogic : IRootLogic
    {
        private readonly IRootRepository _rootRepository;

        public RootLogic(IRootRepository rootRepository)
        {
            _rootRepository = rootRepository;
        }

        private RootDTO map(RootModel item)
        {
            return new RootDTO(item.ID, item.Title);
        }

        public async Task<RootDTO> GetRoot(int rootId)
        {
            RootModel item = await _rootRepository.GetRoot(rootId);
            RootDTO dto = map(item);
            return dto;
        }

        public async Task<RootDTO> GetRoot(string title)
        {
            RootModel item = await _rootRepository.GetRoot(title);
            RootDTO dto = map(item);
            return dto;
        }

        public async Task<List<RootDTO>> GetRoots()
        {
            List<RootModel> items = await _rootRepository.GetRoots();
            List<RootDTO> dtos = new List<RootDTO>();
            dtos.AddRange((from item in items select map(item)).ToList());
            return dtos;
        }
    }
}
