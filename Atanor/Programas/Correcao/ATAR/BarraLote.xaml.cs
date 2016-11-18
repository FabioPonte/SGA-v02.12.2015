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

namespace Atanor.Programas.Correcao.ATAR
{
    /// <summary>
    /// Interaction logic for BarraLote.xaml
    /// </summary>
    public partial class BarraLote : UserControl
    {
        public BarraLote()
        {
            InitializeComponent();
            
        }

        public delegate void click(UserControl controle);
        public event click Click;

      

        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        string lote;
        double max;
        double valor;

        public double Valor
        {
            get { return upDownText1.Valor; }
            set { upDownText1.Valor = value; if (upDownText1.Valor > 0) image1.Opacity = 1; else image1.Opacity = 0; }
        }

        string count;

        public string Count
        {
            get { return count; }
            set { count = value; lbl_cont.Content = count; }
        }
        public double Max
        {
            get { return max; }
            set { max = value; lbl_max.Content = value + ""; upDownText1.Max = value; }
        }

        public string Lote
        {
            get { return lote; }
            set { lote = value; lbl_lote.Content = value; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void upDownText1_ClickDown(UserControl controle)
        {
            try
            {
                Click(this);
            }
            catch { }
        }

        private void upDownText1_ClickUp(UserControl controle)
        {
            try
            {
                Click(this);
            }
            catch { }
        }

        private void upDownText1_Change(UserControl controle)
        {
            try
            {
                Click(this);
            }
            catch { }
        }
    }
}
