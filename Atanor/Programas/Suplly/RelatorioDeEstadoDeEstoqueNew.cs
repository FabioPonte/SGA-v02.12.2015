using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Conector;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using SGAPizza;
using SGABarras;
using System.Windows;
namespace Atanor.Programas.Suplly
{
    class RelatorioDeEstadoDeEstoqueNew
    {

        List<string> cal_passo_fundo = new List<string>();
        List<string> cal_pato_branco = new List<string>();
        List<string> cal_resende = new List<string>();
        List<string> cal_xanxere = new List<string>();
        List<string> cal_consagro_igarapava = new List<string>();
        List<string> cal_consagro_sumare = new List<string>();
        private static string html;
        private void IniciarSelecionador()
        {
            
            cal_passo_fundo.Add("1002-SYSTEM-BIN-LOCATION");
            // Fabio Ponte 30/11/16
            cal_passo_fundo.Add("1002-ZN 26 AVARIAS");
            cal_passo_fundo.Add("1002-ZN 28 BLOQUEADO");


            //cal_passo_fundo.Add("1002-ZN 1 ESTOQUE EM TRANSITO EADI X ARMAZÉM");
            cal_passo_fundo.Add("1002-ZN 2 ENTREGA FUTURA");
            cal_passo_fundo.Add("1002-ZN 3 DEVOLUÇÃO");
            //cal_passo_fundo.Add("1002-ZN 8 SEGREGADO PARA AVALIACAO");
            cal_pato_branco.Add("2002-SYSTEM-BIN-LOCATION");
            //cal_pato_branco.Add("2002-ZN 1 ESTOQUE EM TRANSITO EADI X ARMAZÉM");
            cal_pato_branco.Add("2002-ZN 2 ENTREGA FUTURA");
            cal_pato_branco.Add("2002-ZN 3 DEVOLUÇÃO");

            //Fabio Ponte 30/11/16
            cal_pato_branco.Add("2002-ZN 26 AVARIAS");
            cal_pato_branco.Add("2002-ZN 28 BLOQUEADO");
            //Fabio Ponte 02/03/17
            cal_pato_branco.Add("2002-ZN 41 CAMBE");


            //cal_pato_branco.Add("2002-ZN 8 SEGREGADO PARA AVALIACAO");
            cal_xanxere.Add("3001-SYSTEM-BIN-LOCATION");
            //cal_xanxere.Add("3001-ZN 1 ESTOQUE EM TRANSITO EADI X ARMAZÉM");
            cal_xanxere.Add("3001-ZN 2 ENTREGA FUTURA");
            
            //Fabio Ponte 30/11/16
            cal_xanxere.Add("3001-ZN 26 AVARIAS");
            cal_xanxere.Add("3001-ZN 26 AVARIAS");

            cal_xanxere.Add("3001-ZN 3 DEVOLUÇÃO");

            //cal_xanxere.Add("3001-ZN 8 SEGREGADO PARA AVALIACAO");
            cal_xanxere.Add("3001-ZN9 PINHALZINHO");


            cal_resende.Add("4001-SYSTEM-BIN-LOCATION");
            cal_resende.Add("4001-ZN 2 ENTREGA FUTURA");
            cal_resende.Add("4001-ZN 3 DEVOLUÇÃO");
            cal_resende.Add("4001-ZN 4 INTERDITADOS");
            cal_resende.Add("4001-ZN 5 QUARENTENA");
            cal_resende.Add("4002-SYSTEM-BIN-LOCATION");
            cal_resende.Add("4002-ZN 2 ENTREGA FUTURA");
            cal_resende.Add("4002-ZN 3 DEVOLUÇÃO");
            cal_resende.Add("4002-ZN 4 INTERDITADOS");
            cal_resende.Add("4002-ZN 5 QUARENTENA");
            cal_resende.Add("4001-ZN1 ENTREGA FUTURA");
            cal_resende.Add("4002-ZN1 ENTREGA FUTURA");
            //cal_resende.Add("4003-ZN 29 ARMAZEM EXTERNO");
            //Fábio Ponte 30/11/16
            cal_resende.Add("4001-ZN 26 AVARIAS");
            cal_resende.Add("4001-ZN 28 BLOQUEADO");
            cal_resende.Add("4001-ZN 7 PRODUCAO");
            cal_resende.Add("4002-ZN 26 AVARIAS");
            cal_resende.Add("4002-ZN 28 BLOQUEADO");
            //Fabio Ponte 02/03/17
            cal_resende.Add("4002-ZN 40-EBAMAG");




            //cal_resende.Add("4003-SYSTEM-BIN-LOCATION");
            //cal_resende.Add("4003-ZN 1 ESTOQUE EM TRANSITO EADI X ARMAZÉM");
            //cal_resende.Add("4003-ZN 5 QUARENTENA");
            //cal_resende.Add("4003-ZN 7 PRODUCAO");
            //cal_resende.Add("4003-ZN6 IENS EM PROCESSO EXTERNO");
            //cal_resende.Add("4004-SYSTEM-BIN-LOCATION");
            //cal_resende.Add("4004-ZN 5 QUARENTENA");
            //cal_resende.Add("4004-ZN 7 PRODUCAO");
            //cal_resende.Add("4004-ZN6 IENS EM PROCESSO EXTERNO");

            //cal_consagro.Add("7001-ZN 11 ESTOQUE EM TRÂNSITO IGARAPAVA");
            cal_consagro_igarapava.Add("7001-SYSTEM-BIN-LOCATION");
            cal_consagro_igarapava.Add("7001-ZN 12 DEVOLUÇÃO IGARAPAVA");
            cal_consagro_igarapava.Add("7001-ZN 14 INTERDITADOS IGARAPAVA");
            cal_consagro_igarapava.Add("7001-ZN 16 QUARENTENA IGARAPAVA");
            cal_consagro_igarapava.Add("7001-ZN 18 BLOQUEADO IGARAPAVA");
            cal_consagro_igarapava.Add("7001-ZN 20 ENTREGA FUTURA IGARAPAVA");
            cal_consagro_igarapava.Add("7002-SYSTEM-BIN-LOCATION");
            cal_consagro_igarapava.Add("7002-ZN 12 DEVOLUÇÃO IGARAPAVA");
            cal_consagro_igarapava.Add("7002-ZN 14 INTERDITADOS IGARAPAVA");
            cal_consagro_igarapava.Add("7002-ZN 16 QUARENTENA IGARAPAVA");
            cal_consagro_igarapava.Add("7002-ZN 18 BLOQUEADO IGARAPAVA");
            cal_consagro_igarapava.Add("7002-ZN 20 ENTREGA FUTURA IGARAPAVA");

            //Fabio Ponte  30/11/16                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
            cal_consagro_igarapava.Add("7003-ZN 18 BLOQUEADO IGARAPAVA");

            cal_consagro_sumare.Add("7001-ZN 13 DEVOLUÇÃO SUMARÉ");
            cal_consagro_sumare.Add("7001-ZN 15 INTERDITADOS SUMARÉ");
            cal_consagro_sumare.Add("7001-ZN 17 QUARENTENA SUMARÉ");
            cal_consagro_sumare.Add("7001-ZN 19 BLOQUEADO SUMARÉ");
            cal_consagro_sumare.Add("7001-ZN 21 ENTREGA FUTURA SUMARÉ");
            cal_consagro_sumare.Add("7001-ZN10 UTILIZAÇÃO LIVRE SUMARÉ");
            cal_consagro_sumare.Add("7002-ZN 13 DEVOLUÇÃO SUMARÉ");
            cal_consagro_sumare.Add("7002-ZN 15 INTERDITADOS SUMARÉ");
            cal_consagro_sumare.Add("7002-ZN 17 QUARENTENA SUMARÉ");
            cal_consagro_sumare.Add("7002-ZN 19 BLOQUEADO SUMARÉ");
            cal_consagro_sumare.Add("7002-ZN 21 ENTREGA FUTURA SUMARÉ");
            cal_consagro_sumare.Add("7002-ZN10 UTILIZAÇÃO LIVRE SUMARÉ");

            //Fabio Ponte  30/11/16
            cal_consagro_sumare.Add("7003-ZN 19 BLOQUEADO SUMARÉ");
            cal_consagro_sumare.Add("7003-ZN10 UTILIZAÇÃO LIVRE SUMARÉ");


            //cal_consagro.Add("7001-ZN 22 TERCEIRO FMC");
            //cal_consagro.Add("7001-ZN 23 TERCEIRO SIPCAM");
            //cal_consagro.Add("7001-ZN 24 TERCEIRO SERVATIS");
            //cal_consagro.Add("7001-ZN 25 TERCEIRO TAGMA");



            //cal_consagro_sumare.Add("7002-ZN 11 ESTOQUE EM TRÂNSITO IGARAPAVA");


            //cal_consagro.Add("7002-ZN 22 TERCEIRO FMC");
            //cal_consagro.Add("7002-ZN 23 TERCEIRO SIPCAM");
            //cal_consagro.Add("7002-ZN 24 TERCEIRO SERVATIS");
            //cal_consagro.Add("7002-ZN 25 TERCEIRO TAGMA");

            //cal_consagro.Add("7003-SYSTEM-BIN-LOCATION");
            //cal_consagro.Add("7003-ZN 11 ESTOQUE EM TRÂNSITO IGARAPAVA");
            //cal_consagro.Add("7003-ZN 16 QUARENTENA IGARAPAVA");
            //cal_consagro.Add("7003-ZN 17 QUARENTENA SUMARÉ");
            //cal_consagro.Add("7003-ZN 18 BLOQUEADO IGARAPAVA");
            //cal_consagro.Add("7003-ZN 19 BLOQUEADO SUMARÉ");
            //cal_consagro.Add("7003-ZN 22 TERCEIRO FMC");
            //cal_consagro.Add("7003-ZN 23 TERCEIRO SIPCAM");
            //cal_consagro.Add("7003-ZN 24 TERCEIRO SERVATIS");
            //cal_consagro.Add("7003-ZN 25 TERCEIRO TAGMA");
            //cal_consagro.Add("7003-ZN10 UTILIZAÇÃO LIVRE SUMARÉ");
            //cal_consagro.Add("7004-SYSTEM-BIN-LOCATION");
            //cal_consagro.Add("7004-ZN 11 ESTOQUE EM TRÂNSITO IGARAPAVA");
            //cal_consagro.Add("7004-ZN 16 QUARENTENA IGARAPAVA");
            //cal_consagro.Add("7004-ZN 17 QUARENTENA SUMARÉ");
            //cal_consagro.Add("7004-ZN 18 BLOQUEADO IGARAPAVA");
            //cal_consagro.Add("7004-ZN 19 BLOQUEADO SUMARÉ");
            //cal_consagro.Add("7004-ZN 22 TERCEIRO FMC");
            //cal_consagro.Add("7004-ZN 23 TERCEIRO SIPCAM");
            //cal_consagro.Add("7004-ZN 24 TERCEIRO SERVATIS");
            //cal_consagro.Add("7004-ZN 25 TERCEIRO TAGMA");
            //cal_consagro.Add("7004-ZN10 UTILIZAÇÃO LIVRE SUMARÉ");

            sql_passo_fundo = sql_passo_fundo.Replace("CONVERT", ArrumaWhere(cal_passo_fundo));
            sql_passo_fundo_SEM_SIGER = sql_passo_fundo_SEM_SIGER.Replace("CONVERT", ArrumaWhere(cal_passo_fundo));

            sql_pato_branco = sql_pato_branco.Replace("CONVERT", ArrumaWhere(cal_pato_branco));
            sql_pato_branco_SEM_SIGER = sql_pato_branco_SEM_SIGER.Replace("CONVERT", ArrumaWhere(cal_pato_branco));

            sql_resende = sql_resende.Replace("CONVERT", ArrumaWhere(cal_resende));
            sql_resende_SEM_SIGER = sql_resende_SEM_SIGER.Replace("CONVERT", ArrumaWhere(cal_resende));

            sql_xanxere = sql_xanxere.Replace("CONVERT", ArrumaWhere(cal_xanxere));
            sql_xanxere_SEM_SIGER = sql_xanxere_SEM_SIGER.Replace("CONVERT", ArrumaWhere(cal_xanxere));

            sql_igarapava = sql_igarapava.Replace("CONVERT", ArrumaWhere(cal_consagro_igarapava));
            sql_sumare = sql_sumare.Replace("CONVERT", ArrumaWhere(cal_consagro_sumare));

        }

        private string ArrumaWhere(List<string> centro)
        {
            string faz = "";
            for (int a = 0; a < centro.Count; a++)
            {
                faz += "'" + centro[a] + "',";
            }
            return faz.Substring(0, faz.Length - 1);
        }


        private double C_PassoFundo = 2000000;
        private double C_PatoBranco = 1000000;
        private double C_Xanxere = 150000;
        // private double C_Resende = 4800000;
        private double C_Resende = 3000000;

        private double C_IGARAPAVA7001 = (1300 * 700);
        private double C_IGARAPAVA7002 = (1300 * 700);

        private double C_SUMARE7001 = (4000 * 700);
        private double C_SUMARE7002 = (4000 * 700);

        private string sql_passo_fundo = "SELECT sum(quantidade) FROM logistica.condicaoestoque where data='ADATA' and posicao in (CONVERT)";
        private string sql_pato_branco = "SELECT ( sum(quantidade) + (SELECT SUM(X.QUANTIDADE) FROM logistica.acerto_lote X where cd='PATO BRANCO')) FROM logistica.condicaoestoque where data='ADATA' and posicao in (CONVERT)";
        private string sql_xanxere = "SELECT ( sum(quantidade) + (SELECT SUM(x.QUANTIDADE) FROM logistica.acerto_lote x where cd='XANXERE') ) FROM logistica.condicaoestoque where data='ADATA' and posicao in (CONVERT)";
        private string sql_resende = "SELECT ( sum(quantidade) + (SELECT SUM(x.QUANTIDADE) FROM logistica.acerto_lote x where cd='ATAR') ) FROM logistica.condicaoestoque where data='ADATA' and posicao in (CONVERT)";

        private string sql_igarapava = "SELECT sum(quantidade) FROM logistica.condicaoestoque where data='ADATA' and posicao in (CONVERT)";
        private string sql_sumare = "SELECT sum(quantidade) FROM logistica.condicaoestoque where data='ADATA' and posicao in (CONVERT)";


        private string sql_passo_fundo_SEM_SIGER = "SELECT sum(quantidade) FROM logistica.condicaoestoque where data='ADATA' and posicao in (CONVERT)";
        private string sql_pato_branco_SEM_SIGER = "SELECT  sum(quantidade) FROM logistica.condicaoestoque where data='ADATA' and posicao in (CONVERT)";
        private string sql_xanxere_SEM_SIGER = "SELECT  sum(quantidade)  FROM logistica.condicaoestoque where data='ADATA' and posicao in (CONVERT)";
        private string sql_resende_SEM_SIGER = "SELECT  sum(quantidade)  FROM logistica.condicaoestoque where data='ADATA' and posicao in (CONVERT)";

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

        public Brush cor(string hex)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString(hex);
            return brush;
        }

        public string savfot(string titulo, DateTime data, string sql, string cd, double max,double qtd_deposito)
        {
            try
            {

                string adatatodositens = Facilitadores.ConverterDataParaDataDoMysql.Converter(data);

                Escondido ogrid = new Escondido();

                double volume_cd = 0;
                try
                {
                    volume_cd = double.Parse(Select.SelectSQL(sql).Rows[0][0] + "");
                }
                catch { }


                Gauge pizza = new Gauge();
                pizza.Min = 0;
                pizza.Max = max;
                pizza.AnguloInicio = 0;
                pizza.AnguloFim = 359;
                pizza.Borda = 2;
                pizza.SeguirSeta = true;
                
                
                pizza.Faixa = Brushes.Tan;
                pizza.Valor = volume_cd;
                pizza.Faixa = cor("#FF018633");
                pizza.SeguirSeta = true;
                pizza.CoresAlerta = true;
                pizza.Alerta_med = cor("#FFEBFF80");
                pizza.Alerta_min = cor("#FF77FF3B");
                pizza.Alerta_max = cor("#FFDE2828");
                pizza.Seta = cor("#FF939393");


                
            



                // Create a radial gradient brush with five stops 
                RadialGradientBrush gra = new RadialGradientBrush();
             


                GradientStop a1 = new GradientStop();
                a1.Color = (Color)ColorConverter.ConvertFromString("#FF6F6F6F"); ;
                a1.Offset = 0.756;
                gra.GradientStops.Add(a1);


                GradientStop a2 = new GradientStop();
                a2.Color = (Color)ColorConverter.ConvertFromString("#FFFFFFFF"); ;
                a2.Offset = 0.785;
                gra.GradientStops.Add(a2);


                GradientStop a3 = new GradientStop();
                a3.Color = (Color)ColorConverter.ConvertFromString("#FF6F6F6F"); ;
                a3.Offset = 0;
                gra.GradientStops.Add(a3);

                GradientStop a4 = new GradientStop();
                a4.Color = (Color)ColorConverter.ConvertFromString("#FF9D9D9D"); ;
                a4.Offset = 0.983;
                gra.GradientStops.Add(a4);

                pizza.Centro = gra;

                // Add Rectangle to the page




                RadialGradientBrush gra2 = new RadialGradientBrush();



                GradientStop b1 = new GradientStop();
                b1.Color = (Color)ColorConverter.ConvertFromString("#FF000000"); ;
                b1.Offset = 0;
                gra2.GradientStops.Add(b1);

                GradientStop b2 = new GradientStop();
                b2.Color = (Color)ColorConverter.ConvertFromString("#FFFFFFFF"); ;
                b2.Offset = 0.988;
                gra2.GradientStops.Add(b2);

                GradientStop b3 = new GradientStop();
                b3.Color = (Color)ColorConverter.ConvertFromString("#FFC4C4C4"); ;
                b3.Offset = 1;
                gra2.GradientStops.Add(b3);

                GradientStop b4 = new GradientStop();
                b4.Color = (Color)ColorConverter.ConvertFromString("#FFFFFFFF"); ;
                b4.Offset = 0.936;
                gra2.GradientStops.Add(b4);

                pizza.Fundo = gra2;



                Label atitulo = new Label();
                atitulo.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                atitulo.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                atitulo.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                atitulo.Background = cor("#FF018633");
                atitulo.FontFamily = new FontFamily("Calibri");
                atitulo.Foreground = Brushes.White;
                atitulo.FontSize = 16;
                atitulo.Content = "Ocupação de "+titulo;

                Label acapacidade = new Label();
                acapacidade.Height = 30;
                acapacidade.FontSize = 14;
                acapacidade.Margin = new Thickness(10, 31, 178, 263);
                acapacidade.Content = "CAPACIDADE:";
                acapacidade.FontFamily = new FontFamily("Calibri");

                Label qtd_armaz = new Label();
                qtd_armaz.Height = 30;
                qtd_armaz.FontSize = 14;
                qtd_armaz.Margin = new Thickness(10, 61, 178, 233);
                qtd_armaz.Content = "QTD.ARMAZ:";
                qtd_armaz.FontFamily = new FontFamily("Calibri");


                Label ocupacao = new Label();
                ocupacao.Height = 30;
                ocupacao.FontSize = 14;
                ocupacao.Margin = new Thickness(10, 91, 178, 203);
                ocupacao.Content = "OCUPAÇÃO:";
                ocupacao.FontFamily = new FontFamily("Calibri");

                Label disponivel = new Label();
                disponivel.Height = 30;
                disponivel.FontSize = 14;
                disponivel.Margin = new Thickness(10, 121, 178, 173);
                disponivel.Content = "DISPONÍVEL:";
                disponivel.FontFamily = new FontFamily("Calibri");

                Label a1_capacidade = new Label();
                a1_capacidade.Height = 30;
                a1_capacidade.FontSize = 14;
                a1_capacidade.Margin = new Thickness(102, 31, 86, 263);
                a1_capacidade.Content = ponto(max);
                a1_capacidade.FontFamily = new FontFamily("Calibri");

                Label a2_qtd_armaz = new Label();
                a2_qtd_armaz.Height = 30;
                a2_qtd_armaz.FontSize = 14;
                a2_qtd_armaz.Margin = new Thickness(102, 61, 86, 233);
                a2_qtd_armaz.Content = ponto(qtd_deposito) ;
                a2_qtd_armaz.FontFamily = new FontFamily("Calibri");

                Label a3_ocupacao = new Label();
                a3_ocupacao.Height = 30;
                a3_ocupacao.FontSize = 14;
                a3_ocupacao.Margin = new Thickness(102, 91, 86, 203);
                a3_ocupacao.FontFamily = new FontFamily("Calibri");

                string ocu = Math.Round(((qtd_deposito / max) * 100), 1) + "";
                try
                {
                    if (ocu.Substring(0, ocu.IndexOf(",")).Length < 2)
                    {
                        ocu = ocu.Substring(0, 4);
                    }
                    else
                    {
                        ocu = ocu.Substring(0, 5);
                    }
                }
                catch { }
                a3_ocupacao.Content = ocu + "%";

                Label a4_disponivel = new Label();
                a4_disponivel.Height = 30;
                a4_disponivel.FontSize = 14;
                a4_disponivel.Margin = new Thickness(102, 121, 86, 173);
                a4_disponivel.FontFamily = new FontFamily("Calibri");
                ocu = 100 - Math.Round(((qtd_deposito / max) * 100), 1) + "";
                try
                {
                    if ((ocu.Substring(ocu.IndexOf(","), ocu.Length - ocu.IndexOf(",")).Length > 2))
                    {
                        if (ocu.Substring(0, ocu.IndexOf(",")).Length < 2)
                        {
                            ocu = ocu.Substring(0, 4);
                        }
                        else
                        {
                            ocu = ocu.Substring(0, 5);
                        }
                    }
                }
                catch { }
                a4_disponivel.Content = ocu + "%";

                Grid pai = new Grid();
                pai.Children.Add(atitulo);
                pai.Children.Add(acapacidade);
                pai.Children.Add(qtd_armaz);
                pai.Children.Add(ocupacao);
                pai.Children.Add(disponivel);
                pai.Children.Add(a1_capacidade);
                pai.Children.Add(a2_qtd_armaz);
                pai.Children.Add(a3_ocupacao);
                pai.Children.Add(a4_disponivel);


                

                pizza.Controle = pai;
                




                ogrid.Add = pizza;
                ogrid.Height = 320;

                ogrid.Show();

                string url = Environment.CurrentDirectory + "\\Relatorios\\" + titulo + "." + Environment.UserName + "-" + data.Day + "." + data.Month + "." + data.Year + ".png";

                int Height = (int)ogrid.ActualHeight;
                int Width = (int)ogrid.ActualWidth;

                RenderTargetBitmap bmp = new RenderTargetBitmap(Width, Height, 96, 96, PixelFormats.Pbgra32);
                bmp.Render(ogrid);

                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));

                using (Stream stm = File.Create(url))
                {
                    encoder.Save(stm);
                }


                ogrid.Close();

                return url;
            }
            catch (Exception ex) { MsgBox.Show.Error(ex + ""); return ""; }
        }

        private string converte(string valor)
        {
            if (valor.IndexOf("1002") != -1) { return "PASSO FUNDO"; }
            if (valor.IndexOf("2002") != -1) { return "PATO BRANCO"; }
            if (valor.IndexOf("3001") != -1) { return "XANXERÊ"; }
            if (valor.IndexOf("4001") != -1) { return "VENDA - RESENDE"; }
            if (valor.IndexOf("4002") != -1) { return "REVENDA - RESENDE"; }
            if (valor.IndexOf("4003") != -1 && valor.IndexOf("EXTERNO") != -1) { return "EXTERNO - RESENDE"; }
            if (valor.IndexOf("7001") != -1 && valor.IndexOf("SUMARÉ") != -1) { return "VENDA - SUMARÉ"; }
            if (valor.IndexOf("7002") != -1 && valor.IndexOf("SUMARÉ") != -1) { return "REVENDA - SUMARÉ"; }
            if (valor.IndexOf("7001") != -1 && valor.IndexOf("SUMARÉ") == -1) { return "VENDA - IGARAPAVA"; }
            if (valor.IndexOf("7002") != -1 && valor.IndexOf("SUMARÉ") == -1) { return "REVENDA - IGARAPAVA"; }

            return "";
        }

        private string converte2(string valor)
        {
            if (valor.IndexOf("1002") != -1) { return "1002 ESTOQUE EM TRANSITO"; }
            if (valor.IndexOf("2002") != -1) { return "2002 ESTOQUE EM TRANSITO"; }
            if (valor.IndexOf("3001") != -1) { return "3001 ESTOQUE EM TRANSITO"; }
            if (valor.IndexOf("4001") != -1) { return "4001 ESTOQUE EM TRANSITO"; }
            if (valor.IndexOf("4002") != -1) { return "4002 ESTOQUE EM TRANSITO"; }
            if (valor.IndexOf("7001") != -1) { return "7001 ESTOQUE EM TRANSITO"; }
            if (valor.IndexOf("7002") != -1) { return "7002 ESTOQUE EM TRANSITO"; }
            return "";
        }

        Boolean f1 = false;

        

        private DateTime datantiga;
        DataTable antigos;
        DataTable custo_anterior;

        public double RetornarSaldo(string item, string pos)
        {
            for (int a = 0; a < antigos.Rows.Count; a++)
            {
                string ppo = antigos.Rows[a]["f3"] + "";
                if (pos == ppo)
                {
                    if (item == antigos.Rows[a]["f4"] + "")
                    {
                        double vg = double.Parse(antigos.Rows[a]["f6"] + "");
                        return vg;
                    }
                }
            }
            return 0;
        }

        
        private string ObterAPenultimaData(DateTime data)
        {
            try
            {
                string dataC = Facilitadores.ConverterDataParaDataDoMysql.Converter(data);
                string sql = "select distinct data from condicaoestoque where data <= '" + dataC + "'";
                DataTable tabelaDatas = Select.SelectSQL(sql);
                string PnultimaData = tabelaDatas.Rows[0][tabelaDatas.Rows.Count - 1] + "";
                return PnultimaData;
            }
            catch { return Facilitadores.ConverterDataParaDataDoMysql.Converter(data); }
        }

        private double RetornarCusto(string deposito,string produto)
        {
            deposito = deposito.Substring(0, 4);
            for(int a = 0; a < custo_anterior.Rows.Count; a++)
            {
                
                if ((custo_anterior.Rows[a]["f3"] + "") == deposito)
                {
                    if ((custo_anterior.Rows[a]["f4"] + "") == produto)
                    {
                        return double.Parse(custo_anterior.Rows[a]["f7"] + "");
                    }
                }
            }
            return 0;
        }

        public string MontarHTML(DateTime data, DateTime dataAnterior, Boolean siger, Boolean ComCusto, double CustoMinimo, Boolean lDetalhes = true)
        {
            html = "";
            IniciarSelecionador();
            Boolean comp_custos = false;
            string dia_corrente = "";
            string dia_anterior = "";
            if(data!= dataAnterior)
            {
                comp_custos = true;
                string Ndcorre = "";
                string Nmcorre = "";
                string Adcorre = "";
                string Amcorre = "";
                if (data.Day < 10) Ndcorre = "0";
                if (data.Month < 10) Nmcorre = "0";
                if (dataAnterior.Day < 10) Adcorre = "0";
                if (dataAnterior.Month < 10) Amcorre = "0";

                dia_corrente = "" + Ndcorre + "" + data.Day + "/" + Nmcorre + "" + data.Month + "/" + data.Year + "";
                dia_anterior = "" + Adcorre + "" + dataAnterior.Day + "/" + Amcorre + "" + dataAnterior.Month + "/" + dataAnterior.Year + "";
            }

            //string ConsutaCustoAnterior = "select distinct data, substring(POSICAO,1,4) f3, numeroitem f4,  custo f7 from condicaoestoque where data  = '" + Facilitadores.ConverterDataParaDataDoMysql.Converter(dataAnterior) + "' order by 2";
            string ConsultaCustoAnterior = "select distinct data, substring(POSICAO,1,4) f3, numeroitem f4,  custo f7 from condicaoestoque where data  = '" + Facilitadores.ConverterDataParaDataDoMysql.Converter(dataAnterior) + "' and custo > 0 ";
            ConsultaCustoAnterior += " union all ";
            ConsultaCustoAnterior += " select trx.data,trx.f3,trx.f4,trz.f7 FROM ( select distinct data, substring(POSICAO,1, 4) f3, numeroitem f4, custo f7  from logistica.condicaoestoque where data = '" + Facilitadores.ConverterDataParaDataDoMysql.Converter(dataAnterior) + "' and custo = 0 ) ";
            ConsultaCustoAnterior += " as trx left outer join (  ";
            ConsultaCustoAnterior += " select  max(data), substring(POSICAO,1,4) f3, numeroitem f4,  custo f7 from logistica.condicaoestoque a where a.data < '" + Facilitadores.ConverterDataParaDataDoMysql.Converter(dataAnterior) + "' and a.custo > 0    group by substring(POSICAO, 1, 4), numeroitem ) ";
            ConsultaCustoAnterior += " as trz on  (trx.f4 = trz.f4 and trx.f3 = trz.f3)    order by 2";

      //      custo_anterior = Select.SelectSQL(ConsultaCustoAnterior);

            #region Esse bloco faz a consulta no banco ,procurando todos os itens do dia selecionado
            string adatatodositens = Facilitadores.ConverterDataParaDataDoMysql.Converter(data);
            //DataTable TodosItens = Select.SelectSQL("SELECT distinct numeroitem FROM sga.condicaoestoque where posicao like ('%SYSTEM-BIN-LOCATION%') and data ='" + adatatodositens + "'");
            //string ConsultaTodosItens ="select POSICAO f3,numeroitem f4, descricao f5,quantidade f6,custo f7,valor f8 from condicaoestoque where (posicao like ('%SYSTEM-BIN-LOCATION%') or posicao like ('%PINHALZINHO%') or posicao like ('%UTILIZAÇÃO LIVRE%') or posicao like ('%ARMAZEM EXTERNO%')) and posicao not like ('4003-SYSTEM-BIN-LOCATION') and posicao not like ('4003-ZN 1 ESTOQUE EM TRANSITO EADI X ARMAZÉM') and posicao not like ('4003-ZN 27 ARMAZEM EXTRENO') and posicao not like ('4003-ZN 5 QUARENTENA') and posicao not like ('4003-ZN 7 PRODUCAO') and posicao not like ('4003-ZN6 IENS EM PROCESSO EXTERNO')  and posicao not like ('%4004%') and posicao not like ('%7003%') and posicao not like ('%7004%') and data ='" + adatatodositens + "'  order by 2";
            string ConsultaTodosItens =" ";// Mudança da consulta para buscar o custo anterior  Fabio Ponte 25/08/16


            ConsultaTodosItens += " select 	a.f3,"; 
            ConsultaTodosItens += " 		a.f4,";
            ConsultaTodosItens += "		a.f5,";
            ConsultaTodosItens += "		a.f6,";
            ConsultaTodosItens += "		a.f7,";
            ConsultaTodosItens += "		a.f8,";
            ConsultaTodosItens += "		b.f7 f9 ,";
            ConsultaTodosItens += " concat(Right(cast(a.data as char(10)),2),'/',Right(Left(cast(a.data as char(10)),7),2),'/',Left(cast(a.data as char(10)),4)) f10 ,";
            ConsultaTodosItens += " concat(Right(cast(b.data as char(10)),2),'/',Right(Left(cast(b.data as char(10)),7),2),'/',Left(cast(b.data as char(10)),4)) f11  ";
            ConsultaTodosItens += " from(   ";
            ConsultaTodosItens += "		select POSICAO f3,";
            ConsultaTodosItens += "				numeroitem f4,";
            ConsultaTodosItens += "				descricao f5,";
            ConsultaTodosItens += "				quantidade f6,";
            ConsultaTodosItens += "				custo f7,";
            ConsultaTodosItens += "				valor f8,";
            ConsultaTodosItens += "				data   ";
            ConsultaTodosItens += "				from condicaoestoque";
            ConsultaTodosItens += "				where data ='" + adatatodositens + "'  ";
            ConsultaTodosItens += "				and custo > 0    ";
            ConsultaTodosItens += "	union all     ";
            ConsultaTodosItens += "				select  trx.f3,";
            ConsultaTodosItens += "						trx.f4,";
            ConsultaTodosItens += "						trx.f5, ";
            ConsultaTodosItens += "						trx.f6,";
            ConsultaTodosItens += "						ifnull(trz.f7, 0),";
            ConsultaTodosItens += "						ifnull(trx.f6, 0) * ifnull(trz.f7, 0) f8,";
            ConsultaTodosItens += "						trz.data     ";
            ConsultaTodosItens += "	from(  ";
            ConsultaTodosItens += "";
            ConsultaTodosItens += "						select  POSICAO f3, ";
            ConsultaTodosItens += "								numeroitem f4,";
            ConsultaTodosItens += "								descricao f5, ";
            ConsultaTodosItens += "								quantidade f6,";
            ConsultaTodosItens += "								custo f7,";
            ConsultaTodosItens += "								valor f8,";
            ConsultaTodosItens += "								data     ";
            ConsultaTodosItens += "									from condicaoestoque ";
            ConsultaTodosItens += "									where  data = '" + adatatodositens + "'  "; ;
            ConsultaTodosItens += "									and custo = 0     ";
            ConsultaTodosItens += "	) as trx ";
            ConsultaTodosItens += "		left join ( ";
            ConsultaTodosItens += "						select tr2.Warehouse f3,";
            ConsultaTodosItens += "								tr2.ItemCode f4,";
            ConsultaTodosItens += "								tr2.CalcPrice f7,";
            ConsultaTodosItens += "								tr2.DocDate  data";
            ConsultaTodosItens += "								from logistica.custo tr2 ";
            ConsultaTodosItens += "									inner join (  ";
            ConsultaTodosItens += "										select ItemCode , ";
            ConsultaTodosItens += "												Warehouse , ";
            ConsultaTodosItens += "												max(DocDate) data ";
            ConsultaTodosItens += "												from logistica.custo ";
            ConsultaTodosItens += "													where DocDate <  '" + adatatodositens + "'  "; 
            ConsultaTodosItens += "													and CalcPrice > 0  ";
            ConsultaTodosItens += "													group by ItemCode, Warehouse ";
            ConsultaTodosItens += "									)as tr1 ";
            ConsultaTodosItens += "											ON tr1.ItemCode = tr2.ItemCode";
            ConsultaTodosItens += "											and tr1.Warehouse = tr2.Warehouse";
            ConsultaTodosItens += "											and tr1.data = tr2.DocDate";
            ConsultaTodosItens += "		) as trz on trx.f3 = trz.f3 and trx.f4 = trz.f4";
            ConsultaTodosItens += "";
            ConsultaTodosItens += "		) as a";
            ConsultaTodosItens += "	Left join ( ";
            ConsultaTodosItens += "			select POSICAO f3,";
            ConsultaTodosItens += "							numeroitem f4,";
            ConsultaTodosItens += "							descricao f5,";
            ConsultaTodosItens += "							quantidade f6,";
            ConsultaTodosItens += "							custo f7,";
            ConsultaTodosItens += "							valor f8,";
            ConsultaTodosItens += "							data   ";
            ConsultaTodosItens += "							from condicaoestoque ";
            ConsultaTodosItens += "							where data ='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(dataAnterior) + "' ";
            ConsultaTodosItens += "							and custo > 0    ";
            ConsultaTodosItens += "				union all     ";
            ConsultaTodosItens += "							select  trx.f3,";
            ConsultaTodosItens += "									trx.f4,";
            ConsultaTodosItens += "									trx.f5, ";
            ConsultaTodosItens += "									trx.f6,";
            ConsultaTodosItens += "									ifnull(trz.f7, 0),";
            ConsultaTodosItens += "									ifnull(trx.f6, 0) * ifnull(trz.f7, 0) f8,";
            ConsultaTodosItens += "									trz.data     ";
            ConsultaTodosItens += "				from(  ";
            ConsultaTodosItens += "";
            ConsultaTodosItens += "									select  POSICAO f3,";
            ConsultaTodosItens += "											numeroitem f4,";
            ConsultaTodosItens += "											descricao f5, ";
            ConsultaTodosItens += "											quantidade f6,";
            ConsultaTodosItens += "											custo f7,";
            ConsultaTodosItens += "											valor f8,";
            ConsultaTodosItens += "											data     ";
            ConsultaTodosItens += "												from condicaoestoque ";
            ConsultaTodosItens += "												where  data ='" + adatatodositens + "' ";
            ConsultaTodosItens += "												and custo = 0     ";
            ConsultaTodosItens += "				) as trx ";
            ConsultaTodosItens += "					left join ( ";
            ConsultaTodosItens += "									select tr2.Warehouse f3, ";
            ConsultaTodosItens += "											tr2.ItemCode f4,";
            ConsultaTodosItens += "											tr2.CalcPrice f7,";
            ConsultaTodosItens += "											tr2.DocDate  data";
            ConsultaTodosItens += "											from logistica.custo tr2 ";
            ConsultaTodosItens += "												inner join (  ";
            ConsultaTodosItens += "													select ItemCode ,";
            ConsultaTodosItens += "															Warehouse ,";
            ConsultaTodosItens += "															max(DocDate) data";
            ConsultaTodosItens += "															from logistica.custo ";
            ConsultaTodosItens += "																where DocDate <'" + Facilitadores.ConverterDataParaDataDoMysql.Converter(dataAnterior) + "'  ";
            ConsultaTodosItens += "																and CalcPrice > 0  ";
            ConsultaTodosItens += "																group by ItemCode, Warehouse ";
            ConsultaTodosItens += "												)as tr1 ";
            ConsultaTodosItens += "														ON tr1.ItemCode = tr2.ItemCode ";
            ConsultaTodosItens += "														and tr1.Warehouse = tr2.Warehouse "; 
            ConsultaTodosItens += "														and tr1.data = tr2.DocDate";
            ConsultaTodosItens += "					) as trz on trx.f3 = trz.f3 and trx.f4 = trz.f4";
            ConsultaTodosItens += "";
            ConsultaTodosItens += "		) as b  on a.f3 = b.f3 and a.f4 = b.f4 ";
            ConsultaTodosItens += "	where (a.f3 like('%SYSTEM-BIN-LOCATION%')   ";
            ConsultaTodosItens += "		or a.f3 like('%PINHALZINHO%')   ";
            ConsultaTodosItens += "		or a.f3 like('%UTILIZAÇÃO LIVRE%')";
            ConsultaTodosItens += "	    or a.f3 like('%32 IGARAPAVA%')  ";
            ConsultaTodosItens += "	    or a.f3 like('%2002-ZN 41 CAMBE%') ";
            ConsultaTodosItens += "	    or a.f3 like('%4002-ZN 40-EBAMAG%') ";
            ConsultaTodosItens += "		or a.f3 like('%ARMAZEM EXTERNO%'))  ";
            ConsultaTodosItens += "		and a.f3 not like ('4003-SYSTEM-BIN-LOCATION')  ";
            ConsultaTodosItens += "		and a.f3 not like('4003-ZN 1 ESTOQUE EM TRANSITO EADI X ARMAZÉM') ";
            ConsultaTodosItens += "		and a.f3 not like('4003-ZN 27 ARMAZEM EXTRENO')   ";
            ConsultaTodosItens += "		and a.f3 not like('4003-ZN 5 QUARENTENA')   ";
            ConsultaTodosItens += "		and a.f3 not like('4003-ZN 7 PRODUCAO')   ";
            ConsultaTodosItens += "		and a.f3 not like('4003-ZN6 IENS EM PROCESSO EXTERNO') ";
            ConsultaTodosItens += "		and a.f3 not like('%4004%')   ";
            ConsultaTodosItens += "		and a.f3 not like('%7003%')   ";
            ConsultaTodosItens += "		and a.f3 not like('%7004%')  ";

            ConsultaTodosItens += "		order by 2 ";


            //string ConsultaTodosItensTransito = "select POSICAO f3,numeroitem f4, descricao f5,quantidade f6,custo f7,valor f8 from condicaoestoque where (posicao like ('%TRANSITO%') or posicao like ('%TRÂNSITO%')) and posicao not like ('%4003%') and posicao not like ('%4004%') and posicao not like ('%7003%') and posicao not like ('%7004%') and data ='" + adatatodositens + "' order by 2";
            string ConsultaTodosItensTransito = " ";
            ConsultaTodosItensTransito += " select a.f3,a.f4,a.f5,a.f6,a.f7,a.f8,b.f7 f9 ,concat(Right(cast(a.data as char(10)),2),'/',Right(Left(cast(a.data as char(10)),7),2),'/',Left(cast(a.data as char(10)),4))  f10 ,concat(Right(cast(b.data as char(10)),2),'/',Right(Left(cast(b.data as char(10)),7),2),'/',Left(cast(b.data as char(10)),4)) f11";
            ConsultaTodosItensTransito += " from(  ";
            ConsultaTodosItensTransito += " select POSICAO f3,numeroitem f4, descricao f5,quantidade f6,custo f7,valor f8,data  ";
            ConsultaTodosItensTransito += " from condicaoestoque  ";
            ConsultaTodosItensTransito += " where data ='" + adatatodositens + "'  ";
            ConsultaTodosItensTransito += " and custo > 0   ";
            ConsultaTodosItensTransito += " union all    ";
            ConsultaTodosItensTransito += " select trx.f3,trx.f4, trx.f5, trx.f6, ifnull(trz.f7, 0), ifnull(trx.f6, 0) * ifnull(trz.f7, 0) f8,trz.data    ";
            ConsultaTodosItensTransito += " from( ";
            ConsultaTodosItensTransito += " select  POSICAO f3, numeroitem f4, descricao f5, quantidade f6, custo f7, valor f8,data    ";
            ConsultaTodosItensTransito += " from condicaoestoque      ";
            ConsultaTodosItensTransito += " where  data ='" + adatatodositens + "'  ";
            ConsultaTodosItensTransito += " and custo = 0    ";
            ConsultaTodosItensTransito += " ) as trx left join (    ";
            ConsultaTodosItensTransito += " select  POSICAO f3, numeroitem f4, descricao f5, quantidade f6, custo f7, valor f8, max(data) data       ";
            ConsultaTodosItensTransito += " from logistica.condicaoestoque       ";
            ConsultaTodosItensTransito += " where  data <'" + adatatodositens + "'  ";
            ConsultaTodosItensTransito += " and custo > 0    ";
            ConsultaTodosItensTransito += " group by POSICAO, numeroitem ) as trz on trx.f3 = trz.f3 and trx.f4 = trz.f4  ) as a ";
            ConsultaTodosItensTransito += "  ";
            ConsultaTodosItensTransito += " Left join ( select POSICAO f3,numeroitem f4, descricao f5,quantidade f6,custo f7,valor f8,data  ";
            ConsultaTodosItensTransito += " from condicaoestoque  ";
            ConsultaTodosItensTransito += " where data ='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(dataAnterior) + "'   ";
            ConsultaTodosItensTransito += " and custo > 0   ";
            ConsultaTodosItensTransito += " union all    ";
            ConsultaTodosItensTransito += " select trx.f3,trx.f4, trx.f5, trx.f6, ifnull(trz.f7, 0), ifnull(trx.f6, 0) * ifnull(trz.f7, 0) f8,trz.data    ";
            ConsultaTodosItensTransito += " from( ";
            ConsultaTodosItensTransito += " select  POSICAO f3, numeroitem f4, descricao f5, quantidade f6, custo f7, valor f8,data    ";
            ConsultaTodosItensTransito += " from condicaoestoque      ";
            ConsultaTodosItensTransito += " where  data ='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(dataAnterior) + "'   ";
            ConsultaTodosItensTransito += " and ifnull(custo,0) = 0    ";
            ConsultaTodosItensTransito += " union all  ";
            ConsultaTodosItensTransito += " select  x.POSICAO f3, x.numeroitem f4, x.descricao f5, x.quantidade f6, x.custo f7, x.valor f8,x.data    ";
            ConsultaTodosItensTransito += " from condicaoestoque x  ";
            ConsultaTodosItensTransito += " left outer join condicaoestoque y   ";
            ConsultaTodosItensTransito += " on y.data ='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(dataAnterior) + "'  and x.numeroitem = y.numeroitem and x.POSICAO = y.POSICAO   ";
            ConsultaTodosItensTransito += " where  x.data ='" + adatatodositens + "' ";
            ConsultaTodosItensTransito += " and y.numeroitem is null  ";
            ConsultaTodosItensTransito += " ) as trx left join (    ";
            ConsultaTodosItensTransito += " select  POSICAO f3, numeroitem f4, descricao f5, quantidade f6, custo f7, valor f8, max(data) data       ";
            ConsultaTodosItensTransito += " from logistica.condicaoestoque       ";
            ConsultaTodosItensTransito += " where  data <'" + Facilitadores.ConverterDataParaDataDoMysql.Converter(dataAnterior) + "'   ";
            ConsultaTodosItensTransito += " and custo > 0    ";
            ConsultaTodosItensTransito += " group by POSICAO, numeroitem ) as trz on trx.f3 = trz.f3 and trx.f4 = trz.f4  ) as b  on a.f3 = b.f3 and a.f4 = b.f4 ";
            ConsultaTodosItensTransito += "    where (a.f3 like('%TRANSITO%')  ";
            ConsultaTodosItensTransito += "       or a.f3 like('%TRÂNSITO%'))  ";
            ConsultaTodosItensTransito += "       and a.f3 not like('%4003%')  ";
            ConsultaTodosItensTransito += "        and a.f3 not like('%4004%')  ";
            ConsultaTodosItensTransito += "        and a.f3 not like('%7003%')  ";
            ConsultaTodosItensTransito += "        and a.f3 not like('%7004%')  ";
            ConsultaTodosItensTransito += "  order by 2 ";

            /*
            ConsultaTodosItensTransito = " select POSICAO f3,numeroitem f4, descricao f5,quantidade f6, custo f7,valor f8 ";
            ConsultaTodosItensTransito += "    from condicaoestoque ";
            ConsultaTodosItensTransito += "           where (posicao like('%TRANSITO%') ";
            ConsultaTodosItensTransito += "                or posicao like('%TRÂNSITO%')) ";
            ConsultaTodosItensTransito += "    and posicao not like ('%4003%') ";
            ConsultaTodosItensTransito += "       and posicao not like('%4004%')  ";
            ConsultaTodosItensTransito += "     and posicao not like('%7003%')  ";
            ConsultaTodosItensTransito += "      and posicao not like('%7004%') ";
            ConsultaTodosItensTransito += "      and data = '" + adatatodositens + "' and custo > 0  ";
            ConsultaTodosItensTransito += " union  ";
            ConsultaTodosItensTransito += " select trx.f3, trx.f4, trx.f5, trx.f6, ifnull(trz.f7, 0) f7, ifnull(trx.f6, 0) * ifnull(trz.f7, 0) f8  ";
            ConsultaTodosItensTransito += " from(  ";
            ConsultaTodosItensTransito += " select POSICAO f3, numeroitem f4, descricao f5, quantidade f6, custo f7, valor f8  ";
            ConsultaTodosItensTransito += "    from condicaoestoque  ";
            ConsultaTodosItensTransito += "    where (posicao like('%TRANSITO%')  ";
            ConsultaTodosItensTransito += "       or posicao like('%TRÂNSITO%'))  ";
            ConsultaTodosItensTransito += "       and posicao not like('%4003%')  ";
            ConsultaTodosItensTransito += "        and posicao not like('%4004%')  ";
            ConsultaTodosItensTransito += "        and posicao not like('%7003%')  ";
            ConsultaTodosItensTransito += "        and posicao not like('%7004%')  ";
            ConsultaTodosItensTransito += "       and data = '" + adatatodositens + "' and custo = 0 ) AS trx left outer join(  ";
            ConsultaTodosItensTransito += " select max(data), POSICAO f3, numeroitem f4, descricao f5, quantidade f6, custo f7, valor f8  ";
            ConsultaTodosItensTransito += "   from condicaoestoque  ";
            ConsultaTodosItensTransito += "   where (posicao like('%TRANSITO%')  ";
            ConsultaTodosItensTransito += "    or posicao like('%TRÂNSITO%'))  ";
            ConsultaTodosItensTransito += "    and posicao not like ('%4003%')  ";
            ConsultaTodosItensTransito += "     and posicao not like('%4004%')  ";
            ConsultaTodosItensTransito += "      and posicao not like('%7003%')  ";
            ConsultaTodosItensTransito += "        and posicao not like('%7004%')  ";
            ConsultaTodosItensTransito += "                and data < '" + adatatodositens + "' and custo = 0  ";
            ConsultaTodosItensTransito += " group by POSICAO, numeroitem ) as trz on trx.f3 = trz.f3 and trx.f4 = trz.f4 ";
            */
            DataTable TodosItens = Select.SelectSQL(ConsultaTodosItens);
            DataTable TodosItensTransito = Select.SelectSQL(ConsultaTodosItensTransito);
            //TRANSITO
            var distinct = (from r in TodosItens.AsEnumerable() select r["f4"]).Distinct().ToList();
            var distinct2 = (from r in TodosItensTransito.AsEnumerable() select r["f4"]).Distinct().ToList();
            #endregion

            #region Essas Variaveis guardam os saldos de cada cd
            double pfH = 0;
            double ptH = 0;
            double xaH = 0;
            double reH = 0;
            double sumH = 0;
            double igaH = 0;
            #endregion

            #region Essas Variaveis guardam as url das fotos geradas do grafico
            string pf = "";//String para url da foto gerada do grafico
            string pt = "";
            string xa = "";
            string re = "";
            string sum = "";
            string iga = "";
            #endregion

            #region Esse bloco calcula qual a quantidade total de produto com ou sem saldo do sga e logo depois gera os gráficos
            if (siger == true)
            {
                try
                {
                    pfH = double.Parse(Select.SelectSQL(sql_passo_fundo.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { pfH = 0; }

                try
                {
                    ptH = double.Parse(Select.SelectSQL(sql_pato_branco.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { ptH = 0; }
                try
                {
                    xaH = double.Parse(Select.SelectSQL(sql_xanxere.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { xaH = 0; }

                try
                {
                    reH = double.Parse(Select.SelectSQL(sql_resende.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { reH = 0; }

                try
                {
                    igaH = double.Parse(Select.SelectSQL(sql_igarapava.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { igaH = 0; }

                try
                {
                    sumH = double.Parse(Select.SelectSQL(sql_sumare.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { sumH = 0; }


                pf = savfot("Passo Fundo", data, sql_passo_fundo.Replace("ADATA", "" + adatatodositens), "Ocupado", C_PassoFundo, pfH);
                pt = savfot("Pato Branco", data, sql_pato_branco.Replace("ADATA", "" + adatatodositens), "Ocupado", C_PatoBranco, ptH);
                xa = savfot("Xanxerê", data, sql_xanxere.Replace("ADATA", "" + adatatodositens), "Ocupado", C_Xanxere, xaH);
                re = savfot("Resende", data, sql_resende.Replace("ADATA", "" + adatatodositens), "Ocupado", C_Resende, reH);

                sum = savfot("Sumaré", data, sql_sumare.Replace("ADATA", "" + adatatodositens), "Ocupado", C_SUMARE7001, sumH);
                iga = savfot("Igarapava", data, sql_igarapava.Replace("ADATA", "" + adatatodositens), "Ocupado", C_IGARAPAVA7001, igaH);


            }
            else
            {

                try
                {
                    pfH = double.Parse(Select.SelectSQL(sql_passo_fundo_SEM_SIGER.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { pfH = 0; }

                try
                {
                    ptH = double.Parse(Select.SelectSQL(sql_pato_branco_SEM_SIGER.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { ptH = 0; }
                try
                {
                    xaH = double.Parse(Select.SelectSQL(sql_xanxere_SEM_SIGER.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { xaH = 0; }

                try
                {
                    reH = double.Parse(Select.SelectSQL(sql_resende_SEM_SIGER.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { reH = 0; }

                try
                {
                    igaH = double.Parse(Select.SelectSQL(sql_igarapava.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { igaH = 0; }

                try
                {
                    sumH = double.Parse(Select.SelectSQL(sql_sumare.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { sumH = 0; }

                pf = savfot("Passo Fundo", data, sql_passo_fundo_SEM_SIGER.Replace("ADATA", "" + adatatodositens), "Ocupado", C_PassoFundo, pfH);
                pt = savfot("Pato Branco", data, sql_pato_branco_SEM_SIGER.Replace("ADATA", "" + adatatodositens), "Ocupado", C_PatoBranco, ptH);
                xa = savfot("Xanxerê", data, sql_xanxere_SEM_SIGER.Replace("ADATA", "" + adatatodositens), "Ocupado", C_Xanxere, xaH);
                re = savfot("Resende", data, sql_resende_SEM_SIGER.Replace("ADATA", "" + adatatodositens), "Ocupado", C_Resende, reH);

                sum = savfot("Sumaré", data, sql_sumare.Replace("ADATA", "" + adatatodositens), "Ocupado", C_SUMARE7001, sumH);
                iga = savfot("Igarapava", data, sql_igarapava.Replace("ADATA", "" + adatatodositens), "Ocupado", C_IGARAPAVA7001, igaH);

            }

            #endregion

            #region Esse bloco monta o Relatório de Bin Location

            string dia = "" + data.Day; if (dia.Length <= 1) dia = "0" + dia;
            string mes = "" + data.Month; if (mes.Length <= 1) mes = "0" + mes;
            string ano = "" + data.Year;

            html += "<html>";
            html += "<title></title>";
            html += "<body > ";
            html += "<center> <img src='" + Pastas.Relatorios + "LOGO2.png'  ><br> ";
            html += "<font size=3 face='tahoma' id='res'>" + dia + "/" + mes + "/" + ano + " </font><br><img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br><br>";
            html += "<style>th{padding:7px;}</style>";
            html += "<table style='border:1px solid #018633' cellspacing=0 id='tabela'>";
            html += "<tr>";

            html += "<th bgcolor='#018633' height='25px' width='100' ><font face='calibri' size=2 color=white>Nº do item</FONT></th>";
            html += "<th bgcolor='#018633' height='25px' width='150' ><font face='calibri' size=2 color=white>Descrição do item</FONT></th>";
            html += "<th bgcolor='#018633' height='25px' width='80' ><font face='calibri' size=2 color=white>Quantidade</FONT></th>";
            html += "<th bgcolor='#018633' height='25px' width='200' ><font face='calibri' size=2 color=white>Posição no depósito</FONT></th>";
            html += "<th bgcolor='#018633' height='25px' width='200' ><font face='calibri' size=2 color=white>Localização</FONT></th>";
            if (ComCusto)// se for verdadeiro mostra o custo
            {

                if (comp_custos)
                {
                    html += "<th bgcolor='#018633' height='30px' width='60' ><font face='calibri' size=2 color=white>Custo " + dia_anterior + "</FONT></th>";
                }
                if (comp_custos)
                {
                    html += "<th bgcolor='#018633' height='30px' width='60' ><font face='calibri' size=2 color=white>Custo " + dia_corrente + "</FONT></th>";
                }
                else
                {
                    html += "<th bgcolor='#018633' height='25px' width='60' ><font face='calibri' size=2 color=white>Custo</FONT></th>";
                }
                if (comp_custos) { 
                    html += "<th bgcolor='#018633' height='15px' width='60' ><font face='calibri' size=2 color=white>%</FONT></th>";
                    html += "<th bgcolor='#018633' height='15px' width='60' ><font face='calibri' size=2 color=white>~</FONT></th>";
                }


                html += "<th bgcolor='#018633' height='25px' width='60' ><font face='calibri' size=2 color=white>Valor</FONT></th>";
            }
            html += "</tr>";
            string ohtml = "";

            for (int a = 0; a < distinct.Count; a++)
            {

                

                ohtml = "";
                int qtd = TodosItens.Rows.Count;
                DataRow[] lista = TodosItens.Select("f4 ='" + distinct[a] + "'");

                DataTable todos = new DataTable();
                todos.Columns.Add("f3");
                todos.Columns.Add("f4");
                todos.Columns.Add("f5");
                todos.Columns.Add("f6");
                todos.Columns.Add("f7");
                todos.Columns.Add("f8");
                todos.Columns.Add("f9");
                todos.Columns.Add("f10");
                todos.Columns.Add("f11");


                for (int c = 0; c < lista.Length; c++)
                {
                    todos.Rows.Add(lista[c][0], lista[c][1], lista[c][2], lista[c][3], lista[c][4], lista[c][5], lista[c][6], lista[c][7], lista[c][8]);
                }



                double soma = 0;
                double soma2 = 0;
                if (todos.Rows.Count > 1)
                {
                    for (int b = 0; b < todos.Rows.Count; b++)
                    {
                        soma += double.Parse(todos.Rows[b]["f6"] + "");
                        soma2 += double.Parse(todos.Rows[b]["f8"] + "");
                    }

                    ohtml += "<tr>";
                    ohtml += "<th bgcolor='#99CF57' height='25px'><font face='calibri' size=2>" + todos.Rows[0]["f4"] + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='25px'><font face='calibri' size=2>" + todos.Rows[0]["f5"] + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='25px'><font face='calibri' size=2>" + ponto(soma) + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='25px'></th>";
                    ohtml += "<th bgcolor='#99CF57' height='25px'></th>";
                    if (ComCusto)// se for verdadeiro mostra o custo
                    {
                        ohtml += "<th bgcolor='#99CF57' height='25px'<font face='calibri' size=2></font></th>";
                        if (comp_custos)
                        {
                            ohtml += "<th bgcolor='#99CF57' height='25px'><font face='calibri' size=2></font></th>";
                            ohtml += "<th bgcolor='#99CF57' height='25px'><font face='calibri' size=2></font></th>";
                            ohtml += "<th bgcolor='#99CF57' height='25px'><font face='calibri' size=2></font></th>";
                        }
                        ohtml += "<th bgcolor='#99CF57' height='25px'><font face='calibri' size=2>" + ponto(soma2) + "</font></th>";
                    }
                    ohtml += "</tr>";



                    for (int b = 0; b < todos.Rows.Count; b++)
                    {

                        double custo_corrente = double.Parse("" + todos.Rows[b]["f7"]);
                        double custo_Antigo = 0;
                        double.TryParse("" + todos.Rows[b]["f9"].ToString(), out custo_Antigo);
                        double variacao = ((custo_corrente / custo_Antigo) - 1) * 100;
                        string cor = "black";
                        if (variacao >= 0)
                        {
                            if (variacao >= CustoMinimo)
                            {
                                cor = "red";
                            }
                        }

                        if (variacao < 0)
                        {
                            if (variacao <= -CustoMinimo)
                            {
                                cor = "red";
                            }
                        }

                        ohtml += "<tr>";


                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + todos.Rows[b]["f4"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + todos.Rows[b]["f5"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + ponto(todos.Rows[b]["f6"] + "") + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + todos.Rows[b]["f3"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + converte(todos.Rows[b]["f3"] + "") + "</font></th>";
                        if (ComCusto)// se for verdadeiro mostra o custo
                        {

                            if (comp_custos)
                            {


                                string img = "";

                                if (variacao > 0) { img = "<img src='cima.jpg'>"; }
                                if (variacao == 0) { img = "<img src='meio.jpg'>"; }
                                if (variacao < 0) { img = "<img src='baixo.jpg'>"; }

                                if (custo_Antigo == 0) variacao = 100;

                                ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + custo_Antigo + "</font></th>";
                                ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + todos.Rows[b]["f7"] + "</font></th>";
                                if (variacao == 0)
                                {
                                    ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>0,00%</font></th>";
                                }
                                else
                                {

                                    ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + variacao.ToString("n2") + "%</font></th>";
                                }
                                ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + img + "</font></th>";

                            }
                            else
                            {
                                ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + todos.Rows[b]["f7"] + "</font></th>";
                            }
                            ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + ponto(todos.Rows[b]["f8"]) + "</font></th>";
                        }

                        ohtml += "</tr>";
                        if (lDetalhes && (todos.Rows[b]["f11"].ToString()!= dia_anterior.ToString() || todos.Rows[b]["f10"].ToString() != dia_corrente.ToString()))
                        {
                            ohtml += "<tr>";
                            ohtml += "<th bgcolor='#FFFFFF' colspan='5' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>Data custo anterior: " + todos.Rows[b]["f11"] + "</font></th>";
                            ohtml += "<th bgcolor='#FFFFFF' colspan='5' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>Data custo atual:" + todos.Rows[b]["f10"] + "</font></th>";
                            ohtml += "</tr>";
                        }
                    }

                }
                else
                {

                    double custo_corrente = double.Parse("" + todos.Rows[0]["f7"]);
                    //double custo_Antigo = //RetornarCusto(todos.Rows[0]["f3"] + "", todos.Rows[0]["f4"] + "");
                     double custo_Antigo = 0;
                    double.TryParse("" + todos.Rows[0]["f9"].ToString(), out custo_Antigo);
                    double variacao = ((custo_corrente / custo_Antigo) - 1) * 100;

                    string cor = "black";
                    if (variacao >= 0)
                    {
                        if (variacao >= CustoMinimo)
                        {
                            cor = "red";
                        }
                    }

                    if (variacao < 0)
                    {
                        if (variacao <= -CustoMinimo)
                        {
                            cor = "red";
                        }
                    }

                    string img = "";

                    ohtml += "<tr>";

                    ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:"+cor+";'>" + todos.Rows[0]["f4"] + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";'>" + todos.Rows[0]["f5"] + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";'>" + ponto(todos.Rows[0]["f6"] + "") + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";'>" + todos.Rows[0]["f3"] + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";'>" + converte(todos.Rows[0]["f3"] + "") + "</font></th>";
                    if (ComCusto)// se for verdadeiro mostra o custo
                    {
                        if (comp_custos)
                        {
                            
                            
                            if (variacao > 0) { img = "<img src='cima.jpg'>"; }
                            if (variacao == 0) { img = "<img src='meio.jpg'>"; }
                            if (variacao < 0) { img = "<img src='baixo.jpg'>"; }

                            if (custo_Antigo == 0) variacao = 100;

                            ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";'>" + custo_Antigo + "</font></th>";
                            ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";'>" + todos.Rows[0]["f7"] + "</font></th>";
                            if (variacao == 0)
                            {
                                ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";'>0,00%</font></th>";
                            }
                            else
                            {
                                ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";'>" + variacao.ToString("n2") + "%</font></th>";
                            }
                            ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";'>" + img + "</font></th>";

                        }
                        else
                        {
                            ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";'>" + todos.Rows[0]["f7"] + "</font></th>";
                        }
                       
                        ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";'>" + ponto(todos.Rows[0]["f8"]) + "</font></th>";
                    }


                    ohtml += "</tr>";
                    if (lDetalhes && (todos.Rows[0]["f11"].ToString() != dia_anterior.ToString() || todos.Rows[0]["f10"].ToString() != dia_corrente.ToString()))
                    {
                        ohtml += "<tr>";
                        ohtml += "<th bgcolor='#FFFFFF' colspan='5' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>Data custo anterior: " + todos.Rows[0]["f11"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' colspan='5' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>Data custo atual:" + todos.Rows[0]["f10"] + "</font></th>";
                        ohtml += "</tr>";



                    }
                }

                ohtml += "<tr>";

                ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                if (ComCusto)// se for verdadeiro mostra o custo
                {
                    ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                    if (comp_custos)
                    {
                        ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                        ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                        ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                    }
                    ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                }
                ohtml += "</tr>";

                html += ohtml;
            }
            #endregion

            #region Esse bloco monta o relatorio de Estoque em Transito
            html += "</table>";
            html += "<img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br>";
            html += "<font size=6 face='tahoma' id='res'>RELATÓRIO DE ESTOQUE CONSOLIDADO ESTOQUE EM TRÂNSITO</font><br><br>";
            html += "<table style='border:1px solid #018633' cellspacing=0 id='tabela1'>";
            html += "<tr>";

            html += "<th bgcolor='#018633' height='25px' width='100' ><font face='calibri' size=2 color=white>Nº do item</FONT></th>";
            html += "<th bgcolor='#018633' height='25px' width='150' ><font face='calibri' size=2 color=white>Descrição do item</FONT></th>";
            html += "<th bgcolor='#018633' height='25px' width='80' ><font face='calibri' size=2 color=white>Quantidade</FONT></th>";
            html += "<th bgcolor='#018633' height='25px' width='200' ><font face='calibri' size=2 color=white>Posição no depósito</FONT></th>";
            html += "<th bgcolor='#018633' height='25px' width='200' ><font face='calibri' size=2 color=white>Localização</FONT></th>";
        
            if (ComCusto)// se for verdadeiro mostra o custo
            {

                if (comp_custos)
                {
                    html += "<th bgcolor='#018633' height='30px' width='60' ><font face='calibri' size=2 color=white>Custo " + dia_anterior + "</FONT></th>";
                }
                if (comp_custos)
                {
                    html += "<th bgcolor='#018633' height='30px' width='60' ><font face='calibri' size=2 color=white>Custo " + dia_corrente + "</FONT></th>";
                }
                else
                {
                    html += "<th bgcolor='#018633' height='25px' width='60' ><font face='calibri' size=2 color=white>Custo</FONT></th>";
                }
                if (comp_custos)
                {
                    html += "<th bgcolor='#018633' height='15px' width='60' ><font face='calibri' size=2 color=white>%</FONT></th>";
                    html += "<th bgcolor='#018633' height='15px' width='60' ><font face='calibri' size=2 color=white>~</FONT></th>";
                }


                html += "<th bgcolor='#018633' height='25px' width='60' ><font face='calibri' size=2 color=white>Valor</FONT></th>";
            }


            html += "</tr>";

            for (int a = 0; a < distinct2.Count; a++)
            {
                ohtml = "";
                int qtd = TodosItensTransito.Rows.Count;
                DataRow[] lista = TodosItensTransito.Select("f4 ='" + distinct2[a] + "'");

                DataTable todos = new DataTable();
                todos.Columns.Add("f3");
                todos.Columns.Add("f4");
                todos.Columns.Add("f5");
                todos.Columns.Add("f6");
                todos.Columns.Add("f7");
                todos.Columns.Add("f8");
                todos.Columns.Add("f9");
                todos.Columns.Add("f10");
                todos.Columns.Add("f11");

                for (int c = 0; c < lista.Length; c++)
                {
                    todos.Rows.Add(lista[c][0], lista[c][1], lista[c][2], lista[c][3], lista[c][4], lista[c][5], lista[c][6], lista[c][7], lista[c][8]);
                }

                double soma = 0;
                double soma2 = 0;
                if (todos.Rows.Count > 1)
                {
                    for (int b = 0; b < todos.Rows.Count; b++)
                    {
                        soma += double.Parse(todos.Rows[b]["f6"] + "");
                        soma2 += double.Parse(todos.Rows[b]["f8"] + "");
                    }

                    ohtml += "<tr>";
                    ohtml += "<th bgcolor='#99CF57' height='25px'><font face='calibri' size=2>" + todos.Rows[0]["f4"] + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='25px'><font face='calibri' size=2>" + todos.Rows[0]["f5"] + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='25px'><font face='calibri' size=2>" + ponto(soma) + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='25px'></th>";
                    ohtml += "<th bgcolor='#99CF57' height='25px'></th>";
                    if (ComCusto)// se for verdadeiro mostra o custo
                    {
                        ohtml += "<th bgcolor='#99CF57' height='25px'></th>";
                        ohtml += "<th bgcolor='#99CF57' height='25px'></th>";
                        ohtml += "<th bgcolor='#99CF57' height='25px'></th>";
                        ohtml += "<th bgcolor='#99CF57' height='25px'></th>";
                        ohtml += "<th bgcolor='#99CF57' height='25px'><font face='calibri' size=2>" + ponto(soma2) + "</font></th>";
                    }
                    ohtml += "</tr>";



                    for (int b = 0; b < todos.Rows.Count; b++)
                    {


                        string cor = "black";

                        ohtml += "<tr>";

                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + todos.Rows[b]["f4"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + todos.Rows[b]["f5"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + ponto(todos.Rows[b]["f6"] + "") + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + converte2(todos.Rows[b]["f3"] + "") + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + converte(todos.Rows[b]["f3"] + "") + "</font></th>";
                        if (ComCusto)// se for verdadeiro mostra o custo
                        {

                            double custo_corrente = double.Parse("" + todos.Rows[b]["f7"]);
                            //double custo_Antigo = RetornarCusto(todos.Rows[b]["f3"] + "", todos.Rows[b]["f4"] + "");

                            double custo_Antigo = 0;
                            double.TryParse("" + todos.Rows[b]["f9"].ToString(), out custo_Antigo);
                            double variacao = ((custo_corrente / custo_Antigo) - 1) * 100;
                            cor = "black";
                            if (variacao >= 0)
                            {
                                if (variacao >= CustoMinimo)
                                {
                                    cor = "red";
                                }
                            }

                            if (variacao < 0)
                            {
                                if (variacao <= -CustoMinimo)
                                {
                                    cor = "red";
                                }
                            }

                            string img = "";

                            if (variacao > 0) { img = "<img src='cima.jpg'>"; }
                            if (variacao == 0) { img = "<img src='meio.jpg'>"; }
                            if (variacao < 0) { img = "<img src='baixo.jpg'>"; }

                            if (custo_Antigo == 0) variacao = 100;

                            //ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + custo_Antigo + "</font></th>";
                            ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + todos.Rows[b]["f9"] + "</font></th>";
                            ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + todos.Rows[b]["f7"] + "</font></th>";
                            if (variacao == 0)
                            {
                                ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>0,00%</font></th>";
                            }
                            else
                            {

                                ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + variacao.ToString("n2") + "%</font></th>";
                            }
                            ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + img + "</font></th>";
                            ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + ponto(todos.Rows[b]["f8"] + "") + "</font></th>";

                        }
                        else
                        {
                            //ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2;font-weight: normal;'>" + todos.Rows[b]["f7"] + "</font></th>";
                        }

                        ohtml += "</tr>";
                        if (lDetalhes && (todos.Rows[b]["f11"].ToString() != dia_anterior.ToString() || todos.Rows[b]["f10"].ToString() != dia_corrente.ToString()))
                        {
                            ohtml += "<tr>";
                            ohtml += "<th bgcolor='#FFFFFF' colspan='5' height='20px'><font face='calibri' size=2 style='color:" + cor.ToString() + ";font-weight: normal;'>Data custo anterior: " + todos.Rows[b]["f11"] + "</font></th>";
                            ohtml += "<th bgcolor='#FFFFFF' colspan='5' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>Data custo atual:" + todos.Rows[b]["f10"] + "</font></th>";
                            ohtml += "</tr>";
                        }
                    }
                    //ohtml += "</tr>";
                

                }
                else
                {

                    string cor = "black";

                    ohtml += "<tr>";

                    ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2>" + todos.Rows[0]["f4"] + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2>" + todos.Rows[0]["f5"] + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2>" + ponto(todos.Rows[0]["f6"] + "") + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2>" + converte2(todos.Rows[0]["f3"] + "") + "</font></th>";
                    ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2>" + converte(todos.Rows[0]["f3"] + "") + "</font></th>";
                    if (ComCusto)// se for verdadeiro mostra o custo
                    {

                        double custo_corrente = double.Parse("" + todos.Rows[0]["f7"]);
                        //double custo_Antigo = RetornarCusto(todos.Rows[0]["f3"] + "", todos.Rows[0]["f4"] + "");
                        double custo_Antigo = 0;
                        double.TryParse("" + todos.Rows[0]["f9"].ToString(), out custo_Antigo);

                        double variacao = ((custo_corrente / custo_Antigo) - 1) * 100;
                        if (variacao >= 0)
                        {
                            if (variacao >= CustoMinimo)
                            {
                                cor = "red";
                            }
                        }

                        if (variacao < 0)
                        {
                            if (variacao <= -CustoMinimo)
                            {
                                cor = "red";
                            }
                        }

                        string img = "";

                        if (variacao > 0) { img = "<img src='cima.jpg'>"; }
                        if (variacao == 0) { img = "<img src='meio.jpg'>"; }
                        if (variacao < 0) { img = "<img src='baixo.jpg'>"; }

                        if (custo_Antigo == 0) variacao = 100;

                        // ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + custo_Antigo + "</font></th>";
                        ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + todos.Rows[0]["f9"] + "</font></th>";
                        ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + todos.Rows[0]["f7"] + "</font></th>";
                        ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2>" + ponto(todos.Rows[0]["f8"] + "") + "</font></th>";

                        if (variacao == 0)
                        {
                            ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>0,00%</font></th>";
                        }
                        else
                        {

                            ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + variacao.ToString("n2") + "%</font></th>";
                        }
                        ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>" + img + "</font></th>";

                    }
                    else
                    {
                    //    ohtml += "<th bgcolor='#99CF57' height='20px'><font face='calibri' size=2;font-weight: normal;'>" + todos.Rows[0]["f7"] + "</font></th>";
                    }

                    
                    ohtml += "</tr>";
                    ohtml += "</tr>";
                    if (lDetalhes && (todos.Rows[0]["f11"].ToString() != dia_anterior.ToString() || todos.Rows[0]["f10"].ToString() != dia_corrente.ToString()))
                    {
                        ohtml += "<tr>";
                        ohtml += "<th bgcolor='#FFFFFF' colspan='5' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>Data custo anterior: " + todos.Rows[0]["f11"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' colspan='5' height='20px'><font face='calibri' size=2 style='color:" + cor + ";font-weight: normal;'>Data custo atual:" + todos.Rows[0]["f10"] + "</font></th>";
                        ohtml += "</tr>";
                    }
                }

                ohtml += "<tr>";

                ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                if (ComCusto)// se for verdadeiro mostra o custo
                {
                    ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                    ohtml += "<th height='2px' bgcolor='#ffffff'></th>";
                }
                ohtml += "</tr>";

                html += ohtml;
            }

            html += "</table>";
            #endregion
            #region Esse bloco mostra relatorio das capacidades dos cds
            html += "<img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br>";
            html += "<font size=6 face='tahoma' id='res'>RELATÓRIO DE ESTOQUE CONSOLIDADO DAS CAPACIDADES</font><br><br>";
            html += "<table style='border:1px solid #018633' cellspacing=0 id='tabela2'>";
            html += "<tr>";
            html += "<th bgcolor='#018633' height='30px' width='100' ><font face='calibri' size=2 color=white>ARMAZÉNS</FONT></th>";
            html += "<th bgcolor='#018633' height='30px' width='140' ><font face='calibri' size=2 color=white>QTD.ARMAZ.</FONT></th>";
            html += "<th bgcolor='#018633' height='30px' width='100' ><font face='calibri' size=2 color=white>CAPACIDADE</FONT></th>";
            html += "<th bgcolor='#018633' height='30px' width='180' ><font face='calibri' size=2 color=white>OCUPAÇÃO</FONT></th>";
            html += "<th bgcolor='#018633' height='30px' width='180' ><font face='calibri' size=2 color=white>BUFFER</FONT></th>";
            html += "<th bgcolor='#018633' height='30px' width='180' ><font face='calibri' size=2 color=white>DISPONÍVEL</FONT></th>";
            html += "</tr>";

            try
            {
                html += "<tr>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>Passo Fundo</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + ponto(pfH + "") + "</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>2.000.000</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + Math.Round((pfH / C_PassoFundo) * 100, 1) + "%</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + ponto(C_PassoFundo - pfH + "") + "</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + Math.Round(((100) - (Math.Round((pfH / C_PassoFundo) * 100, 1))), 1) + "%</FONT></th>";
                html += "</tr>";

            }
            catch { }

            try
            {
                html += "<tr>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>Pato Branco</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + ponto(ptH + "") + "</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>1.000.000</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + Math.Round((ptH / C_PatoBranco) * 100, 1) + "%</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + ponto(C_PatoBranco - ptH + "") + "</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + Math.Round(((100) - (Math.Round((ptH / C_PatoBranco) * 100, 1))), 1) + "%</FONT></th>";
                html += "</tr>";
            }
            catch { }

            try
            {
                html += "<tr>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>Xanxerê</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + ponto(xaH + "") + "</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>150.000</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + Math.Round((xaH / C_Xanxere) * 100, 1) + "%</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + ponto(C_Xanxere - xaH + "") + "</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + Math.Round(((100) - (Math.Round((xaH / C_Xanxere) * 100, 1))), 1) + "%</FONT></th>";
                html += "</tr>";

            }
            catch { }


            try
            {
                html += "<tr>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>Resende</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + ponto(reH + "") + "</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>3.000.000</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + Math.Round((reH / C_Resende) * 100, 1) + "%</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + ponto(C_Resende - reH + "") + "</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + Math.Round(((100) - (Math.Round((reH / C_Resende) * 100, 1))), 1) + "%</FONT></th>";
                html += "</tr>";

            }
            catch { }

            try
            {
                html += "<tr>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>Sumaré</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + ponto(sumH + "") + "</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>2.800.000</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + Math.Round((sumH / C_SUMARE7001) * 100, 1) + "%</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + ponto(C_SUMARE7001 - sumH + "") + "</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + Math.Round(((100) - (Math.Round((sumH / C_SUMARE7001) * 100, 1))), 1) + "%</FONT></th>";
                html += "</tr>";

            }
            catch { }

            try
            {
                html += "<tr>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>Igarapava</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + ponto(igaH + "") + "</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>910.000</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + Math.Round((igaH / C_IGARAPAVA7001) * 100, 1) + "%</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + ponto(C_IGARAPAVA7001 - igaH + "") + "</FONT></th>";
                html += "<th bgcolor='#ffffff' height='20px'><font face='calibri' size=2>" + Math.Round(((100) - (Math.Round((igaH / C_IGARAPAVA7001) * 100, 1))), 1) + "%</FONT></th>";
                html += "</tr>";

            }
            catch { }

            html += "</TABLE>§";
            #endregion

            #region Esse bloco monta as imagens dos graficos de capacidade

            html += "<img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br>";
            html += "<img src='" + pf + "' width='699'><img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br>";
            html += "<img src='" + pt + "' width='699'><img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br>";
            html += "<img src='" + xa + "' width='699'><br><img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br>";
            html += "<img src='" + re + "' width='699'><br><img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br><br>";
            html += "<img src='" + sum + "' width='699'><br><img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br><br>";
            html += "<img src='" + iga + "' width='699'><br><img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br><br>";
            #endregion

            #region Esse bloco monta o html e salva na pasta e retorna o url
            string url = Environment.CurrentDirectory + "\\Relatorios\\" + Environment.UserName + "-" + data.Day + "." + data.Month + "." + data.Year + ".html";
            StreamWriter escritor = new StreamWriter(url, false, Encoding.Default);
            escritor.Write(html);
            escritor.Close();

            return url;
            #endregion
        }

        public string MontarHTML(DateTime data, DateTime dataAnterior, Boolean siger)
        {
            html = "";
            IniciarSelecionador();

            datantiga = dataAnterior;

            string anrigoadatatodositens = Facilitadores.ConverterDataParaDataDoMysql.Converter(datantiga);
            antigos = Select.SelectSQL("select POSICAO f3,numeroitem f4, sum(quantidade) f6 from condicaoestoque where data ='" + anrigoadatatodositens + "' group by f3,f4 order by 2");

            string adatatodositens = Facilitadores.ConverterDataParaDataDoMysql.Converter(data);

            //DataTable TodosItens = Select.SelectSQL("SELECT distinct numeroitem FROM sga.condicaoestoque where posicao like ('%SYSTEM-BIN-LOCATION%') and data ='" + adatatodositens + "'");
            string ConsultaTodosItens = "select POSICAO f3,numeroitem f4, descricao f5,quantidade f6,custo f7,valor f8 from condicaoestoque where (posicao like ('%SYSTEM-BIN-LOCATION%') or posicao like ('%PINHALZINHO%') or posicao like ('%ARMAZEM EXTERNO%')) and posicao not like ('4003-SYSTEM-BIN-LOCATION') and posicao not like ('4003-ZN 1 ESTOQUE EM TRANSITO EADI X ARMAZÉM') and posicao not like ('4003-ZN 27 ARMAZEM EXTRENO') and posicao not like ('4003-ZN 5 QUARENTENA') and posicao not like ('4003-ZN 7 PRODUCAO') and posicao not like ('4003-ZN6 IENS EM PROCESSO EXTERNO')  and posicao not like ('%4004%') and data ='" + adatatodositens + "' order by 2";
            string ConsultaTodosItensTransito = "select POSICAO f3,numeroitem f4, descricao f5,quantidade f6,custo f7,valor f8 from condicaoestoque where posicao like ('%TRANSITO%') and posicao not like ('%4003%') and posicao not like ('%4004%') and data ='" + adatatodositens + "' order by 2";
            DataTable TodosItens = Select.SelectSQL(ConsultaTodosItens);
            DataTable TodosItensTransito = Select.SelectSQL(ConsultaTodosItensTransito);

           

            //TRANSITO
            var distinct = (from r in TodosItens.AsEnumerable() select r["f4"]).Distinct().ToList();
            var distinct2 = (from r in TodosItensTransito.AsEnumerable() select r["f4"]).Distinct().ToList();



            double pfH = 0;
            double ptH = 0;
            double xaH = 0;
            double reH = 0;


            try
            {
                pfH = double.Parse(Select.SelectSQL(sql_passo_fundo.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
            }
            catch { }
            try
            {
                ptH = double.Parse(Select.SelectSQL(sql_pato_branco.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
            }
            catch { }
            try
            {
                xaH = double.Parse(Select.SelectSQL(sql_xanxere.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
            }
            catch { }
            try
            {
                reH = double.Parse(Select.SelectSQL(sql_resende.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
            }
            catch { }

            //('4001-SYSTEM-BIN-LOCATION','4001-ZN1 ENTREGA FUTURA','4001-ZN 2 ENTREGA FUTURA','4002-SYSTEM-BIN-LOCATION','4002-ZN1 ENTREGA FUTURA','4002-ZN 2 ENTREGA FUTURA')

            string pf = savfot("Passo Fundo", data, sql_passo_fundo.Replace("ADATA", "" + adatatodositens), "Ocupado", C_PassoFundo, pfH);
            string pt = savfot("Pato Branco", data, sql_pato_branco.Replace("ADATA", "" + adatatodositens), "Ocupado", C_PatoBranco, ptH);
            string xa = savfot("Xanxerê", data, sql_xanxere.Replace("ADATA", "" + adatatodositens), "Ocupado", C_Xanxere, xaH);
            string re = savfot("Resende", data, sql_resende.Replace("ADATA", "" + adatatodositens), "Ocupado", C_Resende, reH);



            if (siger == false)
            {
                pf = savfot("Passo Fundo", data, sql_passo_fundo_SEM_SIGER.Replace("ADATA", "" + adatatodositens), "Ocupado", C_PassoFundo, pfH);
                pt = savfot("Pato Branco", data, sql_pato_branco_SEM_SIGER.Replace("ADATA", "" + adatatodositens), "Ocupado", C_PatoBranco, ptH);
                xa = savfot("Xanxerê", data, sql_xanxere_SEM_SIGER.Replace("ADATA", "" + adatatodositens), "Ocupado", C_Xanxere, xaH);
                re = savfot("Resende", data, sql_resende_SEM_SIGER.Replace("ADATA", "" + adatatodositens), "Ocupado", C_Resende, reH);

                try
                {
                    ptH = double.Parse(Select.SelectSQL(sql_pato_branco_SEM_SIGER.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { }
                try
                {
                    xaH = double.Parse(Select.SelectSQL(sql_xanxere_SEM_SIGER.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { }

                try
                {
                    reH = double.Parse(Select.SelectSQL(sql_resende_SEM_SIGER.Replace("ADATA", "" + adatatodositens)).Rows[0][0] + "");
                }
                catch { }

            }

            html += "<html>";
            html += "<title></title>";
            html += "<body > ";
            html += "<center> <img src='" + Pastas.Relatorios + "LOGO2.png'  ><br> ";
            html += "<b><font size=3 face='tahoma' id='res'>" + dataAnterior.Day + "/" + dataAnterior.Month + "/" + dataAnterior.Year + "</font></B>  Para  ";
            html += "<b><font size=3 face='tahoma' id='res'>" + data.Day + "/" + data.Month + "/" + data.Year + "</font></b><br><img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br><br>";
            html += "";
            html += "<table style='border:1px solid #393939' cellspacing=0>";
            html += "<tr>";

            html += "<th bgcolor='#1E98E4' height='25px' width='100' ><font face='calibri' size=2 color=white>Nº do item</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='150' ><font face='calibri' size=2 color=white>Descrição do item</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='80' ><font face='calibri' size=2 color=white>Quantidade</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='200' ><font face='calibri' size=2 color=white>Posição no depósito</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='200' ><font face='calibri' size=2 color=white>Localização</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='60' ><font face='calibri' size=2 color=white>Custo</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='60' ><font face='calibri' size=2 color=white>Valor</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='20' ><font face='calibri' size=2 color=white>~</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='60' ><font face='calibri' size=2 color=white>Dif ~</FONT></th>";
            html += "</tr>";
            string ohtml = "";

            for (int a = 0; a < distinct.Count; a++)
            {
                ohtml = "";
                int qtd = TodosItens.Rows.Count;
                DataRow[] lista = TodosItens.Select("f4 ='" + distinct[a] + "'");

                DataTable todos = new DataTable();
                todos.Columns.Add("f3");
                todos.Columns.Add("f4");
                todos.Columns.Add("f5");
                todos.Columns.Add("f6");
                todos.Columns.Add("f7");
                todos.Columns.Add("f8");

                for (int c = 0; c < lista.Length; c++)
                {
                    todos.Rows.Add(lista[c][0], lista[c][1], lista[c][2], lista[c][3], lista[c][4], lista[c][5]);
                }

                double soma = 0;
                double soma2 = 0;
                if (todos.Rows.Count > 1)
                {
                    for (int b = 0; b < todos.Rows.Count; b++)
                    {
                        soma += double.Parse(todos.Rows[b]["f6"] + "");
                        soma2 += double.Parse(todos.Rows[b]["f8"] + "");
                    }

                    ohtml += "<tr>";
                    ohtml += "<th bgcolor='silver' height='25px'><font face='calibri' size=2>" + todos.Rows[0]["f4"] + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='25px'><font face='calibri' size=2>" + todos.Rows[0]["f5"] + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='25px'><font face='calibri' size=2>" + ponto(soma) + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='25px'></th>";
                    ohtml += "<th bgcolor='silver' height='25px'></th>";
                    ohtml += "<th bgcolor='silver' height='25px'<font face='calibri' size=2></font></th>";
                    ohtml += "<th bgcolor='silver' height='25px'><font face='calibri' size=2>" + ponto(soma2) + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='25px'></th>";
                    ohtml += "<th bgcolor='silver' height='25px'></th>";
                    ohtml += "</tr>";



                    for (int b = 0; b < todos.Rows.Count; b++)
                    {
                        ohtml += "<tr>";


                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + todos.Rows[b]["f4"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + todos.Rows[b]["f5"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + ponto(todos.Rows[b]["f6"] + "") + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + todos.Rows[b]["f3"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + converte(todos.Rows[b]["f3"] + "") + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + todos.Rows[b]["f7"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + ponto(todos.Rows[b]["f8"]) + "</font></th>";


                        string img = "";
                         double antes = RetornarSaldo(todos.Rows[b]["f4"] + "", todos.Rows[b]["f3"] + "");
                         double agora = double.Parse(todos.Rows[b]["f6"] + "");

                        if (agora - antes < 0)
                        {
                            img = "<img src='baixo.gif'>";
                        }

                        if (agora - antes > 0)
                        {
                            img = "<img src='cima.gif'>";
                        }

                        if (agora - antes == 0)
                        {
                            img = "<img src='meio.jpg'>";
                        }

                        ohtml += "<th bgcolor='white' height='20px'><font face='calibri' size=2>" + img + "</font></th>";
                        ohtml += "<th bgcolor='white' height='20px'><font face='calibri' size=2>" + ponto((agora - antes)) + "</font></th>";



                        ohtml += "</tr>";
                    }

                }
                else
                {

                    string img = "";
                    if (("" + todos.Rows[0]["f3"] + "").IndexOf("1002") != -1 || ("" + todos.Rows[0]["f3"] + "").IndexOf("2002") != -1 || ("" + todos.Rows[0]["f3"] + "").IndexOf("3001") != -1)
                    {
                        img = "<img src='" + Pastas.Relatorios + "icoatanor.png'>";
                    }
                    else
                    {
                        img = "<img src='" + Pastas.Relatorios + "icoatar.png'>";
                    }

                    ohtml += "<tr>";

                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + todos.Rows[0]["f4"] + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + todos.Rows[0]["f5"] + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto(todos.Rows[0]["f6"] + "") + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + todos.Rows[0]["f3"] + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + converte(todos.Rows[0]["f3"] + "") + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + todos.Rows[0]["f7"] + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto(todos.Rows[0]["f8"]) + "</font></th>";

                    double antes = RetornarSaldo(todos.Rows[0]["f4"] + "", todos.Rows[0]["f3"] + "");
                    double agora = double.Parse(todos.Rows[0]["f6"] + "");

                    if (agora - antes < 0)
                    {
                        img = "<img src='baixo.gif'>";
                    }

                    if (agora - antes > 0)
                    {
                        img = "<img src='cima.gif'>";
                    }

                    if (agora - antes == 0)
                    {
                        img = "<img src='meio.jpg'>";
                    }

                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + img + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto((agora - antes)) + "</font></th>";


                    ohtml += "</tr>";
                }

                ohtml += "<tr>";

                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "</tr>";

                html += ohtml;
            }

            html += "</table>";
            html += "<img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br>";
            html += "<font size=6 face='tahoma' id='res'>RELATÓRIO DE ESTOQUE CONSOLIDADO ESTOQUE EM TRÂNSITO</font><br><br>";
            html += "<table style='border:1px solid #393939' cellspacing=0>";
            html += "<tr>";

            html += "<th bgcolor='#1E98E4' height='25px' width='100' ><font face='calibri' size=2 color=white>Nº do item</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='150' ><font face='calibri' size=2 color=white>Descrição do item</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='80' ><font face='calibri' size=2 color=white>Quantidade</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='200' ><font face='calibri' size=2 color=white>Posição no depósito</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='200' ><font face='calibri' size=2 color=white>Localização</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='60' ><font face='calibri' size=2 color=white>Custo</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='60' ><font face='calibri' size=2 color=white>Valor</FONT></th>";
            
            html += "<th bgcolor='#1E98E4' height='25px' width='20' ><font face='calibri' size=2 color=white>~</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='25px' width='60' ><font face='calibri' size=2 color=white>Dif~</FONT></th>";
            html += "</tr>";

            for (int a = 0; a < distinct2.Count; a++)
            {
                ohtml = "";
                int qtd = TodosItensTransito.Rows.Count;
                DataRow[] lista = TodosItensTransito.Select("f4 ='" + distinct2[a] + "'");

                DataTable todos = new DataTable();
                todos.Columns.Add("f3");
                todos.Columns.Add("f4");
                todos.Columns.Add("f5");
                todos.Columns.Add("f6");
                todos.Columns.Add("f7");
                todos.Columns.Add("f8");

                for (int c = 0; c < lista.Length; c++)
                {
                    todos.Rows.Add(lista[c][0], lista[c][1], lista[c][2], lista[c][3], lista[c][4], lista[c][5]);
                }

                double soma = 0;
                double soma2 = 0;
                if (todos.Rows.Count > 1)
                {
                    for (int b = 0; b < todos.Rows.Count; b++)
                    {
                        soma += double.Parse(todos.Rows[b]["f6"] + "");
                        soma2 += double.Parse(todos.Rows[b]["f8"] + "");
                    }

                    ohtml += "<tr>";
                    ohtml += "<th bgcolor='silver' height='25px'><font face='calibri' size=2>" + todos.Rows[0]["f4"] + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='25px'><font face='calibri' size=2>" + todos.Rows[0]["f5"] + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='25px'><font face='calibri' size=2>" + ponto(soma) + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='25px'></th>";
                    ohtml += "<th bgcolor='silver' height='25px'></th>";
                    ohtml += "<th bgcolor='silver' height='25px'></th>";
                    ohtml += "<th bgcolor='silver' height='25px'><font face='calibri' size=2>" + ponto(soma2) + "</font></th>";



                    double antes = RetornarSaldo(todos.Rows[0]["f4"] + "", todos.Rows[0]["f3"] + "");
                    double agora = 0;
                    try
                    {
                        agora = double.Parse(todos.Rows[0]["f6"] + "");
                    }
                    catch { }

                    string img = "";

                    if (agora - antes < 0)
                    {
                        img = "<img src='baixo.gif'>";
                    }

                    if (agora - antes > 0)
                    {
                        img = "<img src='cima.gif'>";
                    }

                    if (agora - antes == 0)
                    {
                        img = "<img src='meio.jpg'>";
                    }

                    ohtml += "<th bgcolor='silver' height='25px'><font face='calibri' size=2>" + img + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='25px'><font face='calibri' size=2>" + ponto((agora - antes)) + "</font></th>";

                    ohtml += "</tr>";

                    for (int b = 0; b < todos.Rows.Count; b++)
                    {



                        ohtml += "<tr>";

                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + todos.Rows[b]["f4"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + todos.Rows[b]["f5"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + ponto(todos.Rows[b]["f6"] + "") + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + converte2(todos.Rows[b]["f3"] + "") + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + converte(todos.Rows[b]["f3"] + "") + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + todos.Rows[b]["f7"] + "</font></th>";
                        ohtml += "<th bgcolor='#FFFFFF' height='20px'><font face='calibri' size=2 style='font-weight: normal;'>" + ponto(todos.Rows[b]["f8"] + "") + "</font></th>";

                        string p1 = todos.Rows[b]["f4"] + "";
                        string p2 = todos.Rows[b]["f3"] + "";
                         antes = RetornarSaldo(p1,p2);
                         agora = 0;
                         try
                         {
                             agora = double.Parse(todos.Rows[b]["f6"] + "");
                         }
                         catch { }
                         img = "";

                        if (agora - antes < 0)
                        {
                            img = "<img src='baixo.gif'>";
                        }

                        if (agora - antes > 0)
                        {
                            img = "<img src='cima.gif'>";
                        }

                        if (agora - antes == 0)
                        {
                            img = "<img src='meio.jpg'>";
                        }

                        ohtml += "<th bgcolor='white' height='25px'><font face='calibri' size=2>" + img + "</font></th>";
                        ohtml += "<th bgcolor='white' height='25px'><font face='calibri' size=2>" + ponto((agora - antes)) + "</font></th>";


                        ohtml += "</tr>";

                    }

                }
                else
                {


                    ohtml += "<tr>";

                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + todos.Rows[0]["f4"] + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + todos.Rows[0]["f5"] + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto(todos.Rows[0]["f6"] + "") + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + converte2(todos.Rows[0]["f3"] + "") + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + converte(todos.Rows[0]["f3"] + "") + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + todos.Rows[0]["f7"] + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto(todos.Rows[0]["f8"] + "") + "</font></th>";


                    double antes = RetornarSaldo(todos.Rows[0]["f4"] + "", todos.Rows[0]["f3"] + "");
                    double agora = double.Parse(todos.Rows[0]["f6"] + "");
                   string img = "";

                    if (agora - antes < 0)
                    {
                        img = "<img src='baixo.gif'>";
                    }

                    if (agora - antes > 0)
                    {
                        img = "<img src='cima.gif'>";
                    }

                    if (agora - antes == 0)
                    {
                        img = "<img src='meio.jpg'>";
                    }

                    ohtml += "<th bgcolor='silver' height='25px'><font face='calibri' size=2>" + img + "</font></th>";
                    ohtml += "<th bgcolor='silver' height='25px'><font face='calibri' size=2>" + ponto((agora - antes)) + "</font></th>";


                    ohtml += "</tr>";

                    
                }

                ohtml += "<tr>";

                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "<th height='2px' bgcolor='#778899'></th>";
                ohtml += "</tr>";

                html += ohtml;
            }

            html += "</table>";

            html += "<img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br>";
            html += "<font size=6 face='tahoma' id='res'>RELATÓRIO DE ESTOQUE CONSOLIDADO DAS CAPACIDADES</font><br><br>";
            html += "<table style='border:1px solid #393939' cellspacing=0>";
            html += "<tr>";
            html += "<th bgcolor='#1E98E4' height='30px' width='100' ><font face='calibri' size=2 color=white>ARMAZÉNS</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='30px' width='140' ><font face='calibri' size=2 color=white>QTD.ARMAZ.</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='30px' width='100' ><font face='calibri' size=2 color=white>CAPACIDADE</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='30px' width='180' ><font face='calibri' size=2 color=white>OCUPAÇÃO</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='30px' width='180' ><font face='calibri' size=2 color=white>BUFFER</FONT></th>";
            html += "<th bgcolor='#1E98E4' height='30px' width='180' ><font face='calibri' size=2 color=white>DISPONÍVEL</FONT></th>";
            html += "</tr>";

            try
            {
                html += "<tr>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>Passo Fundo</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto(pfH + "") + "</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>2.000.000</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + Math.Round((pfH / C_PassoFundo) * 100, 1) + "%</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto(C_PassoFundo - pfH + "") + "</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ((100) - (Math.Round((pfH / C_PassoFundo) * 100, 1))) + "%</FONT></th>";
                html += "</tr>";

            }
            catch { }

            try
            {
                html += "<tr>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>Pato Branco</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto(ptH + "") + "</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>1.000.000</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + Math.Round((ptH / C_PatoBranco) * 100, 1) + "%</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto(C_PatoBranco - ptH + "") + "</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ((100) - (Math.Round((ptH / C_PatoBranco) * 100, 1))) + "%</FONT></th>";
                html += "</tr>";
            }
            catch { }

            try
            {
                html += "<tr>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>Xanxerê</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto(xaH + "") + "</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>50O.000</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + Math.Round((xaH / C_Xanxere) * 100, 1) + "%</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto(C_Xanxere - xaH + "") + "</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ((100) - (Math.Round((xaH / C_Xanxere) * 100, 1))) + "%</FONT></th>";
                html += "</tr>";

            }
            catch { }

            try
            {
                html += "<tr>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>Resende</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto(reH + "") + "</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>3.0000.000</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + Math.Round((reH / C_Resende) * 100, 1) + "%</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ponto(C_Resende - reH + "") + "</FONT></th>";
                html += "<th bgcolor='silver' height='20px'><font face='calibri' size=2>" + ((100) - (Math.Round((reH / C_Resende) * 100, 1))) + "%</FONT></th>";
                html += "</tr>";

            }
            catch { }
            html += "</TABLE>§";

            html += "<img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br><img src='" + pf + "' width='699'><img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br><img src='" + pt + "' width='699'><img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br><img src='" + xa + "' width='699'><BR><img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'><br><img src='" + re + "' width='699'><br>";


            string url = Environment.CurrentDirectory + "\\Relatorios\\" + Environment.UserName + "-" + data.Day + "." + data.Month + "." + data.Year + ".html";
            StreamWriter escritor = new StreamWriter(url, false, Encoding.Default);
            escritor.Write(html);
            escritor.Close();

            return url;
        }


        public static string MontarHTMLComSenha()
        {
            string code = "";
            code += "<script language = \"Javascript\" > ";
            code += "var password = prompt(\"Digite a senha\"); ";
            code += "function senha(x){ var q = 2016; for (e = 0; e < x.length; e++) { q += x.charCodeAt(e) * 3; } if (q == 4647) return true; else return false; } ";
            code += "if (!senha(password)) { window.alert(\"Senha incorreta!\", \"Senha\"); window.document.location = \"http://www.atanorbrasil.com.br/\"; } else { document.getElementById(\"tabela\").style.display=\"\"; document.getElementById(\"tabela1\").style.display=\"\"; document.getElementById(\"tabela2\").style.display=\"\"; }";
            code += " </script> ";
            string ohtml = "" + html.Substring(0, html.IndexOf("</TABLE>§")+9);
            ohtml = ohtml.Replace("<img src='" + Pastas.Relatorios + "LOGO2.png'  >", "<h2>RELATÓRIO DE ESTOQUE</h2>");
            ohtml = ohtml.Replace("< img src = '" + Pastas.Relatorios + "linha1.png' width = '100%' height = '32' >", "<hr>");
            ohtml = ohtml.Replace("<img src='" + Pastas.Relatorios + "linha1.png' width='100%' height='32'>", "<hr>");
            ohtml = ohtml.Replace("border:1px solid #393939", "border:1px solid #393939;display:none;");
            ohtml = ohtml.Replace("</TABLE>§", "</TABLE>§" + code + "");

            return ohtml;
        }

    }
}
