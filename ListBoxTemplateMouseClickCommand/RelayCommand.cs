using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ListBoxTemplateMouseClickCommand
{
    #region Делегаты для методов WPF команд
    public delegate void ExecuteHandler(object parameter);
    public delegate bool CanExecuteHandler(object parameter);
    #endregion
    #region Класс команд - RelayCommand
    /// <summary>Класс реализующий интерфейс ICommand для создания WPF команд</summary>
    public abstract class RelayCommand : ICommand
    {
        private CanExecuteHandler _canExecute;
        private ExecuteHandler _onExecute;
        private EventHandler _requerySuggested;

        /// <summary>Событие извещающее об изменении состояния команды</summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>Строитель команды</summary>
        /// <param name="execute">Выполняемый метод команды</param>
        /// <param name="canExecute">Метод разрешающий выполнение команды</param>
        protected void BuildCommand(ExecuteHandler execute, CanExecuteHandler canExecute = null, bool manual = true)
        {
            _onExecute = execute;
            _canExecute = canExecute;

            _requerySuggested = (o, e) => Invalidate();
            if (!manual)
            {
                CommandManager.RequerySuggested += _requerySuggested;
            }
        }
        /// <summary>
        /// Уведомляем команду о том, что её CanExecute могло измениться
        /// </summary>
        public void Invalidate()
            => Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }), null);

        /// <summary>Вызов разрешающего метода команды</summary>
        /// <param name="parameter">Параметр команды</param>
        /// <returns>True - если выполнение команды разрешено</returns>
        public bool CanExecute(object parameter) => _canExecute == null ? true : _canExecute.Invoke(parameter);

        /// <summary>Вызов выполняющего метода команды</summary>
        /// <param name="parameter">Параметр команды</param>
        public void Execute(object parameter) => _onExecute?.Invoke(parameter);

        public static void InvalidateCommands(params RelayCommand[] commands)
        {
            if (commands != null && commands.Length > 0)
            {
                foreach (var command in commands)
                {
                    command?.Invalidate();
                }
            }
        }

    }
    #endregion
}
