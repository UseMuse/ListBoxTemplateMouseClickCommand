using Microsoft.Xaml.Behaviors;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using TriggerCollection = Microsoft.Xaml.Behaviors.TriggerCollection;

namespace ListBoxTemplateMouseClickCommand
{
    /// <summary>Класс триггера события <see cref="Control.MouseDoubleClick"/>,
    /// позволяющий для триггеров обрабатывать отмену его всплывания.</summary>
    public class MouseDoubleNoBubbling : EventTriggerBase<Control>
    {
        /// <summary>Возвращает значение присоединённого свойства Handled для <paramref name="window"/>.</summary>
        /// <param name="window"><see cref="Window"/> значение свойства которого будет возвращено.</param>
        /// <returns><see cref="bool?"/> значение свойства.</returns>
        public static bool? GetHandled(Window window)
        {
            return (bool?)window.GetValue(HandledProperty);
        }

        /// <summary>Задаёт значение присоединённого свойства Handled для <paramref name="window"/>.</summary>
        /// <param name="window"><see cref="Window"/> значение свойства которого будет возвращено.</param>
        /// <param name="value"><see cref="bool"/> значение для свойства.</param>
        public static void SetHandled(Window window, bool value)
        {
            window.SetValue(HandledProperty, value);
        }

        /// <summary><see cref="DependencyProperty"/> для методов <see cref="GetHandled(Window)"/> и <see cref="SetHandled(Window, bool?)"/>.</summary>
        public static readonly DependencyProperty HandledProperty =
            DependencyProperty.RegisterAttached(nameof(GetHandled).Substring(3), typeof(bool?), typeof(MouseDoubleNoBubbling), new PropertyMetadata(null, HandledChanged));

        private static void HandledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is Window))
            {
                throw new NotImplementedException("Реализовано только для Window.");
            }
        }



        /// <summary>Возвращает значение присоединённого свойства ParentWindow для <paramref name="control"/>.</summary>
        /// <param name="control"><see cref="Control"/> значение свойства которого будет возвращено.</param>
        /// <returns><see cref="Window"/> значение свойства.</returns>
        public static Window GetParentWindow(Control control)
        {
            return (Window)control.GetValue(ParentWindowProperty);
        }

        /// <summary><see cref="DependencyProperty"/> для методов <see cref="GetParentWindow(Control)"/> и <see cref="SetParentWindow(Control, Window)"/>.</summary>
        public static readonly DependencyProperty ParentWindowProperty =
            DependencyProperty.RegisterAttached(nameof(GetParentWindow).Substring(3), typeof(Window), typeof(MouseDoubleNoBubbling), new PropertyMetadata(null, ParentWindowChanged));

        private static void ParentWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is Control control))
            {
                throw new NotImplementedException("Реализовано только для Control.");
            }

            Window oldWindow = (Window)e.OldValue;
            if (oldWindow != null)
            {
                oldWindow.MouseDoubleClick -= OnResetHandled;
                oldWindow.ClearValue(HandledProperty);
            }
            Window newWindow = (Window)e.NewValue;
            if (newWindow != null)
            {
                newWindow.MouseDoubleClick += OnResetHandled;
                SetHandled(newWindow, false);
            }

            if (BindingOperations.GetBinding(control, ParentWindowProperty) != bindingParentWindow && newWindow != null)
            {
                _ = BindingOperations.SetBinding(control, ParentWindowProperty, bindingParentWindow);
            }
        }

        private static void OnResetHandled(object sender, MouseButtonEventArgs e)
        {
            Window window = (Window)sender;
            SetHandled(window, false);
        }

        private static readonly Binding bindingParentWindow = new Binding()
        {
            RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Window), 1)
        };

        protected override void OnSourceChanged(Control oldSource, Control newSource)
        {
            base.OnSourceChanged(oldSource, newSource);
            if (oldSource != null)
            {
                BindingOperations.ClearBinding(oldSource, ParentWindowProperty);
                oldSource.MouseDoubleClick -= OnMouseDoubleClick;
            }
            if (newSource != null)
            {
                _ = BindingOperations.SetBinding(newSource, ParentWindowProperty, bindingParentWindow);
                newSource.MouseDoubleClick += OnMouseDoubleClick;
                TriggerCollection triggers = Interaction.GetTriggers(AssociatedObject);
                if (triggers.IndexOf(this) > 0)
                {
                    _ = AssociatedObject.Dispatcher.BeginInvoke((Action)(() =>
                             {
                                 int index = triggers.IndexOf(this);
                                 if (index > 0)
                                 {
                                     var list = triggers.ToList();
                                     list.RemoveAt(index);
                                     triggers.Clear();
                                     triggers.Add(this);
                                     list.ForEach(trigg => triggers.Add(trigg));
                                 }
                             })
                       );
                }
            }
        }

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs args)
        {
            Control control = (Control)args.Source;
            if (args.RoutedEvent == Control.MouseDoubleClickEvent)
            {

                Window window = GetParentWindow(control);
                if (window != null)
                {
                    args.Handled = (bool)GetHandled(window);
                    SetHandled(window, true);
                }
            }
        }

        protected override string GetEventName()
        {
            return Control.MouseDoubleClickEvent.Name;
        }
    }
}
