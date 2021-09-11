﻿using ListBoxTemplateMouseClickCommand.DataModel;
using ListBoxTemplateMouseClickCommand.View;
using Simplified;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ListBoxTemplateMouseClickCommand.ViewModel
{
    public class ViewModelMain : ViewModelBase
    {
        private ViewModelRoot _selectedRoot;
        public ViewModelRoot SelectedRoot
        {
            get { return _selectedRoot; }
            set
            {
                Set(ref _selectedRoot, value);
                ShowEditDialogCommand.Invalidate();
            }
        }

        /// <summary>
        /// Корневые элементы
        /// </summary>
        public ObservableCollection<ViewModelRoot> Roots { get; private set; }

        public ViewModelMain(List<DataModelRoot> items)
        {
            Roots = new ObservableCollection<ViewModelRoot>((from item in items select new ViewModelRoot(item)).ToList());
            ShowEditDialogCommand = new ViewModelShowEditDialogCommand(this);
        }
        #region команды
        public RelayCommand ShowEditDialogCommand { get; }

        private class ViewModelShowEditDialogCommand : RelayCommand
        {
            ViewModelMain mainView;

            public ViewModelShowEditDialogCommand(ViewModelMain view)
            {
                mainView = view;
                BuildCommand(ExecuteShowEditDialogCommand, CanExecuteShowEditDialogCommand);
            }

            public bool CanExecuteShowEditDialogCommand(object parameter)
            {
                bool canExecute = mainView.SelectedRoot != null;
                return canExecute;
            }

            public void ExecuteShowEditDialogCommand(object parameter)
            {
                DataModelRoot data = mainView?.SelectedRoot?.Data;
                if (data != null)
                {
                    RootEdit view = new RootEdit(/*mainView.SelectedRoot.Data*/);
                    var vm = new ViewModelRootEdit(data, view);
                    view.DataContext = vm;
                    if (view.ShowDialog() == false)
                    {
                        //DataModelRoot newdata = view.Data;
                        ViewModelRoot newview = new ViewModelRoot(data);
                        int index = mainView.Roots.IndexOf(mainView.Roots.Where(p => p.Data.ID.Equals(data.ID)).FirstOrDefault());
                        mainView.Roots[index] = newview;
                    }
                }
            }
        }

        #endregion
    }
}
