using Simplified;
using System.Collections.ObjectModel;

namespace ViewModelLayer
{
    /// <summary>Интерфейс основной ViewModel для представления дерева.</summary>
    public interface IMainTreeViewModel
    {
        ObservableCollection<RootVM> Roots { get; }
        ObservableCollection<ChildVM> Children { get; }

        RelayCommand<RootVM> RootEditCommand { get; }
        RelayCommand<ChildVM> ChildEditCommand { get; }

    }

}
