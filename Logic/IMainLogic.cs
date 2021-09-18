using Logic.Child;
using Logic.Root;

namespace Logic
{
    /// <summary>Интерфейс главной Модели.</summary>
    /// <remarks>В данном случае, кроме объеденения других интерфейсов,
    /// никаких собственных членов не содержит.</remarks>
    public interface IMainLogic : IRootLogic, IChildLogic
    { }
}
