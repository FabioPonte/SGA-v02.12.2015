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

namespace Atanor.Programas.Correcao.ATAR
{
    /// <summary>
    /// Interaction logic for ControlePatoBranco.xaml
    /// </summary>
    public partial class ControlePatoBranco : UserControl
    {
        public ControlePatoBranco()
        {
            InitializeComponent();
            listar();
        }

        string cd = "PATO BRANCO";

        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void listar()
        {
            cbo_item.ItemsSource = Select.SelectSQL("SELECT distinct descricao,item FROM acerto_lote where cd='" + cd + "'").DefaultView;
            cbo_item.DisplayMemberPath = "descricao";
            cbo_item.SelectedValuePath = "item";
        }

        List<BarraLote> barras = new List<BarraLote>();

        public void Mostrar(string item)
        {
            Marcar();
            lsl_barras.Items.Clear();

            DataTable tabela = Select.SelectSQL("SELECT * FROM acerto_lote where cd='"+cd+"' and item='"+item+"' and quantidade >0 order by quantidade");
            
            agrid.Items.Clear();
            barras.Clear();
            double total = 0;

            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                BarraLote novo = new BarraLote();
                novo.Count = (a + 1) + "";
                novo.Id = tabela.Rows[a]["id"] + "";
                novo.Lote = tabela.Rows[a]["lote"] + "";
                novo.Max = double.Parse(tabela.Rows[a]["quantidade"] + "");
                novo.Click += new BarraLote.click(novo_Click);
                total += double.Parse(tabela.Rows[a]["quantidade"] + "");
                barras.Add(novo);
                agrid.Items.Add(barras[barras.Count-1]);
            }

            lbl_total.Content = String.Format("{0:0,0}", total) + "";
        }

        void novo_Click(UserControl controle)
        {
            Marcar();
        }

        public void Marcar()
        {
            lsl_barras.Items.Clear();
            double total = 0;
            for (int a = 0; a < barras.Count; a++)
            {
                if (barras[a].Valor > 0)
                {
                    total += double.Parse(barras[a].Valor + "");
                    lsl_barras.Items.Add(""+barras[a].Lote+" == "+barras[a].Valor+"");
                }
            }
            lbl_soma.Content = String.Format("{0:0,0}", total) + "";
        }

        private void cbo_item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Mostrar(cbo_item.SelectedValue + "");
            }
            catch { }
        }

        private void btn_auto_Click(object sender, RoutedEventArgs e)
        {
            double total = 0;
            try
            {
                total = double.Parse(txt_auto.Text);
            }
            catch { }

            if (total > 0)
            {
                for (int a = 0; a < barras.Count; a++)
                {
                    barras[a].Valor = 0;
                }
                for (int a = 0; a < barras.Count; a++)
                {
                    if (barras[a].Max <= total)
                    {
                        barras[a].Valor = barras[a].Max;
                        total = total - barras[a].Max;
                    }
                    else
                    {
                        barras[a].Valor = total;
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (txt_doc.Text.Trim() != "")
            {

                double codigo = 0;
                try
                {
                    codigo = double.Parse(Select.SelectSQL("SELECT max(codigo) FROM retorno_lote").Rows[0][0] + "");
                }
                catch { }

                codigo++;

                List<string> coluna = new List<string>();
                coluna.Add("idacerto_lote");
                coluna.Add("data_baixa");
                coluna.Add("docsap");
                coluna.Add("quantidade");
                coluna.Add("codigo");

                List<dynamic> valores = new List<dynamic>();
                for (int a = 0; a < barras.Count; a++)
                {
                    if (barras[a].Valor > 0)
                    {
                        valores.Add(barras[a].Id);
                        valores.Add(Facilitadores.ConverterDataParaDataDoMysql.Converter(DateTime.Now));
                        valores.Add(txt_doc.Text);
                        valores.Add(barras[a].Valor);
                        valores.Add(codigo);
                    }
                }

                if (ExecuteNonSql.Executar("retorno_lote", TipoDeOperacao.Tipo.InsertMultiplo, coluna, valores, null) != -1)
                {

                    for (int a = 0; a < barras.Count; a++)
                    {
                        if (barras[a].Valor > 0)
                        {
                            List<string> x_coluna = new List<string>();
                            x_coluna.Add("quantidade");

                            List<dynamic> x_valores = new List<dynamic>();
                            double inicial = double.Parse(Select.SelectSQL("select quantidade from acerto_lote where id=" + barras[a].Id + "").Rows[0][0] + "");
                            inicial = inicial - barras[a].Valor;
                            if (inicial == 0)
                                x_valores.Add(0);
                            else
                                x_valores.Add(inicial);

                            List<dynamic> x_condicao = new List<dynamic>();
                            x_condicao.Add("id=" + barras[a].Id + "");

                            if (ExecuteNonSql.Executar("acerto_lote", TipoDeOperacao.Tipo.Update, x_coluna, x_valores, x_condicao) != -1)
                            {

                            }
                        }
                    }
                    Mostrar(cbo_item.SelectedValue + "");
                    Sessao.AbrirPrograma(new Programas.Correcao.Resumo(),this);
                }
                else
                {
                    MsgBox.Show.Error("Erro ao dar baixa.");

                }
                    
            }
        }

        void ExecuteNonSql_Erro(string msg)
        {
            MsgBox.Show.Error(msg);
        }
    }
}
