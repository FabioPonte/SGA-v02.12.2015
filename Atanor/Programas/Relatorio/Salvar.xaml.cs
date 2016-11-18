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

namespace Atanor.Programas.Relatorio
{
    public partial class Salvar : UserControl
    {
        string osql;
        Facilitadores.Verificador v = new Facilitadores.Verificador();

        public string per = "26";

        public string nome = "Salvar";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/seo2 (1).png", UriKind.RelativeOrAbsolute));

        public Salvar(string sql)
        {
            osql = sql;
            InitializeComponent();
            listar();

            v.Add(txt_nome, "Nome da consulta não foi preenchida", true);
            v.Add(cbo_usuario, "O Usuário não foi selecionado", true);
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void btn_detalhar_Copy_Click_1(object sender, RoutedEventArgs e)
        {
            if (v.Analisar())
            {
                List<string> colunas = new List<string>();
                colunas.Add("idusuarios");
                colunas.Add("nome");
                colunas.Add("descricao");
                colunas.Add("osql");

                List<dynamic> valores = new List<dynamic>();
                valores.Add(cbo_usuario.SelectedValue);
                valores.Add(txt_nome.Text);
                valores.Add(txt_descricao.Text);
                valores.Add(osql);

                if (ExecuteNonSql.Executar("relatorios", TipoDeOperacao.Tipo.Insert, colunas, valores, null) != -1)
                {
                    MsgBox.Show.Info("Cadastrado com sucesso!");
                    Sessao.FecharPrograma(this);
                }
                else
                {
                    MsgBox.Show.Error("Erro ao cadastrar");
                }
            }
        }

        private void listar()
        {
            cbo_usuario.ItemsSource = Select.SelectSQL("select * from usuarios").DefaultView;
            cbo_usuario.SelectedValuePath = "id";
            cbo_usuario.DisplayMemberPath = "nome";
        }

        


    }
}
