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

namespace Atanor.Programas.Expedicao
{
    /// <summary>
    /// Interaction logic for DesconsiderarNota.xaml
    /// </summary>
    public partial class DesconsiderarNota : UserControl
    {

        public string per = "24";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/packages2.png", UriKind.RelativeOrAbsolute));
        public string nome = "Desconsiderar Notas.";
        string Nota = "";
        
        public DesconsiderarNota(string nota)
        {
            Nota = nota;
            InitializeComponent();
            lbl_nota.Content = "Nota Fiscal:" + nota + "";
        }

        public DesconsiderarNota(string nota,Boolean abrir)
        {
            Nota = nota;
            InitializeComponent();
            lbl_nota.Content = "Nota Fiscal:" + nota + "";
            label.Content = "Abaixo o motivo da desconsideração desta nota.";
            Banco.expedicao_notas banco = Banco.expedicao_notas.Obter("nota='" + nota + "'")[0];
            txt_motivo.Text = banco.Motivo;

            btn_salvar.IsEnabled = false;
            btn_salvar.Visibility = Visibility.Collapsed;
        }

        private Boolean moti()
        {
            if (txt_motivo.Text == "")
            {
                MsgBox.Show.Error("Motivo não foi preenchido!");
                return false;
            }
            return true;
        }
        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            if (moti())
            {
                Banco.expedicao_notas novo = new Banco.expedicao_notas();
                novo.Nota = Nota;
                novo.Motivo = txt_motivo.Text;
                novo.Expedida = false;
                if (novo.Inserir() != -1)
                {
                    MsgBox.Show.Info("Cadastrado com sucesso!");
                    Sessao.FecharPrograma(this);
                }
                else
                {
                    MsgBox.Show.Error("Erro ao cadastrar.");
                }
            }
        }
    }
}
