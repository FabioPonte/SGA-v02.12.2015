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
namespace Atanor.Programas.Correcao
{
    /// <summary>
    /// Interaction logic for ListaDeResumo.xaml
    /// </summary>
    public partial class ListaDeResumo : UserControl
    {
        public ListaDeResumo()
        {
            InitializeComponent();
            Listar();
        }
        public string per = "18";
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Sessao.ApagaBots();
            Sessao.AddExcel(ogrid);
        }

        private void Listar()
        {
            ogrid.ItemsSource = Select.SelectSQL("select distinct x.codigo Codigo,x.data_baixa Data,sum(x.quantidade) Soma from retorno_lote x group by codigo,data").DefaultView;
            ogrid.SelectedValuePath = "Codigo";
        }

        private void btn_detalhar_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Programas.Correcao.Resumo(ogrid.SelectedValue + ""), this);
        }
    }
}
