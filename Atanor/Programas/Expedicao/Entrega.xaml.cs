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
using System.Data;

namespace Atanor.Programas.Expedicao
{
    /// <summary>
    /// Interaction logic for Entrega.xaml
    /// </summary>
    public partial class Entrega : UserControl , TaskMenu.Pacotes
    {

        public string per = "24";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/packages2.png", UriKind.RelativeOrAbsolute));
        public string nome = "Controle de Entrega.";
        public Entrega()
        {
            InitializeComponent();
            pacote1.Janela = this;
            Listar();
        }

        private void Listar()
        {
            DataTable tabela = Select.SelectSQL("select * from entrega where data is null");

           // DataTable tabela = Select.SelectSQL("select distinct nota from expedicao");
            ogrid.ItemsSource = tabela.DefaultView;
            ogrid.DisplayMemberPath = "nota";
            ogrid.SelectedValuePath = "nota";
        }

        private void lst_lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Select.SelectDinamico(this, "SELECT e.cliente cliente,e.estado estado,e.cidade cidade,e.data expedicao,e.idromaneio romaneio FROM expedicao e,romaneio r where r.id = e.idromaneio and e.nota = " + ogrid.SelectedValue + "");
            }
            catch { }
        }

        List<string> coluna = new List<string>();
        List<dynamic> valores = new List<dynamic>();
        List<dynamic> condicao = new List<dynamic>();

        private void obtersql()
        {
            try
            {
                coluna.Clear();
                valores.Clear();
                condicao.Clear();
            }
            catch { }

            coluna.Add("data");
            coluna.Add("criador");
            coluna.Add("dataDocumento");
            
            valores.Add(Facilitadores.ConverterDataParaDataDoMysql.Converter((DateTime)dt_data.SelectedDate));
            valores.Add(Sessao.usuario.Usuario);
            valores.Add(Facilitadores.ConverterDataParaDataDoMysql.Converter(DateTime.Now));

            condicao.Add("nota=" + ogrid.SelectedValue + "");
        }

        private Boolean Verificador()
        {
            if (ogrid.SelectedValue == null)
            {
                MsgBox.Show.Error("Nota não foi selecionada!");
                return false;
            }
            else
            {
                if (dt_data.SelectedDate == null)
                {
                    MsgBox.Show.Error("Data de entrega não foi selecionada!");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void pacote_novo()
        {
            if (Verificador())
            {
                obtersql();

                if (MsgBox.Show.Pergunta("Você quer mesmo cadastrar essa data de entrega para esta nota?"))
                {
                    if (ExecuteNonSql.Executar("entrega", TipoDeOperacao.Tipo.Update, coluna, valores, condicao) != -1)
                    {
                        MsgBox.Show.Info("Cadastrado com sucesso!");
                        Listar();
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao cadastrar!");
                    }
                }
            }
        }

        public void pacote_excluir()
        {
            MsgBox.Show.Error("Essa ação é está habilitada!");
        }

        public void pacote_editar()
        {
            if (Verificador())
            {
                obtersql();

                if (MsgBox.Show.Pergunta("Você quer mesmo cadastrar essa data de entrega para esta nota?"))
                {
                    if (ExecuteNonSql.Executar("entrega", TipoDeOperacao.Tipo.Update, coluna, valores, condicao) != -1)
                    {
                        MsgBox.Show.Info("Cadastrado com sucesso!");
                        Listar();
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao cadastrar!");
                    }
                }
            }
        }

        public void pacote_cancelar()
        {
            
        }
    }
}
