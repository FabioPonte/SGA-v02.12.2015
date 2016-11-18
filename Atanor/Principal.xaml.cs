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
using System.Windows.Media.Animation;
using System.Data;
using Conector;
using System.Windows.Threading;

namespace Atanor
{
    
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
            
            Conector.ExecuteNonSql.Retorno += new ExecuteNonSql.retorno(ExecuteNonSql_Retorno);
            this.FocusableChanged += Principal_FocusableChanged;
        }

        void Principal_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsFocused == true)
            {
                try
                {
                    Facilitadores.Flash.StopFlashingWindow(this);
                }
                catch { }
            }
        }


        


        void ExecuteNonSql_Retorno(int retorno)
        {
            if (retorno != -1)
            {
                MsgBox.Show.Info("Ação realizada com sucesso!");
            }
            else {
                MsgBox.Show.Error("Erro ao realizar ação!");
            }
        }

        DispatcherTimer temp = new DispatcherTimer();
        DispatcherTimer temp2 = new DispatcherTimer();
        public Boolean sair = true;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            
            temp.Interval = TimeSpan.FromSeconds(1);
            temp.Tick += temp_Tick;
            temp.Start();

            temp2.Interval = TimeSpan.FromSeconds(10);
            temp2.Tick += new EventHandler(temp2_Tick);
            temp2.Start();

            Sessao.JanelaPrincipal = this;
            Sessao.ogrid = ogrid;
            Sessao.menu = menu;
            Sessao.baixo = status;
            Sessao.Excel = excel;
            Sessao.taskbar = taskbar;
            Sessao.Aparece = FindResource("on") as Storyboard;
            Sessao.Desaparece = FindResource("off") as Storyboard;
            Sessao.AparecePrograma = FindResource("on1") as Storyboard;
            Sessao.DesaparecePrograma = FindResource("off1") as Storyboard;
            
            Sessao.notificar = notificacaoAlerta1;
            Sessao.fotoUsuario = img_foto;
            Sessao.EfeitoBlur = efeitoblur;
            Sessao.FecharNotificador();
            

           


            Sessao.AbrirMenu(new Menu.Modulos());

            lbl_base.Content ="Base: "+ Sessao.usuario.basededados;

            lbl_usuario.Content = Sessao.usuario.Nome;

            if (Sessao.usuario.Foto != null)
            {
                img_foto.Source = Sessao.usuario.Foto;
            }

            
        }

        int qd = 0;
        void temp2_Tick(object sender, EventArgs e)
        {
            try
            {
                DataTable Tabela = Select.SelectSQL("select * from aviso where id not in (select idaviso from aviso_recebido)");
                string id = Tabela.Rows[0]["id"] + "";
                if (Tabela.Rows.Count <= 0)
                {
                    menuCabecalho1.Qtd_legenda = ".";
                    qd = 0;
                }
                else
                {
                    if (Tabela.Rows.Count > qd)
                    {
                        menuCabecalho1.Qtd_legenda = Tabela.Rows.Count + "";

                        if (this.IsFocused == false)
                        {
                            Facilitadores.Flash.FlashWindow(this, 5);
                        }
                        Sessao.Notificar("Aviso de Recebimento!", "Empresa:" + Tabela.Rows[Tabela.Rows.Count - 1]["empresa"] + "" + Environment.NewLine + "Serviço/produtos:" + Tabela.Rows[Tabela.Rows.Count - 1]["produto"] + "" + Environment.NewLine + "Container:" + Tabela.Rows[Tabela.Rows.Count - 1]["container"] + "");
                        qd = Tabela.Rows.Count;
                    }
                    else
                    {
                        qd = Tabela.Rows.Count;
                        menuCabecalho1.Qtd_legenda = Tabela.Rows.Count + "";
                    }
                }
            }
            catch { menuCabecalho1.Qtd_legenda = ""; }
        }

        void temp_Tick(object sender, EventArgs e)
        {
            lbl_hora.Content = Facilitadores.Data.Horas();
            lbl_data.Content = Facilitadores.Data.Datas();

            if (DateTime.Now.Second == 1)
            {
                Sessao.VerificarAlarme();
            }
        }

      

        private void img_foto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Facilitadores.TrocarFotodeUsuario.Mudar();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            sair = true;
            this.Close();
            
        }

       

        public void esconde_menu()
        {
            omenu.Margin = new Thickness(-388, 159, 0, 75);
            image3.Margin = new Thickness(-221, 159, 0, 75);
            ogrid.Margin = new Thickness(12, 93, 12, 75);
        }
        public void aparece_menu()
        {
            omenu.Margin = new Thickness(8, 87, 0, 8);
            image3.Margin = new Thickness(271, 159, 0, 75);
            ogrid.Margin = new Thickness(284, 93, 12, 75);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_email_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift)
            {
                Sessao.Extrerno = true;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (Sessao.Extrerno)
            {
                Sessao.Extrerno = false;
            }
        }

       

        private void fixador_MouseLeave(object sender, MouseEventArgs e)
        {
            fixador.Fill = Facilitadores.ConverterHexaEmBrushes.Color("#FF427DAE");
        }

        private void fixador_MouseEnter(object sender, MouseEventArgs e)
        {
            fixador.Fill = Facilitadores.ConverterHexaEmBrushes.Color("#ff3C719B");
        }


        Boolean escondido = false;

        private void fixador_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!escondido)
            {
                esconde_menu();
                escondido = true;
            }
            else { aparece_menu(); escondido = false; }
        }

        private void menuCabecalho1_Click()
        {
            Facilitadores.ExportarParaExcel.Exportar();
        }

        private void menuCabecalho1_Click_1()
        {
            Sessao.AbrirNotificador();
        }

        
    }
}
