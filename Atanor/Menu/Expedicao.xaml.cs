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

namespace Atanor.Menu
{
    /// <summary>
    /// Interaction logic for Expedicao.xaml
    /// </summary>
    public partial class Expedicao : UserControl
    {
        public Expedicao()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {
            Sessao.MenuIniciar();
        }

        private void menuItemSGA1_Click(UserControl controle)
        {
            
               
                Sessao.AbrirPrograma(new Programas.Expedicao.Expedir(),this);

                //Sessao.AbrirPrograma(new Programas.Expedicao.Entrega(), this);
            //Sessao.AbrirPrograma(new Programas.Expedicao.ListaAtar(),this);


        }

        private void menuItemSGA2_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Expedicao.NotasExpedidas(), this);
        }

        private void menuItemSGA3_Click(UserControl controle)
        {
          //  Programas.RelatorioHTML novo = new Programas.RelatorioHTML(Programas.Expedicao.GerarRelatoriodeDivisaodeFretes.gerar());
            //novo.Show();

            //MsgBox.Show.Error("Esta opção está desabilitada!");

            Sessao.AbrirPrograma(new Programas.Expedicao.DivisaoFrete(), this);
        }

        private void menuItemSGA4_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Expedicao.informacao(), this);
        }

        private void menuItemSGA8_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Expedicao.Cfops(), this);
        }

        private void menuItemGA1_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Expedicao.Entrega(), this);
        }

        private void menuItemSGA7_Click(UserControl controle)
        {
            MsgBox.Show.Error("Ainda não implementado!");
        }

        private void menuItemSGA9_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Expedicao.CheckList(), this);
        }

        private void menuItemSGA5_Click(UserControl controle)
        {
            Sessao.AbrirPrograma(new Programas.Expedicao.ControleNotas(), this);
        }
    }
}
