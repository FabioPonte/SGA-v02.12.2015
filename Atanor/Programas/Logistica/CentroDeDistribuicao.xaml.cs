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
    /// Interaction logic for CentroDeDistribuicao.xaml
    /// </summary>
    public partial class CentroDeDistribuicao : UserControl
    {
        public CentroDeDistribuicao()
        {
            InitializeComponent();
        }

        public string per = "3";
        public string nome = "Centro de Distribuição";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/factory2 (1).png", UriKind.RelativeOrAbsolute));
        public Facilitadores.Verificador verificador = new Facilitadores.Verificador();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridFiltro1.Odatagrid = ogrid;
            pacote1.ModoEdicao = false;
            
            verificador.Add(txt_cidade, "Campos cidade não foi preenchido");
            verificador.Add(txt_estado, "Campos estado não foi preenchido");
            verificador.Add(txt_nome, "Campos nome não foi preenchido");
            verificador.Add(cbo_estado, "Campos Estado não foi preenchido");
            verificador.Add(txt_cnpj, "Campos Cnpj não foi preenchido");

            Listar();

            Sessao.ApagaBots();
            Sessao.AddExcel(ogrid);
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
                colunas.Add("nome");
                colunas.Add("cidade");
                colunas.Add("estado");
                colunas.Add("cnpj");

                List<dynamic> valores = new List<dynamic>();
                valores.Add(txt_nome.Text);
                valores.Add(txt_cidade.Text);
                valores.Add(txt_estado.Text);
                valores.Add(txt_cnpj.Text);
                List<dynamic> condicao = new List<dynamic>();
                condicao.Add("id=" + ogrid.SelectedValue + "");


                if (ExecuteNonSql.Executar("centrodistribuicao", TipoDeOperacao.Tipo.Insert, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Cadastro com êxito.");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao cadastrar!");
                }
            }
        }

        

        private void Editar()
        {
            if (verificador.Analisar())
            {
                List<string> colunas = new List<string>();
                colunas.Add("nome");
                colunas.Add("cidade");
                colunas.Add("estado");
                colunas.Add("cnpj");
                List<dynamic> valores = new List<dynamic>();
                valores.Add(txt_nome.Text);
                valores.Add(txt_cidade.Text);
                valores.Add(txt_estado.Text);
                valores.Add(txt_cnpj.Text);

                List<dynamic> condicao = new List<dynamic>();
                condicao.Add("id=" + ogrid.SelectedValue + "");


                if (ExecuteNonSql.Executar("centrodistribuicao", TipoDeOperacao.Tipo.Update, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Editado com êxito.");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao Editar!");
                }
            }
        }

        private void Deletar()
        {
            if (txt_id.Text.Trim()!="")
            {
                List<string> colunas = new List<string>();
                colunas.Add("nome");
                colunas.Add("cidade");
                colunas.Add("estado");
                List<dynamic> valores = new List<dynamic>();
                valores.Add(txt_nome.Text);
                valores.Add(txt_cidade.Text);
                valores.Add(txt_estado.Text);

                List<dynamic> condicao = new List<dynamic>();
                condicao.Add("id=" + ogrid.SelectedValue + "");


                if (ExecuteNonSql.Executar("centrodistribuicao", TipoDeOperacao.Tipo.Delete, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Deletado com êxito.");
                    Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao Deletar!");
                }
            }
        }

        

        private void pacote1_Loaded(object sender, RoutedEventArgs e)
        {

        }


        public void Listar()
        {
            cbo_estado.ItemsSource = Select.SelectSQL("select * from Estados").DefaultView;
            cbo_estado.SelectedValuePath = "id";
            cbo_estado.DisplayMemberPath = "nome";
            

            ogrid.ItemsSource = Select.SelectSQL("select         x.id AS 'ID',        x.nome AS 'Centro',        y.uf AS 'UF',        y.nome AS 'Nome',        y.local AS 'Local',        x.cnpj AS 'CNPJ'    from        centrodistribuicao x        join estados y    where        x.estado = y.uf").DefaultView;
            ogrid.SelectedValuePath = "ID";
        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Select.SelectDinamicoControle(this, "select * from centrodistribuicao where id=" + ogrid.SelectedValue + "");
                pacote1.ModoEdicao = true;
            }
            catch { }
        }

        private void estado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Select.SelectDinamico(this, "select uf from estados where id=" + cbo_estado.SelectedValue + "");
            }
            catch { }
        }
    }
}
