using WPF.DataModel;
using Simplified;

namespace WPF.ViewModel
{
    public class ViewModelChild : ViewModelBase
    {
        private readonly DataModelChild data;

        public ViewModelChild(DataModelChild item)
        {
            data = item;
        }
        public int? ID => data?.ID;

        public string Title => data?.Title;
        public DataModelChild GetData() => data;
    }
}
