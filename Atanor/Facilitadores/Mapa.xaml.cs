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

namespace Atanor.Facilitadores
{
    /// <summary>
    /// Interaction logic for Mapa.xaml
    /// </summary>
    public partial class Mapa : UserControl
    {
        public Mapa()
        {
            InitializeComponent();
        }

        string origem, destino;

     

        public void SetarDestino(string aorigem, string odestino)
        {
            origem = aorigem;
            destino = odestino;

            limpar();
            SetOrigem();
            SetDestino();
        }

        private void limpar()
        {
            foreach (dynamic tb in FindVisualChildren<Control>(this))
            {
                try
                {
                    ((Label)tb).Background = Brushes.Transparent;
                }
                catch { }
                
            }
        }

        private void SetOrigem()
        {
            foreach (dynamic tb in FindVisualChildren<Control>(this))
            {
                if (tb.Name == origem)
                {
                    double left = ((Label)tb).Margin.Left + (((Label)tb).Width / 2);
                    double top = ((Label)tb).Margin.Top + (((Label)tb).Height / 2);

                    ((Label)tb).Background = Brushes.Green;

                    linha.X1 = left;
                    linha.Y1 = top;
                }
            }
        }
        private void SetDestino()
        {

            foreach (dynamic tb in FindVisualChildren<Control>(this))
            {
                if (tb.Name == destino)
                {
                    double left = ((Label)tb).Margin.Left + (((Label)tb).Width / 2);
                    double top = ((Label)tb).Margin.Top + (((Label)tb).Height / 2);

                    ((Label)tb).Background = Brushes.Yellow;

                    linha.X2 = left;
                    linha.Y2 = top;
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < System.Windows.Media.VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = System.Windows.Media.VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
