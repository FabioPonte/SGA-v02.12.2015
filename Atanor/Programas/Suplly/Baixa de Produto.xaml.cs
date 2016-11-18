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
    /// Interaction logic for Baixa_de_Produto.xaml
    /// </summary>
    public partial class Baixa_de_Produto : UserControl, TaskMenu.Pacotes
    {
        public string nome = "Baixa de Produto";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/search102.png", UriKind.RelativeOrAbsolute));
        public string per = "44";

        public Baixa_de_Produto()
        {
            InitializeComponent();
            pacote1.Janela = this;
            dataGridFiltro1.Odatagrid = agrid;
            Listar();
        }

        private void Listar()
        {
            agrid.ItemsSource = Select.SelectSQL("SELECT p.id id,(select nome from produtos where id=p.id_produto) produto,d.nome1 Depósito,d.nome2 Lado1,d.nome3 Lado2,p.lote Lote,p.quantidade Quantidade  FROM posicao_produto p , posicao_depositos d where p.id_posicao=d.id and quantidade >0").DefaultView;
            agrid.SelectedValuePath = "id";
        }

        private void agrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                mapa.Limpar();
                mapa.LimparSeta();
                Select.SelectDinamico(this, "SELECT p.id id,(select nome from produtos where id=p.id_produto) produto,d.nome1,d.nome2,d.nome3,p.lote,p.quantidade,d.x x,d.y y  FROM posicao_produto p , posicao_depositos d where p.id_posicao=d.id and p.id=" + agrid.SelectedValue + "");

                Point novo = new Point();
                novo.X = double.Parse(txt_x.Text);
                novo.Y = double.Parse(txt_y.Text);

                mapa.Add(novo);
            }
            catch { }
        }

        public void pacote_novo()
        {
            try
            {
                double valor = double.Parse(txt_quantidade.Text);
                if (txt_nota.Text.Trim() == "")
                {
                    MsgBox.Show.Error("Nota Fiscal não foi informada!");
                    return;
                }
                if (valor <= 0)
                {
                    MsgBox.Show.Error("Quantidade inválida!");
                    return;
                }
                else
                {
                    double valor_antes = 0;
                    double valor_depois = 0;
                    double valor_baixa = valor;

                    Banco.posicao_produto novo = Banco.posicao_produto.Obter("id=" + agrid.SelectedValue + "")[0];

                    Banco.posicao_produto nava = new Banco.posicao_produto();
                    valor_antes = double.Parse(novo.Quantidade + "");
                    valor_depois = double.Parse(novo.Quantidade + "") - valor;
                    nava.Quantidade = valor_depois;
                    nava.Condicao = "id=" + agrid.SelectedValue + "";
                    
                    if (valor_depois < 0)
                    {
                        MsgBox.Show.Error("Essa baixa consome mais quantidade do que a disponível em estoque.");
                        return;
                    }

                    if (nava.Alterar() != -1)
                    {

                        Banco.posicao_baixa nova = new Banco.posicao_baixa();
                        nova.Id_produto = int.Parse("" + agrid.SelectedValue);
                        nova.Io = "Saída";
                        nova.Nota = int.Parse("" + txt_nota.Text);
                        nova.Qtd_antes = valor_antes;
                        nova.Qtd_baixada = valor_baixa;
                        nova.Qtd_depois = valor_depois;
                        nova.Usuario = Sessao.usuario.Usuario;
                        nova.Data = DateTime.Now;
                        nova.Deposito = cbo_deposito.Text;
                        nova.Lado1 = cbo_lado1.Text;
                        nova.Lado2 = cbo_lado2.Text;
                        nova.Lote = txt_lote.Text;
                        if (nova.Inserir() != -1)
                        {
                            MsgBox.Show.Info("Baixa Feita com sucesso!");
                            Listar();
                        }
                        else
                        {
                            MsgBox.Show.Error("Erro ao dar baixa!");
                        }

                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao dar baixa!");
                    }
                }

            }
            catch { }
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

        private void txt_quantidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {
                if (e.Key >= Key.D0 && e.Key <= Key.D9)
                {
                    e.Handled = false;
                }
                else
                {
                    if (e.Key == Key.Back || e.Key == Key.Enter || e.Key == Key.Delete || e.Key == Key.OemComma || e.Key == Key.Decimal || e.Key == Key.Left || e.Key == Key.Right)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txt_nota_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {
                if (e.Key >= Key.D0 && e.Key <= Key.D9)
                {
                    e.Handled = false;
                }
                else
                {
                    if (e.Key == Key.Back || e.Key == Key.Enter || e.Key == Key.Delete || e.Key == Key.OemComma || e.Key == Key.Decimal || e.Key == Key.Left || e.Key == Key.Right)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
