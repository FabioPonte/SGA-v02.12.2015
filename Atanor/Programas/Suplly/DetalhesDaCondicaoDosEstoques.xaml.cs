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

namespace Atanor.Programas.Suplly
{
    /// <summary>
    /// Interaction logic for DetalhesDaCondicaoDosEstoques.xaml
    /// </summary>
    public partial class DetalhesDaCondicaoDosEstoques : UserControl
    {
        DateTime dia;
        public DetalhesDaCondicaoDosEstoques(DateTime odia)
        {
            
            dia = odia;
            InitializeComponent();
            nome = "Detalhe da Condição do Estoque no Dia " + dia.Day + "/" + dia.Month + "/" + dia.Year + "";
            Facilitadores.ConverteDataParaDataGrid.Converter(ogrid);
            listar();
            
        }

        public string nome = "Detalhe da Condição do Estoquo";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/search102.png", UriKind.RelativeOrAbsolute));
        public string per = "7";
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridFiltro1.Odatagrid = ogrid;
            Sessao.ApagaBots();
            Sessao.AddExcel(ogrid);
        }

        private void listar()
        {
            ogrid.ItemsSource = Select.SelectSQL("select * from condicaoestoque where data='" + dia.Year + "-" + dia.Month + "-" + dia.Day + "'").DefaultView;
        }

        private void btn_detalhar_Click(object sender, RoutedEventArgs e)
        {
            listar();
        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
