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
using LetsMove.Access2;
using System.Data;

namespace Atanor.Programas.Expedicao
{
    /// <summary>
    /// Interaction logic for ListaAtar.xaml
    /// </summary>
    public partial class ListaAtar : UserControl,TaskMenu.Pacotes
    {

        public string per = "24";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/packages2.png", UriKind.RelativeOrAbsolute));
        public string nome = "Expedição Atar";


        public ListaAtar()
        {
            InitializeComponent();
            pacote1.Janela = this;
            Conexao.Caminho = Pastas.Notas + "db.db";
            Listar();
            pacote1.Ativado = false;
            Sessao.AtualizarCfop();

        }

        private void Listar()
        {
            DataTable TabelaSGA = Conector.Select.SelectSQL("select distinct nota from expedicao");
            DataTable TabelaGetor = Select.SelectSQL("select * from notas where cd='RESENDE' and data >= '2015-10-1'");

            List<int> linhas = new List<int>();

            for(int a = 0; a < TabelaSGA.Rows.Count; a++)
            {
                for(int b = 0; b < TabelaGetor.Rows.Count; b++)
                {
                    if ((TabelaSGA.Rows[a]["nota"] + "") == (TabelaGetor.Rows[b]["nota"] + ""))
                    {
                        linhas.Add(b);
                    }
                }
            }
            int c1 = TabelaGetor.Rows.Count;
            for(int a = 0; a < linhas.Count; a++)
            {
                TabelaGetor.Rows[linhas[a]].Delete();
            }
            TabelaGetor.AcceptChanges(); 
            c1 = TabelaGetor.Rows.Count;
            listexp.ItemSource = TabelaGetor;
        }



        public void pacote_novo()
        {
        }

        public void pacote_excluir()
        {
        }

        public void pacote_editar()
        {
        }

        public void pacote_cancelar()
        {
        }

       
        private void chk_marcar_Click(object sender, RoutedEventArgs e)
        {
            if (chk_marcar.IsChecked == true)
            {
                listexp.MarcarTudo();
            }
            else
            {
                listexp.DesmarcarTudo();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Sessao.NotasAtar = listexp.ObterItensAtivo();
            Sessao.AbrirPrograma(new Programas.Expedicao.Expedir(), this);
            Sessao.FecharPrograma(this);

        }
    }
}
