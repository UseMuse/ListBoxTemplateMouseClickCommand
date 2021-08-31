using ListBoxTemplateMouseClickCommand.DataModel;
using ListBoxTemplateMouseClickCommand.View;
using System.Collections.ObjectModel;
using System.Linq;
namespace ListBoxTemplateMouseClickCommand.ViewModel
{
    public class ViewModelRoot : ViewModelBase
    {
        private ViewModelChild _selectedChild;
        public ViewModelChild SelectedChild
        {
            get => _selectedChild;
            set
            {
                SetProperty(ref _selectedChild, value);
                if (_selectedChild != null)
                {
                    ShowEditDialogCommand.Invalidate();
                }
            }
        }
        public ObservableCollection<ViewModelChild> Children { get; private set; }
 
        public DataModelRoot Data { get; }
        public DataModelRoot DataOriginal { get; }
        public ViewModelRoot(DataModelRoot item)
        {
            Data = item;
            DataOriginal = new DataModelRoot() { ID = item.ID, Title = item.Title };
            Children = new ObservableCollection<ViewModelChild>((from list in DBHelper.GetChildren(Data.ID.Value) select new ViewModelChild(list)).ToList());
            ShowEditDialogCommand = new ViewModelShowEditDialogCommand(this);

        }
        public int? ID => Data.ID;
        public string Title => Data.Title;

        public RelayCommand ShowEditDialogCommand { get; }
        private class ViewModelShowEditDialogCommand : RelayCommand
        {
            ViewModelRoot SelectedRoot;
            public ViewModelShowEditDialogCommand(ViewModelRoot selectedRoot)
            {
                SelectedRoot = selectedRoot;
                BuildCommand(ExecuteEditCommand, CanExecuteEditCommand);
            }

            public bool CanExecuteEditCommand(object parameter)
            {
                bool canExecute = SelectedRoot != null && SelectedRoot.SelectedChild != null;
                return canExecute;
            }

            public void ExecuteEditCommand(object parameter)
            {
                ChildEdit view = new ChildEdit(SelectedRoot.SelectedChild.Data);
                if (view.ShowDialog() == false)
                {
                    DataModelChild newdata = view.Data;
                    ViewModelChild newview = new ViewModelChild(newdata);
                    int index = SelectedRoot.Children.IndexOf(SelectedRoot.Children.Where(p => p.Data.ID.Equals(newdata.ID)).FirstOrDefault());
                    SelectedRoot.Children[index] = newview;
                }
            }
        }
    }
}
