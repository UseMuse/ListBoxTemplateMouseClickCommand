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
            DemoData = GetLarge();
        }

        private Dictionary<int, ChildModel> GetLarge()
        {
            List<ChildModel> datas = new List<ChildModel>();
            for (int i = 0; i < 10000; i++)
            {
                datas.Add(new ChildModel() { ID = i, ParentID = 123, Title = $"{i}" });
            }
            return datas.ToDictionary(rm => rm.ID);
        }

        protected readonly Dictionary<int, ChildModel> DemoData;

    }
}
