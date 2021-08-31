using ListBoxTemplateMouseClickCommand.DataModel;
using System;
using System.Collections.ObjectModel;

namespace ListBoxTemplateMouseClickCommand.ViewModel
{
    public class ViewModelChild : ViewModelBase
    {
        public DataModelChild Data;

        public ViewModelChild(DataModelChild item)
        {
            Data = item;
        }
        public int? ID => Data.ID;

        public string Title => Data.Title;
    }
}
