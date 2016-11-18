using Conector;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Interaction logic for informacao.xaml
    /// </summary>
    public partial class informacao : UserControl
    {
        ObterInformacaoDaNota infornota = new ObterInformacaoDaNota();

        public informacao()
        {
            InitializeComponent();

            cbo_cd.ItemsSource = Select.SelectSQL("select * from centrodistribuicao").DefaultView;
            cbo_cd.SelectedValuePath = "id";
            cbo_cd.DisplayMemberPath = "nome";

            infornota.ErroNota += new ObterInformacaoDaNota.erron(infornota_ErroNota);
            infornota.Retorno += new ObterInformacaoDaNota.retorno(infornota_Retorno);


        }

        public string per = "24";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/packages2.png", UriKind.RelativeOrAbsolute));
        public string nome = "Informação sobre nota!";

        void infornota_Retorno(DadosNota x)
        {

            try
            {
                ogrid.ItemsSource = null;
            }
            catch { }
            MsgBox.Show.EspereFechar();

          

            nota.Content = x.nota;
            data.Content = x.data;
            cliente.Content = x.cliente;
            estado.Content = x.estado;
            cidade.Content = x.cidade;
            bairro.Content = x.bairro;
            rua.Content = x.rua;
            cep.Content = x.cep;
            pais.Content = x.pais;
            telefone.Content = x.fone;
            email.Content = x.email;
            cnpj.Content = x.cnpj_cliente;
            cfop.Content = x.cfop;
            cfaz.Content = x.cfaz;
            valor.Content = x.Valor;
            dif_valor.Content = x.dif_valor;
            transportadora.Content = x.transportadora;
            cnpj_transp.Content = x.cnpj_transportadora;
            embalagem.Content = x.embalegem;
            qtd_embalagem.Content = x.qtd_embalagem;
            peso_bruto.Content = x.peso_bruto;
            peso_liquido.Content = x.peso_liquido;

            DataTable tabela = new DataTable();

            tabela.Columns.Add("Produto",typeof(string));
            tabela.Columns.Add("Valor", typeof(double));
            tabela.Columns.Add("Lote", typeof(string));
            tabela.Columns.Add("Volume", typeof(double));

            for (int a = 0; a < x.produto.Count; a++)
            {
                string p = "";
                double v = 0;
                string l = "";
                double vo = 0;

                p = x.produto[a].produto + "";
                v = x.produto[a].valor;

                for (int b = 0; b < x.produto[a].lote.Count; b++)
                {
                    l = x.produto[a].lote[b] + "";
                    vo = x.produto[a].volume[b];

                    tabela.Rows.Add(p, v, l, vo);
                }

                if (tabela.Rows.Count <= 0)
                {
                    tabela.Rows.Add(p, v, l, v);
                }
            }

            ogrid.ItemsSource = tabela.DefaultView;
            
        }

       

        void infornota_ErroNota(string nota)
        {

    
            MsgBox.Show.EspereFechar();
            MsgBox.Show.Error("Nota Fiscal " + nota + " não foi encontrada!");
        }

        private void ObterInformacao(string nota)
        {
            infornota.SolicitarNota(nota, cbo_cd.Text.ToUpper());
            MsgBox.Show.EspereAbrir();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cbo_cd.Text.Trim() == "")
            {
                MsgBox.Show.Error("O Centro de Distribuição ainda não foi informado", cbo_cd);
            }
            else
            {
                if (txt_nota.Text == "")
                {
                    MsgBox.Show.Error("Nota Fiscal não foi informada!", txt_nota);
                }
                else
                {
                    Frete();
                    expedida();
                    ObterInformacao(txt_nota.Text.Replace("ê","e"));
                }
            }
        }

        private void expedida()
        {
            try
            {

                expedido.Content = "NÃO";
                romaneio.Content = "";
                data_expedido.Content = "";
                acriador.Content = "";
                amotorista.Content = "";
                aplaca.Content = "";

                DataTable tabela = Select.SelectSQL("SELECT r.id,nota,r.data,r.criador,m.nome motorista,c.placa FROM expedicao e,romaneio r,motorista m,caminhao c where e.idromaneio=r.id and idmotorista=m.id and idcaminhao=c.id and nota=" + txt_nota.Text + "");

                string id = "";
                string nota = "";
                string data = "";
                string criador = "";
                string motorista = "";
                string placa = "";

                placa = tabela.Rows[0][5] + "";
                id = tabela.Rows[0][0] + "";
                nota = tabela.Rows[0][1] + "";
                data = tabela.Rows[0][2] + "";
                criador = tabela.Rows[0][3] + "";
                motorista = tabela.Rows[0][4] + "";
                

                expedido.Content = "SIM";
                romaneio.Content = id;
                data_expedido.Content = data;
                acriador.Content = criador;
                amotorista.Content = motorista;
                aplaca.Content = placa;

                expedido.Foreground = Brushes.Red;
            }
            catch { expedido.Content = "NÃO"; expedido.Foreground = Brushes.Black; }

        }


        private void Frete()
        {
            try
            {
                DataTable tabela = Arquivos.Excel.Executar(@"\\servidor.atar.local\departamento\Logistica\Controle de Frete\2015\Controle de frete 2015 YTD.xlsm", "SELECT  F4 AS Nota, F20 AS ESPERADO, F21 AS EFETIVO, F22 AS DIFERENÇA, F23 AS FATURA, F24 AS ICMS, F25 AS VALORPALLET, F31 AS MIX, F32 AS ENTREGA  FROM ['BASE DADOS$'] WHERE F4='" + txt_nota.Text + "'", "NO");

                lbl_nota.Content = tabela.Rows[0]["Nota"] + "";
                lbl_esperado.Content = tabela.Rows[0]["ESPERADO"] + "";
                lbl_cobrado.Content = tabela.Rows[0]["EFETIVO"] + "";
                lbl_dif.Content = tabela.Rows[0]["DIFERENÇA"] + "";
                lbl_fatura.Content = tabela.Rows[0]["FATURA"] + "";
                lbl_icms.Content = tabela.Rows[0]["ICMS"] + "";
                lbl_valor.Content = tabela.Rows[0]["VALORPALLET"] + "";
                lbl_mix.Content = tabela.Rows[0]["MIX"] + "";
                lbl_data.Content = tabela.Rows[0]["ENTREGA"] + "";

            }
            catch { }

        }
      
    }
}
