using Data.Child;
using Data.Root;
using DTO;
using Logic;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ViewModelLayer;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            // Здесь нужно создать реальныее Репозиторий, Модель и ViewModel.
            // Сейчас для примера используется  MainTreeViewModelDemo
            MainTreeViewModel viewModel = new MainTreeViewModelDemo();

            // Создаётся экземпляр Основного Окна,
            // присваивается свойству App.MainWindow.
            // Его DataContext присваивается созданная ViewModel.
            MainWindow = new MainWindow();
            MainWindow.DataContext = viewModel;
            MainWindow.Show();
        }
    }

    /// <summary>ViewModel для Демо Режима.</summary>
    public class MainTreeViewModelDemo : MainTreeViewModel
    {
        public static class DemoHandlers
        {
            public static bool RootTitleEditDialog(in RootDto dto, out string title)
            {
                title = null;
                MessageBox.Show("Здесь должен быть диалог редактирования RootDto.Title.");
                return false;
            }
            public static bool ChildTitleEditDialog(in ChildDto dto, out string title)
            {
                title = null;
                MessageBox.Show("Здесь должен быть диалог редактирования ChildDto.Title.");
                return false;
            }
        }
        public MainTreeViewModelDemo()
            : base(new MainLogic(new RootRepository(), new ChildRepository()),
                   DemoHandlers.RootTitleEditDialog,
                   DemoHandlers.ChildTitleEditDialog)
        { }
    }

    /// <summary>Вспомогательный класс для фильтрации коллекции из <see cref="ChildVM"/> для <see cref="RootVM"/>.</summary>
    public class ChildrenViewSource : CollectionViewSource
    {

        /// <summary><see cref="RootVM"/> по которому производится фильтрация.</summary>
        public RootVM Root
        {
            get => (RootVM)GetValue(RootProperty);
            set => SetValue(RootProperty, value);
        }

        /// <summary><see cref="DependencyProperty"/> для свойства <see cref="Root"/>.</summary>
        public static readonly DependencyProperty RootProperty =
            DependencyProperty.Register(
                nameof(Root),
                typeof(RootVM),
                typeof(ChildrenViewSource),
                new PropertyMetadata(null, RootChanged));
        private RootVM privateRoot;

        private static void RootChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ChildrenViewSource children = (ChildrenViewSource)d;
            children.privateRoot = (RootVM)e.NewValue;
            if (e.NewValue == null)
            {
                children.Filter -= OnChildrenFilter;
            }
            else if (e.OldValue == null)
            {
                children.Filter += OnChildrenFilter;
            }
            else
            {
                children.View?.Refresh();
            }
        }

        public ChildrenViewSource()
        {
            IsLiveFilteringRequested = true;
            LiveFilteringProperties.Add(nameof(ChildVM.Data));
            BindingOperations.SetBinding(this, RootProperty, bindContext);
        }
        private static Binding bindContext = new Binding();
        private static void OnChildrenFilter(object sender, FilterEventArgs e)
        {
            ChildrenViewSource children = (ChildrenViewSource)sender;
            ChildVM child = (ChildVM)e.Item;
            e.Accepted = child.Data.ParentID == children.privateRoot.Data.Id;
        }
    }

    public class ChildrenViewToResources : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            FrameworkElement element = (FrameworkElement)values[0];
            if (!(element.Resources[typeof(ChildrenViewToResources)] is ChildrenViewSource childrenView))
            {
                element.Resources[typeof(ChildrenViewToResources)] = childrenView = new ChildrenViewSource();
            }
            childrenView.Source = values[1];
            if (values.Length > 2)
            {
                childrenView.Root = (RootVM)values[2];
            }

            return childrenView.View;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static ChildrenViewToResources Instance { get; } = new ChildrenViewToResources();
    }
}
