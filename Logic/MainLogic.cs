using Data.Child;
using Data.Root;
using Logic.Child;
using Logic.Root;
using System;

namespace Logic
{
    /// <summary>Модель реализующая интерфейсы <see cref="IRootLogic"/> и <see cref="IChildLogic"/>.</summary>
    public partial class MainLogic : IMainLogic
    {
        private readonly IRootRepository rootRepository;

        private readonly IChildRepository childRepository;

        public MainLogic(IRootRepository rootRepository, IChildRepository childRepository)
        {
            this.rootRepository = rootRepository ?? throw new ArgumentNullException(nameof(rootRepository));
            this.childRepository = childRepository ?? throw new ArgumentNullException(nameof(childRepository));
        }
    }
}
