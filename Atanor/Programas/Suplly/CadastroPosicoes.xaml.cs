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
using Conector;

namespace Atanor.Programas.Suplly
{
    /// <summary>
    /// Interaction logic for CadastroPosicoes.xaml
    /// </summary>
    public partial class CadastroPosicoes : UserControl , TaskMenu.Pacotes
    {
        Facilitadores.Verificador v = new Facilitadores.Verificador();
        public CadastroPosicoes()
        {
            InitializeComponent();
            pacote1.Janela = this;

            v.Add(txt_p1, "Posição 1 não foi informada", true);
            v.Add(txt_p2, "Posição 2 não foi informada", true);
            v.Add(txt_p3, "Posição 3 não foi informada", true);
            v.Add(txt_x, "Posição X não foi informada", true);
            v.Add(txt_y, "Posição Y não foi informada", true);

            mapa.Click += Mapa_Click;
            listar();
        }

        private void Mapa_Click(double x, double y)
        {
            mapa.Limpar();
            mapa.LimparSeta();
            Point novo = new Point();
            novo.X = x;
            novo.Y = y;
            mapa.Add(novo);

            txt_x.Text = x + "";
            txt_y.Text = y + "";
        }

        public string nome = "Cadastro de Posições";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/search102.png", UriKind.RelativeOrAbsolute));
        public string per = "42";

        

        private void listar()
        {
            ogrid.ItemsSource = Banco.posicao_depositos.ListarParaDataGrid();
            ogrid.SelectedValuePath = "id";
        }

        public void pacote_novo()
        {
            if (v.Analisar())
            {
                Banco.posicao_depositos novo = new Banco.posicao_depositos();
                novo.Nome1 = txt_p1.Text;
                novo.Nome2 = txt_p2.Text;
                novo.Nome3 = txt_p3.Text;
                novo.X = int.Parse("" + txt_x.Text);
                novo.Y = int.Parse("" + txt_y.Text);
                novo.Obs = txt_obs.Text;
                novo.Condicao = "id=" + ogrid.SelectedValue + "";
                if (novo.Inserir() != -1)
                {
                    MsgBox.Show.Info("Cadastrado com sucesso!");
                    listar();
                    v.Limpar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao cadastrar!");
                }
            }
        }

        public void pacote_excluir()
        {
            
                Banco.posicao_depositos novo = new Banco.posicao_depositos();
                novo.Nome1 = txt_p1.Text;
                novo.Nome2 = txt_p2.Text;
                novo.Nome3 = txt_p3.Text;
            novo.X = int.Parse("" + txt_x.Text);
            novo.Y = int.Parse("" + txt_y.Text);
                novo.Obs = txt_obs.Text;
                novo.Condicao = "id=" + ogrid.SelectedValue + "";
            if (novo.Excluir() != -1)
            {
                MsgBox.Show.Info("Excluido com sucesso!");
                listar();
                v.Limpar();
            }
            else
            {
                MsgBox.Show.Error("Erro ao excluir!");
            }
            
        }

        public void pacote_editar()
        {
            if (v.Analisar())
            {
                Banco.posicao_depositos novo = new Banco.posicao_depositos();
                novo.Nome1 = txt_p1.Text;
                novo.Nome2 = txt_p2.Text;
                novo.Nome3 = txt_p3.Text;
                novo.X = int.Parse("" + txt_x.Text);
                novo.Y = int.Parse("" + txt_y.Text);
                novo.Obs = txt_obs.Text;
                novo.Condicao = "id=" + ogrid.SelectedValue + "";
                if (novo.Alterar() != -1)
                {
                    MsgBox.Show.Info("Alterado com sucesso!");
                    listar();
                    v.Limpar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao Alterar!");
                }
            }
        }

        public void pacote_cancelar()
        {
            v.Limpar();
            mapa.Limpar();
            mapa.LimparSeta();
        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Select.SelectDinamico(this, "select * from posicao_depositos where id=" + ogrid.SelectedValue + "");
                add();
            }
            catch { }
        }

        private void add()
        {
            Point n = new Point();
            n.X = (int)double.Parse(txt_x.Text);
            n.Y = (int)double.Parse(txt_y.Text);
            mapa.Limpar();
            mapa.LimparSeta();
            mapa.Add(n);
            mapa.Mostra(n);
        }
    }
}
