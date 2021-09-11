using ListBoxTemplateMouseClickCommand.DataModel;
using ListBoxTemplateMouseClickCommand.ViewModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ListBoxTemplateMouseClickCommand
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModelMain viewmodel;

        public MainWindow()
        {
            InitializeComponent();

            //List<DataModelRoot> items = DBHelper.GetRoots();

            //viewmodel = new ViewModelMain(items);
            //DataContext = viewmodel;
        }

        private bool isNestedExecute;
        private void OnNested(object sender, MouseButtonEventArgs e)
        {
            isNestedExecute = true;
        }

        private void OnMain(object sender, MouseButtonEventArgs e)
        {
            e.Handled = isNestedExecute;
            isNestedExecute = false;
        }
    }
}