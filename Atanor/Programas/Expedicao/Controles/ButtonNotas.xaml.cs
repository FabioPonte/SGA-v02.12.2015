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

namespace Atanor.Programas.Expedicao.Controles
{
    /// <summary>
    /// Interaction logic for ButtonNotas.xaml
    /// </summary>
    public partial class ButtonNotas : UserControl
    {
        public ButtonNotas()
        {
            InitializeComponent();
        }

        string nota;
        string cliente;
        string estado;
        string cidade;
        string sefaz;
        string sefazmotico;
        string vendedor;
        string frete;
        double quantidade_total;
        DateTime data;
        List<string> produtos = new List<string>();
        List<string> utilizacao = new List<string>();
        List<string> lote = new List<string>();
        List<double> quantidade_lote = new List<double>();

        Boolean fechado = true;

        

        public void Listar()
        {
           

            if (sefaz != "100")
            {
                lbl_note.Background = Facilitadores.ConverterHexaEmBrushes.Color("#FFFF9292");
            }
            else
            {
                lbl_note.Background = Facilitadores.ConverterHexaEmBrushes.Color("#FF92B5FF");
            }
        }

        

        public string Nota
        {
            get
            {
                return nota;
            }

            set
            {
                nota = value;
                lbl_note.Content = value;
            }
        }

        public string Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
                lbl_cliente.Content = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
                lbl_estado.Content = value;
            }
        }

        public string Cidade
        {
            get
            {
                return cidade;
            }

            set
            {
                cidade = value;
                lbl_cidade.Content = value;
            }
        }

        public string Sefaz
        {
            get
            {
                return sefaz;
            }

            set
            {
                sefaz = value;
                txt_sefaz.Text = value;
            }
        }

        public string Sefazmotico
        {
            get
            {
                return sefazmotico;
            }

            set
            {
                sefazmotico = value;
                txt_motivo.Text = value;
            }
        }

        public string Vendedor
        {
            get
            {
                return vendedor;
            }

            set
            {
                vendedor = value;
                txt_vendedor.Text = value;
            }
        }

        public double Quantidade_total
        {
            get
            {
                return quantidade_total;
            }

            set
            {
                quantidade_total = value;
               
            }
        }

        public DateTime Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
                lbl_data.Content = "" + value;
                    
            }
        }

        public List<string> Produtos
        {
            get
            {
                return produtos;
            }

            set
            {
                produtos = value;
            }
        }

        public List<string> Utilizacao
        {
            get
            {
                return utilizacao;
            }

            set
            {
                utilizacao = value;
            }
        }

        public List<double> Quantidade_lote
        {
            get
            {
                return quantidade_lote;
            }

            set
            {
                quantidade_lote = value;
            }
        }

        public string Frete
        {
            get
            {
                return frete;
            }

            set
            {
                frete = value;
                txt_frete.Text = value;
            }
        }

        private void btn_abrir_Click(object sender, RoutedEventArgs e)
        {
            if (fechado)
            {
                this.Height = 291;
                fechado = false;
            }
            else
            {
                this.Height = 138;
                fechado = true;
            }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            gr.Background = Facilitadores.ConverterHexaEmBrushes.Color("#FFDEDA87");
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            gr.Background = Facilitadores.ConverterHexaEmBrushes.Color("#FFE8E8E8");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Programas.Expedicao.DesconsiderarNota(Nota), this);
        }
    }
}
