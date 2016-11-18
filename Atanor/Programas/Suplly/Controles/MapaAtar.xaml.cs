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

namespace Atanor.Programas.Suplly.Controles
{
    /// <summary>
    /// Interaction logic for MapaAtar.xaml
    /// </summary>
    public partial class MapaAtar : UserControl
    {
        double X = 0;
        double Y = 0;

        public delegate void click(double x, double y);
        public event click Click;

        public MapaAtar()
        {
            InitializeComponent();
            this.MouseMove += MapaAtar_MouseMove;
        }

        private void MapaAtar_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            X = p.X;
            Y = p.Y;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Click(X, Y);
            }
            catch { }

            CriarMaracacao(new Point(X, Y));
        }

        List<Point> lista = new List<Point>();

        public void Add(Point ponto)
        {
            CriarMaracacao(ponto);
            lista.Add(ponto);
        }

        public void Limpar()
        {
            lista.Clear();
            painel.Children.Clear();
            limpar();
        }

        public void LimparSeta()
        {
            setas.Children.Clear();
        }

        public void Remove(Point ponto)
        {
            lista.Remove(ponto);
            limpar();
            for (int a = 0; a < lista.Count; a++)
            {
                CriarMaracacao(lista[a]);
            }
        }

        public void Remove(int index)
        {
            lista.RemoveAt(index);
            limpar();
            for (int a = 0; a < lista.Count; a++)
            {
                CriarMaracacao(lista[a]);
            }
        }

        public List<Point> ObterPontos() { return lista; }
        public Point ObterPonto(int index) { return lista[index]; }

        private void limpar()
        {
            painel.Children.Clear();
        }
        private void CriarMaracacao(Point ponto)
        {
            Ellipse novo = new Ellipse();
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
            novo.Fill = mySolidColorBrush;
            novo.StrokeThickness = 2;
            novo.Stroke = Brushes.Black;
            novo.Width = 10;
            novo.Height = 10;
            Thickness mar = new Thickness();
            mar.Left = ponto.X - 5;
            mar.Top = ponto.Y - 5;
            novo.Margin = mar;
            novo.VerticalAlignment = VerticalAlignment.Top;
            novo.HorizontalAlignment = HorizontalAlignment.Left;

            painel.Children.Add(novo);

            Mostra(ponto);
        }

        public void Mostra(Point ponto)
        {
            /*  Image img = new Image();
              img.Source = new BitmapImage(new Uri("/Images/set.png", UriKind.RelativeOrAbsolute));
              img.Width = 55;
              img.Height = 77;
              img.VerticalAlignment = VerticalAlignment.Top;
              img.HorizontalAlignment = HorizontalAlignment.Left;
              Thickness mar = new Thickness();
              mar.Left = ponto.X;
              mar.Top = ponto.Y;
              img.Margin = mar;
              setas.Children.Add(img);*/

            Rectangle lx = new Rectangle();
            lx.Width = 994;
            lx.Height = 2;
            lx.Stroke = Brushes.Red;
            lx.VerticalAlignment = VerticalAlignment.Top;
            lx.HorizontalAlignment = HorizontalAlignment.Left;
            Thickness mar = new Thickness();
            mar.Left = 0;
            mar.Top = ponto.Y;
            lx.Margin = mar;


            Rectangle ly = new Rectangle();
            ly.Width = 2;
            ly.Height = this.Height;
            ly.Stroke = Brushes.Red;
            ly.VerticalAlignment = VerticalAlignment.Top;
            ly.HorizontalAlignment = HorizontalAlignment.Left;
            mar.Left = ponto.X;
            mar.Top = 0;
            ly.Margin = mar;

            setas.Children.Add(lx);
            setas.Children.Add(ly);

        }

    }
}
