﻿namespace Logic.DTO
{
    public class ChildDto
    {
        public int Id { get; }
        public string Title { get; }
        public int ParentID { get; }
        public ChildDto(int id, string title, int parentID)
        {
            Id = id;
            Title = title;
            ParentID = parentID;
        }
    }
}
