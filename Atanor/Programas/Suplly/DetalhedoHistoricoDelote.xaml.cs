using Conector;
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

namespace Atanor.Programas.Suplly
{
    /// <summary>
    /// Interaction logic for DetalhedoHistoricoDelote.xaml
    /// </summary>
    public partial class DetalhedoHistoricoDelote : UserControl
    {
        DateTime dia;
        public DetalhedoHistoricoDelote(DateTime odia)
        {

            dia = odia;
            InitializeComponent();
            nome = "Detalhe do Historico do Estoque no Dia " + dia.Day + "/" + dia.Month + "/" + dia.Year + "";
            Facilitadores.ConverteDataParaDataGrid.Converter(ogrid);
            listar();

        }

        public string nome = "Detalhe do Historico do Estoque";
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
            ogrid.ItemsSource = Select.SelectSQL("select * from historico_lote where data='"+Facilitadores.ConverterDataParaDataDoMysql.Converter(dia) +"'").DefaultView;
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
