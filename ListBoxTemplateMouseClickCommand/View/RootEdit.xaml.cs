using ListBoxTemplateMouseClickCommand.DataModel;
using ListBoxTemplateMouseClickCommand.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ListBoxTemplateMouseClickCommand.View
{
    /// <summary>
    /// Логика взаимодействия для RootEdit.xaml
    /// </summary>
    public partial class RootEdit : Window
    {
        //private ViewModelRootEdit view;
        //private DataModelRoot viewdata;

        public RootEdit(/*DataModelRoot data*/)
        {
            InitializeComponent();

            //view = new ViewModelRootEdit(data, this);
            //DataContext = view;
            //viewdata = data;
        }

        //public DataModelRoot Data
        //{
        //    get { return view.data; }
        //}
    }
}
