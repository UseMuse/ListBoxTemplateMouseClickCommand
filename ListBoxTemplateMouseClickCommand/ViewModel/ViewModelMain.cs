using WPF.DataModel;
using WPF.View;
using Simplified;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using Logic.Child;
using Logic.Root;
using Data.Child;
using Data.Root;
using System.Windows.Input;
using System.Threading.Tasks;
using Logic.DTO;
using System.Collections.Generic;
using Common.Simplified;
using System.Threading;
using System.Windows;

namespace WPF.ViewModel
{
    public class ViewModelMain : ViewModelBase
    {
        //private readonly IRootLogic _rootLogic;

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
        public ObservableCollection<ViewModelRoot> Roots { get; private set; }

        public ViewModelMain()
        {
            Roots = new ObservableCollection<ViewModelRoot>();
            if (IsInDesignMode)
            {
                // Данные Времени Pазработки
                Roots.AddRange(new ViewModelRoot[]
                {
                    new ViewModelRoot(new DataModelRoot() { ID = 123 }),
                    new ViewModelRoot(new DataModelRoot() { ID = 456 })
                });
            }
            else
            {
                //_rootLogic = new RootLogic(new RootRepository());
                //LoadDataCommand = RelayCommandAsync.Create(LoadDataAsync);
                Roots.AddRange(DBHelper.GetRoots().Select(item => new ViewModelRoot(item)));
            }

            ShowEditDialogCommand = new RelayCommand(ShowEditDialogExecute, ShowEditDialogCanExecute);
        }

        //public ICommand LoadDataCommand { get; set; }

        //public async Task LoadDataAsync(CancellationToken token = new CancellationToken())
        //{
        //    await Task.Delay(TimeSpan.FromSeconds(6), token).ConfigureAwait(false);
        //    List<RootDTO> rootDTOs = await _rootLogic.GetRoots();
        //    await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
        //        {
        //            Roots.AddRange(rootDTOs.Select(item => new ViewModelRoot(new DataModelRoot() { ID = item.ID, Title = item.Title })).ToList());
        //        }));
        //}

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
                    Roots.Replace(p => p.Data.ID.Equals(data.ID), newview);
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
