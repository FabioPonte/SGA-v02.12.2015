using Conector;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Atanor.Programas.Suplly
{
    class RelatoriodeHistoricoDeEstoque
    {
        List<Banco.historico_lote> hist1, hist2;

        public void Abrir(DateTime data1, DateTime data2, int tipo, List<string> wheres)
        {
            if (tipo == 1)
            {
                Programas.RelatorioHTML pagina = new RelatorioHTML(PorProduto(data1, data2, wheres), true);
                pagina.ShowDialog();
            }
            if (tipo == 2)
            {
                Programas.RelatorioHTML pagina = new RelatorioHTML(PorLocal(data1, data2, wheres), true);
                pagina.ShowDialog();
            }
            if (tipo == 3)
            {
                Programas.RelatorioHTML pagina = new RelatorioHTML(PorDeposito(data1, data2, wheres), true);
                pagina.ShowDialog();
            }
        }

        private string obterHTML()
        {
            string html = "";

            html += " <html>";
            html += "<title>Histório de Lote</title>";
            html += "<style> body { padding:5px;}";
            html += "h1";
            html += "{";
            html += "font-family:verdana;";
            html += "font-size:15px;";
            html += "padding:10px;";
            html += "font-color:gray;";
            html += "border:1px solid gray;";
            html += "}";
            html += "h2";
            html += "{";
            html += "font-family:verdana;";
            html += "font-size:14px;";
            html += "background:#75A81A;";
            html += "color:white;";
            html += "margin-bottom:-0px;";
            html += "padding:5px;";
            html += "}";
            html += "table";
            html += "{";
            html += "font-family:verdana;";
            html += "font-size:11px;";
            html += "font-color:gray;";
            html += "border:2px solid #75A81A";
            html += "}";
            html += "th";
            html += "{";
            html += "background:#89C61F;";
            html += "color:white;";
            html += "padding:5px;";
            html += "}";
            html += "td";
            html += "{";
            html += "text-align:center;";
            html += "padding:5px;";
            html += "border-bottom:1px solid #89C61F;";
            html += "}";
            html += ".total{";
            html += "text-decoration:underline;";
            html += "color:red;";
            html += "}";
            html += "</style>";
            html += "<center><img src='logo2.png'>";
            return html;
        }

        private string ponto(dynamic c)
        {

            string af = c + "";
            double valor = double.Parse(af);
            if (valor == 0)
            {
                return "0";
            }

            return String.Format("{0:0,0}", valor);

            return "0";

        }

        string PorLocal(DateTime data1, DateTime data2, List<string> wheres)
        {
            string where = "";
            if (wheres.Count > 0)
            {
                for (int a = 0; a < wheres.Count; a++)
                {
                    where += "'" + wheres[a] + "',";
                }
                where = where.Substring(0, where.Length - 1);
                where = " and local in (" + where + ")";
            }

            Boolean MesmaData = false;
            hist1 = Banco.historico_lote.Obter("data='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(data1) + "' order by 2,6");
            hist2 = Banco.historico_lote.Obter("data='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(data2) + "' order by 2,6");
            DataTable tabela = Select.SelectSQL("select distinct local from historico_lote where data in ('" + Facilitadores.ConverterDataParaDataDoMysql.Converter(data1) + "','" + Facilitadores.ConverterDataParaDataDoMysql.Converter(data2) + "') " + where + " order by 1");
            List<pacHistorico> obanco = Gerar();
            if (data1 == data2) { MesmaData = true; }

            string html = obterHTML();
            if (!MesmaData)
            {
                html += "<h1> Comparação entre (" + data1.Day + "/" + data1.Month + "/" + data1.Year + " " + data1.Hour + ":" + data1.Minute + ") e (" + data2.Day + "/" + data2.Month + "/" + data2.Year + " " + data2.Hour + ":" + data2.Minute + ")</h1>";
            }
            else
            {
                html += "<h1> Relatório do dia (" + data1.Day + "/" + data1.Month + "/" + data1.Year + " " + data1.Hour + ":" + data1.Minute + ") </h1>";
            }
            html += "<hr>";


            for (int c = 0; c < tabela.Rows.Count; c++)
            {
                List<pacHistorico> banco = obanco.Where(i => i.h.Local == "" + tabela.Rows[c][0]).ToList();
                html += "<h2>" + tabela.Rows[c][0] + "</H2>";
                html += "<table width='100%' cellspacing='0'>";
                html += "<tr>";
                html += "<th>Cod</th>";
                html += "<th>Produto</th>";
                html += "<th>Lote</th>";
                html += "<th>Local</th>";
                html += "<th>Depósito</th>";
                html += "<th>Quantidade 1 (" + data1.Day + "/" + data1.Month + "/" + data1.Year + " " + data1.Hour + ":" + data1.Minute + ")</th>";
                if (!MesmaData)
                {
                    html += "<th>Quantidade 2 (" + data2.Day + "/" + data2.Month + "/" + data2.Year + " " + data2.Hour + ":" + data2.Minute + ")</th>";
                    html += "<th>~</th>";
                }
                html += "<th>Custo 1 (" + data1.Day + "/" + data1.Month + "/" + data1.Year + " " + data1.Hour + ":" + data1.Minute + ")</th>";
                if (!MesmaData)
                {
                    html += "<th>Custo 2 (" + data2.Day + "/" + data2.Month + "/" + data2.Year + " " + data2.Hour + ":" + data2.Minute + ")</th>";
                }
                html += "<th>Vencimento</th>";
                html += "<th>Fabricação</th>";
                html += "</tr>";
                double quantidade1 = 0;
                double quantidade2 = 0;
                for (int a = 0; a < banco.Count; a++)
                {
                    html += "<tr>";
                    html += "<td>" + banco[a].h.Cod + "</td>";
                    html += "<td>" + banco[a].h.Produto + "</td>";
                    html += "<td>" + banco[a].h.Lote + "</td>";
                    html += "<td>" + banco[a].h.Local + "</td>";
                    html += "<td>" + banco[a].h.Desposito + "</td>";
                    html += "<td>" + ponto(banco[a].quantidade1) + "</td>";
                    quantidade1 += banco[a].quantidade1;
                    if (!MesmaData)
                    {
                        html += "<td>" + ponto(banco[a].quantidade2) + "</td>";
                        quantidade2 += banco[a].quantidade2;
                        if (banco[a].diferenca < 0) { html += "<td><img src='cima.jpg'></td>"; }
                        if (banco[a].diferenca == 0) { html += "<td><img src='meio.jpg'></td>"; }
                        if (banco[a].diferenca > 0) { html += "<td><img src='baixo.jpg'></td>"; }
                    }

                    html += "<td>" + banco[a].custo1 + "</td>";
                    if (!MesmaData)
                    {
                        html += "<td>" + banco[a].custo2 + "</td>";
                    }

                    html += "<td>" + banco[a].h.Vencimento + "</td>";
                    html += "<td>" + banco[a].h.Fabricacao + "</td>";
                    html += "</tr>";
                }
                double diferenca = quantidade1 - quantidade2;

                html += "<tr class='total'>";
                html += "<th></th>";
                html += "<th></th>";
                html += "<th></th>";
                html += "<th></th>";
                html += "<th></th>";
                html += "<th>" + ponto(quantidade1) + "</th>";
                if (!MesmaData)
                {
                    html += "<th>" + ponto(quantidade2) + "</th>";
                    if (diferenca < 0) { html += "<th><img src='cima.jpg'></th>"; }
                    if (diferenca == 0) { html += "<th><img src='meio.jpg'></th>"; }
                    if (diferenca > 0) { html += "<th><img src='baixo.jpg'></th>"; }
                    html += "<th></th>";
                }
                html += "<th></th>";
                html += "<th></th>";
                html += "<th></th>";
                html += "</tr>";
                html += "</table>";
            }


            string url = Environment.CurrentDirectory + "\\Relatorios\\" + Environment.UserName + "-" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ".html";
            StreamWriter escritor = new StreamWriter(url, false, Encoding.Default);
            escritor.Write(html);
            escritor.Close();

            return url;
        }

        string PorDeposito(DateTime data1, DateTime data2, List<string> wheres)
        {

            string where = "";
            if (wheres.Count > 0)
            {
                for (int a = 0; a < wheres.Count; a++)
                {
                    where += "'" + wheres[a] + "',";
                }
                where = where.Substring(0, where.Length - 1);
                where = " and desposito in (" + where + ")";
            }


            Boolean MesmaData = false;
            hist1 = Banco.historico_lote.Obter("data='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(data1) + "' order by 2,6");
            hist2 = Banco.historico_lote.Obter("data='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(data2) + "' order by 2,6");

            DataTable tabela = Select.SelectSQL("select distinct desposito from historico_lote where data in ('" + Facilitadores.ConverterDataParaDataDoMysql.Converter(data1) + "','" + Facilitadores.ConverterDataParaDataDoMysql.Converter(data2) + "') " + where + " order by 1");

            List<pacHistorico> obanco = Gerar();

            if (data1 == data2)
            {
                MesmaData = true;
            }

            string html = obterHTML();

            if (!MesmaData)
            {
                html += "<h1> Comparação entre (" + data1.Day + "/" + data1.Month + "/" + data1.Year + " " + data1.Hour + ":" + data1.Minute + ") e (" + data2.Day + "/" + data2.Month + "/" + data2.Year + " " + data2.Hour + ":" + data2.Minute + ")</h1>";
            }
            else
            {
                html += "<h1> Relatório do dia (" + data1.Day + "/" + data1.Month + "/" + data1.Year + " " + data1.Hour + ":" + data1.Minute + ") </h1>";
            }
            html += "<hr>";


            for (int c = 0; c < tabela.Rows.Count; c++)
            {


                List<pacHistorico> banco = obanco.Where(i => i.h.Desposito == "" + tabela.Rows[c][0]).ToList();

                html += "<h2>" + tabela.Rows[c][0] + "</H2>";

                html += "<table width='100%' cellspacing='0'>";
                html += "<tr>";
                html += "<th>Cod</th>";
                html += "<th>Produto</th>";
                html += "<th>Lote</th>";
                html += "<th>Local</th>";
                html += "<th>Depósito</th>";
                html += "<th>Quantidade 1 (" + data1.Day + "/" + data1.Month + "/" + data1.Year + " " + data1.Hour + ":" + data1.Minute + ")</th>";
                if (!MesmaData)
                {
                    html += "<th>Quantidade 2 (" + data2.Day + "/" + data2.Month + "/" + data2.Year + " " + data2.Hour + ":" + data2.Minute + ")</th>";
                    html += "<th>~</th>";
                }
                html += "<th>Custo 1 (" + data1.Day + "/" + data1.Month + "/" + data1.Year + " " + data1.Hour + ":" + data1.Minute + ")</th>";
                if (!MesmaData)
                {
                    html += "<th>Custo 2 (" + data2.Day + "/" + data2.Month + "/" + data2.Year + " " + data2.Hour + ":" + data2.Minute + ")</th>";
                }
                html += "<th>Vencimento</th>";
                html += "<th>Fabricação</th>";
                html += "</tr>";

                double quantidade1 = 0;
                double quantidade2 = 0;


                for (int a = 0; a < banco.Count; a++)
                {
                    html += "<tr>";
                    html += "<td>" + banco[a].h.Cod + "</td>";
                    html += "<td>" + banco[a].h.Produto + "</td>";
                    html += "<td>" + banco[a].h.Lote + "</td>";
                    html += "<td>" + banco[a].h.Local + "</td>";
                    html += "<td>" + banco[a].h.Desposito + "</td>";
                    html += "<td>" + ponto(banco[a].quantidade1) + "</td>";
                    quantidade1 += banco[a].quantidade1;
                    if (!MesmaData)
                    {
                        html += "<td>" + ponto(banco[a].quantidade2) + "</td>";
                        quantidade2 += banco[a].quantidade2;
                        if (banco[a].diferenca < 0) { html += "<td><img src='cima.jpg'></td>"; }
                        if (banco[a].diferenca == 0) { html += "<td><img src='meio.jpg'></td>"; }
                        if (banco[a].diferenca > 0) { html += "<td><img src='baixo.jpg'></td>"; }
                    }
                    html += "<td>" + banco[a].custo1 + "</td>";
                    if (!MesmaData)
                    {
                        html += "<td>" + banco[a].custo2 + "</td>";
                    }

                    html += "<td>" + banco[a].h.Vencimento + "</td>";
                    html += "<td>" + banco[a].h.Fabricacao + "</td>";
                    html += "</tr>";
                }
                double diferenca = quantidade1 - quantidade2;

                html += "<tr class='total'>";
                html += "<th></th>";
                html += "<th></th>";
                html += "<th></th>";
                html += "<td></th>";
                html += "<th></th>";
                html += "<th>" + ponto(quantidade1) + "</th>";
                if (!MesmaData)
                {
                    html += "<th>" + ponto(quantidade2) + "</th>";
                    if (diferenca < 0) { html += "<th><img src='cima.jpg'></th>"; }
                    if (diferenca == 0) { html += "<th><img src='meio.jpg'></th>"; }
                    if (diferenca > 0) { html += "<th><img src='baixo.jpg'></th>"; }
                    html += "<th></th>";
                }
                html += "<th></th>";
                html += "<th></th>";
                html += "<th></th>";


                html += "</tr>";
                html += "</table>";
            }


            string url = Environment.CurrentDirectory + "\\Relatorios\\" + Environment.UserName + "-" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ".html";
            StreamWriter escritor = new StreamWriter(url, false, Encoding.Default);
            escritor.Write(html);
            escritor.Close();

            return url;
        }

        string PorProduto(DateTime data1, DateTime data2, List<string> wheres)
        {

            string where = "";
            if (wheres.Count > 0)
            {
                for (int a = 0; a < wheres.Count; a++)
                {
                    where += "'" + wheres[a] + "',";
                }
                where = where.Substring(0, where.Length - 1);
                where = " and cod in (" + where + ")";
            }

            Boolean MesmaData = false;
            hist1 = Banco.historico_lote.Obter("data='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(data1) + "' order by 2,6");
            hist2 = Banco.historico_lote.Obter("data='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(data2) + "' order by 2,6");

            DataTable tabela = Select.SelectSQL("select distinct cod,produto from historico_lote where data in ('" + Facilitadores.ConverterDataParaDataDoMysql.Converter(data1) + "','" + Facilitadores.ConverterDataParaDataDoMysql.Converter(data2) + "') " + where + " order by 1");

            List<pacHistorico> obanco = Gerar();

            if (data1 == data2)
            {
                MesmaData = true;
            }




            string html = obterHTML();

            if (!MesmaData)
            {
                html += "<h1> Comparação entre (" + data1.Day + "/" + data1.Month + "/" + data1.Year + " " + data1.Hour + ":" + data1.Minute + ") e (" + data2.Day + "/" + data2.Month + "/" + data2.Year + " " + data2.Hour + ":" + data2.Minute + ")</h1>";
            }
            else
            {
                html += "<h1> Relatório do dia (" + data1.Day + "/" + data1.Month + "/" + data1.Year + " " + data1.Hour + ":" + data1.Minute + ") </h1>";
            }
            html += "<hr>";


            for (int c = 0; c < tabela.Rows.Count; c++)
            {


                List<pacHistorico> banco = obanco.Where(i => i.h.Cod == "" + tabela.Rows[c][0]).ToList();

                html += "<h2>" + tabela.Rows[c][0] + " - " + tabela.Rows[c][1] + "</H2>";

                html += "<table width='100%' cellspacing='0'>";
                html += "<tr>";
                html += "<th>Cod</th>";
                html += "<th>Produto</th>";
                html += "<th>Lote</th>";
                html += "<th>Local</th>";
                html += "<th>Depósito</th>";
                html += "<th>Quantidade 1 (" + data1.Day + "/" + data1.Month + "/" + data1.Year + " " + data1.Hour + ":" + data1.Minute + ")</th>";
                if (!MesmaData)
                {
                    html += "<th>Quantidade 2 (" + data2.Day + "/" + data2.Month + "/" + data2.Year + " " + data2.Hour + ":" + data2.Minute + ")</th>";
                    html += "<th>~</th>";
                }
                html += "<th>Custo 1 (" + data1.Day + "/" + data1.Month + "/" + data1.Year + " " + data1.Hour + ":" + data1.Minute + ")</th>";
                if (!MesmaData)
                {
                    html += "<th>Custo 2 (" + data2.Day + "/" + data2.Month + "/" + data2.Year + " " + data2.Hour + ":" + data2.Minute + ")</th>";
                }
                html += "<th>Vencimento</th>";
                html += "<th>Fabricação</th>";
                html += "</tr>";

                double quantidade1 = 0;
                double quantidade2 = 0;


                for (int a = 0; a < banco.Count; a++)
                {
                    html += "<tr>";
                    html += "<td>" + banco[a].h.Cod + "</td>";
                    html += "<td>" + banco[a].h.Produto + "</td>";
                    html += "<td>" + banco[a].h.Lote + "</td>";
                    html += "<td>" + banco[a].h.Local + "</td>";
                    html += "<td>" + banco[a].h.Desposito + "</td>";
                    html += "<td>" + ponto(banco[a].quantidade1) + "</td>";
                    quantidade1 += banco[a].quantidade1;
                    if (!MesmaData)
                    {
                        html += "<td>" + ponto(banco[a].quantidade2) + "</td>";
                        quantidade2 += banco[a].quantidade2;
                        if (banco[a].diferenca < 0) { html += "<td><img src='cima.jpg'></td>"; }
                        if (banco[a].diferenca == 0) { html += "<td><img src='meio.jpg'></td>"; }
                        if (banco[a].diferenca > 0) { html += "<td><img src='baixo.jpg'></td>"; }
                    }
                    html += "<td>" + banco[a].custo1 + "</td>";
                    if (!MesmaData)
                    {
                        html += "<td>" + banco[a].custo2 + "</td>";
                    }

                    html += "<td>" + banco[a].h.Vencimento + "</td>";
                    html += "<td>" + banco[a].h.Fabricacao + "</td>";

                    html += "</tr>";
                }
                double diferenca = quantidade1 - quantidade2;

                html += "<tr class='total'>";
                html += "<th></th>";
                html += "<th></th>";
                html += "<th></th>";
                html += "<th></th>";

                html += "<th></th>";

                html += "<th>" + ponto(quantidade1) + "</th>";
                if (!MesmaData)
                {
                    html += "<th>" + ponto(quantidade2) + "</th>";
                    if (diferenca < 0) { html += "<th><img src='cima.jpg'></th>"; }
                    if (diferenca == 0) { html += "<th><img src='meio.jpg'></th>"; }
                    if (diferenca > 0) { html += "<th><img src='baixo.jpg'></th>"; }
                    html += "<th></th>";
                }
                html += "<th></th>";
                html += "<th></th>";
                html += "<th></th>";


                html += "</tr>";
                html += "</table>";
            }


            string url = Environment.CurrentDirectory + "\\Relatorios\\" + Environment.UserName + "-" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ".html";
            StreamWriter escritor = new StreamWriter(url, false, Encoding.Default);
            escritor.Write(html);
            escritor.Close();

            return url;
        }







        private List<pacHistorico> Gerar()
        {
            List<pacHistorico> hist = new List<pacHistorico>();

            for (int a = 0; a < hist1.Count; a++)
            {
                pacHistorico p = new pacHistorico();
                Banco.historico_lote n = tem(hist1[a], hist2);
                if (n != null)
                {
                    p.h = hist1[a];
                    p.custo1 = hist1[a].Custo;
                    p.custo2 = n.Custo;
                    p.quantidade1 = hist1[a].Quantidade;
                    p.quantidade2 = n.Quantidade;
                    p.diferenca = p.quantidade1 - p.quantidade2;
                }
                else
                {
                    p.h = hist1[a];
                    p.custo1 = hist1[a].Custo;
                    p.custo2 = 0;
                    p.quantidade1 = hist1[a].Quantidade;
                    p.quantidade2 = 0;
                    p.diferenca = p.quantidade1 - p.quantidade2;
                }
                hist.Add(p);
            }

            for (int a = 0; a < hist2.Count; a++)
            {
                pacHistorico p = new pacHistorico();
                Banco.historico_lote n = tem(hist2[a], hist1);
                if (n == null)
                {
                    p.h = hist2[a];
                    p.custo1 = 0;
                    p.custo2 = hist2[a].Custo;
                    p.quantidade1 = 0;
                    p.quantidade2 = hist2[a].Quantidade;
                    p.diferenca = p.quantidade1 - p.quantidade2;
                    hist.Add(p);
                }
            }



            return hist;
        }

        private Banco.historico_lote tem(Banco.historico_lote h, List<Banco.historico_lote> hi)
        {
            for (int a = 0; a < hi.Count; a++)
            {
                if (h.Oid == hi[a].Oid)
                {
                    return hi[a];
                }
            }
            return null;
        }
    }
    public class pacHistorico
    {
        public Banco.historico_lote h = new Banco.historico_lote();
        public double quantidade1 = 0;
        public double quantidade2 = 0;
        public double custo1 = 0;
        public double custo2 = 0;
        public double diferenca = 0;
    }

}
