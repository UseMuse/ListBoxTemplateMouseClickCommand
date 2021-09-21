﻿namespace Logic.DTO
{
    public class RootDto
    {
        public int Id { get; }
        public string Title { get; }
        public RootDto(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
