using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTO
{
    public class RootDTO
    {
        public int? ID { get; private set; }
        public string Title { get; private set; }
        public RootDTO(int? id, string title)
        {
            ID = id;
            Title = title;
        }
    }
}
