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
using System.Windows.Shapes;
using Conector;
using System.Data;
namespace Atanor
{
    /// <summary>
    /// Interaction logic for Redefinir.xaml
    /// </summary>
    public partial class Redefinir : Window
    {
        string id = "";
        List<string> colunas = new List<string>();
        List<dynamic> valores = new List<dynamic>();
        List<dynamic> condicao = new List<dynamic>();

        public Redefinir()
        {
            InitializeComponent();
        }
        private void OberSql()
        {
            colunas.Add("senha");
            colunas.Add("email");
            valores.Add(txt_confirmacao.Password);
            valores.Add(txt_email.Text);
            condicao.Add("id=" + id + "");
        }
        
        
        private Boolean Verificar()
        {
            DataTable tabela = Select.SelectSQL("select * from usuarios where usuario='" + txt_usuario.Text + "' and senha='" + txt_senha.Password + "'");
            try
            {
                string nome = tabela.Rows[0]["nome"] + "";
                if (nome != null)
                {
                    if (txt_nova.Password.Trim() == "" || txt_nova.Password.Length < 5)
                    {
                        MsgBox.Show.Error("Nova senha Inválida ou menor do que 5 caracteres!");
                        return false;
                    }
                    if (txt_nova.Password != txt_confirmacao.Password)
                    {
                        MsgBox.Show.Error("Nova senha não confere!");
                        return false;
                    }
                    string email = txt_email.Text.Trim();
                    int arroba = txt_email.Text.IndexOf("@");
                    int com = txt_email.Text.IndexOf(".com");
                    if (email == "" || arroba == -1 || com == -1)
                    {
                        MsgBox.Show.Error("E-mail Inválido!");
                        return false;
                    }
                }
                id = tabela.Rows[0]["id"] + "";
                return true;
            }
            catch { MsgBox.Show.Error("Usuário ou Senha Incorreta!"); return false; }
        }
        private void Cadastrar()
        {
            if (Verificar())
            {
                OberSql();
                if (ExecuteNonSql.Executar("usuarios", TipoDeOperacao.Tipo.Update, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Senha alterada com sucesso!");
                    this.Close();
                }
                else
                {
                    MsgBox.Show.Error("Não foi possivel alterar senha!");
                }
            }
        }

        private void btn_alterar_Click(object sender, RoutedEventArgs e)
        {
            Cadastrar();
        }
        
    }
}
