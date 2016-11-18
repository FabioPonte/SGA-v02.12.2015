using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Atanor
{
    /// <summary>
    /// Interaction logic for Externamente.xaml
    /// </summary>
    public partial class Externamente : Window
    {
        public Boolean externamente = true;
        public Externamente(UserControl controle)
        {
            InitializeComponent();
            ogrid.Children.Add(controle);
            dynamic c = controle;
            try
            {
                this.Icon = c.icone;
            }
            catch { }
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
