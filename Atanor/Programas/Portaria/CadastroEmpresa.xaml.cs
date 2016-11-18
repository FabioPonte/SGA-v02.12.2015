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
using System.Data;
using Conector;

namespace Atanor.Programas.Portaria
{
    /// <summary>
    /// Interaction logic for CadastroEmpresa.xaml
    /// </summary>
    public partial class CadastroEmpresa : UserControl, TaskMenu.Pacotes    
    {

        Facilitadores.Transferidor oid = new Facilitadores.Transferidor();

        public string per = "40";
        public string nome = "Cadastro de Empresas";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/google_alerts-64.png", UriKind.RelativeOrAbsolute));

        Facilitadores.Verificador v = new Facilitadores.Verificador();
        
        public CadastroEmpresa()
        {
            InitializeComponent();
            v.Add(txt_nome, "O nome da empresa não foi preenchido!", true);
            v.Add(txt_cnpj, "O cnpj da empresa não foi preenchido!", true);
            dataGridFiltro1.Odatagrid = ogrid;
            Listar();
            pacote1.Janela = this;
        }


        public CadastroEmpresa(Facilitadores.Transferidor id)
        {
            oid = id;
            InitializeComponent();
            v.Add(txt_nome, "O nome da empresa não foi preenchido!", true);
            v.Add(txt_cnpj, "O cnpj da empresa não foi preenchido!", true);
            dataGridFiltro1.Odatagrid = ogrid;
            Listar();
            pacote1.Janela = this;
        }

        private void Listar()
        {
            v.Limpar();
            DataTable tabela = Select.SelectSQL("select * from empresas order by nome");
            ogrid.ItemsSource = tabela.DefaultView;
            ogrid.SelectedValuePath = "id";
        }

        public List<string> coluna = new List<string>();
        public List<dynamic> valores = new List<dynamic>();
        public List<dynamic> condicao = new List<dynamic>();

        private void ObtePreSql()
        {
            coluna.Add("nome");
            coluna.Add("cnpj");
            valores.Add(txt_nome.Text.ToUpper());
            valores.Add(txt_cnpj.Text.ToUpper());
            condicao.Add("id=" + ogrid.SelectedValue + "");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

       
        private void Deletar()
        {
            if (v.Analisar())
            {
                ObtePreSql();

                if (ExecuteNonSql.Executar("empresas", TipoDeOperacao.Tipo.Delete, coluna, valores, condicao) != -1)
                {
                    Listar();
                    MsgBox.Show.Info("Empresa deletada com sucesso!");
                }
                else
                {
                    MsgBox.Show.Error("Erro ao deletar empressa.");
                }
            }
        }

        private void Editar()
        {
            if (v.Analisar())
            {
                ObtePreSql();

                if (ExecuteNonSql.Executar("empresas", TipoDeOperacao.Tipo.Update, coluna, valores, condicao) != -1)
                {
                    Listar();
                    MsgBox.Show.Info("Empresa alterada com sucesso!");
                }
                else
                {
                    MsgBox.Show.Error("Erro ao editar empressa.");
                }
            }
        }

        private void Cadastro()
        {
            if (v.Analisar())
            {
                ObtePreSql();

                if (ExecuteNonSql.Executar("empresas", TipoDeOperacao.Tipo.Insert, coluna, valores, null) != -1)
                {
                    Listar();
                    MsgBox.Show.Info("Empresa Cadastrada com sucesso!");
                }
                else
                {
                    MsgBox.Show.Error("Erro ao incluir empressa.");
                }
            }
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
                Select.SelectDinamico(this, "select * from empresas where id=" + ogrid.SelectedValue + "");
                pacote1.ModoEdicao = true;
            }
            catch { }
        }

        private void dataGridFiltro1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void pacote_novo()
        {
            Cadastro();
        }

        public void pacote_excluir()
        {
            Deletar();
        }

        public void pacote_editar()
        {
            Editar(); 
        }

        public void pacote_cancelar()
        {
            v.Limpar();
        }
    }
}
