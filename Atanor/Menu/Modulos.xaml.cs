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
    /// Interaction logic for Modulos.xaml
    /// </summary>
    public partial class Modulos : UserControl
    {
        public Modulos()
        {
            InitializeComponent();
        }

      

       

        private void menuItemSGA1_Click(UserControl controle)
        {
            Sessao.AbrirMenu(new Menu.Logistica());
        }

        private void menuItemSGA3_Click(UserControl controle)
        {
            Sessao.AbrirMenu(new Menu.Suplly());
        }

        private void menuItemSGA5_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void menuItemSGA5_Click(UserControl controle)
        {
            
        }

        private void menuItemSGA6_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void menuItemSGA6_Click(UserControl controle)
        {
            Sessao.AbrirMenu(new Menu.Correcao());
        }

        private void menuItemSGA7_Click(UserControl controle)
        {
            Sessao.AbrirMenu(new Menu.Usuarios());
        }

        private void menuItemSGA8_Click(UserControl controle)
        {
            Sessao.AbrirMenu(new Menu.Expedicao());
            
        }

        private void menuItemSGA2_Click(UserControl controle)
        {
            Sessao.AbrirMenu(new Menu.Portaria());
        }

        private void menuItemSGA4_Click(UserControl controle)
        {
            Sessao.AbrirMenu(new Menu.Relatorios());
        }

     

        private void menuItemSGA9_Click_1(UserControl controle)
        {
            
        }

        private void alarme(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Alarme.Alarme(), this);
        }

       

      
    }
}
