using ListBoxTemplateMouseClickCommand.DataModel;
using Simplified;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ListBoxTemplateMouseClickCommand.ViewModel
{
    public class ViewModelRootEdit : ViewModelBase
    {
        private readonly DataModelRoot data;
        //public DataModelRoot DataOriginal { get; }
        public ViewModelRootEdit(DataModelRoot item, Window window)
        {
            data = item;
            //DataOriginal = new DataModelRoot() { ID = Data.ID, Title = Data.Title };
            CloseCommand = new RelayCommand(() =>
            {
                data.Title = Title;
                window.Close();
            });
            SaveCommand = new RelayCommand(
                () => {
                    if (DBHelper.SyncRoot(data))
                        window.Close();
                    else
                    {
                        ViewModelRootEdit datacontext = new ViewModelRootEdit(data, window);
                        datacontext.ErrorMessage = "Ошибка сохранения";
                        window.DataContext = datacontext;
                    }
                },
                () =>
                {
                    bool canExecute = data.Title != Title;
                    return canExecute;
                }
            );
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
        //    private readonly ViewModelRootEdit _view;
        //    private readonly Window _window;

        //    public ViewModelRootEditCloseCommand(ViewModelRootEdit view, Window window)
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
        //    private readonly ViewModelRootEdit _view;
        //    private readonly Window _window;

        //    public ViewModelRootEditSaveCommandCommand(ViewModelRootEdit view, Window window)
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
        //        if (DBHelper.SyncRoot(_view.data))
        //            _window.Close();
        //        else
        //        {
        //            ViewModelRootEdit datacontext = new ViewModelRootEdit(_view.data, _window);
        //            datacontext.ErrorMessage = "Ошибка сохранения";
        //            _window.DataContext = datacontext;
        //        }
        //    }
        //}
        #endregion
    }
}
