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

namespace Atanor.Programas.Correcao
{
    /// <summary>
    /// Interaction logic for BaixaSap.xaml
    /// </summary>
    public partial class BaixaSap : UserControl
    {
        public BaixaSap()
        {
            InitializeComponent();
        }

        public string nome = "Baixa para o Sistema SAP";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/download168.png", UriKind.RelativeOrAbsolute));
        public string per = "15";

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
