using Common;
using Logic;
using Logic.DTO;
using Simplified;
using System;
using System.Linq;
using System.Threading.Tasks;

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
            Task.Run(InitAsync);
        }

        protected async override Task<ChildDto> ChildSaveAsync(ChildDto child, string title)
        {
            await model.UpdateChild(child);
            return child;
        }

        protected async override Task<RootDto> RootSaveAsync(RootDto root, string title)
        {
            await model.UpdateRoot(root);
            return root;
        }

        private async void InitAsync()
        {
            // Здесь нужна обработка исключений,
            // потом позже сами сделаете.
            Roots.AddRange((await model.GetRootsAsync()).Select(CreateVM));
            Children.AddRange((await model.GetChildren()).Select(CreateVM));
        }
    }
}
