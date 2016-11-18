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
    public partial class Cadastro : UserControl
    {
        public Cadastro()
        {
            InitializeComponent();
            pacote1.Janela = this;
            pacote1.GridBase = ogrid;
        }

        public string per = "19";
        public string nome = "Cadastro de Usuários";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/add199.png", UriKind.RelativeOrAbsolute));
        Facilitadores.Verificador v = new Facilitadores.Verificador();

       

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridFiltro1.Odatagrid = ogrid;
            v.Add(txt_id, "", false);
            v.Add(txt_nome, "O campo nome não foi preenchido", true);
            v.Add(txt_senha, "O campo senha não foi preenchido", true);
            v.Add(txt_confimacao, "O campo confirmação de senha não foi preenchido", true);
            v.Add(txt_email, "O Campo e-mail não foi preenchido", true);
            v.Add(txt_usuario, "O nome do usuário não foi preenchido", true);
            v.Add(lsl_tipos, "O tipo de usuário não foi escolhido", true);
            listar();
            
        }

      

        private void listar()
        {
            lsl_tipos.ItemsSource = Select.SelectSQL("select * from tipousuario").DefaultView;
            lsl_tipos.SelectedValuePath = "id";
            lsl_tipos.DisplayMemberPath = "Tipo";

            ogrid.ItemsSource = Select.SelectSQL("SELECT id ID,usuario 'Usuário',nome Nome,email 'E-mail',(select Tipo from tipousuario x where x.id=y.IdTipoUsuario) Tipo FROM usuarios y;").DefaultView;
            ogrid.SelectedValuePath = "ID";
        }

        private void novo()
        {
            if (v.Analisar())
            {
                if (txt_senha.Password == txt_confimacao.Password)
                {
                    List<string> colunas = new List<string>();
                    colunas.Add("IdTipoUsuario");
                    colunas.Add("usuario");
                    colunas.Add("senha");
                    colunas.Add("nome");
                    colunas.Add("email");

                    List<dynamic> valores = new List<dynamic>();
                    valores.Add(lsl_tipos.SelectedValue);
                    valores.Add(txt_usuario.Text);
                    valores.Add(txt_senha.Password);
                    valores.Add(txt_nome.Text);
                    valores.Add(txt_email.Text);

                    if (ExecuteNonSql.Executar("usuarios", TipoDeOperacao.Tipo.Insert, colunas, valores, null) != -1)
                    {
                        MsgBox.Show.Info("Usuário cadastrado com êxito");
                        v.Limpar();
                        listar();
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao cadastrar usuário");
                    }
                }
                else
                {
                    MsgBox.Show.Error("Senha não é igual a confirmação de senha.");
                }

            }
        }


        private void excluir()
        {

            if (Facilitadores.ObterPermissao.Obter(this))
            {
                List<dynamic> condicao = new List<dynamic>();
                condicao.Add("id=" + ogrid.SelectedValue + "");

                if (ExecuteNonSql.Executar("usuarios", TipoDeOperacao.Tipo.Delete, null, null, condicao) != -1)
                {
                    MsgBox.Show.Info("Usuário excluido com êxito");
                    v.Limpar();
                    listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao excluido usuário");
                }
            }
        
        }

        private void editar()
        {
            if (v.Analisar())
            {
                if (txt_senha.Password == txt_confimacao.Password)
                {
                    List<string> colunas = new List<string>();
                    colunas.Add("IdTipoUsuario");
                    colunas.Add("usuario");
                    colunas.Add("senha");
                    colunas.Add("nome");
                    colunas.Add("email");

                    List<dynamic> valores = new List<dynamic>();
                    valores.Add(lsl_tipos.SelectedValue);
                    valores.Add(txt_usuario.Text);
                    valores.Add(txt_senha.Password);
                    valores.Add(txt_nome.Text);
                    valores.Add(txt_email.Text);

                    List<dynamic> condicao = new List<dynamic>();
                    condicao.Add("id=" + ogrid.SelectedValue + "");

                    if (ExecuteNonSql.Executar("usuarios", TipoDeOperacao.Tipo.Update, colunas, valores,condicao) != -1)
                    {
                        MsgBox.Show.Info("Usuário editador com êxito");
                        v.Limpar();
                        listar();
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao editar usuário");
                    }
                }
                else
                {
                    MsgBox.Show.Error("Senha não é igual a confirmação de senha.");
                }

            }
            

        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Select.SelectDinamico(this, "select * from usuarios where id=" + ogrid.SelectedValue + "");
                pacote1.ModoEdicao = true;
            }
            catch { }
        }

        private void pacote1_Click(TaskMenu.PacoteManutencao.Tipo tipo)
        {
            if (tipo == TaskMenu.PacoteManutencao.Tipo.Cancelar)
            {
                v.Limpar();
            }
            if (tipo == TaskMenu.PacoteManutencao.Tipo.Editar)
            {
                editar();
            }
            if (tipo == TaskMenu.PacoteManutencao.Tipo.Excluir)
            {
                excluir();
            }
            if (tipo == TaskMenu.PacoteManutencao.Tipo.Novo)
            {
                novo();
            }    
        }
    }
}
