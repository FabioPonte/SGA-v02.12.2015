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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Atanor.Programas.Suplly
{
    /// <summary>
    /// Interaction logic for ManutencaoLote.xaml
    /// </summary>
    public partial class ManutencaoLote : UserControl
    {

        public string per = "7";
        public string nome = "Historico de Lote";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/factory2.png", UriKind.RelativeOrAbsolute));
        BancoFileIanez novo = new BancoFileIanez(@"c:\notas\");
        public ManutencaoLote()
        {
            InitializeComponent();

            d_dia.Valor = DateTime.Now.Day;
            d_mes.Valor = DateTime.Now.Month;
            d_ano.Valor = DateTime.Now.Year;
            d_hora.Valor = DateTime.Now.Hour;
            d_minuto.Valor = DateTime.Now.Minute;

            novo.Carregando += Novo_Carregando;
            novo.Erro += Novo_Erro;
            novo.Esperando += Novo_Esperando;
            novo.Msg += Novo_Msg;
            novo.Retornado += Novo_Retornado;
            novo.Retorno += Novo_Retorno;

            Facilitadores.ConverteDataParaDataGrid.ConverterHora(ogrid);

            Conector.ExecuteNonSql.Erro += ExecuteNonSql_Erro;
            Listar();
        }

        private void ExecuteNonSql_Erro(string msg)
        {
            MessageBox.Show(msg);
        }

        DataTable tabela = new DataTable();

        

        private void Novo_Retorno(System.Data.DataSet tabelas)
        {
            tabela = tabelas.Tables[0];
            MsgBox.Show.EspereFechar();
            incluir();
        }

        

        private void Novo_Retornado()
        {
            MsgBox.Show.EspereFechar();
            MsgBox.Show.aguarde.MSG.Content = "Retornado.";
        }

        private void Novo_Msg(string msg)
        {
            MsgBox.Show.aguarde.MSG.Content = msg;
        }

        private void Novo_Esperando()
        {
            MsgBox.Show.aguarde.MSG.Content = "Buscando no SAP.";
        }

        private void Novo_Erro(string msg)
        {
            MsgBox.Show.EspereFechar();
            MsgBox.Show.Error(msg);
        }

        private void Novo_Carregando()
        {
            MsgBox.Show.aguarde.MSG.Content = "Buscando no SAP.";
        }

        private void Listar()
        {
            ogrid.ItemsSource = Select.SelectSQL("select data Dia,count(*) Quantidade from historico_lote group by data desc").DefaultView;
            ogrid.SelectedValuePath = "Dia";
        }

        private void pacote1_Click(ThemaMeritor.TipoEvento.evento tipo)
        {
            if (tipo == ThemaMeritor.TipoEvento.evento.Novo)
            {
                cadastrar();
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Editar)
            {
                MsgBox.Show.Error("Esta opção está desabilitada, por favor , exclua o item e inclua novamente");
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Excluir)
            {
                delete();   
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Cancelar)
            {
                btn_detalhar.IsEnabled = false;
            }
        }

        private void delete()
        {
            try
            {
                DateTime data = DateTime.Parse("" + ogrid.SelectedValue);

                string dt=Facilitadores.ConverterDataParaDataDoMysql.Converter(data);

                Banco.historico_lote n = new Banco.historico_lote();
                n.Condicao = "data='" + dt + "'";
                if (n.Excluir() != -1)
                {
                    MsgBox.Show.Info("Sucesso!");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao excluir.");
                }

            }
            catch { MsgBox.Show.Error("Data inválida!"); }
        }

        private void cadastrar()
        {
            novo.Select("SELECT  T0.[ITEMCODE] 'COD',  T4.ITEMNAME 'PRODUTO', T2.[ONHANDQTY] 'QUANTIDADE',  T4.[DISTNUMBER] 'LOTE',  T1.[BINCODE] 'LOCAL',  T1.[WHSCODE] 'DEPOSITO',(select T99.[ExpDate]  from [SBO_ATANOR].[DBO].OBTN T99 WHERE T99.ItemCode=T0.ITEMCODE AND T99.DistNumber=T4.[DISTNUMBER]) as 'DATA DO VENCIMENTO',(select T99.[MnfDate]  from [SBO_ATANOR].[DBO].OBTN T99 WHERE T99.ItemCode=T0.ITEMCODE AND T99.DistNumber=T4.[DISTNUMBER]) AS 'DATA DA FABRICAÇÃO',(SELECT B1.AvgPrice FROM [SBO_ATANOR].[DBO].OITW B1 where b1.itemcode=T4.ItemCode and B1.WHSCODE=T1.WHSCODE) Custo FROM   [SBO_ATANOR].[DBO].[OIBQ] T0    INNER  JOIN [SBO_ATANOR].[DBO].[OBIN] T1  ON     T0.[BINABS] = T1.[ABSENTRY]  AND  T0.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_ATANOR].[DBO].[OBBQ] T2    ON   T0.[BINABS] = T2.[BINABS]  AND  T0.[ITEMCODE] = T2.[ITEMCODE]  AND  T2.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_ATANOR].[DBO].[OSBQ] T3    ON  T0.[BINABS] = T3.[BINABS]  AND  T0.[ITEMCODE] = T3.[ITEMCODE]  AND  T3.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_ATANOR].[DBO].[OBTN] T4    ON   T2.[SNBMDABS] = T4.[ABSENTRY]   AND  T2.[ITEMCODE] = T4.[ITEMCODE]    LEFT OUTER  JOIN [SBO_ATANOR].[DBO].[OSRN] T5    ON  T3.[SNBMDABS] = T5.[ABSENTRY]  AND  T3.[ITEMCODE] = T5.[ITEMCODE]   WHERE  T1.[ABSENTRY] >= 0  AND  (T2.[ABSENTRY] IS NOT NULL) UNION ALL  SELECT  T0.[ITEMCODE] 'COD',  T4.ITEMNAME 'PRODUTO', T2.[ONHANDQTY] 'QUANTIDADE',  T4.[DISTNUMBER] 'LOTE',  T1.[BINCODE] 'LOCAL',  T1.[WHSCODE] 'DEPOSITO',(select T99.[ExpDate]  from [SBO_ATANOR].[DBO].OBTN T99 WHERE T99.ItemCode=T0.ITEMCODE AND T99.DistNumber=T4.[DISTNUMBER]) as 'DATA DO VENCIMENTO',(select T99.[MnfDate]  from [SBO_ATANOR].[DBO].OBTN T99 WHERE T99.ItemCode=T0.ITEMCODE AND T99.DistNumber=T4.[DISTNUMBER]) AS 'DATA DA FABRICAÇÃO',(SELECT B1.AvgPrice FROM [SBO_ATANOR].[DBO].OITW B1 where b1.itemcode=T4.ItemCode and B1.WHSCODE=T1.WHSCODE) Custo FROM   [SBO_ATANOR].[DBO].[OIBQ] T0    INNER  JOIN [SBO_ATANOR].[DBO].[OBIN] T1  ON     T0.[BINABS] = T1.[ABSENTRY]  AND  T0.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_ATANOR].[DBO].[OBBQ] T2    ON   T0.[BINABS] = T2.[BINABS]  AND  T0.[ITEMCODE] = T2.[ITEMCODE]  AND  T2.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_ATANOR].[DBO].[OSBQ] T3    ON  T0.[BINABS] = T3.[BINABS]  AND  T0.[ITEMCODE] = T3.[ITEMCODE]  AND  T3.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_ATANOR].[DBO].[OBTN] T4    ON    T2.[SNBMDABS] = T4.[ABSENTRY]  AND  T2.[ITEMCODE] = T4.[ITEMCODE]    LEFT OUTER  JOIN [SBO_ATANOR].[DBO].[OSRN] T5    ON  T3.[SNBMDABS] = T5.[ABSENTRY]  AND  T3.[ITEMCODE] = T5.[ITEMCODE]   WHERE  T1.[ABSENTRY] >= 0  AND  (T3.[ABSENTRY] IS NOT NULL) UNION ALL               SELECT  T0.[ITEMCODE] 'COD',  T4.ITEMNAME 'PRODUTO', T2.[ONHANDQTY] 'QUANTIDADE',  T4.[DISTNUMBER] 'LOTE',  T1.[BINCODE] 'LOCAL',  T1.[WHSCODE] 'DEPOSITO',(select T99.[ExpDate]  from [SBO_ATANOR].[DBO].OBTN T99 WHERE T99.ItemCode=T0.ITEMCODE AND T99.DistNumber=T4.[DISTNUMBER]) as 'DATA DO VENCIMENTO',(select T99.[MnfDate]  from [SBO_ATANOR].[DBO].OBTN T99 WHERE T99.ItemCode=T0.ITEMCODE AND T99.DistNumber=T4.[DISTNUMBER]) AS 'DATA DA FABRICAÇÃO',(SELECT B1.AvgPrice FROM [SBO_ATANOR].[DBO].OITW B1 where b1.itemcode=T4.ItemCode and B1.WHSCODE=T1.WHSCODE) Custo FROM   [SBO_ATANOR].[DBO].[OIBQ] T0    INNER  JOIN [SBO_ATANOR].[DBO].[OBIN] T1  ON     T0.[BINABS] = T1.[ABSENTRY]  AND  T0.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_ATANOR].[DBO].[OBBQ] T2    ON   T0.[BINABS] = T2.[BINABS]  AND  T0.[ITEMCODE] = T2.[ITEMCODE]  AND  T2.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_ATANOR].[DBO].[OSBQ] T3    ON  T0.[BINABS] = T3.[BINABS]  AND  T0.[ITEMCODE] = T3.[ITEMCODE]  AND  T3.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_ATANOR].[DBO].[OBTN] T4    ON  T2.[SNBMDABS] = T4.[ABSENTRY]    AND  T2.[ITEMCODE] = T4.[ITEMCODE]    LEFT OUTER  JOIN [SBO_ATANOR].[DBO].[OSRN] T5    ON  T3.[SNBMDABS] = T5.[ABSENTRY]  AND  T3.[ITEMCODE] = T5.[ITEMCODE]   WHERE	 T1.[ABSENTRY] >= 0  AND  (T2.[ABSENTRY] IS NULL AND  T3.[ABSENTRY] IS NULL) UNION ALL 					SELECT  T0.[ITEMCODE] 'COD',  T4.ITEMNAME 'PRODUTO', T2.[ONHANDQTY] 'QUANTIDADE',  T4.[DISTNUMBER] 'LOTE',  T1.[BINCODE] 'LOCAL',  T1.[WHSCODE] 'DEPOSITO',(select T99.[ExpDate]  from [SBO_CONSAGRO].[DBO].OBTN T99 WHERE T99.ItemCode=T0.ITEMCODE AND T99.DistNumber=T4.[DISTNUMBER]) as 'DATA DO VENCIMENTO',(select T99.[MnfDate]  from [SBO_CONSAGRO].[DBO].OBTN T99 WHERE T99.ItemCode=T0.ITEMCODE AND T99.DistNumber=T4.[DISTNUMBER]) AS 'DATA DA FABRICAÇÃO',(SELECT B1.AvgPrice FROM [SBO_CONSAGRO].[DBO].OITW B1 where b1.itemcode=T4.ItemCode and B1.WHSCODE=T1.WHSCODE) Custo FROM   [SBO_CONSAGRO].[DBO].[OIBQ] T0  INNER  JOIN [SBO_CONSAGRO].[DBO].[OBIN] T1  ON   T0.[BINABS] = T1.[ABSENTRY]  AND  T0.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_CONSAGRO].[DBO].[OBBQ] T2  ON   T0.[BINABS] = T2.[BINABS]  AND  T0.[ITEMCODE] = T2.[ITEMCODE]  AND  T2.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_CONSAGRO].[DBO].[OSBQ] T3  ON  T0.[BINABS] = T3.[BINABS]  AND  T0.[ITEMCODE] = T3.[ITEMCODE]  AND  T3.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_CONSAGRO].[DBO].[OBTN] T4  ON   T2.[SNBMDABS] = T4.[ABSENTRY]   AND  T2.[ITEMCODE] = T4.[ITEMCODE]    LEFT OUTER  JOIN [SBO_CONSAGRO].[DBO].[OSRN] T5  ON  T3.[SNBMDABS] = T5.[ABSENTRY]  AND  T3.[ITEMCODE] = T5.[ITEMCODE]   WHERE  T1.[ABSENTRY] >= 0  AND  (T2.[ABSENTRY] IS NOT NULL) UNION ALL  SELECT  T0.[ITEMCODE] 'COD',  T4.ITEMNAME 'PRODUTO', T2.[ONHANDQTY] 'QUANTIDADE',  T4.[DISTNUMBER] 'LOTE',  T1.[BINCODE] 'LOCAL',  T1.[WHSCODE] 'DEPOSITO',(select T99.[ExpDate]  from [SBO_CONSAGRO].[DBO].OBTN T99 WHERE T99.ItemCode=T0.ITEMCODE AND T99.DistNumber=T4.[DISTNUMBER]) as 'DATA DO VENCIMENTO',(select T99.[MnfDate]  from [SBO_CONSAGRO].[DBO].OBTN T99 WHERE T99.ItemCode=T0.ITEMCODE AND T99.DistNumber=T4.[DISTNUMBER]) AS 'DATA DA FABRICAÇÃO',(SELECT B1.AvgPrice FROM [SBO_CONSAGRO].[DBO].OITW B1 where b1.itemcode=T4.ItemCode and B1.WHSCODE=T1.WHSCODE) Custo FROM   [SBO_CONSAGRO].[DBO].[OIBQ] T0  INNER  JOIN [SBO_CONSAGRO].[DBO].[OBIN] T1  ON   T0.[BINABS] = T1.[ABSENTRY]  AND  T0.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_CONSAGRO].[DBO].[OBBQ] T2  ON   T0.[BINABS] = T2.[BINABS]  AND  T0.[ITEMCODE] = T2.[ITEMCODE]  AND  T2.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_CONSAGRO].[DBO].[OSBQ] T3  ON  T0.[BINABS] = T3.[BINABS]  AND  T0.[ITEMCODE] = T3.[ITEMCODE]  AND  T3.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_CONSAGRO].[DBO].[OBTN] T4  ON    T2.[SNBMDABS] = T4.[ABSENTRY]  AND  T2.[ITEMCODE] = T4.[ITEMCODE]    LEFT OUTER  JOIN [SBO_CONSAGRO].[DBO].[OSRN] T5  ON  T3.[SNBMDABS] = T5.[ABSENTRY]  AND  T3.[ITEMCODE] = T5.[ITEMCODE]   WHERE  T1.[ABSENTRY] >= 0  AND  (T3.[ABSENTRY] IS NOT NULL) UNION ALL               SELECT  T0.[ITEMCODE] 'COD',  T4.ITEMNAME 'PRODUTO', T2.[ONHANDQTY] 'QUANTIDADE',  T4.[DISTNUMBER] 'LOTE',  T1.[BINCODE] 'LOCAL',  T1.[WHSCODE] 'DEPOSITO',(select T99.[ExpDate]  from [SBO_CONSAGRO].[DBO].OBTN T99 WHERE T99.ItemCode=T0.ITEMCODE AND T99.DistNumber=T4.[DISTNUMBER]) as 'DATA DO VENCIMENTO',(select T99.[MnfDate]  from [SBO_CONSAGRO].[DBO].OBTN T99 WHERE T99.ItemCode=T0.ITEMCODE AND T99.DistNumber=T4.[DISTNUMBER]) AS 'DATA DA FABRICAÇÃO',(SELECT B1.AvgPrice FROM [SBO_CONSAGRO].[DBO].OITW B1 where b1.itemcode=T4.ItemCode and B1.WHSCODE=T1.WHSCODE) Custo FROM   [SBO_CONSAGRO].[DBO].[OIBQ] T0  INNER  JOIN [SBO_CONSAGRO].[DBO].[OBIN] T1  ON   T0.[BINABS] = T1.[ABSENTRY]  AND  T0.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_CONSAGRO].[DBO].[OBBQ] T2  ON   T0.[BINABS] = T2.[BINABS]  AND  T0.[ITEMCODE] = T2.[ITEMCODE]  AND  T2.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_CONSAGRO].[DBO].[OSBQ] T3  ON  T0.[BINABS] = T3.[BINABS]  AND  T0.[ITEMCODE] = T3.[ITEMCODE]  AND  T3.[ONHANDQTY] <> 0    LEFT OUTER  JOIN [SBO_CONSAGRO].[DBO].[OBTN] T4  ON  T2.[SNBMDABS] = T4.[ABSENTRY]    AND  T2.[ITEMCODE] = T4.[ITEMCODE]    LEFT OUTER  JOIN [SBO_CONSAGRO].[DBO].[OSRN] T5  ON  T3.[SNBMDABS] = T5.[ABSENTRY]  AND  T3.[ITEMCODE] = T5.[ITEMCODE]   WHERE	 T1.[ABSENTRY] >= 0  AND  (T2.[ABSENTRY] IS NULL AND  T3.[ABSENTRY] IS NULL) ");
            MsgBox.Show.EspereAbrir();
        }

        private void incluir()
        {
            Banco.historico_lote n = new Banco.historico_lote();
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                n.Cod = tabela.Rows[a][0] + "";
                n.Produto = tabela.Rows[a][1] + "";
                string qtd = tabela.Rows[a][2] + "";
                if (qtd.IndexOf(".") != -1)
                {
                    qtd = qtd.Substring(0, qtd.IndexOf("."));
                    n.Quantidade = double.Parse(qtd);
                }
                else
                {
                    n.Quantidade = 0;
                }
                n.Lote = tabela.Rows[a][3] + "";
                n.Local = tabela.Rows[a][4] + "";
                n.Desposito = tabela.Rows[a][5] + "";
                string data = "" + d_dia.Valor + "/" + d_mes.Valor + "/" + d_ano.Valor + " " + d_hora.Valor + ":" + d_minuto.Valor + ":00";
                n.Data = DateTime.Parse(data);
                n.Oid = "" + n.Cod + "" + n.Local + "" + n.Lote + "";

                n.Vencimento = ConvertData(tabela.Rows[a][6] + "");
                n.Fabricacao = ConvertData(tabela.Rows[a][7] + "");
                try
                {
                    n.Custo = double.Parse((tabela.Rows[a][8] + "").Replace(".", ","));
                }
                catch { n.Custo = 0; }

            }

            if (n.Inserir() != -1)
            {
                MsgBox.Show.Info("Cadastrado com sucesso!");
                Listar();
            }
            else
            {
                MsgBox.Show.Error("Erro ao cadastrar.");
            }
        }

        private string ConvertData(string data)
        {
            try
            {
                //2014-11-27T00: 00:00 - 02:00
                string dia = data.Substring(8, 2);
            string mes = data.Substring(5, 2); 
            string ano = data.Substring(0, 4);
         
               
                return ("" + dia + "/" + mes + "/" + ano + ""); 
            }
            catch { return ""; }
        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pacote1.ModoEdicao = true;
            btn_detalhar.IsEnabled = true;
        }

        

        private void btn_relatorio_Click(object sender, RoutedEventArgs e)
        {
            RelatoriodeHistoricoDeEstoque n = new RelatoriodeHistoricoDeEstoque();

            EscolherData dt = new EscolherData();
            dt.ShowDialog();

            if (dt.ok)
            {
                n.Abrir(dt.menor, dt.maior,dt.tipo,dt.wheres);
            }

        }

        private void btn_detalhar_Click(object sender, RoutedEventArgs e)
        {
            DateTime odia = DateTime.Parse(ogrid.SelectedValue + "");
            Sessao.AbrirPrograma(new Programas.Suplly.DetalhedoHistoricoDelote(odia), this);
        }
    }
}
