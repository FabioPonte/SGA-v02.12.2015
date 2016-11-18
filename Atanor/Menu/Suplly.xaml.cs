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
    /// Interaction logic for Suplly.xaml
    /// </summary>
    public partial class Suplly : UserControl
    {
        public Suplly()
        {
            InitializeComponent();
        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirMenu(new Menu.Modulos());
        }

 
        private void menuItemSGA1_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Suplly.CondicaoEstoque(), this);
        }

        private void menuItemSGA2_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Suplly.CadastroPosicoes(), this);
        }

        private void menuItemSGA3_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Suplly.Ingresso_de_Produto(), this);
        }

        private void menuItemSGA4_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Suplly.Baixa_de_Produto(), this);
        }

        private void menuItemSGA4_Click_1(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Suplly.Transferencia(), this);
        }

        private void menuItemSGA9_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Suplly.ManutencaoLote(), this);
        }

        private void menuItemSGA10_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Suplly.CondicaoEstoqueNew(), this);
        }
    }
}
