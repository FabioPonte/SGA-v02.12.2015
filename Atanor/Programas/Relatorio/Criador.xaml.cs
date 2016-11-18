using System;
using System.Collections.Generic;
using System.Data;
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
namespace Atanor.Programas.Relatorio
{
    /// <summary>
    /// Interaction logic for Criador.xaml
    /// </summary>
    public partial class Criador : UserControl
    {
        public Criador()
        {
            InitializeComponent();
            listar();
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {

        }


        public string per = "26";

        public string nome = "Criador de Relatorios";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/seo2 (1).png", UriKind.RelativeOrAbsolute));


        private void listar()
        {
            DataTable tabela = Select.SelectSQL("select distinct table_name tabelas from information_schema.columns where table_schema='" + Sessao.usuario.tabela + "'");
            lst_tabelas.ItemsSource = tabela.DefaultView;
            lst_tabelas.DisplayMemberPath = "tabelas";
            lst_tabelas.SelectedValuePath = "tabelas";
        }
        private void listarColunas()
        {
            try
            {
                lst_colunas.Items.Clear();
            }
            catch { }
            try
            {
                DataTable tabela = Select.SelectSQL("select distinct column_name tabelas from information_schema.columns where table_schema='" + Sessao.usuario.tabela + "' and table_name='" + lst_tabelas.SelectedValue + "'");
                lst_colunas.ItemsSource = tabela.DefaultView;
                lst_colunas.DisplayMemberPath = "tabelas";
                lst_colunas.SelectedValuePath = "tabelas";
            }
            catch { }
        }

        private void lst_tabelas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listarColunas();
        }

        private void lst_colunas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_sql.Text += lst_colunas.SelectedValue + "";
        }

        private void lst_tabelas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txt_sql.Text += lst_tabelas.SelectedValue + "";
        }

        private void btn_detalhar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ogrid.ItemsSource = Select.SelectSQL(txt_sql.Text).DefaultView;
            }
            catch { }
        }

        private void UserControl_Loaded_2(object sender, RoutedEventArgs e)
        {

        }

        private void btn_detalhar_Copy_Click_1(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Programas.Relatorio.Salvar(txt_sql.Text), this);
        }
    }
}
