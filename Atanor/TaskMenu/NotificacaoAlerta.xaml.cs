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

namespace Atanor.TaskMenu
{
    /// <summary>
    /// Interaction logic for NotificacaoAlerta.xaml
    /// </summary>
    public partial class NotificacaoAlerta : UserControl
    {
        public NotificacaoAlerta()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void Atualizar()
        {
            try
            {
                painel.Children.Clear();
            }
            catch { }
            DataTable Tabela = new DataTable();
            Tabela = Select.SelectSQL("select * from aviso where id not in (select idaviso from aviso_recebido)");
            if (Tabela.Rows.Count <= 0)
            {
                lbl_info.Content = "Não existe notificações!";
            }
            else
            {
                lbl_info.Content = "Você tem "+Tabela.Rows.Count+" notificações!";
            }

            for (int a = 0; a < Tabela.Rows.Count; a++)
            {
                TaskMenu.NotificationTab tab = new NotificationTab();
                tab.Id = Tabela.Rows[a]["id"] + "";
                tab.Empresa = Tabela.Rows[a]["empresa"] + "";
                tab.Servico = Tabela.Rows[a]["produto"] + "";
                tab.Placa = Tabela.Rows[a]["placa"] + "";
                tab.Motorista = Tabela.Rows[a]["motorista"] + "";
                tab.Nota = Tabela.Rows[a]["nota"] + "";
                tab.Data = Tabela.Rows[a]["data"] + "";
                tab.Container= Tabela.Rows[a]["container"] + "";
                DateTime inicio = DateTime.Parse(Tabela.Rows[a]["data"] + "");
                DateTime fim = DateTime.Now;
                double d = (fim - inicio).TotalMinutes;
                tab.Espera = "" + Math.Round(d,1) + " Minutos";

                tab.Margin = new Thickness(0, 1, 0, 0);
                tab.Height = 256;
                painel.Children.Add(tab);
            }
        }

        private void sair1_Click()
        {
            Sessao.FecharNotificador();
        }
    }
}
