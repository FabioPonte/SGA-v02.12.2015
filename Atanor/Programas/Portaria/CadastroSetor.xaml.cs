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

namespace Atanor.Programas.Portaria
{
    /// <summary>
    /// Interaction logic for CadastroSetor.xaml
    /// </summary>
    public partial class CadastroSetor : UserControl, TaskMenu.Pacotes
    {

        public string per = "40";
        public string nome = "Cadastro de Setores";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/delivery18.png", UriKind.RelativeOrAbsolute));
        Facilitadores.Transferidor oid = new Facilitadores.Transferidor();
        Facilitadores.Verificador v = new Facilitadores.Verificador();
        public CadastroSetor()
        {
            InitializeComponent();
            v.Add(txt_nome, "Nome do setor não foi preenchido!");
            pacote1.Janela = this;
            Listar();
            dataGridFiltro1.Odatagrid = ogrid;
        }

        public CadastroSetor(Facilitadores.Transferidor id)
        {
            oid = id;
            InitializeComponent();
            v.Add(txt_nome, "Nome do setor não foi preenchido!");
            pacote1.Janela = this;
            Listar();
            dataGridFiltro1.Odatagrid = ogrid;
        }

        public void pacote_novo()
        {
            if (v.Analisar())
            {
                Banco.setor n = new Banco.setor();
                n.Nome = txt_nome.Text;
                int r = n.Inserir();
                if (r > 0)
                {
                    MsgBox.Show.Info("Cadastrado com sucesso!");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao realizar ação");
                }
            }
        }

        public void pacote_excluir()
        {
            if (MsgBox.Show.Pergunta("Quer mesmo deletar essa informação?"))
            {
                Banco.setor n = new Banco.setor();
                n.Condicao = "id=" + ogrid.SelectedValue + "";
                n.Nome = txt_nome.Text;
                int r = n.Excluir();
                if (r > 0)
                {
                    MsgBox.Show.Info("Excluido com sucesso!");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao realizar ação");
                }
            }
        }

        public void pacote_editar()
        {
            if (v.Analisar())
            {
                if (MsgBox.Show.Pergunta("Quer mesmo editar essa informação?"))
                {
                    Banco.setor n = new Banco.setor();
                    n.Condicao = "id=" + ogrid.SelectedValue + "";
                    n.Nome = txt_nome.Text;
                    int r = n.Alterar();
                    if (r > 0)
                    {
                        MsgBox.Show.Info("Alterado com sucesso!");
                        Listar();
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao realizar ação");
                    }
                }
            }
        }

        public void pacote_cancelar()
        {
            
        }

        private void Listar()
        {
            ogrid.ItemsSource = Banco.setor.ListarParaDataGrid();
            ogrid.SelectedValuePath = "id";
        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (oid.Combo != null)
                {
                    oid.add(ogrid.SelectedValue + "");
                    Sessao.FecharPrograma(this);
                }
            }
            catch { }


            try
            {
                Banco.setor n = Banco.setor.Obter("id=" + ogrid.SelectedValue + "")[0];
                txt_nome.Text = n.Nome;
            }
            catch { }
        }
    }
}
