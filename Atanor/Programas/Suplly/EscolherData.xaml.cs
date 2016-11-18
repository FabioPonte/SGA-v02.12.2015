using Conector;
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
using System.Windows.Shapes;

namespace Atanor.Programas.Suplly
{
    /// <summary>
    /// Interaction logic for EscolherData.xaml
    /// </summary>
    public partial class EscolherData : Window
    {
        public EscolherData()
        {
            InitializeComponent();
            listar();
        }

         public DateTime menor = DateTime.Now;
        public DateTime maior = DateTime.Now;
        public Boolean ok = false;
        public int tipo = -1;
        public List<string> wheres = new List<string>();

        DataTable tabela = new DataTable();

        private void listar()
        {
            DataTable tabela = Select.SelectSQL("select distinct data from historico_lote order by 1 desc");

            lst_maior.ItemsSource = tabela.DefaultView;
            lst_menor.ItemsSource = tabela.DefaultView;

            lst_maior.DisplayMemberPath = "data";
            lst_menor.DisplayMemberPath = "data";
            lst_maior.SelectedValuePath = "data";
            lst_menor.SelectedValuePath = "data";

            rd1.Checked += Rd1_Checked;
            rd2.Checked += Rd2_Checked;
            rd3.Checked += Rd3_Checked;

            
            
        }

        private void Rd3_Checked(object sender, RoutedEventArgs e)
        {
            tipo = 3;
            CriarFiltros();
        }

        private void Rd2_Checked(object sender, RoutedEventArgs e)
        {
            tipo = 2;
            CriarFiltros();
        }

        private void Rd1_Checked(object sender, RoutedEventArgs e)
        {
            tipo = 1;
            CriarFiltros();
        }

        private void CriarFiltros()
        {
            if (lst_maior.SelectedIndex != -1 && lst_menor.SelectedIndex != -1)
            {
                DateTime d1 = DateTime.Parse(lst_menor.SelectedValue + "");
                DateTime d2 = DateTime.Parse(lst_maior.SelectedValue + "");


                if (d1 < d2)
                {
                    menor = d1;
                    maior = d2;
                }
                else
                {
                    menor = d2;
                    maior = d1;
                }
                chk_filtro.IsEnabled = true;
            }
            else
            {
                chk_filtro.IsChecked = false;
                chk_filtro.IsEnabled = false;
                
            }

            if (tipo == 1)
            {
                tabela = Select.SelectSQL("select distinct cod from historico_lote where data in ('" + Facilitadores.ConverterDataParaDataDoMysql.Converter(menor) + "','" + Facilitadores.ConverterDataParaDataDoMysql.Converter(maior) + "')  order by 1");
            }

            if (tipo == 2)
            {
                tabela = Select.SelectSQL("select distinct local from historico_lote where data in ('" + Facilitadores.ConverterDataParaDataDoMysql.Converter(menor) + "','" + Facilitadores.ConverterDataParaDataDoMysql.Converter(maior) + "')  order by 1");
            }

            if (tipo == 3)
            {
                tabela = Select.SelectSQL("select distinct desposito from historico_lote where data in ('" + Facilitadores.ConverterDataParaDataDoMysql.Converter(menor) + "','" + Facilitadores.ConverterDataParaDataDoMysql.Converter(maior) + "')  order by 1");
            }

            lst_filtro.Items.Clear();
            for(int a = 0; a < tabela.Rows.Count; a++)
            {
                lst_filtro.Items.Add("" + tabela.Rows[a][0]);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (tipo == -1)
            {
                MsgBox.Show.Error("Tipo de seleção não foi informada!");
                return;
            }
            if (lst_maior.SelectedIndex!=-1 && lst_menor.SelectedIndex != -1)
            {
                DateTime d1 = DateTime.Parse(lst_menor.SelectedValue + "");
                DateTime d2 = DateTime.Parse(lst_maior.SelectedValue + "");

                
                if (d1 < d2)
                {
                    menor = d1;
                    maior = d2;
                }
                else
                {
                    menor = d2;
                    maior = d1;
                }
                selecionados();
                ok = true;
                this.Close();
            }
            else
            {
                ok = false;
            }
        }


        private void selecionados()
        {
            if (chk_filtro.IsChecked == true)
            {
                System.Collections.IList lista = lst_filtro.SelectedItems;
                for (int a = 0; a < lista.Count; a++)
                {
                    wheres.Add("" + lista[a]);
                }
            }
            else
            {
                lst_filtro.SelectedIndex = -1;
                wheres.Clear();
            }
        }

        private void chk_filtro_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chk_filtro_Click(object sender, RoutedEventArgs e)
        {
                lst_filtro.IsEnabled = (Boolean)chk_filtro.IsChecked;           
        }
    }
}
