using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
using System.Windows.Controls;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

namespace Atanor.Programas.Expedicao
{
    public class GerarRelatoriodeDivisaodeFretes
    {
        static public string gerar()
        {

            DataTable tabela = Select.SelectSQL("SELECT y.apelido,count(y.apelido) FROM romaneio x,transportadoras y where y.id=x.idtransportadoras group by y.apelido");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {

            }

            string html = "";
            html += "<html>";
            html += "<head>";
            html += "<script type='text/javascript' src='https://www.google.com/jsapi'></script>";
            html += "<script type='text/javascript'>";
            html += "google.load('visualization', '1', {packages:['corechart']});";
            html += "google.setOnLoadCallback(drawChart);";
            html += "function drawChart() {";
            html += "var data = google.visualization.arrayToDataTable([";
            html += "['Task', 'Hours per Day'],";
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                if (a == tabela.Rows.Count - 1)
                {
                    html += "['" + tabela.Rows[a][0] + "',     " + tabela.Rows[a][1] + "]";
                }
                else
                {
                    html += "['" + tabela.Rows[a][0] + "',     " + tabela.Rows[a][1] + "],";
                }
            }

            html += "]);";

            html += "var options = {";
            html += "title: 'Divisão de Fretes por Transportadoras'";
            html += "};";

            html += "var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));";
            html += "chart.draw(data, options);";
            html += "}";
            html += "</script>";
            html += "</head>";
            html += "<body>";
            html += "<div id='piechart_3d' style='width: 900px; height: 500px;'></div>";
            html += "</body>";
            html += "</html>";


            string url = Pastas.Relatorios + "Divisao" + Sessao.usuario.Usuario + "" + Facilitadores.Data.Dia() + "." + Facilitadores.Data.Mes() + "." + Facilitadores.Data.Ano() + "." + Facilitadores.Data.Hora() + "." + Facilitadores.Data.Minuto() + "." + Facilitadores.Data.Segundo() + ".htm";
            StreamWriter escritor = new StreamWriter(url, false, Encoding.Default);
            escritor.Write(html);
            escritor.Close();

            return url;
        }


        

        

       
    }
}
