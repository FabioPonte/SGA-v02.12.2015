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

namespace Atanor.Programas.Usuarios.Controles
{
    /// <summary>
    /// Interaction logic for Lista.xaml
    /// </summary>
    public partial class Lista : UserControl
    {
        public Lista()
        {
            InitializeComponent();
        }

      
        List<PacotePermissao> pacotes = new List<PacotePermissao>();

        public List<PacotePermissao> Pacotes
        {
            get { return pacotes; }
            set { pacotes = value; montar(); }
        }

        private void montar()
        {
            lbl_grupo.Content = pacotes[0].grupo;
            for (int a = 0; a<pacotes.Count; a++)
            {
                CheckBox novo = new CheckBox();
                novo.Content = pacotes[a].nome;
                novo.IsChecked = pacotes[a].marcado;
                pacotes[a].check = novo;
                ogrid.Children.Add(novo);
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        Boolean bol = true;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (bol)
            {
                for (int a = 0; a < pacotes.Count; a++)
                {
                    pacotes[a].check.IsChecked = true;
                }
                bol = false;
            }
            else
            {
                for (int a = 0; a < pacotes.Count; a++)
                {
                    pacotes[a].check.IsChecked = false ;
                }
                bol = true;
            }
        }
    }
}
