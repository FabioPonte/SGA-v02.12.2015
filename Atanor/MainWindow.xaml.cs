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
using System.Windows.Controls.Primitives;

namespace Atanor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void autologin()
        {
            //txt_usuario.Text = "ianez";
            //xt_senha.Password = "ianezfast123";
            //cbo_base.SelectedIndex = 1;
            //Login();
        }
        public MainWindow()
        {
            Programas.MapaRelacao.Mapa x = new Programas.MapaRelacao.Mapa();
            //x.ShowDialog();
           // this.Close();
            
            
            InitializeComponent();
            Sessao.Bloqueio();
            Conector.Conexao.QuantidadeDeRequisicoes += Conexao_QuantidadeDeRequisicoes;
            Conector.Conexao.Erro += new Conexao.aviso(Conexao_Erro);
            Conector.ExecuteNonSql.Erro += new ExecuteNonSql.Aviso(Conexao_Erro);
            Conector.Select.Erro += new Select.Aviso(Conexao_Erro);
            Sessao.MyNotifyIcon = MyNotifyIcon;            
        }

        private void Conexao_QuantidadeDeRequisicoes(string msg)
        {
           
        }

        void Conexao_Erro(string msg)
        {
            try {
                Facilitadores.ErroLog.Registrar(msg);
               // MsgBox.Show.Error(msg);
            }
            catch { }
        }

        private void Janela_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_usuario.Focus();

            Sessao.JanelaPrincipal = this;
            Sessao.FundoAlerta = FundoAlerta;
            

            DataTable tabela = Arquivos.Listador.ListarConectores();
            cbo_base.ItemsSource = tabela.DefaultView;
            cbo_base.DisplayMemberPath = "nome";
            cbo_base.SelectedValuePath = "local";

            if (tabela.Rows.Count > 0)
                cbo_base.SelectedIndex = 0;
            

            autologin();
        }

        private void cbo_base_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          }


        private void Login()
        {
            if (verificador())
            {
                string us = txt_usuario.Text.Replace("-", "");
                string ps = txt_senha.Password.Replace("-", "");
                DataTable tabela = Select.SelectSQL("select * from usuarios where usuario like ('" + us + "') and senha like ('" + ps + "')");
                
                if (tabela.Rows.Count > 0)
                {
                    try
                    {
                        SessaoUsuario novo = new SessaoUsuario();
                        novo.Id = int.Parse(tabela.Rows[0]["id"] + "");
                        novo.Nome = tabela.Rows[0]["nome"] + "";
                        novo.Usuario = tabela.Rows[0]["usuario"] + "";
                        novo.Email = tabela.Rows[0]["email"] + "";
                        novo.basededados = cbo_base.Text;
                        novo.tabela = "logistica";
                        Sessao.usuario = novo;

                        this.Hide();
                        Principal janela = new Principal();
                      
                            janela.ShowDialog();
                        
                       
                        if (janela.sair == true)
                        {
                            Environment.Exit(1);
                            this.Close();
                        }
                        else
                        {
                            txt_senha.Password = "";
                            txt_usuario.Text = "";
                            this.Show();
                        }
                    }
                    catch (Exception ex) { Facilitadores.ErroLog.Registrar(ex); MsgBox.Show.Error(ex + ""); }
                }
                else
                {
                    
                    MsgBox.Show.Error("Usuário ou senha incorreto!");
                }
            }
        }

        private Boolean verificador()
        {
            if (txt_usuario.Text.Trim() == "")
            {
                MsgBox.Show.Error("Usuário não preenchido", txt_usuario);
                return false;
            }
            else
            {
                if (txt_senha.Password.Trim() == "")
                {
                    MsgBox.Show.Error("Senha não preenchida!", txt_senha);
                    return false;
                }
                else
                {
                    if (cbo_base.Text.Trim() == "" || (cbo_base.SelectedValue + "").Trim() == "")
                    {
                        MsgBox.Show.Error("Base não foi selecionada", cbo_base);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Conector.Conexao.Caminho = cbo_base.SelectedValue + "";
            }
            catch { }
            Login();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Redefinir nova = new Redefinir();
            nova.ShowDialog();
        }

        private void txt_senha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            

        }

        private void MyNotifyIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Sessao.JanelaPrincipal.WindowState == System.Windows.WindowState.Minimized)
                {
                    Sessao.JanelaPrincipal.WindowState = System.Windows.WindowState.Normal;                    
                }
            }
            catch { }
        }


       

        
    }
}
