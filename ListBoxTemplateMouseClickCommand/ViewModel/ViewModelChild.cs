using ListBoxTemplateMouseClickCommand.DataModel;
using Simplified;

namespace ListBoxTemplateMouseClickCommand.ViewModel
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
