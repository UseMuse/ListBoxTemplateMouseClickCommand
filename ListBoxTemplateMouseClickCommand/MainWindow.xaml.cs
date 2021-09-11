using ListBoxTemplateMouseClickCommand.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace ListBoxTemplateMouseClickCommand
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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