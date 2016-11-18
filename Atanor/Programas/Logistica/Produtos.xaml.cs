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
    /// Interaction logic for Produtos.xaml
    /// </summary>
    public partial class Produtos : UserControl
    {
        Facilitadores.Transferidor oid = new Facilitadores.Transferidor();
        Facilitadores.Verificador v = new Facilitadores.Verificador();

        public Produtos()
        {
            InitializeComponent();
            v.Add(txt_sap, "Número id sap não foi preenchido", true);
            v.Add(txt_nome, "Nome do produto não foi preenchido", true);
            v.Add(txt_peso, "Número id sap não foi preenchido", false);
            v.Add(txt_conversao, "Número id sap não foi preenchido", false);
            Listar();
            filtro.Odatagrid = ogrid;
            this.Loaded += Produtos_Loaded;
        }

        void Produtos_Loaded(object sender, RoutedEventArgs e)
        {
            Sessao.ApagaBots();
            Sessao.AddExcel(ogrid);
        }

        public Produtos(Facilitadores.Transferidor id)
        {
            oid = id;
            InitializeComponent();
            v.Add(txt_sap, "Número id sap não foi preenchido",true);
            v.Add(txt_nome, "Nome do produto não foi preenchido",true);
            v.Add(txt_peso, "Número id sap não foi preenchido", false);
            v.Add(txt_conversao, "Número id sap não foi preenchido", false);
            Listar();

        }

        public string per = "6";
        public string nome = "Cadastro de Produtos";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/chemistry2.png", UriKind.RelativeOrAbsolute));

        private void produtos_Loaded(object sender, RoutedEventArgs e)
        {
            filtro.Odatagrid = ogrid;
        }

        private void Listar()
        {
            ogrid.ItemsSource = Select.SelectSQL("select id,idsap Sap,nome Nome,peso 'Peso Liquido',conversao 'Peso Bruto' from produtos").DefaultView;
            ogrid.SelectedValuePath = "id";
        }

        private void pacote1_Click(ThemaMeritor.TipoEvento.evento tipo)
        {
            if (tipo == ThemaMeritor.TipoEvento.evento.Cancelar)
            {
                v.Limpar();
            }

            if (tipo == ThemaMeritor.TipoEvento.evento.Editar)
            {
                editar();
            }

            if (tipo == ThemaMeritor.TipoEvento.evento.Excluir)
            {
                excluir();
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Novo)
            {
                novo();
            }
        }

        private void novo()
        {
            if (v.Analisar())
            {
                List<string> colunas = new List<string>();
                colunas.Add("idsap");
                colunas.Add("nome");
                colunas.Add("peso");
                colunas.Add("conversao");

                List<dynamic> valores = new List<dynamic>();
                valores.Add(txt_sap.Text);
                valores.Add(txt_nome.Text);
                valores.Add(txt_peso.Text);
                valores.Add(txt_conversao.Text);

                List<dynamic> condicao=new List<dynamic>();
                condicao.Add("id="+ogrid.SelectedValue+"");


                if (ExecuteNonSql.Executar("produtos", TipoDeOperacao.Tipo.Insert, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Cadastrado com êxito!");
                    Listar();
                    v.Limpar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao cadastrar!");
                }
            }
        }

        private void excluir()
        {
            if (v.Analisar())
            {
                List<string> colunas = new List<string>();
                colunas.Add("idsap");
                colunas.Add("nome");
                colunas.Add("peso");
                colunas.Add("conversao");

                List<dynamic> valores = new List<dynamic>();
                valores.Add(txt_sap.Text);
                valores.Add(txt_nome.Text);
                valores.Add(txt_peso.Text);
                valores.Add(txt_conversao.Text);

                List<dynamic> condicao = new List<dynamic>();
                condicao.Add("id=" + ogrid.SelectedValue + "");


                if (ExecuteNonSql.Executar("produtos", TipoDeOperacao.Tipo.Delete, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Deletado com êxito!");
                    Listar();
                    v.Limpar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao deletar!");
                }
            }
        }

        private void editar()
        {
            if (v.Analisar())
            {
                List<string> colunas = new List<string>();
                colunas.Add("idsap");
                colunas.Add("nome");
                colunas.Add("peso");
                colunas.Add("conversao");

                List<dynamic> valores = new List<dynamic>();
                valores.Add(txt_sap.Text);
                valores.Add(txt_nome.Text);
                valores.Add(txt_peso.Text);
                valores.Add(txt_conversao.Text);

                List<dynamic> condicao = new List<dynamic>();
                condicao.Add("id=" + ogrid.SelectedValue + "");


                if (ExecuteNonSql.Executar("produtos", TipoDeOperacao.Tipo.Update, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Editado com êxito!");
                    Listar();
                    v.Limpar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao edtitar!");
                }
            }
        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (oid.Combo != null)
                {
                    oid.add(ogrid.SelectedValue + "");
                    Sessao.FecharPrograma(this);
                }
            }
            catch { }
            try
            {
                pacote1.ModoEdicao = true;
                Select.SelectDinamico(this, "select * from produtos where id=" + ogrid.SelectedValue + "");
            }
            catch { }
        }
    }
}
