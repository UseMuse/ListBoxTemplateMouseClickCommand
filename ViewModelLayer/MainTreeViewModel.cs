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

        protected override ChildDto ChildSave(ChildDto root, string title)
        {
            throw new NotImplementedException();
        }

        protected override RootDto RootSave(RootDto root, string title)
        {
            throw new NotImplementedException();
        }

        private async void InitAsync()
        {
            // Здесь нужна обработка исключений,
            // потом позже сами сделаете.
            Roots.AddRange((await model.GetRoots()).Select(CreateVM));
            Children.AddRange((await model.GetChildren()).Select(CreateVM));
        }
    }
}
