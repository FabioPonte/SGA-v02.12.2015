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
using Conector;
namespace Atanor.Programas.Logistica
{
    /// <summary>
    /// Interaction logic for Transportadora.xaml
    /// </summary>
    public partial class Transportadora : UserControl
    {
        public Transportadora()
        {
            InitializeComponent();
        }

        public string nome = "Transportadoras";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/logistics3 (1).png", UriKind.RelativeOrAbsolute));
        public Facilitadores.Verificador verificador = new Facilitadores.Verificador();
        public string per = "4";

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            verificador.Add(txt_cnpj, "Campo cnpj não foi preenchido");
            verificador.Add(txt_nome, "Campo nome não foi preenchido");
            verificador.Add(txt_apelido, "Campo apelido não foi preenchido");
            dataGridFiltro1.Odatagrid = ogrid;
            Listar();
        }

        public void Listar()
        {
            ogrid.ItemsSource = Select.SelectSQL("select * from Transportadoras").DefaultView;
            ogrid.SelectedValuePath = "id";
        }

        private void pacote1_Click(ThemaMeritor.TipoEvento.evento tipo)
        {
            if (tipo == ThemaMeritor.TipoEvento.evento.Novo)
            {
                Cadastro();
            }

            if (tipo == ThemaMeritor.TipoEvento.evento.Editar)
            {
                Editar();
            }

            if (tipo == ThemaMeritor.TipoEvento.evento.Excluir)
            {
                Deletar();
            }

            if (tipo == ThemaMeritor.TipoEvento.evento.Cancelar)
            {
                verificador.Limpar();
            }
        }

        private void Cadastro()
        {
            if (verificador.Analisar())
            {
                List<string> colunas = new List<string>();
                List<dynamic> valores = new List<dynamic>();
                List<dynamic> condicao = new List<dynamic>();

                colunas.Add("Nome");
                colunas.Add("Apelido");
                colunas.Add("Cnpj");

                valores.Add(txt_nome.Text);
                valores.Add(txt_apelido.Text);
                valores.Add(txt_cnpj.Text);

                condicao.Add("id="+txt_id.Text+"");

                if (ExecuteNonSql.Executar("Transportadoras", TipoDeOperacao.Tipo.Insert, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Comando com êxito!");
                    Listar();
                    verificador.Limpar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao executar comando!");
                }
            }
        }

        private void Editar()
        {
            if (verificador.Analisar())
            {
                List<string> colunas = new List<string>();
                List<dynamic> valores = new List<dynamic>();
                List<dynamic> condicao = new List<dynamic>();

                colunas.Add("Nome");
                colunas.Add("Apelido");
                colunas.Add("Cnpj");

                valores.Add(txt_nome.Text);
                valores.Add(txt_apelido.Text);
                valores.Add(txt_cnpj.Text);

                condicao.Add("id=" + txt_id.Text + "");

                if (ExecuteNonSql.Executar("Transportadoras", TipoDeOperacao.Tipo.Update, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Comando com êxito!");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao executar comando!");
                }
            }
        }

        private void Deletar()
        {
            if (verificador.Analisar())
            {
                List<string> colunas = new List<string>();
                List<dynamic> valores = new List<dynamic>();
                List<dynamic> condicao = new List<dynamic>();

                colunas.Add("Nome");
                colunas.Add("Apelido");
                colunas.Add("Cnpj");

                valores.Add(txt_nome.Text);
                valores.Add(txt_apelido.Text);
                valores.Add(txt_cnpj.Text);

                condicao.Add("id=" + txt_id.Text + "");

                if (ExecuteNonSql.Executar("Transportadoras", TipoDeOperacao.Tipo.Delete, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Comando com êxito!");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao executar comando!");
                }
            }
        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Select.SelectDinamico(this, "select * from Transportadoras where id=" + ogrid.SelectedValue + "");
                pacote1.ModoEdicao = true;
            }
            catch { }
        }
    }
}

