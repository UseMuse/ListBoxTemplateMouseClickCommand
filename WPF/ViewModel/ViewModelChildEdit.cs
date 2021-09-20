using WPF.DataModel;
using Simplified;
using System.Windows.Input;

namespace WPF.ViewModel
{
    public class ViewModelChildEdit : ViewModelBase
    {
        private readonly DataModelChild data;
        public ViewModelChildEdit(DataModelChild item)
        {
            data = item;
            Title = data?.Title;
            CloseCommand = new RelayCommand(() =>
            {
                //data.Title = Title;
            });

            SaveCommand = new RelayCommand(() =>
              {
                  data.Title = Title;
                  if (!DBHelper.SyncChild(data))
                  {
                      ErrorMessage = "Ошибка сохранения";
                  }
              }, () => data.Title != Title);
        }

        public int? ID => data?.ID;

        private string _title;
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => Set(ref _errorMessage, value);
        }

        #region Команды
        public ICommand CloseCommand { get; }

        public RelayCommand SaveCommand { get; }
        #endregion
    }
}
