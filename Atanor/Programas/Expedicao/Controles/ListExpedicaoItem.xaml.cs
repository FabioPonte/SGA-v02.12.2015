using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Conector;
using System.Windows.Media.Animation;

namespace Atanor.Programas.Expedicao.Controles
{
    /// <summary>
    /// Interaction logic for ListExpedicaoItem.xaml
    /// </summary>
    public partial class ListExpedicaoItem : UserControl
    {
        Storyboard on = new Storyboard();
        Storyboard off = new Storyboard();
        public ListExpedicaoItem()
        {
            InitializeComponent();
            fundo.MouseEnter += fundo_MouseEnter;
            fundo.MouseLeave += fundo_MouseLeave;
            chk_expedir.Checked += chk_expedir_Checked;

            on = FindResource("on") as Storyboard;
            off = FindResource("off") as Storyboard;

            
        }


        public void Desmarcar()
        {
            chk_expedir.IsChecked = false;
            Expedir = false;
        }

        public void Marcar()
        {
            chk_expedir.IsChecked = true;
            Expedir = true;
        }

        private void mardesmar()
        {
            if (Expedir)
            {
                Desmarcar();
            }
            else { Marcar(); }
        }


        void chk_expedir_Checked(object sender, RoutedEventArgs e)
        {
          
        }

        void fundo_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!Expedir)
            {
                off.Begin();
            }
            
        }
        void fundo_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!Expedir)
            {
                on.Begin();
            }
        }

        string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        string data;
        public string Data
        {
            get { return data; }
            set { data = value; lbl_data.Content = value; }
        }

        string nota;
        public string Nota
        {
            get { return nota; }
            set { nota = value; lbl_nota.Content = value; }
        }

        string cfop;
        public string Cfop
        {
            get { return cfop; }
            set { cfop = value; lbl_cfop.Content = value; Obtercor(); }
        }

        string cliente;
        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; lbl_cliente.Content = value; }
        }

        string cd;
        public string Cd
        {
            get { return cd; }
            set { cd = value; lbl_cidade.Content = value; }
        }

        string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; lbl_estado.Content = value; }
        }

        Boolean expedir = false;

        public delegate void change(ListExpedicaoItem index);
        public event change ChangeCheck;

        public Boolean Expedir
        {
            get { return expedir; }
            set { expedir = value;

                if (value)
                {
                    fundo.Background = Facilitadores.ConverterHexaEmBrushes.Color("#FF3F782A");
                }
                else
                {
                    fundo_MouseEnter(null, null);
                 }
                try
                {
                    ChangeCheck(this);
                }
                catch
                {

                }



            }
        }

        public delegate void deletar(Programas.Expedicao.Controles.ListExpedicaoItem item);
        public event deletar Excluido;

        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {
            MsgBox.PacoteMotivo motivo = MsgBox.Show.Motivo("Você quer mesmo apagar esta nota?","Qual o motivo para não expedir essa nota?");
            if (motivo.Retorno)
            {

                List<string> colunas = new List<string>();
                colunas.Add("excluida");
                colunas.Add("motivo");

                List<dynamic> valores = new List<dynamic>();
                valores.Add(1);
                valores.Add(motivo.Motivo);

                List<dynamic> condicao = new List<dynamic>();
                condicao.Add("id=" + Id + "");

                if (ExecuteNonSql.Executar("nota_expedicao", TipoDeOperacao.Tipo.Update, colunas, valores, condicao) == -1)
                {
                    MsgBox.Show.Error("Erro ao excluir nota.");
                }
                else
                {
                    try
                    {
                        Excluido(this);
                    }
                    catch { }
                }
            }
        }

        private void chk_expedir_Click(object sender, RoutedEventArgs e)
        {
            if (chk_expedir.IsChecked == true)
            {
                Expedir = true;
            }
            else
            {
                Expedir = false;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mardesmar();
        }

        private void Obtercor()
        {
           
                string cor = Sessao.ObterCfop(cfop).cor;
                corinfo.Fill = Facilitadores.ConverterHexaEmBrushes.Color(cor);
            
        }
    }
}
