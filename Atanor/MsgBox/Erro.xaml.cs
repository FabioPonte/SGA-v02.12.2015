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

namespace Atanor.MsgBox
{
    /// <summary>
    /// Interaction logic for Erro.xaml
    /// </summary>
    public partial class Erro : Window
    {
        public Erro(string msg)
        {
            InitializeComponent();
            textBox1.Text = msg;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            button1.Focus();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
