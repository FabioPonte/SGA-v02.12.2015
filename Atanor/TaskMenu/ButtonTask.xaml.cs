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
using System.Windows.Media.Animation;

namespace Atanor.TaskMenu
{
    /// <summary>
    /// Interaction logic for ButtonTask.xaml
    /// </summary>
    public partial class ButtonTask : UserControl
    {
        public ButtonTask()
        {
            InitializeComponent();
        }

        string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; texto.Content = nome; }
        }
        BitmapImage icone;

        public BitmapImage Icone
        {
            get { return icone; }
            set { icone = value; icon.Source = Icone; }
        }

        UserControl controle;

        public UserControl Controle
        {
            get { return controle; }
            set { controle = value; }
        }

        Boolean marcado;
        Storyboard on, off, flag, flagoff;
        public Boolean Marcado
        {
            get { return marcado; }
            set { marcado = value; Setar(); }
        }

        private void Setar()
        {
            try
            {
                if (Marcado == false)
                {
                    texto.Foreground = clique.Foreground;
                }
                else
                {
                    texto.Foreground = Brushes.Red;
                }
            }
            catch { }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!marcado)
            {
                texto.Foreground = clique.Foreground;
            }
        }

        

        private void clique_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Click(this, Controle);
            }
            catch { }
        }

        public delegate void click(ButtonTask botao,UserControl programa);
        public event click Click;

        private void sair1_Click()
        {
            Sessao.FecharPrograma(Controle);
        }
    }
}
