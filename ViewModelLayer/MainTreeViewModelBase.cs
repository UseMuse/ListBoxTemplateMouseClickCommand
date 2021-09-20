using Logic.DTO;
using Simplified;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace ViewModelLayer
{
    public abstract class MainTreeViewModelAbstract : ViewModelBase, IMainTreeViewModel
    {
        public ObservableCollection<RootVM> Roots { get; } = new ObservableCollection<RootVM>();
        public ObservableCollection<ChildVM> Children { get; } = new ObservableCollection<ChildVM>();
        public RelayCommand<RootVM> RootEditCommand { get; }
        public RelayCommand<ChildVM> ChildEditCommand { get; }

        protected readonly EditDialogHandler<RootDto, string> rootTitleEditDialog;
        protected readonly EditDialogHandler<ChildDto, string> childTitleEditDialog;

        protected MainTreeViewModelAbstract(EditDialogHandler<RootDto, string> rootTitleEditDialog,
                                            EditDialogHandler<ChildDto, string> childTitleEditDialog)
        {
            this.rootTitleEditDialog = rootTitleEditDialog ?? throw new ArgumentNullException(nameof(rootTitleEditDialog));
            this.childTitleEditDialog = childTitleEditDialog ?? throw new ArgumentNullException(nameof(childTitleEditDialog));
            RootEditCommand = new RelayCommand<RootVM>(RootEditExecute, RootEditCanExecute);
            ChildEditCommand = new RelayCommand<ChildVM>(ChildEditExecute, ChildEditCanExecute);

            if (Dispatcher.CheckAccess())
            {
                BindingOperations.EnableCollectionSynchronization(Roots, ((ICollection)Roots).SyncRoot);
                BindingOperations.EnableCollectionSynchronization(Children, ((ICollection)Children).SyncRoot);
            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    BindingOperations.EnableCollectionSynchronization(Roots, ((ICollection)Roots).SyncRoot);
                    BindingOperations.EnableCollectionSynchronization(Children, ((ICollection)Children).SyncRoot);
                });
            }
        }

        /// <summary>Метод сохранения данных корневого элемента.</summary>
        /// <param name="root">Исходные Данные отражающие элемент.</param>
        /// <param name="title">Данные для сохранения.</param>
        /// <returns>Новый экземпляр Данных отражающих элемент.</returns>
        protected abstract RootDto RootSave(RootDto root, string title);

        /// <summary>Метод сохранения данных дочернего элемента.</summary>
        /// <param name="root">Исходные Данные отражающие элемент.</param>
        /// <param name="title">Данные для сохранения.</param>
        /// <returns>Новый экземпляр Данных отражающих элемент.</returns>
        protected abstract ChildDto ChildSave(ChildDto root, string title);

        private void RootEditExecute(RootVM root)
        {
            if (rootTitleEditDialog(root.Data, out string title))
            {
                root.SetData(RootSave(root.Data, title));
            }
        }
        protected virtual bool RootEditCanExecute(RootVM root)
        {
            return true;
        }
        private void ChildEditExecute(ChildVM child)
        {
            if (childTitleEditDialog(child.Data, out string title))
            {
                child.SetData(ChildSave(child.Data, title));
            }
        }
        protected virtual bool ChildEditCanExecute(ChildVM child)
        {
            return true;
        }

        /// <summary>Возвращает <see cref="RootVM"/> с установленым <see cref="EntityVM{T}.Data">RootVM.Data</see>.</summary>
        /// <param name="dto">Значение для свойства <see cref="EntityVM{T}.Data">RootVM.Data</see>.</param>
        /// <returns>Новый экземпляр <see cref="RootVM"/>.</returns>
        public static RootVM CreateVM(RootDto dto)
        {
            RootVM root = new RootVM();
            root.SetData(dto);
            return root;
        }

        /// <summary>Возвращает <see cref="ChildVM"/> с установленым <see cref="EntityVM{T}.Data">RootVM.Data</see>.</summary>
        /// <param name="dto">Значение для свойства <see cref="EntityVM{T}.Data">RootVM.Data</see>.</param>
        /// <returns>Новый экземпляр <see cref="ChildVM"/>.</returns>
        public static ChildVM CreateVM(ChildDto dto)
        {
            ChildVM child = new ChildVM();
            child.SetData(dto);
            return child;
        }

    }

    /// <summary>Делегат диалога редактирования.</summary>
    /// <typeparam name="InT">Тип Данных для редактирования.</typeparam>
    /// <typeparam name="OutT">Тип Данных содержащий результаты редактирования.</typeparam>
    /// <param name="inData">Данные для редактирования.</param>
    /// <param name="outData">Данные содержащие результаты редактирования.</param>
    /// <returns><see langword="true"/> - если нужно сохранить результаты редактирования.</returns>
    public delegate bool EditDialogHandler<InT, OutT>(in InT inData, out OutT outData);
}
