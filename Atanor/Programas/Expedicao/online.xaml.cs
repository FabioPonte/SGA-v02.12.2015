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
    /// Interaction logic for online.xaml
    /// </summary>
    public partial class online : UserControl
    {
        public online()
        {
            InitializeComponent();
            web.Navigate("www.transnecher.com.br/clientes?company=17");
        }

        public string per = "24";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/packages2.png", UriKind.RelativeOrAbsolute));
        public string nome = "Notas Online";

        
    }
}
