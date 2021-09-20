using Logic.DTO;
using Simplified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer
{
    /// <summary>Класс сущности для представления одно элемента Данных.</summary>
    public class EntityVM<T> : BaseInpc
    {
        private T _data;

        /// <summary>Элемент с данными.</summary>
        public T Data { get => _data; private set => Set(ref _data, value); }

        /// <summary>Получение другого элемента с данными.</summary>
        /// <param name="data">Новый элемент с данными.</param>
        public void SetData(T data) => Data = data;
    }


    /// <summary>Класс сущности для представления одно дочернего элемента.</summary>
    public class ChildVM : EntityVM<ChildDto>
    { }

    /// <summary>Класс сущности для представления одно корневого элемента.</summary>
    public class RootVM : EntityVM<RootDto>
    { }

}
