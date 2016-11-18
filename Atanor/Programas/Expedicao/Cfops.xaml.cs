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
using System.Data;

namespace Atanor.Programas.Expedicao
{
    /// <summary>
    /// Interaction logic for Cfops.xaml
    /// </summary>
    /// 
    public class InfoCfop
    {
        public string cfop;
        public string apelido;
        public string cor;
        public string ativo;
    }
    public partial class Cfops : UserControl, TaskMenu.Pacotes
    {

        public Facilitadores.Verificador v = new Facilitadores.Verificador();
        public string per = "24";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/packages2.png", UriKind.RelativeOrAbsolute));
        public string nome = "Controles de CFOPs";
       

        public Cfops()
        {
            InitializeComponent();
            pacote1.Janela = this;
            v.Add(txt_apelido, "Apelido não foi informado!", true);
            v.Add(txt_cfop, "O nome do Cfop não foi informado!", true);
            v.Add(txt_cor, "A cor não foi informada!", true);
            listar();
            dataGridFiltro1.Odatagrid = ogrid;
        }

        public void listar()
        {
            ogrid.ItemsSource = Select.SelectSQL("select * from cfop").DefaultView;
            ogrid.SelectedValuePath = "id";
            Sessao.AtualizarCfop();
        }

        public void pacote_novo()
        {
            if (v.Analisar())
            {

                Banco.cfop n = new Banco.cfop();
                n.Apelido = txt_apelido.Text;
                n.Cor = txt_cor.Text;
                n.Ocfop = txt_cfop.Text;
                n.Ignorar = ((Boolean)chk_ignorar.IsEnabled) ? 1 : 0;
                n.Condicao = "id=" + ogrid.SelectedValue + "";
                if (n.Inserir() != -1) { 
                    MsgBox.Show.Info("Cadastrado com sucesso!");
                    listar();
                    v.Limpar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao cadastrar");
                }
                
            }
        }

        public void pacote_excluir()
        {

            Banco.cfop n = new Banco.cfop();
            n.Condicao = "id=" + ogrid.SelectedValue + "";

            if (n.Excluir()!= -1)
                {
                    MsgBox.Show.Info("Deletado com sucesso!");
                listar();
                v.Limpar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao Deletadar");
                }

        }

        public void pacote_editar()
        {
            if (v.Analisar())
            {

                Banco.cfop n = new Banco.cfop();
                n.Apelido = txt_apelido.Text;
                n.Cor = txt_cor.Text;
                n.Ocfop = txt_cfop.Text;
                n.Ignorar = ((Boolean)chk_ignorar.IsEnabled) ? 1 : 0;
                n.Condicao = "id=" + ogrid.SelectedValue + "";
                if (n.Alterar()!=-1)
                {
                    MsgBox.Show.Info("Editado com sucesso!");
                    listar();
                    v.Limpar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao Editadar");
                }

            }
        }

        public void pacote_cancelar()
        {
            v.Limpar();
        }

      

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataTable tabela=Select.SelectSQL("select * from cfop x where x.id=" + ogrid.SelectedValue + "");
                txt_apelido.Text = tabela.Rows[0]["apelido"] + "";
                txt_cfop.Text = tabela.Rows[0]["ocfop"] + "";
                txt_cor.Text = tabela.Rows[0]["cor"] + "";
                if ((tabela.Rows[0]["ignorar"] + "") == "1")
                {
                    chk_ignorar.IsChecked = true;
                }
                else
                {
                    chk_ignorar.IsChecked = false;
                }

            }
            catch { }
        }
    }
}
