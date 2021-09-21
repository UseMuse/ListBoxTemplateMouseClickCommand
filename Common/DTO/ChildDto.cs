namespace DTO
{
    public class ChildDto : IdDto<int>
    {
        public string Title { get; }
        public int ParentID { get; }
        public ChildDto(int id, string title, int parentID)
            : base(id)
        {
            Title = title;
            ParentID = parentID;
        }
    }
}
