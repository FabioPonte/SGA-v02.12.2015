using Conector;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Atanor.Programas.Suplly
{
    /// <summary>
    /// Interaction logic for Ingresso_de_Produto.xaml
    /// </summary>
    public partial class Ingresso_de_Produto : UserControl , TaskMenu.Pacotes
    {

        Facilitadores.Transferidor produto = new Facilitadores.Transferidor();

        Facilitadores.Verificador v = new Facilitadores.Verificador();
        public Ingresso_de_Produto()
        {
            InitializeComponent();
            pacote1.Janela = this;
            produto.Combo = cbo_produto;
            produto.Retorno += Listarprodutos;
            produto.controle = this;
            listar();

            v.Add(cbo_deposito, "Depoósito não foi informado", true);
            v.Add(cbo_lado1, "Primeiro lado não foi informado", true);
            v.Add(cbo_lado2, "Segundo lado não foi informado", true);
            v.Add(cbo_produto, "Segundo lado não foi informado", true);
            v.Add(txt_lote, "Lote não foi informado", true);
            v.Add(txt_quantidade, "Quantidade não foi informado", true);
        }


        public string nome = "Ingresso de Produto";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/search102.png", UriKind.RelativeOrAbsolute));
        public string per = "43";

        private void Listarprodutos()
        {
            cbo_produto.ItemsSource = Banco.produtos.ListarParaDataGrid();
            cbo_produto.DisplayMemberPath = "nome";
            cbo_produto.SelectedValuePath = "id";
        }

        private void listar()
        {
            cbo_deposito.ItemsSource = Select.SelectSQL("select distinct nome1 from posicao_depositos").DefaultView;
            cbo_deposito.DisplayMemberPath = "nome1";
            cbo_deposito.SelectedValuePath = "nome1";

            Listarprodutos();
        }

        private void cbo_deposito_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            cbo_lado1.ItemsSource = Select.SelectSQL("select distinct nome2 from posicao_depositos where nome1='" + cbo_deposito.SelectedValue + "'").DefaultView;
            cbo_lado1.DisplayMemberPath = "nome2";
            cbo_lado1.SelectedValuePath = "nome2";

        }

        private void cbo_lado1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbo_lado2.ItemsSource = Select.SelectSQL("select distinct nome3,id from posicao_depositos where nome1='" + cbo_deposito.SelectedValue + "' and nome2='" + cbo_lado1.SelectedValue + "'").DefaultView;
            cbo_lado2.DisplayMemberPath = "nome3";
            cbo_lado2.SelectedValuePath = "id";
        }

        private void cbo_lado2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mapa.Limpar();
            mapa.LimparSeta();
            try
            {
                DataTable tabela = Select.SelectSQL("select * from posicao_depositos where id=" + cbo_lado2.SelectedValue + "");
                Point p = new Point();
                p.X = int.Parse(tabela.Rows[0]["x"] + "");
                p.Y = int.Parse(tabela.Rows[0]["y"] + "");
                mapa.Add(p);
            }
            catch { }
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Programas.Logistica.Produtos(produto), this);
        }

        private void txt_quantidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
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
                    if (e.Key == Key.Back || e.Key == Key.Enter || e.Key == Key.Delete || e.Key == Key.OemComma || e.Key == Key.Decimal || e.Key==Key.Left || e.Key==Key.Right)
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

        public void pacote_novo()
        {
            if (v.Analisar())
            {
                if (MsgBox.Show.Pergunta("Quer mesmo adicionar este lote?"))
                {
                    List<Banco.posicao_produto> lista = Banco.posicao_produto.Obter();

                    Boolean modo = true;
                    string id = "";
                    double quantidade = 0;
                    for (int a = 0; a < lista.Count; a++)
                    {
                        if (lista[a].Lote == txt_lote.Text)
                        {
                            modo = false;
                            id = lista[a].Id + "";
                            quantidade = double.Parse(lista[a].Quantidade + "");
                            break;
                        }
                    }
                    if (modo)
                    {
                        Banco.posicao_produto novo = new Banco.posicao_produto();
                        novo.Id_posicao = int.Parse("" + cbo_lado2.SelectedValue);
                        novo.Id_produto = int.Parse("" + cbo_produto.SelectedValue);
                        novo.Lote = txt_lote.Text;
                        novo.Quantidade = int.Parse("" + txt_quantidade.Text);
                        if (novo.Inserir() != -1)
                        {
                            List<Banco.posicao_produto> p = Banco.posicao_produto.Obter();
                            Banco.posicao_baixa nova = new Banco.posicao_baixa();
                            nova.Id_produto = p[p.Count - 1].Id;
                            nova.Io = "Entrada";
                            nova.Qtd_antes = 0;
                            nova.Qtd_baixada = p[p.Count - 1].Quantidade;
                            nova.Qtd_depois = p[p.Count - 1].Quantidade;
                            nova.Usuario = Sessao.usuario.Usuario;
                            nova.Data = DateTime.Now;
                            nova.Deposito = cbo_deposito.Text;
                            nova.Lado1 = cbo_lado1.Text;
                            nova.Lado2 = cbo_lado2.Text;
                            nova.Lote = txt_lote.Text;
                            if (nova.Inserir() != -1)
                            {
                                MsgBox.Show.Info("Produto inserido com sucesso!");
                                v.Limpar();
                            }
                            else
                            {
                                MsgBox.Show.Error("Erro ao adicionar produto!");
                            }
                            
                            
                        }
                        else
                        {
                            MsgBox.Show.Error("Erro ao adicionar produto!");
                        }
                    }
                    else
                    {
                        if (MsgBox.Show.Pergunta("Esse lote já existe, deseja acrescentar mais este saldo?"))
                        {

                            double quantidade_antes = 0;
                            double quantidade_depois = 0;
                            double quantidade_baixa = 0;


                            Banco.posicao_produto novo = new Banco.posicao_produto();
                            novo.Condicao = "id=" + id + "";

                            quantidade_antes = quantidade;
                            quantidade_depois= quantidade + double.Parse(txt_quantidade.Text);
                            quantidade_baixa= double.Parse(txt_quantidade.Text);

                            novo.Quantidade = quantidade + double.Parse(txt_quantidade.Text);
                            if (novo.Alterar() != -1)
                            {
                                Banco.posicao_baixa nova = new Banco.posicao_baixa();
                                nova.Id_produto = int.Parse("" + id);
                                nova.Io = "Acrescento";
                                nova.Qtd_antes = quantidade_antes;
                                nova.Qtd_baixada = quantidade_baixa;
                                nova.Qtd_depois = quantidade_depois;
                                nova.Usuario = Sessao.usuario.Usuario;
                                nova.Data = DateTime.Now;
                                nova.Deposito = cbo_deposito.Text;
                                nova.Lado1 = cbo_lado1.Text;
                                nova.Lado2 = cbo_lado2.Text;
                                nova.Lote = txt_lote.Text;
                                if (nova.Inserir() != -1)
                                {
                                    MsgBox.Show.Info("Produto inserido com sucesso!");
                                    v.Limpar();
                                }
                                else
                                {
                                    MsgBox.Show.Error("Erro ao adicionar produto!");
                                }
                            }
                            else
                            {
                                MsgBox.Show.Error("Erro ao adicionar produto!");
                            }
                        }
                    }
                }
            }
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
    }
}
