using ListBoxTemplateMouseClickCommand.DataModel;
using ListBoxTemplateMouseClickCommand.View;
using Simplified;
using System.Collections.ObjectModel;
using System.Linq;

namespace ListBoxTemplateMouseClickCommand.ViewModel
{
    public class ViewModelMain : ViewModelBase
    {
        private ViewModelRoot _selectedRoot;
        public ViewModelRoot SelectedRoot
        {
            get => _selectedRoot;
            set
            {
                if (Set(ref _selectedRoot, value))
                {
                    ShowEditDialogCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Корневые элементы
        /// </summary>
        public ObservableCollection<ViewModelRoot> Roots { get; } = new ObservableCollection<ViewModelRoot>();

        public ViewModelMain()
        {
            if (IsInDesignMode)
            {
                // Данные Времени Pазработки
                Roots.AddRange(new ViewModelRoot[]
                {
                    new ViewModelRoot(new DataModelRoot() {ID = 123 }),
                    new ViewModelRoot(new DataModelRoot() {ID = 456 })
                });
            }
            else
            {
                // Данные Времени Исполнения.
                Roots.AddRange(DBHelper.GetRoots().Select(item => new ViewModelRoot(item)));
            }
            ShowEditDialogCommand = new RelayCommand(ShowEditDialogExecute, ShowEditDialogCanExecute);
        }

        #region команды
        public RelayCommand ShowEditDialogCommand { get; }

        private void ShowEditDialogExecute()
        {
            DataModelRoot data = SelectedRoot?.Data;
            if (data != null)
            {
                RootEdit view = new RootEdit();
                var vm = new ViewModelRootEdit(data, view.Close);
                view.DataContext = vm;
                if (view.ShowDialog() == false)
                {
                    ViewModelRoot newview = new ViewModelRoot(data);
                    int index = Roots.IndexOf(Roots.Where(p => p.Data.ID.Equals(data.ID)).FirstOrDefault());
                    Roots[index] = newview;
                }
            }
        }
        public bool ShowEditDialogCanExecute()
        {
            bool canExecute = SelectedRoot != null;
            return canExecute;
        }
        #endregion
    }
}
