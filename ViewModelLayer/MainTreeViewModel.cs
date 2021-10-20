using Common;
using DTO;
using Logic;
using Simplified;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModelLayer
{
    public class MainTreeViewModel : MainTreeViewModelAbstract
    {
        private readonly IMainLogic model;

        public MainTreeViewModel(IMainLogic model,
                                 EditDialogHandler<RootDto, string> rootTitleEditDialog,
                                 EditDialogHandler<ChildDto, string> childTitleEditDialog)
            : base(rootTitleEditDialog, childTitleEditDialog)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            //Task.Run(InitAsync);
            LoadAsync = new RelayCommand(InitAsync);
        }

        protected async override Task<ChildDto> ChildSaveAsync(ChildDto child, string title)
        {
            ChildDto newChild = new ChildDto(child.Id, title, child.ParentID);
            await model.UpdateChildAsync(child, newChild);
            return child;
        }
        protected async override Task<RootDto> RootSaveAsync(RootDto root, string title)
        {
            RootDto newRoot = new RootDto(root.Id, title);
            await model.UpdateRootAsync(root, newRoot);
            return root;
        }

        private async void InitAsync()
        {
            // Здесь нужна обработка исключений,
            // потом позже сами сделаете.
            Roots.AddRange((await model.GetRootsAsync()).Select(CreateVM));
            Children.AddRange((await model.GetChildrenAsync()).Select(CreateVM));
        }

        public ICommand LoadAsync { get; private set; }
    }
}
