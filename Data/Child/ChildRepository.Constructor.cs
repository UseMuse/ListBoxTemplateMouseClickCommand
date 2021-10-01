using Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Child
{
    public partial class ChildRepository
    {
        public bool IsDemoData { get; }

        public ChildRepository()
            : this(true)
        { }

        public ChildRepository(bool isDemoData)
        {
            IsDemoData = isDemoData;
        }
        protected readonly Dictionary<int, ChildModel> DemoData = new List<ChildModel>()
        {
            new ChildModel() {ID=12, ParentID=123, Title="Firs-Firs" },
            new ChildModel() {ID=121, ParentID=123, Title="Firs-Second" },
            new ChildModel() {ID=122, ParentID=34, Title="Second-Firs" },
            new ChildModel() {ID=221, ParentID=56, Title="Third-Second" },
            new ChildModel() {ID=333, ParentID=78, Title="Forth-Second" },
            new ChildModel() {ID=444, ParentID=78, Title="Forth-Firs" },
            new ChildModel() {ID=555, ParentID=78, Title="Forth-Third" },
        }
        .ToDictionary(rm => rm.ID);
    }
}
