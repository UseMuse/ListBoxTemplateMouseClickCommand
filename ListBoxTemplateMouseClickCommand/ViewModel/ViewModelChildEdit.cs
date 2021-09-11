using ListBoxTemplateMouseClickCommand.DataModel;
using Simplified;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ListBoxTemplateMouseClickCommand.ViewModel
{
    public class ViewModelChildEdit : ViewModelBase
    {
        private readonly DataModelChild data;
        //private readonly DataModelChild dataOriginal;
        public ViewModelChildEdit(DataModelChild item/*, Window window*/)
        {
            data = item;
            //dataOriginal = new DataModelChild() { ID = data.ID, Title = data.Title };
            CloseCommand = new RelayCommand(() => 
            {
                data.Title = Title;
                //window.Close();
            });

            SaveCommand = new RelayCommand(() =>
            {
                data.Title = Title;
                //window.Close();
            });
        }

        public int? ID => data?.ID;

        private string _title;
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public string ErrorMessage { get; set; }

        #region Команды
        public ICommand CloseCommand { get; }


        //private class ViewModelRootEditCloseCommand : ICommand
        //{
        //    private readonly ViewModelChildEdit _view;
        //    private readonly Window _window;

        //    public ViewModelRootEditCloseCommand(ViewModelChildEdit view, Window window)
        //    {
        //        _view = view;
        //        _window = window;
        //    }

        //    event EventHandler ICommand.CanExecuteChanged
        //    {
        //        add { }
        //        remove { }
        //    }

        //    public bool CanExecute(object parameter)
        //    {
        //        return true;
        //    }

        //    public void Execute(object parameter)
        //    {
        //        _view.data.Title = _view.Title;
        //        _window.Close();
        //    }
        //}

        public RelayCommand SaveCommand { get; }


        //private class ViewModelRootEditSaveCommandCommand : RelayCommand
        //{
        //    private readonly ViewModelChildEdit _view;
        //    private readonly Window _window;

        //    public ViewModelRootEditSaveCommandCommand(ViewModelChildEdit view, Window window)
        //    {
        //        _view = view;
        //        _window = window;
        //        BuildCommand(ExecuteEditSaveCommand, CanExecuteEditSaveCommand);
        //    }
        //    public bool CanExecuteEditSaveCommand(object parameter)
        //    {
        //        bool canExecute = _view.data.Title != _view.Title;
        //        return canExecute;
        //    }

        //    public void ExecuteEditSaveCommand(object parameter)
        //    {
        //        if (DBHelper.SyncChild(_view.data))
        //            _window.Close();
        //        else
        //        {
        //            ViewModelChildEdit datacontext = new ViewModelChildEdit(_view.data, _window)
        //            {
        //                ErrorMessage = "Ошибка!"
        //            };
        //            _window.DataContext = datacontext;
        //        }
        //    }
        //}
        #endregion
    }
}
