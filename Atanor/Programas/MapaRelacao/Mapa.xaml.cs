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
using System.Windows.Shapes;

namespace Atanor.Programas.MapaRelacao
{
    /// <summary>
    /// Interaction logic for Mapa.xaml
    /// </summary>
    public partial class Mapa : Window
    {
        int grupo = -1;
        List<int> G_altura = new List<int>();
        List<int> G_largura = new List<int>();
        public int G_distancia_entre_grupos = 150;
        public int C_altura = 100;
        public int C_largura = 100;
        

        public Mapa()
        {
            InitializeComponent();
            montarTeste();
        }

        List<Caixa> caixas = new List<Caixa>();

        public int Grupo
        {
            get
            {
                return grupo;
            }

            set
            {
                grupo = value;
                G_altura.Add(20-100);
                G_largura.Add(100+ G_distancia_entre_grupos);
            }
        }

        private void montarTeste()
        {


            Caixa a1 = new Caixa();
            Caixa a2 = new Caixa();
            Caixa a3 = new Caixa();
            Caixa a4 = new Caixa();
            Caixa a5 = new Caixa();
            Caixa a6 = new Caixa();
            Caixa a7 = new Caixa();


            a1.filhos.Add(a2);
            a1.filhos.Add(a3);

            a3.filhos.Add(a4);
            a3.filhos.Add(a5);

            a2.filhos.Add(a6);
            a2.filhos.Add(a7);

            a1.msg = "Ianez";
            a2.msg = "Débora";
            a3.msg = "Samarinha";

            a4.msg = "Netinho";
            a5.msg = "Gabriel";

            a6.msg = "Feijão";
            a7.msg = "Arroz";

            Caixa caixa = new Caixa();
            caixa.msg = "Ana";
            caixa.filhos.Add(a1);

            Montar(caixa);
        }

        public void Montar(Caixa mae)
        {
            Grupo++;
            List<Caixa> volta = new List<Caixa>();
            Caixa pai = mae;
            Boolean voltando = false;
            int ogrupo = 0;
            int altura_pai = 0;
            int c = 0;
            while (true)
            {
                if (!voltando)
                {
                    ogrupo = Grupo;
                }

                G_altura[ogrupo] += C_altura+10;

                if (G_altura[ogrupo] < altura_pai)
                {
                    G_altura[ogrupo] = altura_pai;
                }

                dynamic novo = MontarCaixa(pai.msg);
                pai.feito = true;
                Canvas.SetTop(novo, G_altura[ogrupo]);
                Canvas.SetLeft(novo, 110*ogrupo);
                pai.meugrupo = ogrupo;
                pai.id = c;
                if (pai.filhos.Count > 1) { volta.Add(pai);  }
                c++;
                if (pai.filhos.Count > 0)
                {

                    altura_pai = G_altura[ogrupo];
                    if (!voltando)
                    {
                        Grupo++;
                    }
                    else
                    {
                        ogrupo = pai.meugrupo + 1;
                        if (ogrupo > Grupo)
                        {
                            Grupo++;
                        }
                    }
                    
                    pai = pai.filhos[0];
                }
                else
                {
                    if (volta.Count > 0)
                    {
                        for (int b = 0; b < volta.Count; b++)
                        {
                            Boolean deletar = true;
                            for (int a = 0; a < volta[0].filhos.Count; a++)
                            {
                                if (volta[0].filhos[a].feito == false)
                                {
                                    deletar = false;
                                    pai = volta[0].filhos[a];
                                    voltando = true;
                                    altura_pai = G_altura[volta[0].meugrupo];
                                    ogrupo = volta[0].meugrupo + 1;
                                    break;
                                }
                            }
                            if (deletar)
                            {
                                volta.RemoveAt(0);
                            }
                            else
                            {
                                break;
                            }
                            b = -1;
                        }
                        if (volta.Count == 0) break;
                    }
                    else
                    {
                        break;
                    }
                }


            }
        }
            
            
        

        private Button MontarCaixa(string msg)
        {
            
            Button n = new Button();
            n.Width = C_largura;
            n.Height = C_altura;
            n.Background = Brushes.Red;
            n.Content = msg;
            ogrid.Children.Add(n);
            return n;
        }

        
    }

    public class Caixa
    {
        public int id = 0;
        public List<Caixa> filhos = new List<Caixa>();
        public Boolean feito = false;
        public string msg;
        public int meugrupo;
    }
    
  
    
}
