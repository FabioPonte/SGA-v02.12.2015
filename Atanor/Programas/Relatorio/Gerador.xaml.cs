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
using System.Data;
using Conector;
namespace Atanor.Programas.Relatorio
{
    /// <summary>
    /// Interaction logic for Gerador.xaml
    /// </summary>
    public partial class Gerador : UserControl
    {
        public Gerador(string idrelatorio)
        {
            InitializeComponent();
            listar(idrelatorio);
            dataGridFiltro1.Odatagrid = ogrid;
        }

        public string per = "27";

        public string nome = "Relatórios";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/seo2 (1).png", UriKind.RelativeOrAbsolute));
        public Boolean varios = true;

        private void listar(string id)
        {
            DataTable tabela = Select.SelectSQL("select * from relatorios x where x.id=" + id + "");
            label1.Content = tabela.Rows[0]["nome"];
            ogrid.ItemsSource = Select.SelectSQL(tabela.Rows[0]["osql"] + "").DefaultView;
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void UserControl_Loaded_2(object sender, RoutedEventArgs e)
        {
            Sessao.ApagaBots();
            Sessao.AddExcel(ogrid);
        }
    }
}
