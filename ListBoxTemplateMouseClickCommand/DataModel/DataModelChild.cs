using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.DataModel
{
    public class DataModelChild
    {
        public int? ID { get; set; }
        public string Title { get; set; }
        public int? ParentID { get; set; }
    }
}
