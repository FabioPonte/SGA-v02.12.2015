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
    /// Interaction logic for CadastroMotorista.xaml
    /// </summary>
    public partial class CadastroMotorista : UserControl
    {

        Facilitadores.Transferidor oid = new Facilitadores.Transferidor();

        public string per = "22";

        public string nome = "Cadastro de Motoristas";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/car186.png", UriKind.RelativeOrAbsolute));

        public CadastroMotorista()
        {
            InitializeComponent();
        }

        public CadastroMotorista(Facilitadores.Transferidor id)
        {
            oid = id;
            InitializeComponent();
        }

        Facilitadores.Verificador v = new Facilitadores.Verificador();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private Boolean VerificarExistenciaDeMotorista()
        {
            try
            {
                DataTable ver = Select.SelectSQL("select * from motorista where cnh='" + txt_cnh.Text + "'");
                string id = ver.Rows[0]["cnh"] + "";
                if (id != "")
                {
                    MsgBox.Show.Error("O motorista " + ver.Rows[0]["nome"] + " já esta cadastrado com o cnh " + ver.Rows[0]["cnh"] + "");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch { return true; }
        }

        private void produtos_Loaded(object sender, RoutedEventArgs e)
        {
            v.Add(txt_nome, "Nome não foi preenchido", true);
            v.Add(txt_cnh, "CNH não foi preenchido", true);
            v.Add(txt_cpf, "CPF não foi preenchido", true);
            listar();
            dataGridFiltro1.Odatagrid = ogrid;
        }

        private void listar()
        {
            ogrid.ItemsSource = Select.SelectSQL("select * from motorista order by nome").DefaultView;
            ogrid.SelectedValuePath = "id";
        }

        private void pacote1_Click(ThemaMeritor.TipoEvento.evento tipo)
        {
            if (tipo == ThemaMeritor.TipoEvento.evento.Cancelar)
            {
                v.Limpar();
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Editar)
            {
                editar();
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Excluir)
            {
                excluir();
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Novo)
            {
                novo();
            }
        }

        private void editar()
        {
            if (v.Analisar())
            {
                
                    List<string> colunas = new List<string>();
                    List<dynamic> valores = new List<dynamic>();
                    List<string> condicao = new List<string>();

                    colunas.Add("nome");
                    colunas.Add("cnh");
                    colunas.Add("cpf");
                    colunas.Add("vencimento");

                    valores.Add(txt_nome.Text);
                    valores.Add(txt_cnh.Text);
                    valores.Add(txt_cpf.Text);
                    valores.Add(dt_data.DisplayDate);

                    condicao.Add("id=" + ogrid.SelectedValue + "");

                    if (ExecuteNonSql.Executar("motorista", TipoDeOperacao.Tipo.Update, colunas, valores, condicao) != -1)
                    {
                        MsgBox.Show.Info("Editado com êxito");
                        v.Limpar();
                        listar();
                        pacote1.ModoEdicao = false;
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao editar!");
                    }
                }
           
        }

        private void excluir()
        {
            if (v.Analisar())
            {
                
                    List<string> colunas = new List<string>();
                    List<dynamic> valores = new List<dynamic>();
                    List<string> condicao = new List<string>();

                    colunas.Add("nome");
                    colunas.Add("cnh");
                    colunas.Add("cpf");
                    colunas.Add("vencimento");

                    valores.Add(txt_nome.Text);
                    valores.Add(txt_cnh.Text);
                    valores.Add(txt_cpf.Text);
                    valores.Add(dt_data.DisplayDate);

                    condicao.Add("id=" + ogrid.SelectedValue + "");

                    if (ExecuteNonSql.Executar("motorista", TipoDeOperacao.Tipo.Delete, colunas, valores, condicao) != -1)
                    {
                        MsgBox.Show.Info("Excluido com êxito");
                        v.Limpar();
                        listar();
                        pacote1.ModoEdicao = false;
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao excluir!");
                    }
                
            }
        }

        private void novo()
        {
            if (v.Analisar())
            {
                if (VerificarExistenciaDeMotorista())
                {

                    List<string> colunas = new List<string>();
                    List<dynamic> valores = new List<dynamic>();
                    List<string> condicao = new List<string>();

                    colunas.Add("nome");
                    colunas.Add("cnh");
                    colunas.Add("cpf");
                    colunas.Add("vencimento");

                    valores.Add(txt_nome.Text);
                    valores.Add(txt_cnh.Text);
                    valores.Add(txt_cpf.Text);
                    valores.Add(dt_data.DisplayDate);

                    condicao.Add("id=" + ogrid.SelectedValue + "");

                    if (ExecuteNonSql.Executar("motorista", TipoDeOperacao.Tipo.Insert, colunas, valores, null) != -1)
                    {
                        MsgBox.Show.Info("Cadastrado com êxito");
                        v.Limpar();
                        listar();
                        pacote1.ModoEdicao = false;
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao cadastrar!");
                    }
                }
            }
        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pacote1.ModoEdicao = true;
            try
            {
                if (oid.combo != null)
                {
                    oid.add(ogrid.SelectedValue + "");
                    Sessao.FecharPrograma(this);
                }
            }
            catch { }

            try
            {
                Select.SelectDinamico(this, "select * from motorista where id=" + ogrid.SelectedValue + "");
            }
            catch { }
        }
    }
}
