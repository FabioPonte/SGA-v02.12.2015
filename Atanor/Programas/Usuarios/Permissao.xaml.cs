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

namespace Atanor.Programas.Usuarios
{
    /// <summary>
    /// Interaction logic for Permissao.xaml
    /// </summary>
    public partial class Permissao : UserControl
    {
        public Permissao()
        {
            InitializeComponent();
            ExecuteNonSql.Retorno += new ExecuteNonSql.retorno(ExecuteNonSql_Retorno);
            ExecuteNonSql.Iniciou += new ExecuteNonSql.SQLl(ExecuteNonSql_Iniciou);
            ExecuteNonSql.Terminou += new ExecuteNonSql.SQLl(ExecuteNonSql_Terminou);
            listar();
        }

        void ExecuteNonSql_Terminou(string msg, string sql, TipoDeOperacao.Tipo tipo)
        {

           
        }

        void ExecuteNonSql_Iniciou(string msg, string sql, TipoDeOperacao.Tipo tipo)
        {
           
          
        }

        

        public string per = "21";
        public string nome = "Permissões";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/lock7.png", UriKind.RelativeOrAbsolute));

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void listar()
        {
            cbo_nome.ItemsSource = Select.SelectSQL("select * from usuarios").DefaultView;
            cbo_nome.SelectedValuePath = "id";
            cbo_nome.DisplayMemberPath = "nome";

        }

        private void cbo_nome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            agrid.Items.Clear();
            mostrar();
        }

        private void mostrar()
        {
            try {
                DataTable tabela = Select.SelectSQL("SELECT *,(select idusuario from permissao_usuario y where y.idusuario=" + cbo_nome.SelectedValue + " and y.idpermissao=x.id) marcado FROM permissao x order by 2");

                string controle = tabela.Rows[0]["modulo"] + "";

                List<Controles.PacotePermissao> pacotes = new List<Controles.PacotePermissao>();
                for (int a = 0; a < tabela.Rows.Count; a++)
                {

                    if (tabela.Rows[a]["modulo"] + "" == controle)
                    {
                        Controles.PacotePermissao novo = new Controles.PacotePermissao();
                        novo.grupo = tabela.Rows[a]["modulo"] + "";
                        novo.id = tabela.Rows[a]["id"] + "";
                        novo.nome = tabela.Rows[a]["programa"] + "";
                        string valor = tabela.Rows[a]["marcado"] + "";
                        if (valor != "")
                        { novo.marcado = true; }
                        else
                        { novo.marcado = false; }
                        pacotes.Add(novo);
                    }
                    else
                    {
                        agrid.Items.Add(new Controles.Lista() { Pacotes = pacotes });
                        controle = tabela.Rows[a]["modulo"] + "";
                        pacotes = new List<Controles.PacotePermissao>();
                        a--;
                    }
                }
                agrid.Items.Add(new Controles.Lista() { Pacotes = pacotes });
            }
            catch { }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (MsgBox.Show.Pergunta("Você quer mesmo alterar as permissões deste usuário?"))
            {
                montarsql();
            }
        }

        private void montarsql()
        {
            List<string> coluna = new List<string>();
            coluna.Add("idusuario");
            coluna.Add("idpermissao");

            List<dynamic> valores = new List<dynamic>();
            
            for (int a = 0; a < agrid.Items.Count; a++)
            {
                
                dynamic c = agrid.Items[a];
                List<Controles.PacotePermissao> ad = c.Pacotes;

                for (int b = 0; b < ad.Count; b++)
                {

                    if (ad[b].check.IsChecked == true)
                    {
                        valores.Add(cbo_nome.SelectedValue);
                        valores.Add(ad[b].id);
                    }
                }
            }

            List<dynamic> condicao = new List<dynamic>();
            condicao.Add("idusuario=" + cbo_nome.SelectedValue + "");

            ExecuteNonSql.Executar("permissao_usuario", TipoDeOperacao.Tipo.Delete, null, null, condicao);


            if (valores.Count > 0)
            {
                ExecuteNonSql.ExecutarThread("permissao_usuario", TipoDeOperacao.Tipo.InsertMultiplo, coluna, valores, null, true);
            }

            else
            {
                MsgBox.Show.Info("Alterado com êxito");
                agrid.Items.Clear();
                mostrar();
            }
        }

        void ExecuteNonSql_Retorno(int retorno)
        {
            if (retorno != -1)
            {
                agrid.Items.Clear();
                mostrar();
            }
        }
    }
}
