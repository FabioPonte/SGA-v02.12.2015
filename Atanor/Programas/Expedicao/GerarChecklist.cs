using Conector;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Atanor.Programas.Expedicao
{
    public class GerarChecklist
    {
        static public string Gerar(string idRomaneio)
        {
            try
            {
                DataTable romaneio = Select.SelectSQL("SELECT r.id,r.data,m.nome motorista,m.cnh cnh,t.nome transportadora,c.placa placa,tc.nome tipo ,data,liquido,bruto,r.criador criador FROM romaneio r,transportadoras t,motorista m,caminhao c,tipo_caminhao tc where r.idmotorista=m.id and r.idtransportadoras=t.id and r.idcaminhao=c.id and tc.id=c.idtipo_caminhao and r.id=" + idRomaneio + "");
                DataTable expedicao = Select.SelectSQL("SELECT e.nota,e.data,e.cliente,e.cidade,e.estado,p.idsap,p.nome,e.lote,e.liquido,e.bruto FROM expedicao e,produtos p where e.idprodutos=p.id and e.idromaneio=" + idRomaneio + "");

                DataTable produto = Select.SelectSQL("SELECT distinct p.nome FROM expedicao e,produtos p where e.idprodutos=p.id and e.idromaneio=" + idRomaneio + "");
                DataTable emissao = Select.SelectSQL("SELECT distinct e.data FROM expedicao e,produtos p where e.idprodutos=p.id and e.idromaneio=" + idRomaneio + "");
                DataTable nota = Select.SelectSQL("SELECT distinct e.nota FROM expedicao e,produtos p where e.idprodutos=p.id and e.idromaneio=" + idRomaneio + "");

                string urlModelo = Pastas.Modelos + "CHECKLIST\\modelo.htm";

                if (!File.Exists(urlModelo))
                {
                    MsgBox.Show.Error("O modelo de checklist não foi encontrado!");
                    return null;
                }

                string html = "";
                StreamReader leitor = new StreamReader(urlModelo, Encoding.Default);
                html = leitor.ReadToEnd();
                leitor.Close();

                html = html.Replace("0motorista0", romaneio.Rows[0]["motorista"] + "");
                html = html.Replace("0transportadora0", romaneio.Rows[0]["transportadora"] + "");
                html = html.Replace("0data0", romaneio.Rows[0]["data"] + "");
                html = html.Replace("0romaneio0", romaneio.Rows[0]["id"] + "");
                html = html.Replace("0placa0", romaneio.Rows[0]["placa"] + "");
                html = html.Replace("0tipo0", romaneio.Rows[0]["tipo"] + "");
                html = html.Replace("0cnh0", romaneio.Rows[0]["cnh"] + "");
                html = html.Replace("0criador0", romaneio.Rows[0]["criador"] + "");


                List<Banco.checklist> chk = Banco.checklist.Obter("idromaneio=" + idRomaneio + "");
                if (chk.Count > 0)
                {
                    html=SetarAsChecklist(chk[0], html);
                }
                else
                {
                    SetarAsChecklist(null, html);
                }

                string produtos = "";
                string notas = "";
                string emissoes = "";

                for (int a = 0; a < nota.Rows.Count; a++)
                {
                    notas += nota.Rows[a][0] + ",";
                }
                for (int a = 0; a < produto.Rows.Count; a++)
                {
                    produtos += produto.Rows[a][0] + ",";
                }
                for (int a = 0; a < emissao.Rows.Count; a++)
                {
                    emissoes += "" + emissao.Rows[a][0] + ",";
                }

                produtos = produtos.Substring(0, produtos.Length - 1);
                notas = notas.Substring(0, notas.Length - 1);
                emissoes = emissoes.Substring(0, emissoes.Length - 1);

                html = html.Replace("0produtos0", produtos);
                html = html.Replace("0notas0", notas);
                html = html.Replace("0emissoes0", emissoes).Replace("00:00:00", "");

                string url = Pastas.Relatorios + "CheckList" + Sessao.usuario.Usuario + "." + Facilitadores.Data.Dia() + "." + Facilitadores.Data.Mes() + "." + Facilitadores.Data.Ano() + "." + Facilitadores.Data.Hora() + "." + Facilitadores.Data.Minuto() + "." + Facilitadores.Data.Segundo() + ".htm";
                StreamWriter escritor = new StreamWriter(url, false, Encoding.Default);
                escritor.Write(html);
                escritor.Close();
                return url;
            }
            catch (Exception ex)
            {
                Facilitadores.ErroLog.Registrar(ex);
                MsgBox.Show.Error(ex + "");
                return "";
            }
        }

        static private string SetarAsChecklist(Banco.checklist chk,string Ohtml)
        {
            string html = Ohtml;
            if (chk != null)
            {
                if (chk.M1)
                {
                    html = html.Replace("MS1", "P");
                    html = html.Replace("MN1", "");
                }
                else
                {
                    html = html.Replace("MS1", "");
                    html = html.Replace("MN1", "P");
                }

                if (chk.M2)
                {
                    html = html.Replace("MS2", "P");
                    html = html.Replace("MN2", "");
                }
                else
                {
                    html = html.Replace("MS2", "");
                    html = html.Replace("MN2", "P");
                }

                if (chk.M3)
                {
                    html = html.Replace("MS3", "P");
                    html = html.Replace("MN3", "");
                }
                else
                {
                    html = html.Replace("MS3", "");
                    html = html.Replace("MN3", "P");
                }

                if (chk.M4)
                {
                    html = html.Replace("MS4", "P");
                    html = html.Replace("MN4", "");
                }
                else
                {
                    html = html.Replace("MS4", "");
                    html = html.Replace("MN4", "P");
                }


                if (chk.M5)
                {
                    html = html.Replace("MS5", "P");
                    html = html.Replace("MN5", "");
                }
                else
                {
                    html = html.Replace("MS5", "");
                    html = html.Replace("MN5", "P");
                }

                if (chk.I1)
                {
                    html = html.Replace("IS1", "P");
                    html = html.Replace("IN1", "");
                }
                else
                {
                    html = html.Replace("IS1", "");
                    html = html.Replace("IN1", "P");
                }

                if (chk.I2)
                {
                    html = html.Replace("IS2", "P");
                    html = html.Replace("IN2", "");
                }
                else
                {
                    html = html.Replace("IS2", "");
                    html = html.Replace("IN2", "P");
                }

                if (chk.I3)
                {
                    html = html.Replace("IS3", "P");
                    html = html.Replace("IN3", "");
                }
                else
                {
                    html = html.Replace("IS3", "");
                    html = html.Replace("IN3", "P");
                }

                if (chk.I4)
                {
                    html = html.Replace("IS4", "P");
                    html = html.Replace("IN4", "");
                }
                else
                {
                    html = html.Replace("IS4", "");
                    html = html.Replace("IN4", "P");
                }

                if (chk.I5)
                {
                    html = html.Replace("IS5", "P");
                    html = html.Replace("IN5", "");
                }
                else
                {
                    html = html.Replace("IS5", "");
                    html = html.Replace("IN5", "P");
                }

                if (chk.I6)
                {
                    html = html.Replace("IS6", "P");
                    html = html.Replace("IN6", "");
                }
                else
                {
                    html = html.Replace("IS6", "");
                    html = html.Replace("IN6", "P");
                }


                if (chk.L1)
                {
                    html = html.Replace("LS1", "P");
                    html = html.Replace("LN1", "");
                }
                else
                {
                    html = html.Replace("LS1", "");
                    html = html.Replace("LN1", "P");
                }

                if (chk.L2)
                {
                    html = html.Replace("LS2", "P");
                    html = html.Replace("LN2", "");
                }
                else
                {
                    html = html.Replace("LS2", "");
                    html = html.Replace("LN2", "P");
                }

                if (chk.L3)
                {
                    html = html.Replace("LS3", "P");
                    html = html.Replace("LN3", "");
                }
                else
                {
                    html = html.Replace("LS3", "");
                    html = html.Replace("LN3", "P");
                }

                if (chk.L4)
                {
                    html = html.Replace("LS4", "P");
                    html = html.Replace("LN4", "");
                }
                else
                {
                    html = html.Replace("LS4", "");
                    html = html.Replace("LN4", "P");
                }

                if (chk.L5)
                {
                    html = html.Replace("LS5", "P");
                    html = html.Replace("LN5", "");
                }
                else
                {
                    html = html.Replace("LS5", "");
                    html = html.Replace("LN5", "P");
                }

                if (chk.L6)
                {
                    html = html.Replace("LS6", "P");
                    html = html.Replace("LN6", "");
                }
                else
                {
                    html = html.Replace("LS6", "");
                    html = html.Replace("LN6", "P");
                }

                if (chk.L7)
                {
                    html = html.Replace("LS7", "P");
                    html = html.Replace("LN7", "");
                }
                else
                {
                    html = html.Replace("LS7", "");
                    html = html.Replace("LN7", "P");
                }
            }
            else
            {
                html = html.Replace("MS1", "");
                html = html.Replace("MS2", "");
                html = html.Replace("MS3", "");
                html = html.Replace("MS4", "");
                html = html.Replace("MS5", "");
                html = html.Replace("MN1", "");
                html = html.Replace("MN2", "");
                html = html.Replace("MN3", "");
                html = html.Replace("MN4", "");
                html = html.Replace("MN5", "");
                html = html.Replace("IS1", "");
                html = html.Replace("IS2", "");
                html = html.Replace("IS3", "");
                html = html.Replace("IS4", "");
                html = html.Replace("IS5", "");
                html = html.Replace("IS6", "");
                html = html.Replace("IN1", "");
                html = html.Replace("IN2", "");
                html = html.Replace("IN3", "");
                html = html.Replace("IN4", "");
                html = html.Replace("IN5", "");
                html = html.Replace("IN6", "");
                html = html.Replace("LS1", "");
                html = html.Replace("LS2", "");
                html = html.Replace("LS3", "");
                html = html.Replace("LS4", "");
                html = html.Replace("LS5", "");
                html = html.Replace("LS6", "");
                html = html.Replace("LS7", "");
                html = html.Replace("LN1", "");
                html = html.Replace("LN2", "");
                html = html.Replace("LN3", "");
                html = html.Replace("LN4", "");
                html = html.Replace("LN5", "");
                html = html.Replace("LN6", "");
                html = html.Replace("LN7", "");
            }
            return html;
        }
        static public string GerarVerificadpr(string idTransportadora,string idMotorista,string idCaminhao)
        {
            try
            {
                DataTable motorista = Select.SelectSQL("select * from motorista where id="+idMotorista+"");
                DataTable caminhao = Select.SelectSQL("select * from caminhao c, tipo_caminhao tc where tc.id = c.idtipo_caminhao and c.id =" + idCaminhao + "");
                DataTable transportadora = Select.SelectSQL("select * from transportadoras where id=" + idTransportadora + "");

                string urlModelo = Pastas.Modelos + "CHECKLIST\\modelo2.htm";

                if (!File.Exists(urlModelo))
                {
                    MsgBox.Show.Error("O modelo de checklist não foi encontrado!");
                    return null;
                }

                string html = "";
                StreamReader leitor = new StreamReader(urlModelo, Encoding.Default);
                html = leitor.ReadToEnd();
                leitor.Close();

                html = html.Replace("0motorista0", motorista.Rows[0]["nome"] + "");
                html = html.Replace("0transportadora0", transportadora.Rows[0]["nome"] + "");
                html = html.Replace("0data0", Facilitadores.Data.DataHora() + "");
                html = html.Replace("0placa0", caminhao.Rows[0]["placa"] + "");
                html = html.Replace("0tipo0", caminhao.Rows[0]["nome"] + "");
                html = html.Replace("0cnh0", motorista.Rows[0]["cnh"] + "");
                html = html.Replace("0criador0", Sessao.usuario.Nome + "");

             
               
             

                string url = Pastas.Relatorios + "CheckList" + Sessao.usuario.Usuario + "." + Facilitadores.Data.Dia() + "." + Facilitadores.Data.Mes() + "." + Facilitadores.Data.Ano() + "." + Facilitadores.Data.Hora() + "." + Facilitadores.Data.Minuto() + "." + Facilitadores.Data.Segundo() + ".htm";
                StreamWriter escritor = new StreamWriter(url, false, Encoding.Default);
                escritor.Write(html);
                escritor.Close();
                return url;
            }
            catch (Exception ex)
            {
                Facilitadores.ErroLog.Registrar(ex);
                MsgBox.Show.Error(ex + "");
                return "";
            }
        }
    }
}
