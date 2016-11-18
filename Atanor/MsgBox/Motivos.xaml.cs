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

namespace Atanor.MsgBox
{
    /// <summary>
    /// Interaction logic for Motivos.xaml
    /// </summary>
    public partial class Motivos : Window
    {
        public PacoteMotivo motivo = new PacoteMotivo();

        public Motivos(string titulo,string msg)
        {
            InitializeComponent();
            this.Title = titulo;
            lbl_msg.Content = msg;
            motivo.Retorno = false;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (verificador())
            {
                motivo.Motivo = txt_motivo.Text;
                motivo.Retorno = true;
                this.Close();
            }
        }

        private Boolean verificador()
        {
            if (txt_motivo.Text.Trim() == "")
            {
                MsgBox.Show.Error("Motivo inválido.");
                return false;
            }
            else
            {
                if (txt_motivo.Text.Length < 5)
                {
                    MsgBox.Show.Error("Motivo inválido.");
                    return false;
                }
                else { return true; }
            }
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            motivo.Retorno = false;
            this.Close();
        }
    }
}
