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
using SGAPizza;
using System.Data;
using Conector;
namespace Atanor.Programas.Expedicao
{
    /// <summary>
    /// Interaction logic for DivisaoFrete.xaml
    /// </summary>
    public partial class DivisaoFrete : UserControl
    {

        public string per = "24";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/packages2.png", UriKind.RelativeOrAbsolute));
        public string nome = "Divisão de Frete.";

        List<string> cores = new List<string>();
        public DivisaoFrete()
        {
            InitializeComponent();

            cores.Add("#FFF3D240");
            cores.Add("#FFADD85F");
            cores.Add("#FF78D9D9");
            cores.Add("#FFFFAF51");
            cores.Add("#FFFF6F6F");
            cores.Add("#FFF359A8");
            cores.Add("#FFC48AFF");
            cores.Add("#FF58B1FC");
            cores.Add("#FF9898FF");
            cores.Add("#FF9898FF");
            cores.Add("#FFC3B5A8");
            cores.Add("#FFFCFCFC");
            montar();
        }

       

        int c = 0;
        private string cor()
        {
            if (c < cores.Count)
            {
                string retorno = cores[c];
                c++;
                return retorno;
            }
            else
            {
                c = 0;
                return cores[c];
            }
        }

        private void montar()
        {
            SGAPizza.Grafico gra = new Grafico();
            gra.Width = 600;
            gra.Height = 250;
            gra.Margin = new Thickness(10, 62, 0, 0);
            gra.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            gra.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            gra.Titulo = "Divisão de Frete.";

            DataTable tabela = Select.SelectSQL("SELECT y.apelido,count(y.apelido) FROM romaneio x,transportadoras y where y.id=x.idtransportadoras group by y.apelido");
            double max = 0;

            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                max += double.Parse(tabela.Rows[a][1] + "");
            }

            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                Parte n = new Parte();
                n.nome = tabela.Rows[a][0] + " - " + Math.Round((double.Parse(tabela.Rows[a][1] + "")/max) * 100,2) + "%";
                n.valor = double.Parse(tabela.Rows[a][1] + "");
                n.cor = cor();
                gra.Add(n);
            }

            painel.Children.Add(gra);
            gra.Montar();

            tabela = Select.SelectSQL("SELECT month(x.data),y.apelido,count(y.apelido) FROM romaneio x,transportadoras y where y.id=x.idtransportadoras group by y.apelido,month(x.data) order by 1");
            int m = 1;
            int mar = 62;

            max = 0;

            SGAPizza.Grafico g = new Grafico();
         
            for (int b = 1; b <= 12; b++)
            {

                g = new Grafico();
                g.Width = 600;
                g.Height = 250;
                g.Margin = new Thickness(10, mar, 0, 0);
                g.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                g.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                g.Titulo = "Divisão de Frete. Mês (" + m + ")";

                for (int a = 0; a < tabela.Rows.Count; a++)
                {
                    if (int.Parse(tabela.Rows[a][0].ToString()) == m)
                    {
                        max += double.Parse(tabela.Rows[a][2] + "");
                    }
                }


                for (int a = 0; a < tabela.Rows.Count; a++)
                {
                    if (int.Parse(tabela.Rows[a][0].ToString()) == m)
                    {
                        Parte n = new Parte();
                        n.nome = tabela.Rows[a][1] + " - " + Math.Round((double.Parse(tabela.Rows[a][2] + "") / max) * 100, 2) + "%";
                        n.valor = double.Parse(tabela.Rows[a][2] + "");
                        n.cor = cor();
                        g.Add(n);
                    }
                }

                
                g.Montar();
                m = b;
                mar += 270;
                max = 0;
                c = 0;

              //  painel.Children.Add(g); Libera aqui para mostrar Mês.
            }

        }
    }
}
