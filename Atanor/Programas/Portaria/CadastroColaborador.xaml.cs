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
    /// Interaction logic for CadastroColaborador.xaml
    /// </summary>
    public partial class CadastroColaborador : UserControl, TaskMenu.Pacotes
    {

        public string per = "40";
        public string nome = "Cadastro de Colaborador";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/delivery18.png", UriKind.RelativeOrAbsolute));
        Facilitadores.Transferidor oid = new Facilitadores.Transferidor();


        public CadastroColaborador(Facilitadores.Transferidor id)
        {
            oid = id;
            InitializeComponent();
            dataGridFiltro1.Odatagrid = ogrid;
            pacote1.Janela = this;
            Listar();
        }


        public CadastroColaborador()
        {
            InitializeComponent();
            dataGridFiltro1.Odatagrid = ogrid;
            pacote1.Janela = this;
            Listar();
        }



        private Boolean verificador()
        {
            if (txt_nome.Text.Trim() == "")
            {
                MsgBox.Show.Error("Nome não foi preenchido!");
                return false;
            }
            else
            {
                if (txt_cpf.Text == "" && txt_rg.Text == "" && txt_cnpj.Text == "")
                {
                    MsgBox.Show.Error("Se faz necessário alguma documentação da pessoa.");
                    return false;
                }
            }
            return true;
        }
        private void Listar()
        {
            ogrid.ItemsSource = Banco.colaborador.ListarParaDataGrid();
            ogrid.SelectedValuePath = "id";
        }

        public void pacote_novo()
        {
            if (verificador())
            {
                Banco.colaborador novo = new Banco.colaborador();
                novo.Nome = txt_nome.Text;
                novo.Cnpj = txt_cnpj.Text;
                novo.Cpf = txt_cpf.Text;
                novo.Rg = txt_rg.Text;
                int r = novo.Inserir();
                if (r>0)
                {
                    MsgBox.Show.Info("Cadastrado com sucesso!");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao cadastrar colaborador!");
                }
            }
        }

        public void pacote_excluir()
        {
            if(MsgBox.Show.Pergunta("Quer mesmo deletar esse colaborador?"))
            {
                Banco.colaborador novo = new Banco.colaborador();
                novo.Condicao = "id=" + int.Parse(ogrid.SelectedValue + "");
                int r = novo.Excluir();
                if (r > 0)
                {
                    MsgBox.Show.Info("Excluido com sucesso!");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao excluir colaborador!");
                }
            }
        }

        public void pacote_editar()
        {
            if (verificador())
            {
                if (MsgBox.Show.Pergunta("Quer mesmo deletar esse colaborador?"))
                {
                    Banco.colaborador novo = new Banco.colaborador();
                    novo.Condicao = "id=" + int.Parse(ogrid.SelectedValue + "");
                    novo.Nome = txt_nome.Text;
                    novo.Cnpj = txt_cnpj.Text;
                    novo.Cpf = txt_cpf.Text;
                    novo.Rg = txt_rg.Text;
                    int r = novo.Alterar();
                    if (r > 0)
                    {
                        MsgBox.Show.Info("Editado com sucesso!");
                        Listar();
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao editar colaborador!");
                    }
                }
            }
        }

        public void pacote_cancelar()
        {
            txt_nome.Text = "";
            txt_cpf.Text = "";
            txt_rg.Text = "";
            txt_cnpj.Text = "";
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

            try {
                Banco.colaborador novo = Banco.colaborador.Obter("id=" + ogrid.SelectedValue + "")[0];
                txt_nome.Text = novo.Nome;
                txt_rg.Text = novo.Rg;
                txt_cpf.Text = novo.Cpf;
                txt_cnpj.Text = novo.Cnpj;
            }
            catch { }
        }
    }
}
