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
    /// Interaction logic for MenuCabecalho.xaml
    /// </summary>
    public partial class MenuCabecalho : UserControl
    {
        public MenuCabecalho()
        {
            InitializeComponent();
        }

        string qtd_legenda;

        public string Qtd_legenda
        {
            get { return qtd_legenda; }
            set { qtd_legenda = value;
            if (value != "")
            {
                qtd.Opacity = 1;
                qtd.Content = value;
            }
            else
            {
                qtd.Opacity = 0;
            }
            }
        }

        ImageSource image;

        public ImageSource Image
        {
            get { return image; }
            set { image = value; image1.Source = image; }
        }

        public delegate void click();
        public event click Click;

        private void orgid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.IsEnabled == true)
            {
                orgid.Background = Facilitadores.ConverterHexaEmBrushes.Color("#ff3C719B");
            }
        }

        private void orgid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.IsEnabled == true)
            {
                orgid.Background = Facilitadores.ConverterHexaEmBrushes.Color("#FF4A8BC2");
            }
        }

        private void orgid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Click();
            }
            catch { }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            IsEnabledChanged += new DependencyPropertyChangedEventHandler(MenuCabecalho_IsEnabledChanged);
           
        }

        void MenuCabecalho_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsEnabled == false)
            {
                this.Opacity = 0.3;
            }
            else
            {
                this.Opacity = 1;
            }
        }
    }
}
