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
using System.Windows.Shapes;

namespace Atanor.Programas.Suplly
{
    /// <summary>
    /// Interaction logic for EscolherData_Estoque.xaml
    /// </summary>
    public partial class EscolherData_Estoque : Window
    {
        public DateTime Data;
        public EscolherData_Estoque()
        {
            InitializeComponent();
            listar();
        }

        private void listar()
        {
            lst_datas.ItemsSource = Select.SelectSQL("select distinct data from condicaoestoque").DefaultView;
            lst_datas.DisplayMemberPath = "data";
            lst_datas.SelectedValuePath = "data";
        }

        private void btn_gerar_Click(object sender, RoutedEventArgs e)
        {
            if (lst_datas.SelectedIndex != -1)
            {
                Data=Facilitadores.ConverterDataSQLemDataTime.converter(lst_datas.SelectedValue + "");
                this.Close();
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                lbl_por.Content = "" + slider.Value + "%";
            }
            catch { }
        }
    }
}
