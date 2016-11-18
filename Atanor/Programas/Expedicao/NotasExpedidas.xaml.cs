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
namespace Atanor.Programas.Expedicao
{
    /// <summary>
    /// Interaction logic for NotasExpedidas.xaml
    /// </summary>
    public partial class NotasExpedidas : UserControl
    {
        public NotasExpedidas()
        {
            InitializeComponent();
            
        }
        public string per = "24";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/packages2.png", UriKind.RelativeOrAbsolute));
        public string nome = "Notas Expedidas";

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void procurar()
        {
            label12.Content = "";
            label13.Content = "";
            label14.Content = "";
            label15.Content = "";
            label16.Content = "";
            label17.Content = "";
            label18.Content = "";
            label19.Content = "";
            label20.Content = "";
            label21.Content = "";
            try
            {
                Select.SelectDinamico(this, "SELECT *,(SELECT nome FROM produtos p where p.id=e.idprodutos) produto,(SELECT c.estado FROM romaneio r, centrodistribuicao c where r.idcd=c.id and r.id=e.idromaneio) origem FROM expedicao e where e.nota='" + txt_nota.Text + "'");

            
            string destino = label15.Content + "";
            string origem = label16.Content + "";

            mapa1.SetarDestino(origem, destino);
            }
            catch {
                try
                {
                    Banco.expedicao_notas nota = Banco.expedicao_notas.Obter("nota='" + txt_nota.Text + "'")[0];
                    if (nota != null)
                    {
                        MsgBox.Show.Error("Essa nota foi desconsiderada para expedição.");
                        Sessao.AbrirPrograma(new Programas.Expedicao.DesconsiderarNota(txt_nota.Text,true), this);
                    }
                    else
                    {
                        MsgBox.Show.Error("Nota não foi encontrada.");
                    }
                }
                catch { MsgBox.Show.Error("Nota não foi encontrada."); }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            procurar();
        }

        private void txt_nota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                procurar();
            }
        }

        
    }
}
