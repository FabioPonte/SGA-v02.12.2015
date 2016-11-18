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
    /// Interaction logic for Usuarios.xaml
    /// </summary>
    public partial class Usuarios : UserControl
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {
            Sessao.MenuIniciar();
        }

        private void menuItemSGA1_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Usuarios.TipoUsuario(), this);
        }

        private void menuItemSGA1_Click_1(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Usuarios.Cadastro(), this);
        }

        private void menuItemSGA3_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Usuarios.Permissao(), this);
        }
    }
}
