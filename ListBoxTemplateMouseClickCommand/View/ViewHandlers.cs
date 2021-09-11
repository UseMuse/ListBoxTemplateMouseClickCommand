using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ListBoxTemplateMouseClickCommand.View
{
    public static class ViewHandlers
    {
        public static RoutedEventHandler WindowClose { get; } = (sender, e) => 
        {
            DependencyObject current = sender as DependencyObject;
            Window window = null;
            while(current != null && (window = current as Window) == null)
            {
                current = VisualTreeHelper.GetParent(current);
            }
            window?.Close();
        };
    }
}
