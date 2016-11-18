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
    /// Interaction logic for Relatorio.xaml
    /// </summary>
    public partial class Relatorio : UserControl
    {
        public Relatorio()
        {
            InitializeComponent();
            dataGridFiltro1.Odatagrid = ogrid;
            listar();
        }

        public string nome = "Lista dos Lotes";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/seo2%20%281%29.png", UriKind.RelativeOrAbsolute));
        public string per = "25";

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Sessao.ApagaBots();
            Sessao.AddExcel(ogrid);
            
        }

        private void listar()
        {
            ogrid.ItemsSource = Select.SelectSQL("select * from acerto_lote").DefaultView;
        }
    }
}
