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
    /// Interaction logic for CadastroItemIO.xaml
    /// </summary>
    public partial class CadastroItemIO : UserControl, TaskMenu.Pacotes
    {

        public string per = "40";
        public string nome = "Cadastro de Itens";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/delivery18.png", UriKind.RelativeOrAbsolute));
        Facilitadores.Transferidor oid = new Facilitadores.Transferidor();
        Facilitadores.Verificador v = new Facilitadores.Verificador();

        public CadastroItemIO()
        {
            InitializeComponent();
            pacote1.Janela = this;
            dataGridFiltro1.Odatagrid = ogrid;
            Listar();
            v.Add(txt_nome, "O nome do item não foi cadastrado");
        }

        public CadastroItemIO(Facilitadores.Transferidor id)
        {
            oid = id;
            InitializeComponent();
            pacote1.Janela = this;
            dataGridFiltro1.Odatagrid = ogrid;
            Listar();
            v.Add(txt_nome, "O nome do item não foi cadastrado");
        }

        private void Listar()
        {
            ogrid.ItemsSource = Banco.itens_io.ListarParaDataGrid();
            ogrid.SelectedValuePath = "id";
        }

        public void pacote_novo()
        {
            if (v.Analisar())
            {
                Banco.itens_io n = new Banco.itens_io();
               // n.Condicao = "id=" + ogrid.SelectedValue + "";
                n.Nome = txt_nome.Text;
                n.Fabricante = txt_fabricante.Text;
                n.Marca = txt_marca.Text;
                if (n.Inserir() > 0)
                {
                    MsgBox.Show.Info("Ação realizado com sucesso!");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao realizar ação.");
                }
            }
        }

        public void pacote_excluir()
        {
            if (MsgBox.Show.Pergunta("Você quer mesmo excluir essa informação?"))
            {
                Banco.itens_io n = new Banco.itens_io();
                n.Condicao = "id=" + ogrid.SelectedValue + "";
                n.Nome = txt_nome.Text;
                n.Fabricante = txt_fabricante.Text;
                n.Marca = txt_marca.Text;
                if (n.Excluir() > 0)
                {
                    MsgBox.Show.Info("Ação realizado com sucesso!");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao realizar ação.");
                }
            }
        }

        public void pacote_editar()
        {
            if (v.Analisar())
            {
                if (MsgBox.Show.Pergunta("Você quer mesmo editar essa informação?"))
                {
                    Banco.itens_io n = new Banco.itens_io();
                    n.Condicao = "id=" + ogrid.SelectedValue + "";
                    n.Nome = txt_nome.Text;
                    n.Fabricante = txt_fabricante.Text;
                    n.Marca = txt_marca.Text;
                    if (n.Alterar() > 0)
                    {
                        MsgBox.Show.Info("Ação realizado com sucesso!");
                        Listar();
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao realizar ação.");
                    }
                }
            }
        }

        public void pacote_cancelar()
        {
            
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
                Banco.itens_io n = Banco.itens_io.Obter("id=" + ogrid.SelectedValue + "")[0];
                txt_fabricante.Text = n.Fabricante;
                txt_marca.Text = n.Marca;
                txt_nome.Text = n.Nome;
            }
            catch { }
        }
    }
}
