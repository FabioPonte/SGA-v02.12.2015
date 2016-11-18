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

namespace Atanor.TaskMenu
{
    /// <summary>
    /// Interaction logic for PacoteManutencao.xaml
    /// </summary>
    public partial class PacoteManutencao : UserControl
    {
        public enum Tipo
        {
            Novo,
            Editar,
            Excluir,
            Cancelar
        }
        Boolean modoEdicao = false;
        public delegate void click(Tipo tipo);
        public event click Click;
        DataGrid gridBase;

        dynamic janela;

        public dynamic Janela
        {
            get { return janela; }
            set { janela = value;

            try
            {
                titulo.Content = "" + janela.nome + "";
                icone.Source = janela.icone;

                try
                {
                    dynamic jan = value;
                    GridBase = jan.ogrid;
                }
                catch { }
            }
            catch { }

            }
        }

        Boolean ativado = true;

        public DataGrid GridBase
        {
            get { return gridBase; }
            set { gridBase = value;

            try
            {
                GridBase.SelectionChanged += GridBase_SelectionChanged;
            }
            catch { }

            }
        }

        public PacoteManutencao()
        {
            InitializeComponent();
            btn_cadastro.Click += btn_cadastro_Click;
            btn_editar.Click += btn_editar_Click;
            btn_excluir.Click += btn_excluir_Click;
            btn_cancelar.Click += btn_cancelar_Click;

           
        }

        void GridBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModoEdicao = true;
        }

        void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            ModoEdicao = false;
            try
            {
                Click(Tipo.Cancelar);
            }
            catch { }

            try
            {
                // chama a função da janela de nome pacote_cancelar
                Janela.pacote_cancelar();
            }
            catch { }
        }

        void btn_excluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Click(Tipo.Excluir);
            }
            catch { }

            try
            {
                // chama a função da janela de nome pacote_excluir()
                Janela.pacote_excluir();
            }
            catch { }
        }

        void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Click(Tipo.Editar);
            }
            catch { }

            try
            {
                // chama a função da janela de nome pacote_editar()
                Janela.pacote_editar();
            }
            catch { }

        }

        void btn_cadastro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Click(Tipo.Novo);
            }
            catch { }

            try
            {
                Janela.pacote_novo();
            }
            catch { }
        }

        public Boolean ModoEdicao
        {
            get { return modoEdicao; }
            set
            {
                modoEdicao = value;
                if (Ativado)
                {
                    if (value)
                    {
                        btn_cadastro.IsEnabled = false;
                        btn_cancelar.IsEnabled = true;
                        btn_editar.IsEnabled = true;
                        btn_excluir.IsEnabled = true;
                    }
                    else
                    {
                        btn_cadastro.IsEnabled = true;
                        btn_cancelar.IsEnabled = false;
                        btn_editar.IsEnabled = false;
                        btn_excluir.IsEnabled = false;
                    }
                }
            }
        }

        public bool Ativado
        {
            get
            {
                return ativado;
            }

            set
            {
                ativado = value;
                btn_cadastro.IsEnabled = value;
            }
        }

       
    }
}
