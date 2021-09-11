using ListBoxTemplateMouseClickCommand.DataModel;
using ListBoxTemplateMouseClickCommand.View;
using Simplified;
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
                if (Set(ref _selectedChild, value))
                {
                    ShowEditDialogCommand.RaiseCanExecuteChanged();
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
            Children = new ObservableCollection<ViewModelChild>(DBHelper.GetChildren(Data.ID.Value).Select(list => new ViewModelChild(list)));
            ShowEditDialogCommand = new RelayCommand(EditExecute, EditCanExecute);

        }
        public int? ID => Data.ID;
        public string Title => Data.Title;

        public RelayCommand ShowEditDialogCommand { get; }
        public bool EditCanExecute()
        {
            bool canExecute = SelectedChild != null;
            return canExecute;
        }

        public void EditExecute()
        {
            var data = SelectedChild?.GetData();
            if (data != null)
            {
                ChildEdit view = new ChildEdit(/*data*/);
                ViewModelChildEdit vm = new ViewModelChildEdit(data, view);
                view.DataContext = vm;

                if (view.ShowDialog() == false)
                {
                    //DataModelChild newdata = view.Data;
                    ViewModelChild newview = new ViewModelChild(data);
                    int index = Children.IndexOf(Children.Where(p => p.ID.Equals(data.ID)).FirstOrDefault());
                    Children[index] = newview;
                }
            }
        }
        //private class ViewModelShowEditDialogCommand : RelayCommand
        //{
        //    ViewModelRoot SelectedRoot;
        //    public ViewModelShowEditDialogCommand(ViewModelRoot selectedRoot)
        //    {
        //        SelectedRoot = selectedRoot;
        //        BuildCommand(ExecuteEditCommand, CanExecuteEditCommand);
        //    }

        //    public bool CanExecuteEditCommand(object parameter)
        //    {
        //        bool canExecute = SelectedRoot != null && SelectedRoot.SelectedChild != null;
        //        return canExecute;
        //    }

        //    public void ExecuteEditCommand(object parameter)
        //    {
        //        var data = SelectedRoot?.SelectedChild?.GetData();
        //        if (data != null)
        //        {
        //            ChildEdit view = new ChildEdit(/*data*/);
        //            ViewModelChildEdit vm = new ViewModelChildEdit(data, view);
        //            view.DataContext = vm;

        //            if (view.ShowDialog() == false)
        //            {
        //                //DataModelChild newdata = view.Data;
        //                ViewModelChild newview = new ViewModelChild(data);
        //                int index = SelectedRoot.Children.IndexOf(SelectedRoot.Children.Where(p => p.ID.Equals(data.ID)).FirstOrDefault());
        //                SelectedRoot.Children[index] = newview;
        //            }
        //        }
        //    }
        //}
    }
}
