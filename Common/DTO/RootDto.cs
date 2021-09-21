using Interfaces;

namespace DTO
{
    public class RootDto : IdDto<int>
    {
        public string Title { get; }
        public RootDto(int id, string title)
            : base(id)
        {
            Title = title;
        }
    }
}
