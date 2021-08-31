using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxTemplateMouseClickCommand
{
    /// <summary>Базовый класс с реализацией INPC </summary>
    public abstract class OnPropertyChangedClass : INotifyPropertyChanged
    {
        #region Событие PropertyChanged
        /// <summary>Событие для извещения об изменения свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Методы вызова события PropertyChanged
        /// <summary>Метод для вызова события извещения об изменении свойства</summary>
        /// <param name="propertyName">Изменившееся свойство</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            string[] names = propertyName.Split("\\/\r \n()\"\'-".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            switch (names.Length)
            {
                case 0: break;
                case 1:
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                    break;
                default:
                    OnPropertyChanged(names);
                    break;
            }

        }
        /// <summary>Метод для вызова события извещения об изменении списка свойств</summary>
        /// <param name="propList">Список имён свойств</param>
        protected virtual void OnPropertyChanged(IEnumerable<string> propList)
        {
            foreach (string propertyName in propList.Where(name => !string.IsNullOrWhiteSpace(name)))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>Метод для вызова события извещения об изменении перечня свойств</summary>
        /// <param name="propList">Список имён свойств</param>
        protected virtual void OnPropertyChanged(params string[] propList)
        {
            foreach (string propertyName in propList.Where(name => !string.IsNullOrWhiteSpace(name)))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>Метод для вызова события извещения об изменении списка свойств</summary>
        /// <param name="propList">Список свойств</param>
        protected virtual void OnPropertyChanged(IEnumerable<PropertyInfo> propList)
        {
            foreach (PropertyInfo prop in propList)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop.Name));
        }

        /// <summary>Метод для вызова события извещения об изменении всех свойств</summary>
        /// <param name="propList">Список свойств</param>
        protected virtual void OnAllPropertyChanged()
        {
            OnPropertyChanged(GetType().GetProperties());
        }
        #endregion


        #region методы для изменения значений свойств


        /// <summary>Виртуальный метод определяющий изменения в значении поля значения свойства</summary>
        /// <param name="fieldProperty">Ссылка на поле значения свойства</param>
        /// <param name="newValue">Новое значение</param>
        /// <param name="propertyName">Название свойства</param>
        /// <param name="changed">Считать изменённым, по переданному значению, иначе выполняется проверка на изменение внутри метода</param>
        /// <returns>изменилось ли значение</returns>
        protected virtual bool SetProperty<T>(ref T fieldProperty, T newValue, [CallerMemberName] string propertyName = "", bool? changed = null)
        {
            if (changed ?? ChangeProp(fieldProperty, newValue))
            {
                PropertyNewValue(ref fieldProperty, newValue, propertyName);
                return true;
            }
            return false;
        }

        /// <summary>Виртуальный метод изменяющий значение поля значения свойства и вызывающий OnPropertyChanged</summary>
        /// <param name="fieldProperty">Ссылка на поле значения свойства</param>
        /// <param name="newValue">Новое значение</param>
        /// <param name="propertyName">Название свойства</param>
        protected virtual void PropertyNewValue<T>(ref T fieldProperty, T newValue, string propertyName)
        {
            fieldProperty = newValue;
            OnPropertyChanged(propertyName);
        }

        #endregion

        #region  статичные методы для изменения значений свойств

        public static bool ChangeProp<T>(T fieldProperty, T newValue)
        {
            return ((fieldProperty != null && !fieldProperty.Equals(newValue)) || (fieldProperty == null && newValue != null));
        }

        #endregion
    }
}
