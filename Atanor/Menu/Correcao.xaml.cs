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
    /// Interaction logic for Correcao.xaml
    /// </summary>
    public partial class Correcao : UserControl
    {
        public Correcao()
        {
            InitializeComponent();
        }

        private void menuItemSGA1_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Correcao.BaixaSap(), this);
        }

        private void menuItemSGA2_Click(UserControl controle)
        {

        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirMenu(new Menu.Modulos());
        }

        private void menuItemSGA3_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Correcao.ListaDeResumo(), this);
        }

        private void menuItemSGA4_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Correcao.Relatorio(), this);
        }
    }
}
