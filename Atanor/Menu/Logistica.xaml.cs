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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Atanor.Menu
{
    /// <summary>
    /// Interaction logic for Logistica.xaml
    /// </summary>
    public partial class Logistica : UserControl
    {
        public Logistica()
        {
            InitializeComponent();
        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirMenu(new Menu.Modulos());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Programas.Logistica.CentroDeDistribuicao(), this);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Programas.Logistica.Transportadora(), this);
        }

        

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Programas.Logistica.Produtos(), this);
        }
    }
}
