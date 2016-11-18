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
namespace Atanor.Programas.Usuarios
{
    /// <summary>
    /// Interaction logic for TipoUsuario.xaml
    /// </summary>
    public partial class TipoUsuario : UserControl
    {
        public TipoUsuario()
        {
            InitializeComponent();
        }

        public string per = "20";
        public string nome = "Tipos de Usuários";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/man343.png", UriKind.RelativeOrAbsolute));


        Facilitadores.Verificador v = new Facilitadores.Verificador();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            v.Add(txt_nome, "Tipo do usuário não preenchido", true);
            listar();
        }

        private void listar()
        {
            ogrid.ItemsSource = Select.SelectSQL("select * from tipousuario").DefaultView;
            ogrid.SelectedValuePath = "id";
        }

        private void pacote1_Click(ThemaMeritor.TipoEvento.evento tipo)
        {
            if (tipo == ThemaMeritor.TipoEvento.evento.Novo)
            {
                cadastro();
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Editar)
            {
                editar();
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Excluir)
            {
                excluir();
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Cancelar)
            {
                v.Limpar();
            }
        }

        private void excluir()
        {
            if (v.Analisar())
            {
                List<string> colunas = new List<string>();
                colunas.Add("tipo");
                List<dynamic> valores = new List<dynamic>();
                valores.Add(txt_nome.Text);
                List<dynamic> condicao = new List<dynamic>();
                condicao.Add("id="+ogrid.SelectedValue + "");
                if (ExecuteNonSql.Executar("tipousuario", TipoDeOperacao.Tipo.Delete, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Deletado com êxito!");
                    v.Limpar();
                    listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao deletar!");
                }
            }
        }

        private void editar()
        {
            if (v.Analisar())
            {
                List<string> colunas = new List<string>();
                colunas.Add("tipo");
                List<dynamic> valores = new List<dynamic>();
                valores.Add(txt_nome.Text);
                List<dynamic> condicao = new List<dynamic>();
                condicao.Add("id="+ogrid.SelectedValue + "");
                if (ExecuteNonSql.Executar("tipousuario", TipoDeOperacao.Tipo.Update, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("editado com êxito!");
                    v.Limpar();
                    listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao editar!");
                }
            }
        }

        private void cadastro()
        {
            if (v.Analisar())
            {
                List<string> colunas = new List<string>();
                colunas.Add("tipo");
                List<dynamic> valores = new List<dynamic>();
                valores.Add(txt_nome.Text);
                List<string> condicao = new List<string>();
                condicao.Add(ogrid.SelectedValue+"");
                if (ExecuteNonSql.Executar("tipousuario", TipoDeOperacao.Tipo.Insert, colunas, valores, null) != -1)
                {
                    MsgBox.Show.Info("Cadastrado com êxito!");
                    v.Limpar();
                    listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao cadastrar!");
                }
            }
        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                pacote1.ModoEdicao = true;
                Select.SelectDinamico(this, "select * from tipousuario x where x.id=" + ogrid.SelectedValue + "");
            }
            catch { }
        }
    }
}
