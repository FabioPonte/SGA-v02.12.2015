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
namespace Atanor.Programas.Correcao
{
    /// <summary>
    /// Interaction logic for Resumo.xaml
    /// </summary>
    public partial class Resumo : UserControl
    {
        public Resumo()
        {
            InitializeComponent();
            listar();

        }
        string id = "";

        public Resumo(string oid)
        {
            id = oid;
            InitializeComponent();
            listar();
            nome = "Resumo da Baixa ("+oid+")";
        }

        public string nome = "Resumo da Baixa";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/download168.png", UriKind.RelativeOrAbsolute));
        public Boolean varios = true;
        public string per = "17";

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void listar()
        {
            DataTable tabela = new DataTable();

            if (id == "")
            {
                tabela = Select.SelectSQL("select (select lote from acerto_lote y where y.id=x.idacerto_lote) lote,(select cd from acerto_lote y where y.id=x.idacerto_lote) CD,(select item from acerto_lote y where y.id=x.idacerto_lote) item,(select descricao from acerto_lote y where y.id=x.idacerto_lote) descr,x.data_baixa data,x.docsap docsap,x.quantidade quantidade from retorno_lote x where x.codigo=(select max(codigo) from retorno_lote)");
                id=Select.SelectSQL("select max(codigo) from retorno_lote").Rows[0][0]+"";
            }
            else
            {
                tabela = Select.SelectSQL("select (select lote from acerto_lote y where y.id=x.idacerto_lote) lote,(select cd from acerto_lote y where y.id=x.idacerto_lote) CD,(select item from acerto_lote y where y.id=x.idacerto_lote) item,(select descricao from acerto_lote y where y.id=x.idacerto_lote) descr,x.data_baixa data,x.docsap docsap,x.quantidade quantidade from retorno_lote x where x.codigo=" + id + "");
            }
            double total = 0;
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                total += double.Parse(tabela.Rows[a][6] + "");
            }

            textBox1.Text="Código de Rastreamento do SGA: "+id+""+Environment.NewLine;
            textBox1.Text += "Total: " + total + "" + Environment.NewLine;
            textBox1.Text += "======================================================" + Environment.NewLine + Environment.NewLine;

            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                textBox1.Text += "CD:" + tabela.Rows[a][1] + ""+Environment.NewLine;
                textBox1.Text += "Item:" + tabela.Rows[a][2] + "" + Environment.NewLine;
                textBox1.Text += "Descrição:" + tabela.Rows[a][3] + "" + Environment.NewLine;
                textBox1.Text += "Data:" + tabela.Rows[a][4] + "" + Environment.NewLine;
                textBox1.Text += "DocSap:" + tabela.Rows[a][5] + "" + Environment.NewLine;
                textBox1.Text += "Lote:" + tabela.Rows[a][0] + "" + Environment.NewLine;
                textBox1.Text += "Disponível:" + tabela.Rows[a][6] + "" + Environment.NewLine;
                textBox1.Text += "======================================================" + Environment.NewLine + Environment.NewLine;
            }
        }
    }
}
