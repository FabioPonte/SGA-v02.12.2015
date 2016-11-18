using Conector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Atanor.MsgBox
{
    /// <summary>
    /// Interaction logic for Alarme.xaml
    /// </summary>
    public partial class Alarme : Window
    {
        int Id = -1;

        string unico = "";
        string diaria = "";
        string semanal = "";
        string mensal = "";

        public Alarme(int id)
        {
            InitializeComponent();
            Id = id;
            ObterInfor();
        }

        private void ObterInfor()
        {
            DataTable tabela = Select.SelectSQL("select * from alarme where id="+Id+"");
            string titulo = tabela.Rows[0]["titulo"] + "";
            string msg = tabela.Rows[0]["msg"] + "";
            unico = tabela.Rows[0]["unico"] + "";

            this.Title = titulo;
            Msg = msg;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            button1.Focus();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (unico == "1")
            {
                List<string> coluna = new List<string>();
                List<dynamic> valores = new List<dynamic>();
                List<dynamic> condicao = new List<dynamic>();
                coluna.Add("ativo");
                valores.Add(0);
                condicao.Add("id=" + Id + "");
                ExecuteNonSql.Executar("alarme", TipoDeOperacao.Tipo.Update, coluna, valores, condicao);
            }
            this.Close();
        }

        string titulo;

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; this.Title = value; }
        }
        string msg;

        public string Msg
        {
            get { return msg; }
            set { msg = value; textBox1.Text = value; }
        }
    }
}
