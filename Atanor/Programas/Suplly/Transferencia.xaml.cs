using Conector;
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

namespace Atanor.Programas.Suplly
{
    /// <summary>
    /// Interaction logic for Transferencia.xaml
    /// </summary>
    public partial class Transferencia : UserControl
    {
        Facilitadores.Verificador v = new Facilitadores.Verificador();
        public Transferencia()
        {
            InitializeComponent();
            pacote1.Janela = this;
            dataGridFiltro1.Odatagrid = agrid;
            Listar();
            v.Add(cbo_para_deposito, "Depósito de destino não foi selecionado!");
            v.Add(cbo_lado1, "Lado 1 não foi selecionado!");
            v.Add(cbo_lado2, "Lado 2 não foi selecionado!");
            v.Add(cbo_produto, "Produto não foi selecionado!");
            v.Add(cbo_deposito, "Depósito de origem não foi selecionado!");
        }

        private void Listar()
        {
            agrid.ItemsSource = Select.SelectSQL("SELECT p.id id,(select nome from produtos where id=p.id_produto) produto,d.nome1 Depósito,d.nome2 Lado1,d.nome3 Lado2,p.lote Lote,p.quantidade Quantidade  FROM posicao_produto p , posicao_depositos d where p.id_posicao=d.id and quantidade >0").DefaultView;
            agrid.SelectedValuePath = "id";
            listar();
        }

        public string nome = "Transferência de Produto";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/search102.png", UriKind.RelativeOrAbsolute));
        public string per = "44";


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

                cbo_para_deposito.Text = cbo_deposito.Text;
                cbo_para_lado1.Text = cbo_lado1.Text;
                cbo_para_lado2.Text = cbo_lado2.Text;
                cbo_para_produto.Text = cbo_produto.Text;
                cbo_para_lote.Text = txt_lote.Text;
            }
            catch { }
        }

        public void pacote_novo()
        {

            try
            {

                if (v.Analisar())
                {
                    int qtd = 0;
                    int max = 0;
                    try
                    {
                        qtd = int.Parse(txt_quantidade.Text + "");
                    }
                    catch { MsgBox.Show.Error("Volume a ser transferido é inválido!"); return;}
                    try
                    {
                        max = int.Parse(txt_max.Text + "");
                    }
                    catch { MsgBox.Show.Error("Volume original não é válido!"); return; }

                    if (qtd > max){MsgBox.Show.Error("A quantidade a ser transferida é maior do que o saldo existente."); return; }
                    if (qtd <= 0) { MsgBox.Show.Error("A quantidade a ser transferida é inválida");return; }
                    if (max <= 0) { MsgBox.Show.Error("A quantidade em estoque não pode ser transferida."); return; }

                    if(qtd>0 && qtd <= max)
                    {

                        List<Banco.posicao_produto> novo = Banco.posicao_produto.Obter("id=" + agrid.SelectedValue + "");
                        if (novo.Count > 0)
                        {
                            #region Saida do produto
                            int idprod = novo[0].Id_produto;
                            novo[0].Quantidade = max - qtd;
                            if (novo[0].Alterar()!=-1)
                            {
                                Banco.posicao_baixa baixa = new Banco.posicao_baixa();
                                baixa.Id_produto = Banco.posicao_produto.Obter("id=" + agrid.SelectedValue + "")[0].Id_produto;
                                baixa.Qtd_baixada = qtd;
                                baixa.Qtd_antes = max;
                                baixa.Qtd_depois= max - qtd;
                                baixa.Io = "Transf.Saída";
                                baixa.Usuario = Sessao.usuario.Nome;
                                baixa.Data = DateTime.Now;
                                baixa.Deposito = cbo_deposito.Text;
                                baixa.Lado1 = cbo_lado1.Text;
                                baixa.Lado2 = cbo_lado2.Text;
                                baixa.Lote = txt_lote.Text;
                                if (baixa.Inserir() == -1)
                                {
                                    MsgBox.Show.Error("Erro ao cadastrar auditoria na saída!");
                                    return;
                                }
                            }
                            else
                            {
                                MsgBox.Show.Error("Erro ao debitar produto!");
                                return;
                            }
                            #endregion
                            #region Entrada do produto
                            List<Banco.posicao_produto> para = Banco.posicao_produto.Obter("id_posicao=" + cbo_para_lado2.SelectedValue + " and id_produto=" + idprod + "");
                            #region se o lote já existe na nova posição
                            if (para.Count > 0)
                            {
                                double antes = para[0].Quantidade;
                                para[0].Quantidade = para[0].Quantidade + qtd;
                                if (para[0].Alterar()!=-1)
                                {
                                    Banco.posicao_baixa baixa = new Banco.posicao_baixa();
                                    baixa.Id_produto = idprod;
                                    baixa.Qtd_baixada = qtd;
                                    baixa.Qtd_antes = antes;
                                    baixa.Qtd_depois = antes + qtd;
                                    baixa.Io = "Transf.Entrada";
                                    baixa.Usuario = Sessao.usuario.Nome;
                                    baixa.Data = DateTime.Now;
                                    baixa.Deposito = cbo_para_deposito.Text;
                                    baixa.Lado1 = cbo_para_lado1.Text;
                                    baixa.Lado2 = cbo_para_lado2.Text;
                                    baixa.Lote = txt_lote.Text;
                                    if (baixa.Inserir() == -1)
                                    {
                                        MsgBox.Show.Error("Erro ao cadastrar auditoria na entrada existente!");
                                        return;
                                    }
                                }
                                else
                                {
                                    MsgBox.Show.Error("Erro ao creditar produto");
                                    return;
                                }
                            }
                            #endregion
                            #region se o lote não existe na posição
                            else
                            {
                                Banco.posicao_produto inc = new Banco.posicao_produto();
                                inc.Id_posicao = int.Parse(cbo_para_lado2.SelectedValue + "");
                                inc.Id_produto = idprod;
                                inc.Lote = txt_lote.Text;
                                inc.Quantidade = qtd;
                                if (inc.Inserir() != -1)
                                {
                                    Banco.posicao_baixa baixa = new Banco.posicao_baixa();
                                    baixa.Id_produto = idprod;
                                    baixa.Qtd_baixada = qtd;
                                    baixa.Qtd_antes = 0;
                                    baixa.Qtd_depois = qtd;
                                    baixa.Usuario = Sessao.usuario.Nome;
                                    baixa.Io = "Transf.Entrada";
                                    baixa.Data = DateTime.Now;
                                    baixa.Deposito = cbo_para_deposito.Text;
                                    baixa.Lado1 = cbo_para_lado1.Text;
                                    baixa.Lado2 = cbo_para_lado2.Text;
                                    baixa.Lote = txt_lote.Text;
                                    if (baixa.Inserir() == -1)
                                    {
                                        MsgBox.Show.Error("Erro ao cadastrar auditoria na nova entrada!");
                                        return;
                                    }
                                }
                                else
                                {
                                    MsgBox.Show.Error("Erro ao creditar novo produto.");
                                    return;
                                }
                            }
                            #endregion
                            #endregion
                        }
                    }
                    MsgBox.Show.Info("Produto transferido com sucesso!");
                    v.Limpar();
                    Listar();
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

      

        private void mapa2_Click(double x, double y)
        {

        }


        private void listar()
        {
            cbo_para_deposito.ItemsSource = Select.SelectSQL("select distinct nome1 from posicao_depositos").DefaultView;
            cbo_para_deposito.DisplayMemberPath = "nome1";
            cbo_para_deposito.SelectedValuePath = "nome1";
        }

        private void cbo_para_deposito_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
             
                cbo_para_lado1.ItemsSource = Select.SelectSQL("select distinct nome2 from posicao_depositos where nome1='" + cbo_para_deposito.SelectedValue + "'").DefaultView;
                cbo_para_lado1.DisplayMemberPath = "nome2";
                cbo_para_lado1.SelectedValuePath = "nome2";
            }
            catch { }

        }

        private void cbo_para_lado1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
              
                string sql = "select distinct nome3,id from posicao_depositos where nome1='" + cbo_para_deposito.SelectedValue + "' and nome2='" + cbo_para_lado1.SelectedValue + "'";
                cbo_para_lado2.ItemsSource = Select.SelectSQL(sql).DefaultView;
                cbo_para_lado2.DisplayMemberPath = "nome3";
                cbo_para_lado2.SelectedValuePath = "id";
            }
            catch(Exception ex) { MsgBox.Show.Error(ex+""); }

        }

       
      
        private void cbo_para_lado2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbo_para_lado2.SelectedValue == null) return;
                string sql = "select distinct x px,y py from posicao_depositos where id=" + cbo_para_lado2.SelectedValue + "";
                Select.SelectDinamico(this, sql);

                mapa2.Limpar();
                mapa2.LimparSeta();

                Point novo = new Point();
                novo.X = double.Parse(txt_para_x.Text);
                novo.Y = double.Parse(txt_para_y.Text);
                mapa2.Add(novo);
            }
            catch { }
        }
    }
}
