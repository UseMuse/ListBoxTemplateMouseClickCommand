using ListBoxTemplateMouseClickCommand.DataModel;
using Simplified;
using System.Windows.Input;

namespace ListBoxTemplateMouseClickCommand.ViewModel
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

        public RelayCommand SaveCommand { get; }
        #endregion
    }
}
