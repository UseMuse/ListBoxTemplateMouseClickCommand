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
    /// Логика взаимодействия для ChildEdit.xaml
    /// </summary>
    public partial class ChildEdit : Window
    {
        //private ViewModelChildEdit view;
        //private DataModelChild viewdata;

        public ChildEdit(/*DataModelChild data*/)
        {
            InitializeComponent();

            //view = new ViewModelChildEdit(data, this);
            //DataContext = view;
            //viewdata = data;
        }

        //public DataModelChild Data
        //{
        //    get { return view.data; }
        //}
    }
}
