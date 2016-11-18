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
    /// Interaction logic for Pergunta.xaml
    /// </summary>
    public partial class Pergunta : Window
    {
        public Boolean retorno = false;
        public Pergunta(string msg)
        {
            InitializeComponent();
            textBox1.Text = msg;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            retorno = true;
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            retorno = false;
            this.Close();
        }
    }
}
