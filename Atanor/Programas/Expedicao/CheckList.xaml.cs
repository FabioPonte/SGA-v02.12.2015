using Conector;
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

namespace Atanor.Programas.Expedicao
{
    /// <summary>
    /// Interaction logic for CheckList.xaml
    /// </summary>
    public partial class CheckList : UserControl
    {

        Facilitadores.Transferidor motorista = new Facilitadores.Transferidor();
        Facilitadores.Transferidor caminhao = new Facilitadores.Transferidor();
        Facilitadores.Verificador vn = new Facilitadores.Verificador();
        public string per = "24";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/packages2.png", UriKind.RelativeOrAbsolute));
        public string nome = "CheckList";


        public CheckList()
        {
            InitializeComponent();

            listar();

            motorista.Combo = cbo_motorista;
            motorista.controle = this;
            caminhao.Combo = cbo_caminhao;
            caminhao.controle = this;
            motorista.Retorno += motorista_Retorno;
            caminhao.Retorno += caminhao_Retorno;

            vn.Add(cbo_caminhao, "Caminhão não foi selecionado!");
            vn.Add(cbo_transportadora, "Transportadora não foi selecionada!");
            vn.Add(cbo_motorista, "Motorista não foi selecionado!");
        }

        private void listar()
        {
            cbo_transportadora.ItemsSource = Select.SelectSQL("select * from transportadoras order by Apelido").DefaultView;
            cbo_transportadora.SelectedValuePath = "id";
            cbo_transportadora.DisplayMemberPath = "Apelido";

            cbo_caminhao.ItemsSource = Select.SelectSQL("select * from caminhao order by placa").DefaultView;
            cbo_caminhao.SelectedValuePath = "id";
            cbo_caminhao.DisplayMemberPath = "placa";

            cbo_motorista.ItemsSource = Select.SelectSQL("select * from motorista order by nome").DefaultView;
            cbo_motorista.SelectedValuePath = "id";
            cbo_motorista.DisplayMemberPath = "nome";

        }
        void motorista_Retorno()
        {
            cbo_motorista.ItemsSource = Select.SelectSQL("select * from motorista order by nome").DefaultView;
            cbo_motorista.SelectedValuePath = "id";
            cbo_motorista.DisplayMemberPath = "nome";
        }

        void caminhao_Retorno()
        {
            cbo_caminhao.ItemsSource = Select.SelectSQL("select * from caminhao order by placa").DefaultView;
            cbo_caminhao.SelectedValuePath = "id";
            cbo_caminhao.DisplayMemberPath = "placa";
        }

        private void buttonq_Click(object sender, RoutedEventArgs e)
        {
            if (vn.Analisar())
            {
                try
                {

                    string url = GerarChecklist.GerarVerificadpr(cbo_transportadora.SelectedValue+"", ""+cbo_motorista.SelectedValue, ""+cbo_caminhao.SelectedValue);
                        if (url != "")
                        {
                            Programas.RelatorioHTML novo = new RelatorioHTML(url, false);
                            novo.Show();
                        }
                    
                }
                catch (Exception ex)
                {
                    Facilitadores.ErroLog.Registrar(ex);
                    MsgBox.Show.Error(ex + "");
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Portaria.CadastroMotorista(motorista), this);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Portaria.CadastroCaminhao(caminhao), this);
        }
    }
}
