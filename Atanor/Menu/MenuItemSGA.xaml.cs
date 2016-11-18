using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Animation;


namespace Atanor.Menu
{
    /// <summary>
    /// Interaction logic for MenuItemSGA.xaml
    /// </summary>
    public partial class MenuItemSGA : UserControl
    {
        public MenuItemSGA()
        {
            InitializeComponent();           
        }

        ImageSource icone;

        string nome;

        [Description("Define o Texto do Botão"), Category("Principal")] 
        public string Nome
        {
            get { return nome; }
            set { nome = value; label1.Content = value; }
        }

        [Description("Define o Icone do Botão"), Category("Principal")] 
        public ImageSource Icone
        {
            get { return icone; }
            set { icone = value; icon.Source = value; }
        }


        public delegate void click(UserControl controle);
        [Description("Define o Click"), Category("Principal")] 
        public event click Click;

        private void btn_logistica_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Click(this);
            }
            catch { }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        void MenuItemSGA_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        void MenuItemSGA_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void btn_logistica_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void btn_logistica_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            fundo.Background = Facilitadores.ConverterHexaEmBrushes.Color("#ff5F5F5F");
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            fundo.Background = Facilitadores.ConverterHexaEmBrushes.Color("#FF505050");
            
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btn_logistica_Click(null, null);
        }


        
    }
}
