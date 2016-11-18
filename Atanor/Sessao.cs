using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Data;
using Conector;
using Hardcodet.Wpf.TaskbarNotification;
using System.Windows.Controls.Primitives;
using Atanor.Programas.Expedicao.Controles;
using Atanor.Programas.Expedicao;
using System.IO;
using System.Security.Permissions;
using System.Windows.Threading;

namespace Atanor
{
    public class Sessao
    {
        static public TaskMenu.NotificacaoAlerta notificar;
        static public Grid EfeitoBlur;
        static public System.Windows.Shapes.Rectangle FundoAlerta;
        static private Window janelaPrincipal;

        public static Window JanelaPrincipal
        {
            get { return Sessao.janelaPrincipal; }
            set { 
                Sessao.janelaPrincipal = value;
                value.StateChanged += value_StateChanged;
            }
        }

        static void value_StateChanged(object sender, EventArgs e)
        {
            if (janelaPrincipal.WindowState == WindowState.Minimized)
            {
                janelaPrincipal.ShowInTaskbar = false;
            }
            else
            {
                janelaPrincipal.ShowInTaskbar = true;
            }
        }
        static public Boolean Extrerno = false;
        static public Image fotoUsuario;
        static public SessaoUsuario usuario;
        static private Storyboard aparece, desaparece;
        static private Storyboard aparecePrograma, desaparecePrograma;
        static private UserControl controleMenu;
        static public Grid cima, menu, baixo, ogrid;
        static public StackPanel taskbar;
        static List<Programas.MemoriaPrograma> programas = new List<Programas.MemoriaPrograma>();
        static private Programas.MemoriaPrograma controlePrograma;
        static List<dynamic> exportaExcel = new List<dynamic>();
        static List<dynamic> exportaPdf = new List<dynamic>();
        static List<dynamic> exportaImpressora = new List<dynamic>();
        static List<dynamic> exportaEmail = new List<dynamic>();
        static public TaskbarIcon MyNotifyIcon;
        static public List<ListExpedicaoItem> NotasAtar;
        static public List<ListExpedicaoItem> NotasAtanor;
        static List<InfoCfop> cfopinfo = new List<InfoCfop>();


        static public void AtualizarCfop()
        {
            try { cfopinfo.Clear(); }
            catch { }
            DataTable tabela = Select.SelectSQL("select * from cfop");
            for(int a = 0; a < tabela.Rows.Count; a++)
            {
                InfoCfop n = new InfoCfop();
                n.cfop = tabela.Rows[a]["ocfop"] + "";
                n.ativo = tabela.Rows[a]["ignorar"] + "";
                n.apelido = tabela.Rows[a]["apelido"] + "";
                n.cor = tabela.Rows[a]["cor"] + "";
                cfopinfo.Add(n);
            }

        }

        static public InfoCfop ObterCfop(string cfop)
        {
            InfoCfop nulo = new InfoCfop();
            nulo.cor = "#000000";

            for (int a = 0; a < cfopinfo.Count; a++)
            {
                if (cfopinfo[a].cfop == cfop)
                {
                    return cfopinfo[a];
                }

            }
            return nulo;
        }


        static public void Notificar(string Titulo,string msg)
        {
            MsgBox.Notificacao balloon = new MsgBox.Notificacao();
            balloon.BalloonText = Titulo;
            balloon.BallonMsg = msg;
           // MyNotifyIcon.ShowBalloonTip(Titulo, msg, BalloonIcon.Info);
            MyNotifyIcon.ShowCustomBalloon(balloon, PopupAnimation.Slide, 6000);
        }

        static public void VerificarAlarme()
        {
            DataTable tabela = Select.SelectSQL("select * from alarme where idusuario=" + Sessao.usuario.Id + " and ativo=1");

            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                string id = tabela.Rows[a]["id"] + "";
                string dia = tabela.Rows[a]["dia"] + "";
                string mes = tabela.Rows[a]["mes"] + "";
                string ano = tabela.Rows[a]["ano"] + "";
                string hora = tabela.Rows[a]["hora"] + "";
                string minuto = tabela.Rows[a]["minuto"] + "";

                string unico = tabela.Rows[a]["unico"] + "";
                string diario = tabela.Rows[a]["diario"] + "";
                string semanal = tabela.Rows[a]["semanal"] + "";
                string mensal = tabela.Rows[a]["mensal"] + "";


                string diaAgora = DateTime.Now.Day + "";
                string mesAgora = DateTime.Now.Month + "";
                string anoAgora = DateTime.Now.Year + "";
                string horaAgoraa = DateTime.Now.Hour + "";
                string minutoAgora = DateTime.Now.Minute + "";

                DayOfWeek semana = (DateTime.Parse("" + dia + "/" + mes + "/" + ano + "")).DayOfWeek;
                DayOfWeek semanaAgora = DateTime.Now.DayOfWeek;

                

                if (diario == "1")
                {
                    if (hora == horaAgoraa && minuto == minutoAgora)
                    {
                        MsgBox.Show.Alarme(int.Parse(id));
                    }
                }


                if (semanal == "1")
                {
                    if (semana == semanaAgora)
                    {
                        if (hora == horaAgoraa && minuto == minutoAgora)
                        {
                            MsgBox.Show.Alarme(int.Parse(id));
                        }
                    }
                }

                if (mensal == "1")
                {
                    if (dia==diaAgora)
                    {
                        if (hora == horaAgoraa && minuto == minutoAgora)
                        {
                            MsgBox.Show.Alarme(int.Parse(id));
                        }
                    }
                }



                if ( unico== "1")
                {
                    if (diaAgora == dia && mesAgora == mes && anoAgora == ano)
                    {
                        if (hora == horaAgoraa && minuto == minutoAgora)
                        {
                            MsgBox.Show.Alarme(int.Parse(id));
                        }
                    }
                }
            }
        }

        static public void AbrirNotificador()
        {
            
            notificar.Margin=new Thickness(0,75,199,0);
            notificar.Atualizar();
        }


        static public void FecharNotificador()
        {
            
            notificar.Margin = new Thickness(0, -705, 199, 0);
        }

        static public void AtualizarNotificador()
        {
            notificar.Atualizar();
        }

        static public Menu.MenuCabecalho Excel;

        static public Boolean SouExterno(UserControl controle)
        {
            Window janela = Window.GetWindow(controle);
            Boolean externo = false;
            try
            {
                dynamic c = janela;
                externo = c.externamente;
            }
            catch { }
            return externo;
        }

        public static List<dynamic> ExportaEmail
        {
            get { return Sessao.exportaEmail;  }
            set { Sessao.exportaEmail = value;  }
        }
        public static List<dynamic> ExportaExcel
        {
            get { return Sessao.exportaExcel;  }
            set { Sessao.exportaExcel = value;  }
        }
        public static List<dynamic> ExportaPdf
        {
            get { return Sessao.exportaPdf;  }
            set { Sessao.exportaPdf = value;  }
        }
        public static List<dynamic> ExportaImpressora
        {
            get { return Sessao.exportaImpressora;  }
            set { Sessao.exportaImpressora = value;  }
        }

        static public void AddExcel(dynamic controle)
        {
            ExportaExcel.Add(controle);
            MostraBotoes();
        }

        static public void AddEmail(dynamic controle)
        {
            ExportaEmail.Add(controle);
            MostraBotoes();
        }

        static public void AddPdf(dynamic controle)
        {
            ExportaPdf.Add(controle);
            MostraBotoes();
        }

        static public void AddImpressora(dynamic controle)
        {
            ExportaImpressora.Add(controle);
            MostraBotoes();
        }

        static private void MostraBotoes()
        {
            if (exportaExcel.Count > 0) Excel.IsEnabled = true; else Excel.IsEnabled = false;
        }

        static public void ApagaBots()
        {
            exportaEmail.Clear();
            exportaExcel.Clear();
            exportaImpressora.Clear();
            exportaPdf.Clear();

            exportaExcel = new List<dynamic>();
            exportaPdf = new List<dynamic>();
            exportaImpressora = new List<dynamic>();
            exportaEmail = new List<dynamic>();
            Excel.IsEnabled = false;
            
        }

        static public void MenuIniciar()
        {
            Sessao.AbrirMenu(new Menu.Modulos());
        }

        public static Storyboard AparecePrograma
        {
            get { return Sessao.aparecePrograma; }
            set { Sessao.aparecePrograma = value; EventoAparecePrograma(); }
        }

        public static Storyboard DesaparecePrograma
        {
            get { return Sessao.desaparecePrograma; }
            set { Sessao.desaparecePrograma = value; EventoDesaparecePrograma(); }
        }

        public static Storyboard Aparece
        {
            get { return Sessao.aparece; }
            set { Sessao.aparece = value; EventoAparece(); }
        }

        public static Storyboard Desaparece
        {
            get { return Sessao.desaparece; }
            set { Sessao.desaparece = value; EventoDesaparece(); }
        }

        static private void EventoAparecePrograma()
        {
            aparecePrograma.Completed += new EventHandler(aparecePrograma_Completed);
        }

        static private void EventoDesaparecePrograma()
        {
            desaparecePrograma.Completed += new EventHandler(desaparecePrograma_Completed);
        }

        static void desaparecePrograma_Completed(object sender, EventArgs e)
        {
            try
            {
                ApagaBots();
                ogrid.Children.Clear();
                ogrid.Children.Add(controlePrograma.controle);
                MostraProgramaDespoisdoEfeito();
            }
            catch { }
        }

        

        static void aparecePrograma_Completed(object sender, EventArgs e)
        {
            
        }

        static private void EventoAparece()
        {
            aparece.Completed += new EventHandler(aparece_Completed);
        }

        static private void EventoDesaparece()
        {
            desaparece.Completed += new EventHandler(desaparece_Completed);
        }

        static void aparece_Completed(object sender, EventArgs e)
        {

        }

        static void desaparece_Completed(object sender, EventArgs e)
        {
            AbrirMenuDepoisDoEfeito();
        }
        
        static private void AbrirMenuDepoisDoEfeito()
        {
            aparece.Begin();
            controleMenu.Width = menu.Height;
            menu.Children.Clear();
            menu.Children.Add(controleMenu);
        }

        static public void AbrirMenu(UserControl controle)
        {
            desaparece.Begin();
            controleMenu = controle;
        }

        static private Programas.MemoriaPrograma VerificarExistenciaDePrograma(UserControl controle)
        {
            for (int a = 0; a < programas.Count; a++)
            {
                if (programas[a].controle.GetType() == controle.GetType())
                {
                    return programas[a];
                }
            }
            return null;
        }

        static public void AbrirProgramaExternamente(UserControl controle)
        {
            if (Facilitadores.Bloqueador.VerificarPermissao(controle))
            {
                Programas.MemoriaPrograma ocontrole = VerificarExistenciaDePrograma(controle);
                if (ocontrole == null)
                {
                    Programas.MemoriaPrograma nova = new Programas.MemoriaPrograma();
                    nova.controle = controle;
                    nova.taskmenu = CriarButtonTask(controle);
                    //programas.Add(nova);
                    new Externamente(controle).Show();
                }
                else
                {
                    try
                    {
                        dynamic varios = (ocontrole.controle);
                        if (varios.varios == true)
                        {
                            Programas.MemoriaPrograma nova = new Programas.MemoriaPrograma();
                            nova.controle = controle;
                            nova.taskmenu = CriarButtonTask(controle);
                            taskbar.Children.Add(nova.taskmenu);
                            MostarPrograma(nova);
                            programas.Add(nova);
                        }
                        else
                        {
                            MostarPrograma(ocontrole);
                        }
                    }
                    catch { MostarPrograma(ocontrole); }

                }
            }

            Extrerno = false;
        }

        static public void AbrirPrograma(UserControl controle,UserControl ProgramaPai)
        {
            if (SouExterno(ProgramaPai))
            {
                AbrirProgramaExternamente(controle);
            }
            else
            {
                if (Facilitadores.Bloqueador.VerificarPermissao(controle))
                {
                    if (Extrerno)
                    {
                        AbrirProgramaExternamente(controle);
                        return;

                    }
                    Programas.MemoriaPrograma ocontrole = VerificarExistenciaDePrograma(controle);
                    if (ocontrole == null)
                    {
                        Programas.MemoriaPrograma nova = new Programas.MemoriaPrograma();
                        nova.controle = controle;
                        nova.taskmenu = CriarButtonTask(controle);
                        taskbar.Children.Add(nova.taskmenu);
                        MostarPrograma(nova);
                        programas.Add(nova);
                    }
                    else
                    {
                        try
                        {
                            dynamic varios = (ocontrole.controle);
                            if (varios.varios == true)
                            {
                                Programas.MemoriaPrograma nova = new Programas.MemoriaPrograma();
                                nova.controle = controle;
                                nova.taskmenu = CriarButtonTask(controle);
                                taskbar.Children.Add(nova.taskmenu);
                                MostarPrograma(nova);
                                programas.Add(nova);
                            }
                            else
                            {
                                MostarPrograma(ocontrole);
                            }
                        }
                        catch { MostarPrograma(ocontrole); }

                    }
                }
            }
            
        }

        static private TaskMenu.ButtonTask CriarButtonTask(UserControl controle)
        {
            TaskMenu.ButtonTask novo = new TaskMenu.ButtonTask();
            novo.Height = 30;
            novo.Margin = new System.Windows.Thickness(0, 0, 2, 0);
            try { novo.Nome = ((dynamic)controle).nome; } catch { novo.Nome = "Nova Janela"; };
            try { novo.Icone = ((dynamic)controle).icone; } catch {  };
            novo.Controle = controle;
            novo.Click += new TaskMenu.ButtonTask.click(novo_Click);
            return novo;
        }

        static void novo_Click(TaskMenu.ButtonTask botao, UserControl programa)
        {
            for (int a = 0; a < programas.Count; a++)
            {
                TaskMenu.ButtonTask es = botao;
                if (es == programas[a].taskmenu)
                {
                    MostarPrograma(programas[a]);
                    break;
                }
            }
        }

        static private void MostarPrograma(Programas.MemoriaPrograma controle)
        {
            ApagaBots();
            controlePrograma = controle;

            
                desaparecePrograma.Begin();
            
            
        }

        static private void MostraProgramaDespoisdoEfeito()
        {
            
            AparecePrograma.Begin();
            for (int a = 0; a < programas.Count; a++)
            {
                if (programas[a].controle == controlePrograma.controle)
                {
                    programas[a].taskmenu.Marcado = true;
                }
                else
                {
                    if (programas[a].taskmenu.Marcado == true)
                    {
                        programas[a].taskmenu.Marcado = false;
                    }
                }
            }
            
            
        }

        static public void FecharPrograma(UserControl controle)
        {
            if (SouExterno(controle))
            {
                Window janela = Window.GetWindow(controle);
                janela.Close();
            }
            else
            {
                ApagaBots();
                for (int a = 0; a < programas.Count; a++)
                {
                    if (programas[a].controle == controle)
                    {
                        taskbar.Children.Remove(programas[a].taskmenu);
                        ogrid.Children.Clear();
                        programas.Remove(programas[a]);
                        break;
                    }
                }

                if (programas.Count > 0)
                {
                    MostarPrograma(programas[0]);
                }
            }
            
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        static public void Bloqueio()
        {
            DispatcherTimer temp = new DispatcherTimer();
            temp.Interval = TimeSpan.FromSeconds(1);
            temp.Tick += delegate (System.Object o, System.EventArgs e)
            {
                try
                {
                    StreamReader leitor = new StreamReader(Environment.CurrentDirectory + "\\ConfigSystem.ini");
                    string bloq = leitor.ReadLine();
                    leitor.Close();

                    if (bloq == "0")
                    {
                        
                        Environment.Exit(1);
                    }
                }
                catch(Exception ex) { }
            };
            temp.Start();
        }

       
    }

    public class SessaoUsuario
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; mostrarfoto(); }
        }
        private void mostrarfoto()
        {
            try
            {
                dynamic afoto = ((dynamic)Conector.Select.SelectSQL("select * from usuarios x where x.id=" + Id + "").Rows[0]["foto"]);

                Foto = Facilitadores.ConverterBytsEmImagens.Converter(afoto);
            }
            catch { }
        }
        public string Usuario;
        public string Nome;
        public string Email;
        BitmapImage foto;
        public string basededados;
        public string tabela;

        public BitmapImage Foto
        {
            get { return foto; }
            set { 
                foto = value;
                try
                {
                    Sessao.fotoUsuario.Source = value;
                }
                catch { }
            }
        }

    }
}
