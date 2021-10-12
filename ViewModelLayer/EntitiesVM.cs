using DTO;
using Simplified;
using System.Windows;

namespace ViewModelLayer
{
    /// <summary>Класс сущности для представления одного элемента Данных.</summary>
    public class EntityVM<T> : BaseInpc
    {
        private T _data;

        /// <summary>Элемент с данными.</summary>
        public T Data { get => _data; private set => Set(ref _data, value); }

        /// <summary>Получение другого элемента с данными.</summary>
        /// <param name="data">Новый элемент с данными.</param>
        public void SetData(T data) => Data = data;
    }


    /// <summary>Класс сущности для представления одного дочернего элемента.</summary>
    public class ChildVM : EntityVM<ChildDto>
    {
        protected override void OnPropertyChanged(in string propertyName, in object oldValue, in object newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);

            if (propertyName == nameof(Data))
            {
                MessageBox.Show(
$@"Изменилось свойство ChildVM.Data.
Значения свойств:
{nameof(ChildDto.Id)}: {((ChildDto)oldValue)?.Id} -> {Data?.Id};
{nameof(ChildDto.ParentID)}: {((ChildDto)oldValue)?.ParentID} -> {Data?.ParentID};
{nameof(ChildDto.Title)}: {((ChildDto)oldValue)?.Title} -> {Data?.Title}.");
            }
        }
    }

    /// <summary>Класс сущности для представления одного корневого элемента.</summary>
    public class RootVM : EntityVM<RootDto>
    { }

}
