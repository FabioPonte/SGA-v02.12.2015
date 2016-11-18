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
    /// Interaction logic for AvisoRecebimento.xaml
    /// </summary>
    public partial class AvisoRecebimento : UserControl
    {

        Facilitadores.Transferidor empresa = new Facilitadores.Transferidor();
        Facilitadores.Transferidor placa = new Facilitadores.Transferidor();
        Facilitadores.Transferidor responsavel = new Facilitadores.Transferidor();
        Facilitadores.Verificador v = new Facilitadores.Verificador();

        public string per = "40";

        public string nome = "Aviso de Recebimento";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/google_alerts-64.png", UriKind.RelativeOrAbsolute));


        public AvisoRecebimento()
        {
            InitializeComponent();
            empresa.Combo = cbo_empresa;
            empresa.controle = this;
            empresa.Retorno += new Facilitadores.Transferidor.retorno(empresa_Retorno);

            placa.Combo = cbo_placa;
            placa.controle = this;
            placa.Retorno += new Facilitadores.Transferidor.retorno(placa_Retorno);

            responsavel.Combo = cbo_motorista;
            responsavel.controle = this;
            responsavel.Retorno += new Facilitadores.Transferidor.retorno(responsavel_Retorno);
            Listar();

            v.Add(cbo_empresa, "Empresa não foi selecionada.", true);
            v.Add(cbo_motorista, "Motorista não foi selecionado.", true);
            v.Add(cbo_placa, "Automovel não foi selecionado.", true);
            v.Add(cbo_servico, "Produto/Serviço não foi selecionado.", false);
            v.Add(txt_cnh, "", false);
            v.Add(txt_cpf, "", false);
            v.Add(txt_nota, "Nota Fiscal não foi informada", true);
            v.Add(txt_conteiner, "", false);

            
        }

        void responsavel_Retorno()
        {
            DataTable tabela = Select.SelectSQL("select * from motorista");
            cbo_motorista.ItemsSource = tabela.DefaultView;
            cbo_motorista.DisplayMemberPath = "nome";
            cbo_motorista.SelectedValuePath = "id";
        }

        void placa_Retorno()
        {
            DataTable tabela = Select.SelectSQL("select * from caminhao");
            cbo_placa.ItemsSource = tabela.DefaultView;
            cbo_placa.DisplayMemberPath = "placa";
            cbo_placa.SelectedValuePath = "id";
        }

        private void listarServicos()
        {
            cbo_servico.ItemsSource = Banco.servicos.ListarParaDataGrid();
            cbo_servico.DisplayMemberPath = "nome";
            cbo_servico.SelectedValuePath = "nome";
        }
        private void Listar()
        {
            listarServicos();
            empresa_Retorno();
            placa_Retorno();
            responsavel_Retorno();
            v.Limpar();
        }

        void empresa_Retorno()
        {
            DataTable tabela = Select.SelectSQL("select * from empresas");
            cbo_empresa.ItemsSource = tabela.DefaultView;
            cbo_empresa.DisplayMemberPath = "nome";
            cbo_empresa.SelectedValuePath = "id";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Portaria.CadastroEmpresa(empresa), this);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Portaria.CadastroCaminhao(placa), this);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Portaria.CadastroMotorista(responsavel), this);
        }

        private void cbo_motorista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Select.SelectDinamico(this, "select * from motorista where id=" + cbo_motorista.SelectedValue + "");
            }
            catch { }
        }

        private void btn_cadastro_aviso_Click(object sender, RoutedEventArgs e)
        {
            if (v.Analisar())
            {
                List<string> coluna = new List<string>();
                coluna.Add("empresa");
                coluna.Add("produto");
                coluna.Add("placa");
                coluna.Add("motorista");
                coluna.Add("nota");
                coluna.Add("idmotorista");
                coluna.Add("data");
                coluna.Add("container");

                List<dynamic> valores = new List<dynamic>();
                valores.Add(cbo_empresa.Text);
                valores.Add(cbo_servico.Text);
                valores.Add(cbo_placa.Text);
                valores.Add(cbo_motorista.Text);
                valores.Add(txt_nota.Text);
                valores.Add(cbo_motorista.SelectedValue);
                valores.Add(Facilitadores.ConverterDataParaDataDoMysql.Converter(DateTime.Now));
                valores.Add(txt_conteiner.Text);

                if (ExecuteNonSql.Executar("aviso", TipoDeOperacao.Tipo.Insert, coluna, valores, null) != -1)
                {
                    MsgBox.Show.Info("Aviso cadastrado com sucesso!");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao Cadastrar Aviso!");
                }

                try
                {
                    Banco.servicos n = new Banco.servicos();
                    n.Nome = cbo_servico.Text;
                    n.Inserir();
                }
                catch { }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            empresa_Retorno();
        }

        private void button1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            placa_Retorno();
        }
    }
}
