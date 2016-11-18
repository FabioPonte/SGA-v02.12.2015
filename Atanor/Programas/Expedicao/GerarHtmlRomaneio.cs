using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Conector;
using System.IO;
namespace Atanor.Programas.Expedicao
{
    public class GerarHtmlRomaneio
    {
        static public string Gerar(string idRomaneio)
        {

            DataTable romaneio = Select.SelectSQL("SELECT r.id,r.data,m.nome motorista,m.cnh cnh,t.nome transportadora,c.placa placa,tc.nome tipo ,data,liquido,bruto FROM romaneio r,transportadoras t,motorista m,caminhao c,tipo_caminhao tc where r.idmotorista=m.id and r.idtransportadoras=t.id and r.idcaminhao=c.id and tc.id=c.idtipo_caminhao and r.id="+idRomaneio+"");
            DataTable expedicao = Select.SelectSQL("SELECT e.nota,e.data,e.cliente,e.cidade,e.estado,p.idsap,p.nome,e.lote,e.liquido,e.bruto FROM expedicao e,produtos p where e.idprodutos=p.id and e.idromaneio="+idRomaneio+"");

            string html="";
            html += "<html>";
            html += "<title>Romaneio</title>";
            html += "<body style='font-size:10px'>";
            html += "<table width='100%'>";
            html += "<tr>";
            html += "<th width='110'>";
            html += "<img src='logo.png' width='100'>";
            html += "</th>";
            html += "<th style='font-family:Lucida Sans;'>";
            html += "ROMANEIO DE EMBARQUE";
            html += "</th>";
            html += "</tr>";
            html += "</table>";
            html += "<hr>";
            html += "<table width='250px' cellspacing=0>";
            html += "<tr>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px'>NR ROMANEIO</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px'>DATA</th>";
            html += "</tr>";
            html += "<tr>";
            html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px'>" + idRomaneio + "</th>";
            html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px'>" + romaneio.Rows[0]["data"] + "</th>";
            html += "</tr>";
            html += "</table><br><br>";
            html += "";
            html += "<center>";
            html += "<table  cellspacing=0>";
            html += "<tr>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='120px'>NOTA FISCAL</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='120px'>EMISSÃO</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='320px'>CLIENTE	</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='120px'>CIDADE</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='60px'>UF</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='100px'>CODIGO</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='320px'>PRODUTO</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='160px'>LOTE</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='100px'>LIQUIDO</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='100px'>BRUTO</th>";
            html += "</tr>";
            html += "";
            html += "";

            for (int a = 0; a < expedicao.Rows.Count; a++)
            {

                html += "<tr>";
                html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px'>" + expedicao.Rows[a][0] + "</th>";
                html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px'>" + expedicao.Rows[a][1].ToString().Replace("00:00:00","") + "</th>";
                html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px'>" + expedicao.Rows[a][2] + "</th>";
                html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px'>" + expedicao.Rows[a][3] + "</th>";
                html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px'>" + expedicao.Rows[a][4] + "</th>";
                html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px'>" + expedicao.Rows[a][5] + "</th>";
                html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px'>" + expedicao.Rows[a][6] + "</th>";
                html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px'>" + expedicao.Rows[a][7] + "</th>";
                html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px'>" + expedicao.Rows[a][8] + "</th>";
                html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px'>" + expedicao.Rows[a][9] + "</th>";
                html += "</tr>";
                html += "";
            }


            html += "<tr>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='120px'>TOTAL</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='120px'></th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='320px'></th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='120px'></th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='60px'></th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='100px'></th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='320px'></th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='160px'></th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='100px'>" + romaneio.Rows[0]["liquido"] + "</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='100px'>" + romaneio.Rows[0]["bruto"] + "</th>";
            html += "</tr>";
            html += "";
            html += "</table>";
            html += "</center>";
            html += "";
            html += "<BR><BR><BR><BR><hr>";
            html += "";
            html += "</center>";
            html += "<table  cellspacing=0>";
            html += "<tr>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='120px'>TRANSPORTADORA</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='100px'>PLACA</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='120px'>TIPO</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='120px'>CHN</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='220px'>MOTORISTA</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='200px'>ASSINATURA MOTORISTA</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='200px'>ASSINATURA PORTARIA</th>";
            html += "<th style='background:gray;color:white;font-family:Lucida Sans;font-size:10px' width='200px'>CONFERENTE LOGÍSTICA</th>";
            html += "";
            html += "</tr>";
            html += "";
            html += "";
            html += "<tr>";
            html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px' height=60>" + romaneio.Rows[0]["transportadora"] + "</th>";
            html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px' height=60>" + romaneio.Rows[0]["placa"] + "</th>";
            html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px' height=60>" + romaneio.Rows[0]["tipo"] + "</th>";
            html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px' height=60>" + romaneio.Rows[0]["cnh"] + "</th>";
            html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px' height=60>" + romaneio.Rows[0]["motorista"] + "</th>";
            html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px' height=60> </th>";
            html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px' height=60> </th>";
            html += "<th style='border:1px solid gray;font-family:Lucida Sans;font-size:10px' height=60> </th>";
            html += "";
            html += "</tr>";
            html += "</TABLE>";

            string url = Pastas.Relatorios + "Romaneio" + Sessao.usuario.Usuario + "" + Facilitadores.Data.Dia() + "." + Facilitadores.Data.Mes() + "." + Facilitadores.Data.Ano() + "." + Facilitadores.Data.Hora() + "." + Facilitadores.Data.Minuto() + "." + Facilitadores.Data.Segundo() + ".htm";
            StreamWriter escritor = new StreamWriter(url, false,Encoding.Default);
            escritor.Write(html);
            escritor.Close();
            return url;
        }
    }
}
