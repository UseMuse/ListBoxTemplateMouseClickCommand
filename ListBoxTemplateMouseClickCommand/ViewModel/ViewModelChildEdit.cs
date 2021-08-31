using ListBoxTemplateMouseClickCommand.DataModel;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ListBoxTemplateMouseClickCommand.ViewModel
{
    public class ViewModelChildEdit : ViewModelBase
    {
        public DataModelChild Data { get; }
        public DataModelChild DataOriginal { get; }
        public ViewModelChildEdit(DataModelChild item, Window window)
        {
            Data = item;
            DataOriginal = new DataModelChild() { ID = Data.ID, Title = Data.Title };
            CloseCommand = new ViewModelRootEditCloseCommand(this, window);
            SaveCommand = new ViewModelRootEditSaveCommandCommand(this, window);
        }
        public int? ID
        {
            get => Data.ID;
        }
        public string Title
        {
            get => Data.Title;
            set
            {
                bool changed = OnPropertyChangedClass.ChangeProp(Data.Title, value);
                Data.Title = value;
                if (changed)
                    SaveCommand.Invalidate();
            }
        }

        public string ErrorMessage { get; set; }

        #region Команды
        public ICommand CloseCommand { get; }
        private class ViewModelRootEditCloseCommand : ICommand
        {
            private readonly ViewModelChildEdit _view;
            private readonly Window _window;

            public ViewModelRootEditCloseCommand(ViewModelChildEdit view, Window window)
            {
                _view = view;
                _window = window;
            }

            event EventHandler ICommand.CanExecuteChanged
            {
                add { }
                remove { }
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                _view.Data.Title = _view.DataOriginal.Title;
                _window.Close();
            }
        }

        public RelayCommand SaveCommand { get; }
        private class ViewModelRootEditSaveCommandCommand : RelayCommand
        {
            private readonly ViewModelChildEdit _view;
            private readonly Window _window;

            public ViewModelRootEditSaveCommandCommand(ViewModelChildEdit view, Window window)
            {
                _view = view;
                _window = window;
                BuildCommand(ExecuteEditSaveCommand, CanExecuteEditSaveCommand);
            }
            public bool CanExecuteEditSaveCommand(object parameter)
            {
                bool canExecute = _view.Data.Title != _view.DataOriginal.Title;
                return canExecute;
            }

            public void ExecuteEditSaveCommand(object parameter)
            {
                if (DBHelper.SyncChild(_view.Data))
                    _window.Close();
                else
                {
                    ViewModelChildEdit datacontext = new ViewModelChildEdit(_view.Data, _window)
                    {
                        ErrorMessage = "Ошибка!"
                    };
                    _window.DataContext = datacontext;
                }
            }
        }
        #endregion
    }
}
