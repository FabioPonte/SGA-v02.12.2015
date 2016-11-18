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
using Conector;
using System.Data;
namespace Atanor.Menu
{
    /// <summary>
    /// Interaction logic for Relatorios.xaml
    /// </summary>
    public partial class Relatorios : UserControl
    {
        public Relatorios()
        {
            InitializeComponent();
            listar();
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {
            Sessao.MenuIniciar();
        }

        private void menuItemSGA1_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Relatorio.Criador(), this);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void listar()
        {
            DataTable tabela = Select.SelectSQL("select * from relatorios where idusuarios="+Sessao.usuario.Id+"");

            //<my1:MenuItemSGA HorizontalAlignment="Left" Margin="0,48,0,0" x:Name="menuItemSGA1" VerticalAlignment="Top" Width="300" Icone="/Atanor;component/Images/seo2 (1).png" Nome="Criar Relatório" Click="menuItemSGA1_Click" />

            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                Menu.MenuItemSGA nova = new MenuItemSGA();
                nova.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                nova.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                nova.Nome = tabela.Rows[a]["nome"] + "";
                nova.Tag = tabela.Rows[a]["id"] + "";
                nova.Margin = new Thickness(0, 0, 0, 0);
                nova.Icone = new BitmapImage(new Uri("../Images/seo2 (1).png", UriKind.RelativeOrAbsolute));
                nova.Click += new MenuItemSGA.click(nova_Click);
                opainel.Children.Add(nova);
            }

        }

        void nova_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Relatorio.Gerador(controle.Tag + ""), this);
        }
    }
}
