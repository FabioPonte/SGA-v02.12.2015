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

namespace Atanor.Programas.Expedicao
{
    /// <summary>
    /// Interaction logic for ControleNotas.xaml
    /// </summary>
    public partial class ControleNotas : UserControl
    {

        public string per = "24";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/packages2.png", UriKind.RelativeOrAbsolute));
        public string nome = "Controle de Notas Expedidas.";

        BancoFileIanez novo = new BancoFileIanez(@"c:\notas\");

        public ControleNotas()
        {
            InitializeComponent();
            novo.Carregando += Novo_Carregando;
            novo.Erro += Novo_Erro;
            novo.Esperando += Novo_Esperando;
            novo.Msg += Novo_Msg;
            novo.Retornado += Novo_Retornado;
            novo.Retorno += Novo_Retorno;



            novo.Select("select  distinct T1.DocEntry, T1.Serial, t2.TargetType, t1.CANCELED, t1.DocStatus, t1.BPLId, t1.BPLName, t1.CardCode, t1.CardName, (SELECT MAX(countrys) FROM inv12 X WHERE X.docentry=t2.DocEntry) AS 'PAIS', (SELECT MAX(states) FROM inv12 X WHERE X.docentry=t2.DocEntry)  AS 'ESTADO', (SELECT (SELECT NAME FROM OCNT WHERE ABSID=X.countys) FROM inv12 X WHERE X.docentry=t2.DocEntry)  AS 'CIDADE', (SELECT T2.SlpName FROM OSLP T2 WHERE t1.[SlpCode] = T2.[SlpCode] )  AS 'VENDEDOR', t1.DocDate, (select TrnspName from oshp T99 WHERE T99.TrnspCode=t1.TrnspCode) frete, CONVERT(int , t1.U_nfe_STU) cod, CONVERT(varchar(200), t1.U_nfe_STU_Motivo) motivo   from oinv t1, inv1 t2 where t1.docentry=t2.docentry and t1.BPLId=5 and t2.basetype=15 union all select  distinct T1.DocEntry, T1.Serial, t2.TargetType, t1.CANCELED, t1.DocStatus, t1.BPLId, t1.BPLName, t1.CardCode, t1.CardName, (SELECT MAX(countrys) FROM inv12 X WHERE X.docentry=t2.DocEntry) AS 'PAIS', (SELECT MAX(states) FROM inv12 X WHERE X.docentry=t2.DocEntry)  AS 'ESTADO', (SELECT (SELECT NAME FROM OCNT WHERE ABSID=X.countys) FROM inv12 X WHERE X.docentry=t2.DocEntry)  AS 'CIDADE', (SELECT T2.SlpName FROM OSLP T2 WHERE t1.[SlpCode] = T2.[SlpCode] )  AS 'VENDEDOR', t1.DocDate, (select TrnspName from oshp T99 WHERE T99.TrnspCode=t1.TrnspCode) frete, CONVERT(int , t1.U_nfe_STU) cod, CONVERT(varchar(200), t1.U_nfe_STU_Motivo) motivo from odln t1, dln1 t2 where t1.docentry=t2.docentry and t1.BPLId=5 and (t2.BaseType=13 or t2.BaseType=15) order by 2");

            MsgBox.Show.EspereAbrir();
        }


        DataTable tabelaSAP = new DataTable();
        DataTable tabelaSGA = new DataTable();
        DataTable tabelaDesconsiderada = new DataTable();
        DataTable tabelaResultado = new DataTable();

        private void Novo_Retorno(System.Data.DataSet tabelas)
        {
            MsgBox.Show.EspereFechar();
            tabelaSAP = tabelas.Tables[0];
            tabelaSGA = Select.SelectSQL("select distinct nota from expedicao order by 1");
            tabelaDesconsiderada = Select.SelectSQL("select * from expedicao_notas order by 2");
            for(int a = 0; a < tabelaSAP.Columns.Count; a++)
                tabelaResultado.Columns.Add(tabelaSAP.Columns[a].ColumnName);
            CruzarInformacoes();
        }

        private void CruzarInformacoes()
        {
            int c = tabelaSAP.Columns.Count;
            object[] infos = new object[c];
            for (int a = 0; a < tabelaSAP.Rows.Count; a++)
            {
                if (!tem(tabelaSAP.Rows[a][1] + ""))
                {
                    infos = new object[c];
                    for (int b = 0; b < c; b++)
                        infos[b] = tabelaSAP.Rows[a][b];
                    tabelaResultado.Rows.Add(infos);
                }
            }
            Mostrar();
        }
        private Boolean tem(string nota)
        {
            for (int b = 0; b < tabelaSGA.Rows.Count; b++)
            {
                if (nota == tabelaSGA.Rows[b][0] + "")
                {
                    return true;
                }
            }
            for(int a = 0; a < tabelaDesconsiderada.Rows.Count; a++)
            {
                if (nota == tabelaDesconsiderada.Rows[a]["nota"] + "")
                {
                    return true;
                }
            }
            return false;
        }
        

        

        private void Mostrar()
        {
            int c = 0;
            for (int a = 0; a < tabelaResultado.Rows.Count; a++)
            {
                if ((tabelaResultado.Rows[a][3] + "") == "N")
                {
                    if ((tabelaResultado.Rows[a][2] + "") == "Null" || (tabelaResultado.Rows[a][2] + "") == "-1")
                    {
                        Programas.Expedicao.Controles.ButtonNotas novo = new Controles.ButtonNotas();
                        novo.Nota = tabelaResultado.Rows[a][1] + "";
                        novo.Cliente = tabelaResultado.Rows[a][8] + "";
                        novo.Estado = tabelaResultado.Rows[a][10] + "";
                        novo.Cidade = tabelaResultado.Rows[a][11] + "";
                        novo.Sefaz = tabelaResultado.Rows[a][15] + "";
                        novo.Sefazmotico = tabelaResultado.Rows[a][16] + "";
                        novo.Vendedor = tabelaResultado.Rows[a][12] + "";
                        novo.Frete = tabelaResultado.Rows[a][14] + "";
                        novo.Data = Facilitadores.ConverterDataSQLemDataTime.converter(tabelaResultado.Rows[a][13] + "");
                        c++;
                        novo.Listar();
                        painel.Children.Add(novo);
                    }
                }
            }

            lbl_info.Content = "" + c + " Sem expedição";
        }

        private void Novo_Retornado()
        {
            MsgBox.Show.EspereFechar();
        }

        private void Novo_Msg(string msg)
        {
            MsgBox.Show.aguarde.MSG.Content = msg;
        }

        private void Novo_Esperando()
        {
            MsgBox.Show.aguarde.MSG.Content = "Aguarde!";
        }

        private void Novo_Erro(string msg)
        {
            MsgBox.Show.EspereFechar();
            MsgBox.Show.Error(msg);
        }

        private void Novo_Carregando()
        {

            MsgBox.Show.aguarde.MSG.Content = "Carregando!";
        }

        private void btn_atualizar_Click(object sender, RoutedEventArgs e)
        {
             tabelaSAP = new DataTable();
             tabelaSGA = new DataTable();
             tabelaDesconsiderada = new DataTable();
             tabelaResultado = new DataTable();
            painel.Children.Clear();

            novo.Select("select  distinct T1.DocEntry, T1.Serial, t2.TargetType, t1.CANCELED, t1.DocStatus, t1.BPLId, t1.BPLName, t1.CardCode, t1.CardName, (SELECT MAX(countrys) FROM inv12 X WHERE X.docentry=t2.DocEntry) AS 'PAIS', (SELECT MAX(states) FROM inv12 X WHERE X.docentry=t2.DocEntry)  AS 'ESTADO', (SELECT (SELECT NAME FROM OCNT WHERE ABSID=X.countys) FROM inv12 X WHERE X.docentry=t2.DocEntry)  AS 'CIDADE', (SELECT T2.SlpName FROM OSLP T2 WHERE t1.[SlpCode] = T2.[SlpCode] )  AS 'VENDEDOR', t1.DocDate, (select TrnspName from oshp T99 WHERE T99.TrnspCode=t1.TrnspCode) frete, CONVERT(int , t1.U_nfe_STU) cod, CONVERT(varchar(200), t1.U_nfe_STU_Motivo) motivo   from oinv t1, inv1 t2 where t1.docentry=t2.docentry and t1.BPLId=5 and t2.basetype=15 union all select  distinct T1.DocEntry, T1.Serial, t2.TargetType, t1.CANCELED, t1.DocStatus, t1.BPLId, t1.BPLName, t1.CardCode, t1.CardName, (SELECT MAX(countrys) FROM inv12 X WHERE X.docentry=t2.DocEntry) AS 'PAIS', (SELECT MAX(states) FROM inv12 X WHERE X.docentry=t2.DocEntry)  AS 'ESTADO', (SELECT (SELECT NAME FROM OCNT WHERE ABSID=X.countys) FROM inv12 X WHERE X.docentry=t2.DocEntry)  AS 'CIDADE', (SELECT T2.SlpName FROM OSLP T2 WHERE t1.[SlpCode] = T2.[SlpCode] )  AS 'VENDEDOR', t1.DocDate, (select TrnspName from oshp T99 WHERE T99.TrnspCode=t1.TrnspCode) frete, CONVERT(int , t1.U_nfe_STU) cod, CONVERT(varchar(200), t1.U_nfe_STU_Motivo) motivo from odln t1, dln1 t2 where t1.docentry=t2.docentry and t1.BPLId=5 and (t2.BaseType=13 or t2.BaseType=15) order by 2");

            MsgBox.Show.EspereAbrir();
        }
    }
}
