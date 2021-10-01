using Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Root
{
    public partial class RootRepository 
    {
        public bool IsDemoData { get; }

        public RootRepository()
            : this(true)
        { }

        public RootRepository(bool isDemoData)
        {
            IsDemoData = isDemoData;
        }

        protected readonly Dictionary<int, RootModel> DemoData = new List<RootModel>()
        {
            new RootModel() {ID=123, Title="Firs"},
            new RootModel() {ID=34, Title="Second"},
            new RootModel() {ID=56, Title="Third"},
            new RootModel() {ID=78, Title="Forth"}
        }
        .ToDictionary(rm => rm.ID);
    }
}
