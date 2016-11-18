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
using SGABarras;
using SGAPizza;

namespace Atanor
{
    /// <summary>
    /// Interaction logic for Escondido.xaml
    /// </summary>
    public partial class Escondido : Window
    {
        public Escondido()
        {
            InitializeComponent();
        }

        dynamic add;

        public dynamic Add
        {
            get { return add; }
            set { add = value; novo.Children.Add(value); }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
