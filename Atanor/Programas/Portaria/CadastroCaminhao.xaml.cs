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

namespace Atanor.Programas.Portaria
{
    /// <summary>
    /// Interaction logic for CadastroCaminhao.xaml
    /// </summary>
    public partial class CadastroCaminhao : UserControl , TaskMenu.Pacotes
    {
        Facilitadores.Transferidor oid = new Facilitadores.Transferidor();
        Facilitadores.Verificador v = new Facilitadores.Verificador();

        public string per = "23";

        public string nome = "Cadastro de Caminhões";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/delivery18.png", UriKind.RelativeOrAbsolute));

        public CadastroCaminhao()
        {
            InitializeComponent();
            pacote1.Janela = this;
        }

        public CadastroCaminhao(Facilitadores.Transferidor id)
        {
            oid = id;
            InitializeComponent();
            pacote1.Janela = this;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void listar()
        {
            ogrid.ItemsSource = Select.SelectSQL("select * from caminhao order by placa").DefaultView;
            ogrid.SelectedValuePath = "id";

            cbo_tipo.ItemsSource = Select.SelectSQL("select * from tipo_caminhao").DefaultView;
            cbo_tipo.SelectedValuePath = "id";
            cbo_tipo.DisplayMemberPath = "nome";
        }

      

        private Boolean VerificadorDaExistenciaDoCaminhão()
        {
            try
            {
                DataTable tabela = Select.SelectSQL("select * from caminhao where placa='" + txt_placa.Text + "'");
                if (("" + tabela.Rows[0]["placa"] + "") == txt_placa.Text)
                {
                    MsgBox.Show.Error("Essa caminhão já esta cadastrado!");
                    return false;
                }
                else { return true; }

            }
            catch { return true; }
        }

        private void novo()
        {
            if (v.Analisar())
            {
                if (VerificadorDaExistenciaDoCaminhão())
                {
                    List<string> colunas = new List<string>();
                    List<dynamic> valores = new List<dynamic>();
                    List<dynamic> condicao = new List<dynamic>();

                    colunas.Add("idtipo_caminhao");
                    colunas.Add("placa");

                    valores.Add(cbo_tipo.SelectedValue);
                    valores.Add(txt_placa.Text);

                    condicao.Add("id=" + ogrid.SelectedValue + "");

                    if (ExecuteNonSql.Executar("caminhao", TipoDeOperacao.Tipo.Insert, colunas, valores, condicao) != -1)
                    {
                        MsgBox.Show.Info("Cadastro com êxito");
                        v.Limpar();
                        listar();
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao cadastrar.");
                    }
                }
            }
        }

        private void excluir()
        {
            if (v.Analisar())
            {
                List<string> colunas = new List<string>();
                List<dynamic> valores = new List<dynamic>();
                List<dynamic> condicao = new List<dynamic>();

                colunas.Add("idtipo_caminhao");
                colunas.Add("placa");

                valores.Add(cbo_tipo.SelectedValue);
                valores.Add(txt_placa.Text);

                condicao.Add("id=" + ogrid.SelectedValue + "");

                if (ExecuteNonSql.Executar("caminhao", TipoDeOperacao.Tipo.Delete, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Deletado com êxito");
                    v.Limpar();
                    listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao deletar.");
                }
            }
        }

        private void editar()
        {
            if (v.Analisar())
            {
                List<string> colunas = new List<string>();
                List<dynamic> valores = new List<dynamic>();
                List<dynamic> condicao = new List<dynamic>();

                colunas.Add("idtipo_caminhao");
                colunas.Add("placa");

                valores.Add(cbo_tipo.SelectedValue);
                valores.Add(txt_placa.Text);

                condicao.Add("id=" + ogrid.SelectedValue + "");

                if (ExecuteNonSql.Executar("caminhao", TipoDeOperacao.Tipo.Update, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Editado com êxito");
                    v.Limpar();
                    listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao editar.");
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
                pacote1.ModoEdicao = true;
                Select.SelectDinamico(this, "select * from caminhao where id=" + ogrid.SelectedValue + "");
            }
            catch { }
        }

        private void cbo_tipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                dynamic afoto = ((dynamic)Conector.Select.SelectSQL("SELECT y.foto FROM tipo_caminhao y where  Y.id=" + cbo_tipo.SelectedValue + "").Rows[0]["foto"]);
                img_foto.Source=Facilitadores.ConverterBytsEmImagens.Converter(afoto);
            }
            catch { }
        }

        

        private void produtos_Loaded(object sender, RoutedEventArgs e)
        {
            v.Add(txt_placa, "Placa não foi informada", true);
            v.Add(cbo_tipo, "Tipo não foi selecionado", true);
            listar();

            dataGridFiltro1.Odatagrid = ogrid;
        }

        public void pacote_novo()
        {
            novo();
        }

        public void pacote_excluir()
        {
            excluir();
        }

        public void pacote_editar()
        {
            editar();
        }

        public void pacote_cancelar()
        {
            v.Limpar();
        }
    }
}
