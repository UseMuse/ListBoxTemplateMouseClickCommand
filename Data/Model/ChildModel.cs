using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class ChildModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int ParentID { get; set; }
    }
}
