using WPF.DataModel;
using Simplified;
using System;
using System.Windows.Input;

namespace WPF.ViewModel
{
    public class ViewModelRootEdit : ViewModelBase
    {
        private readonly DataModelRoot data;
        public ViewModelRootEdit(DataModelRoot item, Action exit)
        {
            data = item;
            Title = item.Title;
            CloseCommand = new RelayCommand(() =>
            {
                //data.Title = Title;
            });
            SaveCommand = new RelayCommand(
                () =>
                {
                    data.Title = Title;
                    if (DBHelper.SyncRoot(data))
                        exit();
                    else
                    {
                        ErrorMessage = "Ошибка сохранения";
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
        private string _errorMessage;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public string ErrorMessage { get => _errorMessage; private set => Set(ref _errorMessage, value); }

        #region Команды
        public ICommand CloseCommand { get; }

        public RelayCommand SaveCommand { get; }
        #endregion
    }
}
