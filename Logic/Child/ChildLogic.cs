using Data.Child;
using Data.Model;
using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Child
{
    public class ChildLogic : IChildLogic
    {
        private readonly IChildRepository _childRepository;

        public ChildLogic(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        private ChildDTO map(ChildModel item)
        {
           return new ChildDTO(item.ID, item.Title, item.ParentID);
        }

        public async Task<ChildDTO> GetChild(int childId)
        {
            ChildModel item = await _childRepository.GetChild(childId);
            ChildDTO dto = map(item);
            return dto;
        }

        public async Task<ChildDTO> GetChild(string title)
        {
            ChildModel item = await _childRepository.GetChild(title);
            ChildDTO dto = map(item);
            return dto;
        }

        public async Task<List<ChildDTO>> GetChildren()
        {
            List<ChildModel> items = await _childRepository.GetChildren();
            List<ChildDTO> dtos = new List<ChildDTO>();
            dtos.AddRange((from item in items select map(item)).ToList());
            return dtos;
        }

        public async Task<List<ChildDTO>> GetChildren(int rootId)
        {
            List<ChildModel> items = await _childRepository.GetChildren(rootId);
            List<ChildDTO> dtos = new List<ChildDTO>();
            dtos.AddRange((from item in items select map(item)).ToList());
            return dtos;
        }
    }
}
