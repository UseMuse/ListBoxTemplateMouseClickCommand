﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTO
{
    public class ChildDto
    {
        public int? ID { get; private set; }
        public string Title { get; private set; }
        public int? ParentID { get; private set; }
        public ChildDto(int? id, string title, int? parentID)
        {
            ID = id;
            Title = title;
            ParentID = parentID;
        }
    }
}
