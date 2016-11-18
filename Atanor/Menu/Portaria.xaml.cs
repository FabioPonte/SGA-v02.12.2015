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
    /// Interaction logic for Portaria.xaml
    /// </summary>
    public partial class Portaria : UserControl
    {
        public Portaria()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void menuItemSGA1_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Portaria.CadastroMotorista(), this);
        }

        private void menuItemSGA2_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Portaria.CadastroCaminhao(), this);
        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {
            Sessao.MenuIniciar();
        }

        private void menuItemSGA3_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Portaria.AvisoRecebimento(), this);
        }

        private void menuItemSGA4_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Portaria.CadastroEmpresa(), this);
        }

        private void menuItemSGA5_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Portaria.CadastroColaborador(), this);
        }

        private void menuItemSGA6_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Portaria.CadastroSetor(), this);
        }

        private void menuItemSGA7_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Portaria.CadastroItemIO(), this);
        }

        private void menuItemSGA8_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Portaria.EntradaSaidaMaterial(), this);
        }
    }
}
